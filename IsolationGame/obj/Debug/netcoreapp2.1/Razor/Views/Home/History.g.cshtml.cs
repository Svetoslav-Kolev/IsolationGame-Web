#pragma checksum "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c333d7648f9b83bba120c7baa7b09db49bfb842c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_History), @"mvc.1.0.view", @"/Views/Home/History.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/History.cshtml", typeof(AspNetCore.Views_Home_History))]
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
#line 5 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 6 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
using IsolationGame.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c333d7648f9b83bba120c7baa7b09db49bfb842c", @"/Views/Home/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4da2d0256beb225275894f7fa69bbf852990c912", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HistoryViewMovel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
  
    ViewData["Title"] = "History";

#line default
#line hidden
            BeginContext(187, 22, true);
            WriteLiteral("\r\n<h2>History</h2>\r\n\r\n");
            EndContext();
#line 12 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
 foreach (var game in Model.games)
{
    

#line default
#line hidden
#line 14 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
     if (Model.userId == game.PlayerOneId)
    {
        

#line default
#line hidden
#line 16 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
         if (game.CurrentPlayerAndTurn == 5)
        {

#line default
#line hidden
            BeginContext(356, 32, true);
            WriteLiteral("            <h2>You Won Against ");
            EndContext();
            BeginContext(389, 40, false);
#line 18 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
                           Write(Model.enemyUsernames[game.Id.ToString()]);

#line default
#line hidden
            EndContext();
            BeginContext(429, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 19 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
        }
        else if (game.CurrentPlayerAndTurn == 6)
        {

#line default
#line hidden
            BeginContext(508, 33, true);
            WriteLiteral("            <h2>You Lost Against ");
            EndContext();
            BeginContext(542, 40, false);
#line 22 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
                            Write(Model.enemyUsernames[game.Id.ToString()]);

#line default
#line hidden
            EndContext();
            BeginContext(582, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 23 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
        }

#line default
#line hidden
#line 23 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
         
    }
    else
    {
        

#line default
#line hidden
#line 27 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
         if (game.CurrentPlayerAndTurn == 5)
        {

#line default
#line hidden
            BeginContext(681, 33, true);
            WriteLiteral("            <h2>You Lost Against ");
            EndContext();
            BeginContext(715, 40, false);
#line 29 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
                            Write(Model.enemyUsernames[game.Id.ToString()]);

#line default
#line hidden
            EndContext();
            BeginContext(755, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 30 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
        }
        else if (game.CurrentPlayerAndTurn == 6)
        {

#line default
#line hidden
            BeginContext(834, 32, true);
            WriteLiteral("            <h2>You Won Against ");
            EndContext();
            BeginContext(867, 40, false);
#line 33 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
                           Write(Model.enemyUsernames[game.Id.ToString()]);

#line default
#line hidden
            EndContext();
            BeginContext(907, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 34 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
        }

#line default
#line hidden
#line 34 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
         
    }

#line default
#line hidden
#line 35 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Home\History.cshtml"
     

}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HistoryViewMovel> Html { get; private set; }
    }
}
#pragma warning restore 1591
