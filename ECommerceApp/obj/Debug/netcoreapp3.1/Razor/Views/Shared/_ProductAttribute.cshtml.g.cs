#pragma checksum "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87136a71f23a8e26e0b52a809faa8d330fd80075"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductAttribute), @"mvc.1.0.view", @"/Views/Shared/_ProductAttribute.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\_ViewImports.cshtml"
using ECommerceApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\_ViewImports.cshtml"
using ECommerceApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87136a71f23a8e26e0b52a809faa8d330fd80075", @"/Views/Shared/_ProductAttribute.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"325bf3e3cf6a1be1caec55f16db518eb1a742bbc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductAttribute : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ECommerceApp.Data.Models.AttributeLookUpMapping>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div style=""overflow:auto;height:280px; width:100%; margin:0 auto;"">
        <table id=""tblProductAttribute"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
            <thead>
                <tr>
                    <th>Attribute Name</th>
                    <th>Attribute Value</th>
                    <th>Edit</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 17 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml"
                 if (Model != null && Model.Count() > 0)
                {
                    foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 22 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml"
                           Write(item.AttributeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-break\">");
#nullable restore
#line 23 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml"
                                              Write(item.AttributeValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td><a class=\"btn btn-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 948, "\"", 992, 3);
            WriteAttributeValue("", 958, "EditData(\'", 958, 10, true);
#nullable restore
#line 24 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml"
WriteAttributeValue("", 968, item.AttributeId, 968, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 985, "\',this)", 985, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Edit</a> ");
#nullable restore
#line 24 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml"
                                                                                                         Write(Html.Hidden("hdnAttributeId", item.AttributeId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml"
                                                                                                                                                         Write(Html.Hidden("hdnProductAttrId", item.ProductAttrId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 26 "C:\Arvind\faltu\Nanaji chat\ECommerceDemo\ECommerceApp\Views\Shared\_ProductAttribute.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ECommerceApp.Data.Models.AttributeLookUpMapping>> Html { get; private set; }
    }
}
#pragma warning restore 1591
