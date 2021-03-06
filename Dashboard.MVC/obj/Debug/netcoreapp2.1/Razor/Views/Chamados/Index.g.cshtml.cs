#pragma checksum "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5dc0635ef2b4d1b55d6bbb54a315f5842a3ef8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chamados_Index), @"mvc.1.0.view", @"/Views/Chamados/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Chamados/Index.cshtml", typeof(AspNetCore.Views_Chamados_Index))]
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
#line 1 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\_ViewImports.cshtml"
using Dashboard.MVC;

#line default
#line hidden
#line 2 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\_ViewImports.cshtml"
using Dashboard.MVC.ViewModels;

#line default
#line hidden
#line 1 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
using Dashboard.MVC.ViewModels.Chamados;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5dc0635ef2b4d1b55d6bbb54a315f5842a3ef8f", @"/Views/Chamados/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a2f1c48035fba815527e15ca324c71f1c9e7776", @"/Views/_ViewImports.cshtml")]
    public class Views_Chamados_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "chamado", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(65, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
  
    ViewData["Title"] = "Chamados";

#line default
#line hidden
            BeginContext(111, 772, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Todos os chamados</h5>

                <table class=""table table-responsive table-hover dataTable"">
                    <thead>
                        <tr>
                            <th>Nº</th>
                            <th>Abertura</th>
                            <th>Tipo</th>
                            <th>Assunto</th>
                            <th>Último posicionamento</th>
                            <th>Status</th>
                            <th>Responsavel</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 28 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                         foreach (var item in Model.Chamados)
                        {

#line default
#line hidden
            BeginContext(973, 96, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1070, 44, false);
#line 32 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ChamadoId));

#line default
#line hidden
            EndContext();
            BeginContext(1114, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1218, 40, false);
#line 35 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                           Write(item.DataAbertura.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1258, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1362, 56, false);
#line 38 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.TipoChamado.Descricao));

#line default
#line hidden
            EndContext();
            BeginContext(1418, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1522, 59, false);
#line 41 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.AssuntoChamado.Descricao));

#line default
#line hidden
            EndContext();
            BeginContext(1581, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1686, 99, false);
#line 44 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                            Write(item.UltimoPosicionamento.HasValue ? item.UltimoPosicionamento.Value.ToString("dd/MM/yyyy") : "N/A");

#line default
#line hidden
            EndContext();
            BeginContext(1786, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1890, 41, false);
#line 47 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
            EndContext();
            BeginContext(1931, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2035, 46, false);
#line 50 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Responsavel));

#line default
#line hidden
            EndContext();
            BeginContext(2081, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2184, 117, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4892da8cb361418082832804a6ebaa71", async() => {
                BeginContext(2270, 27, true);
                WriteLiteral("<i class=\"far fa-edit\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                                                                                         WriteLiteral(item.ChamadoId);

#line default
#line hidden
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
            EndContext();
            BeginContext(2301, 70, true);
            WriteLiteral(" |\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 56 "C:\Users\marco\OneDrive\Desktop\Dashboard\Dashboard.MVC\Views\Chamados\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(2398, 110, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
