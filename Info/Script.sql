IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'ProductAttrId' AND Object_ID = Object_ID(N'dbo.ProductAttribute'))
BEGIN
   Alter Table ProductAttribute Add ProductAttrId int Primary Key Identity(1,1)  
END
GO
CREATE OR ALTER   PROC [dbo].[InsertUpdateProduct]
(
 @ProductJson varchar(max),
 @AttributeJson varchar(max),
 @OutResult varchar(100) OUT
)
AS
BEGIN
BEGIN TRY
 BEGIN TRANSACTION      
  
  Declare @tblProduct Table(ProductId int,ProdCatId int,ProductName varchar(250),ProductDescription varchar(max))
  Insert INTo @tblProduct
  SELECT * FROM OpenJson(@ProductJson)
    WITH (          
          ProductId INT '$.ProductId',
		  ProdCatId INT '$.ProdCatId',
          ProductName varchar(250) '$.ProdName',
          Description VARCHAR(MAX) '$.ProdDescription'
         )


  Declare @tblProdcutAtt Table(ProductAttrId int,ProductId INT,AttributeId INT,AttributeValue varchar(250))
  INSERT INTO @tblProdcutAtt
  SELECT * FROM OpenJson(@AttributeJson)
    WITH (
          ProductAttrId int '$.ProductAttrId',
          ProductId INT '$.ProductId',
          AttributeId INT '$.AttributeId',
          AttributeValue VARCHAR(250) '$.AttributeValue'
         )

  
 Declare @ProdName varchar(50),@ProductId INT
 Select @ProdName=ProductName ,@ProductId=ProductId from @tblProduct
 
 IF (Select count(1) from Product Where ProdName=@ProdName AND @ProductId=0) >0
 BEGIN
   SET @OutResult='ProductName already exists !!!'
 END
 ELSE
  BEGIN
      IF @ProductId=0
	  BEGIN
         Insert INTO Product(ProdCatId,ProdName,ProdDescription)
	     Select ProdCatId,ProductName,ProductDescription from @tblProduct     
		 SET @ProductId=@@IDENTITY
      END
	  ELSE
	  BEGIN	   
	    Update P SET P.ProdName=tp.ProductName,P.ProdDescription=TP.ProductDescription 
		   FROM Product P
		   INNER JOIN @tblProduct TP ON TP.ProductId=p.ProductId
	  END	 
	  Update @tblProdcutAtt SET ProductId=@ProductId
  
      MERGE ProductAttribute AS Target
         USING @tblProdcutAtt	AS Source
         ON Source.ProductID = Target.ProductID AND Source.AttributeId=Target.AttributeId
    
    -- For Inserts
        WHEN NOT MATCHED BY Target THEN
         INSERT (ProductID,AttributeId, AttributeValue) 
         VALUES (Source.ProductID,Source.AttributeId, Source.AttributeValue)
    
    -- For Updates
        WHEN MATCHED THEN UPDATE SET
         Target.AttributeId	= Source.AttributeId,
         Target.AttributeValue		= Source.AttributeValue;

  END
 COMMIT TRANSACTION

 SET @OutResult='Product saved successfully !!!' 
 
 
 Select @OutResult
END TRY
BEGIN CATCH
 IF @@TRANCOUNT > 0    
   BEGIN         
     ROLLBACK TRANSACTION        
   END   
   
    SET @OutResult=ERROR_MESSAGE()+ 'Line No : '+CAST(ERROR_LINE() AS VARCHAR(50))
    
END CATCH

END