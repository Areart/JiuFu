#pragma checksum "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab82aaebf550343769ae44b98e7fcd1dccf2c74a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Backstage_PersonnelDetails), @"mvc.1.0.view", @"/Views/Backstage/PersonnelDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Backstage/PersonnelDetails.cshtml", typeof(AspNetCore.Views_Backstage_PersonnelDetails))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab82aaebf550343769ae44b98e7fcd1dccf2c74a", @"/Views/Backstage/PersonnelDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5529b7a8e15e0d7cfd56931e3a1f0e9783c4d3cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Backstage_PersonnelDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JiuFu.UserAndRole.ApplicationUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersonnelEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersonnelIndex", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
  
    ViewData["Title"] = "PersonnelDetails";
    Layout = "~/Views/Shared/_LayoutView.cshtml";

#line default
#line hidden
            BeginContext(147, 175, true);
            WriteLiteral("\r\n<h1>员工信息</h1>\r\n\r\n<div>\r\n   \r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n           用户名\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(323, 36, false);
#line 18 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(359, 126, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n           性别\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(486, 35, false);
#line 24 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
       Write(Html.DisplayFor(model => model.Sex));

#line default
#line hidden
            EndContext();
            BeginContext(521, 126, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n           生日\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(648, 40, false);
#line 30 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
       Write(Html.DisplayFor(model => model.Birthday));

#line default
#line hidden
            EndContext();
            BeginContext(688, 127, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n           手机号\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(816, 44, false);
#line 36 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
       Write(Html.DisplayFor(model => model.MobileNumber));

#line default
#line hidden
            EndContext();
            BeginContext(860, 129, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n           头像\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n           <img");
            EndContext();
            BeginWriteAttribute("src", "  src=\"", 989, "\"", 1039, 1);
#line 42 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
WriteAttributeValue("", 996, Html.DisplayFor(model => model.AvatarPath), 996, 43, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1040, 128, true);
            WriteLiteral("/> \r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n          楼层\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1169, 37, false);
#line 48 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
       Write(Html.DisplayFor(model => model.floor));

#line default
#line hidden
            EndContext();
            BeginContext(1206, 128, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            登陆名\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1335, 40, false);
#line 54 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(1375, 70, true);
            WriteLiteral("\r\n        </dd>        \r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1446, 41, false);
#line 57 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1487, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1551, 37, false);
#line 60 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1588, 54, true);
            WriteLiteral("\r\n        </dd>       \r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1642, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab82aaebf550343769ae44b98e7fcd1dccf2c74a8951", async() => {
                BeginContext(1697, 2, true);
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
#line 65 "C:\Users\Administrator\source\repos\JiuFu3\JiuFu\JiuFu.Web\Views\Backstage\PersonnelDetails.cshtml"
                                    WriteLiteral(Model.Id);

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
            BeginContext(1703, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1711, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab82aaebf550343769ae44b98e7fcd1dccf2c74a11298", async() => {
                BeginContext(1742, 2, true);
                WriteLiteral("返回");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1748, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JiuFu.UserAndRole.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
