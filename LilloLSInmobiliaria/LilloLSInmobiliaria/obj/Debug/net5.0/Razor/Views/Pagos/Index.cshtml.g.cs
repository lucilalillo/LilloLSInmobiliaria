#pragma checksum "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "114600c77547787d50dd6a2fb58374f0499688d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pagos_Index), @"mvc.1.0.view", @"/Views/Pagos/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\_ViewImports.cshtml"
using LilloLSInmobiliaria;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\_ViewImports.cshtml"
using LilloLSInmobiliaria.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"114600c77547787d50dd6a2fb58374f0499688d4", @"/Views/Pagos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d22846c18b756cc793cfdfad2c9c88c1159da0bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Pagos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LilloLSInmobiliaria.Models.Pago>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
  
    if (TempData["Error"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 13 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
      Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 14 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
    }


#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
  
    if (TempData["Mensaje"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 20 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
      Write(TempData["Mensaje"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 21 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Listado de Pagos</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NumPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Importe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ContratoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.contrato.Inquilino));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 49 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FechaPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 59 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Importe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 62 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ContratoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 65 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
            Write(item.contrato.Inquilino.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 68 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.ActionLink("Editar", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 69 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.ActionLink("Detalle", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 70 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.ActionLink("Eliminar", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Pagos\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LilloLSInmobiliaria.Models.Pago>> Html { get; private set; }
    }
}
#pragma warning restore 1591
