#pragma checksum "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\EndGame.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e8d5b256971f80ff2cca68055bbf2ce9abb0b8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_EndGame), @"mvc.1.0.view", @"/Views/Game/EndGame.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Game/EndGame.cshtml", typeof(AspNetCore.Views_Game_EndGame))]
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
#line 1 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\_ViewImports.cshtml"
using IsolationGame;

#line default
#line hidden
#line 2 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\_ViewImports.cshtml"
using IsolationGame.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e8d5b256971f80ff2cca68055bbf2ce9abb0b8c", @"/Views/Game/EndGame.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4da2d0256beb225275894f7fa69bbf852990c912", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_EndGame : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\EndGame.cshtml"
  
    ViewData["Title"] = "EndGame";

#line default
#line hidden
            BeginContext(45, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(52, 22, false);
#line 6 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\EndGame.cshtml"
Write(ViewData["gameWinner"]);

#line default
#line hidden
            EndContext();
            BeginContext(74, 110, true);
            WriteLiteral("</h2>\r\n\r\n<a href=\"/Game/Rematch\"><h1>Rematch</h1></a>\r\n\r\n<a href=\"/Home/Index\"><h1>Return To Menu</h1></a>\r\n\r\n");
            EndContext();
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
