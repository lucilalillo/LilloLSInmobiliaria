#pragma checksum "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Restringido.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0d64707d77a62800d1b1c3f1df05c494148b7db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Restringido), @"mvc.1.0.view", @"/Views/Home/Restringido.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0d64707d77a62800d1b1c3f1df05c494148b7db", @"/Views/Home/Restringido.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d22846c18b756cc793cfdfad2c9c88c1159da0bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Restringido : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Restringido.cshtml"
  
    ViewData["Title"] = "Restringido";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Restringido</h1>\r\n\r\n<h4>\r\n    <b>\r\n");
#nullable restore
#line 9 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Restringido.cshtml"
         foreach (var u in User.Claims) { 
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Restringido.cshtml"
       Write(u.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br/>\r\n");
#nullable restore
#line 11 "C:\Users\Usuario\Documents\GitHub\LilloLSInmobiliaria\LilloLSInmobiliaria\LilloLSInmobiliaria\Views\Home\Restringido.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </b>\r\n</h4>\r\n");
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
