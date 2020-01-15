#pragma checksum "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\Rematch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d71cac5860a921ba0aa9898f27f518e4fbdb4f4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Rematch), @"mvc.1.0.view", @"/Views/Game/Rematch.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Game/Rematch.cshtml", typeof(AspNetCore.Views_Game_Rematch))]
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
#line 4 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\Rematch.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 5 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\Rematch.cshtml"
using IsolationGame.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d71cac5860a921ba0aa9898f27f518e4fbdb4f4d", @"/Views/Game/Rematch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4da2d0256beb225275894f7fa69bbf852990c912", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Rematch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\Rematch.cshtml"
  
    ViewData["Title"] = "Game";

#line default
#line hidden
            BeginContext(157, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(164, 27, false);
#line 8 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\Rematch.cshtml"
Write(ViewData["CurrentPlayerId"]);

#line default
#line hidden
            EndContext();
            BeginContext(191, 11, true);
            WriteLiteral("</h1>\r\n<h1>");
            EndContext();
            BeginContext(203, 18, false);
#line 9 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\Rematch.cshtml"
Write(ViewData["GameId"]);

#line default
#line hidden
            EndContext();
            BeginContext(221, 11, true);
            WriteLiteral("</h1>\r\n<h1>");
            EndContext();
            BeginContext(233, 26, false);
#line 10 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\Rematch.cshtml"
Write(ViewData["PlayerOneOrTwo"]);

#line default
#line hidden
            EndContext();
            BeginContext(259, 11, true);
            WriteLiteral("</h1>\r\n<h3>");
            EndContext();
            BeginContext(271, 19, false);
#line 11 "C:\Users\User\source\repos\IsolationGame\IsolationGame\Views\Game\Rematch.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(290, 3325, true);
            WriteLiteral(@"</h3>

<script src=""https://code.jquery.com/jquery-3.4.1.min.js""
        integrity=""sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=""
        crossorigin=""anonymous""></script>
<script>
    (function update() {
        $.ajax({
            url: '/Game/Update',
            success: function (data) {
                drawTable(data.field)
                displayTurn(data.currentPlayerAndTurn)
                checkGameStatus(data)
                if (data.currentPlayerAndTurn >= 5) {
                    redirectToEndGame();
                }
            },
            complete: function () {
                setTimeout(update, 1000);
                $(document).ready(function () {
                    $("".cell"").click(function () {
                        $.get({
                            url: '/Game/Action',
                            data:
                            {
                                coordinates: $(event.target).attr(""id"")
                            }
            ");
            WriteLiteral(@"            })
                    });
                })
            }
        });
    })();

    function redirectToEndGame() {
        window.location.href = ""/Game/EndGame"";
    }
    function checkGameStatus(game) {
        var playerOneIdCheck = game.playerOneId;
        var playerTwoIdCheck = game.playerTwoId;
        var statusLabel = $('<h1>');
        if (playerOneIdCheck == null || playerTwoIdCheck == null) {
            statusLabel.text(""Game has yet to Begin - waiting for opponent to connect."");
        } else {
            statusLabel.text(""Game is active!"");
        }
        $('#game_status').html(statusLabel);
    }

    function drawTable(field) {
        var gameField = JSON.parse(field);
        var table = $('<table>').css({ ""margin"": ""0 auto"", ""table-layout"": ""fixed"" }).attr(""border"", ""1"");
        for (i = 0; i < gameField.length; i++) {
            var row = $('<tr>');
            for (var j = 0; j < gameField.length; j++) {
                var col = $('<td>");
            WriteLiteral(@"').attr(""id"", `${i}_${j}`).css({ ""width"": ""30px"", ""height"": ""30px"", }).addClass(""cell"")
                if (gameField[i][j] == 0) {
                    col.text("" "");
                } else if (gameField[i][j] == 1) {
                    col.text(""X"");
                } else if (gameField[i][j] == 2) {
                    col.text(""P1"");
                }
                else if (gameField[i][j] == 3) {
                    col.text(""P2"");
                }
                row.append(col);
            }
            table.append(row);
        }

        $('#game_field').html(table);
    }
    function displayTurn(turn) {
        var currTurn = JSON.parse(turn);
        var turnLabel = $('<h1>');
        if (currTurn == 0) {
            turnLabel.text(""It's Player One's Move Phase"");
        } else if (currTurn == 1) {
            turnLabel.text(""It's Player One's Block Phase"");
        }
        else if (currTurn == 2) {
            turnLabel.text(""It's Player Two's Move Phase"");
   ");
            WriteLiteral("     } else {\r\n            turnLabel.text(\"It\'s Player Two\'s Block Phase\");\r\n        }\r\n        $(\'#curr_turn\').html(turnLabel);\r\n    }\r\n</script>\r\n\r\n<div id=\"game_field\">\r\n\r\n</div>\r\n<div id=\"curr_turn\">\r\n\r\n</div>\r\n<div id=\"game_status\">\r\n\r\n</div>\r\n\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591