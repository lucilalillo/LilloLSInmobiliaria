#pragma checksum "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d21c6d0ee041041470c6bff4ac51593e3693cebf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contratos_Index), @"mvc.1.0.view", @"/Views/Contratos/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d21c6d0ee041041470c6bff4ac51593e3693cebf", @"/Views/Contratos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d22846c18b756cc793cfdfad2c9c88c1159da0bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Contratos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LilloLSInmobiliaria.Models.Contrato>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Pagos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
  
    if (TempData["Error"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 10 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
      Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 11 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
    }


#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
  
    if (TempData["Mensaje"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 17 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
      Write(TempData["Mensaje"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 18 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Listado de Contratos</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d21c6d0ee041041470c6bff4ac51593e3693cebf5796", async() => {
                WriteLiteral("Crear Nuevo Contrato");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Inmueble.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.InquilinoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FecInicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FecFin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Monto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.GaranteId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 55 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 59 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
                Write(item.Inmueble.Direccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 62 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
                Write(item.Inquilino.Nombre+" "+item.Inquilino.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 65 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FecInicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FecFin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 71 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Monto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 74 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 77 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
                Write(item.Garante.Nombre+" "+item.Garante.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 80 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
               Write(Html.ActionLink("Editar", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 81 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
               Write(Html.ActionLink("Detalles", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 82 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
               Write(Html.ActionLink("Eliminar", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d21c6d0ee041041470c6bff4ac51593e3693cebf13629", async() => {
                WriteLiteral("Nuevo Pago");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 86 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Contratos\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LilloLSInmobiliaria.Models.Contrato>> Html { get; private set; }
    }
}
#pragma warning restore 1591
