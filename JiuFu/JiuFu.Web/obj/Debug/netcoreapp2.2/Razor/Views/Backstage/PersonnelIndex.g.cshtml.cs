#pragma checksum "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c288940d5381573159d60100f0b2ffa2b33d1e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Backstage_PersonnelIndex), @"mvc.1.0.view", @"/Views/Backstage/PersonnelIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Backstage/PersonnelIndex.cshtml", typeof(AspNetCore.Views_Backstage_PersonnelIndex))]
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
#line 1 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\_ViewImports.cshtml"
using JiuFu.Web;

#line default
#line hidden
#line 2 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\_ViewImports.cshtml"
using JiuFu.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c288940d5381573159d60100f0b2ffa2b33d1e1", @"/Views/Backstage/PersonnelIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5529b7a8e15e0d7cfd56931e3a1f0e9783c4d3cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Backstage_PersonnelIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<JiuFu.ViewModels.PersonnelVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersonnelEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersonnelDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersonnelDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
  
    ViewData["Title"] = "PersonnelIndex";
    Layout = "~/Views/Shared/_LayoutView.cshtml";

#line default
#line hidden
            BeginContext(153, 512, true);
            WriteLiteral(@"
<h1>员工管理</h1>

<table class=""table"">
    <thead>
        <tr>
            <th>
               名字
            </th>
            <th>
                性别
            </th>
            <th>
               生日
            </th>
            <th>
                手机号
            </th>            
            <th>
               房间号
            </th>                  
            <th>
               邮箱
            </th>        
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 35 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(697, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(746, 39, false);
#line 38 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(785, 54, true);
            WriteLiteral("\r\n            </td>\r\n            <td>               \r\n");
            EndContext();
#line 41 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
                 if (item.Sex)
                {

#line default
#line hidden
            BeginContext(890, 30, true);
            WriteLiteral("                    <p>男</p>\r\n");
            EndContext();
#line 44 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(980, 30, true);
            WriteLiteral("                    <p>女</p>\r\n");
            EndContext();
#line 48 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
                }

#line default
#line hidden
            BeginContext(1029, 53, true);
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1083, 43, false);
#line 51 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
           Write(Html.DisplayFor(modelItem => item.Birthday));

#line default
#line hidden
            EndContext();
            BeginContext(1126, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1182, 47, false);
#line 54 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
           Write(Html.DisplayFor(modelItem => item.MobileNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1229, 67, true);
            WriteLiteral("\r\n            </td>            \r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1297, 40, false);
#line 57 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
           Write(Html.DisplayFor(modelItem => item.floor));

#line default
#line hidden
            EndContext();
            BeginContext(1337, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1393, 40, false);
#line 60 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1433, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1488, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c288940d5381573159d60100f0b2ffa2b33d1e18579", async() => {
                BeginContext(1542, 2, true);
                WriteLiteral("修改");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 63 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
                                                WriteLiteral(item.Id);

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
            BeginContext(1548, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1568, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c288940d5381573159d60100f0b2ffa2b33d1e110948", async() => {
                BeginContext(1625, 2, true);
                WriteLiteral("详细");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 64 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
                                                   WriteLiteral(item.Id);

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
            BeginContext(1631, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1651, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c288940d5381573159d60100f0b2ffa2b33d1e113321", async() => {
                BeginContext(1707, 2, true);
                WriteLiteral("删除");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 65 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
                                                  WriteLiteral(item.Id);

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
            BeginContext(1713, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 68 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelIndex.cshtml"
}

#line default
#line hidden
            BeginContext(1752, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<JiuFu.ViewModels.PersonnelVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591