#pragma checksum "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Seguro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5ee545d7ce1ced3e367abb34c203c918d2e911a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Seguro), @"mvc.1.0.view", @"/Views/Home/Seguro.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5ee545d7ce1ced3e367abb34c203c918d2e911a", @"/Views/Home/Seguro.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d22846c18b756cc793cfdfad2c9c88c1159da0bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Seguro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Seguro.cshtml"
  
    ViewData["Title"] = "Seguro";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Seguro</h1>\r\n\r\n<p>Usted está Autenticado. Su identificación es ");
#nullable restore
#line 7 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Seguro.cshtml"
                                           Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>FullName es ");
#nullable restore
#line 8 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Seguro.cshtml"
          Write(User.Claims.First(x => x.Type == "FullName").Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Lista de claims:</p>\r\n<ul>\r\n");
#nullable restore
#line 11 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Seguro.cshtml"
     foreach (var c in User.Claims)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li><b>");
#nullable restore
#line 13 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Seguro.cshtml"
           Write(c.Type+": ");

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>");
#nullable restore
#line 13 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Seguro.cshtml"
                            Write(c.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 14 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Seguro.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
#nullable restore
#line 16 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Seguro.cshtml"
Write(Html.ActionLink("Salir", "Logout", "Usuarios", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
