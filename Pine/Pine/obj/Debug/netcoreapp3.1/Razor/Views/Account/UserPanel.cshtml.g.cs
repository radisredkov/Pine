#pragma checksum "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "048a2e5bb53b7d74f35fa0dfb6a6050c361a19f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_UserPanel), @"mvc.1.0.view", @"/Views/Account/UserPanel.cshtml")]
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
#line 1 "D:\Radi's Folder\Pine\Pine\Pine\Views\_ViewImports.cshtml"
using Pine;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Radi's Folder\Pine\Pine\Pine\Views\_ViewImports.cshtml"
using Pine.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
using Pine.Data.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
using Pine.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"048a2e5bb53b7d74f35fa0dfb6a6050c361a19f1", @"/Views/Account/UserPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbb7b500c91f25d377bb53c736849b6b38c9b885", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_UserPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<PostsViewModel, User, ShopListingsViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Community/PostCard.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Shop/ListingCard.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
  
    ViewData["Title"] = Model.Item2.UserName;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<center><h1 style=\"color:#00ff21; margin-top: 50px;\">");
#nullable restore
#line 9 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
                                                Write(Html.DisplayFor(model => model.Item2.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1></center>\r\n<div class=\"transbox\">\r\n    <h2 style=\"color:aqua\">Posts:</h2>\r\n");
#nullable restore
#line 12 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
     if (Model.Item1.posts.Count == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p style=\"color: #00ff21; display: inline; margin: 0px !important;\">");
#nullable restore
#line 14 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Item2.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p><p style=\"display: inline;color:#fff; margin: 0px !important;\";>has no posts.</p>\r\n");
#nullable restore
#line 15 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n");
#nullable restore
#line 19 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
             foreach (var post in Model.Item1.posts.Where(p => p.userName == Model.Item2.UserName))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "048a2e5bb53b7d74f35fa0dfb6a6050c361a19f15907", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 21 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = post;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 22 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 24 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h2 style=\"color:aqua\">Listings:</h2>\r\n");
#nullable restore
#line 27 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
     if (Model.Item3.listings.Count == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p style=\"color: #00ff21; display: inline; margin: 0px !important;\">");
#nullable restore
#line 29 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Item2.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p><p style=\"display: inline;color:#fff; margin: 0px !important;\">has no active listings at the moment.</p>\r\n");
#nullable restore
#line 30 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n");
#nullable restore
#line 34 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
             foreach (var listing in Model.Item3.listings.Where(l => l.userName == Model.Item2.UserName))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "048a2e5bb53b7d74f35fa0dfb6a6050c361a19f19146", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 36 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = listing;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 37 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 39 "D:\Radi's Folder\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<PostsViewModel, User, ShopListingsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
