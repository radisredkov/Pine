#pragma checksum "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc1a272277fd76d1048180532ee8377371a8bd4a"
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
#line 1 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\_ViewImports.cshtml"
using Pine;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\_ViewImports.cshtml"
using Pine.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
using Pine.Data.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
using Pine.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc1a272277fd76d1048180532ee8377371a8bd4a", @"/Views/Account/UserPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbb7b500c91f25d377bb53c736849b6b38c9b885", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_UserPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<PostsViewModel, User, ShopListingsViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "./EditUser.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Chat", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateChat", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Shared/PostCard.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Shop/ListingCard.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
  
    ViewData["Title"] = Model.Item2.UserName;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
 if (Model.Item2.userCss != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <style>");
#nullable restore
#line 11 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
      Write(System.Text.Encoding.Default.GetString(Model.Item2.userCss));

#line default
#line hidden
#nullable disable
            WriteLiteral("</style>\r\n");
#nullable restore
#line 12 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<center>\r\n    <h1 style=\"color:#00ff21;\">\r\n        ");
#nullable restore
#line 16 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
   Write(Html.DisplayFor(model => model.Item2.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 16 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
                                                         if (Model.Item2.UserName == User.Identity.Name)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <button class=""btn btn-primary"" data-toggle=""collapse"" data-target=""#editUserContainer"">
                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-pencil-fill"" viewBox=""0 0 16 16"">
                    <path d=""M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z"" />
                </svg>
            </button>
            <div id=""editUserContainer"" class=""collapse"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dc1a272277fd76d1048180532ee8377371a8bd4a7807", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 24 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = (new UserPanelInputModel { });

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
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 26 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(" <img id=\"userProfilePicture\" onclick=\"resizePfp(this)\" onerror=\"this.style.display=\'none\'\" style=\"height:110px; width:110px; float:right;\" frameborder=\"0\"");
            BeginWriteAttribute("src", " src=\"", 1562, "\"", 1643, 2);
            WriteAttributeValue("", 1568, "data:image/jpeg;base64,", 1568, 23, true);
#nullable restore
#line 26 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
WriteAttributeValue("", 1591, Convert.ToBase64String(@Model.Item2.profilePicture), 1591, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </h1>\r\n    <p>");
#nullable restore
#line 28 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
  Write(Html.DisplayFor(model => Model.Item2.userDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 29 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
     if (Model.Item2.UserName != User.Identity.Name && User.Identity.Name != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc1a272277fd76d1048180532ee8377371a8bd4a10812", async() => {
                WriteLiteral("Message User");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
                                                                                 WriteLiteral(Model.Item2.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 34 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</center>\r\n<h2 style=\"color:aqua\">Posts:</h2>\r\n");
#nullable restore
#line 38 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
 if (Model.Item1.posts.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p style=\"color: #00ff21; display: inline; margin: 0px !important;\">");
#nullable restore
#line 40 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Item2.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p><p style=\"display: inline;color:#fff; margin: 0px !important;\">has no posts.</p>\r\n");
#nullable restore
#line 41 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n");
#nullable restore
#line 45 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
         foreach (var post in Model.Item1.posts.Where(p => p.userName == Model.Item2.UserName))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dc1a272277fd76d1048180532ee8377371a8bd4a14753", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 47 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
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
#line 48 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 50 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 style=\"color:aqua\">Listings:</h2>\r\n");
#nullable restore
#line 53 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
 if (Model.Item3.listings.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p style=\"color: #00ff21; display: inline; margin: 0px !important;\">");
#nullable restore
#line 55 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Item2.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p><p style=\"display: inline;color:#fff; margin: 0px !important;\">has no active listings at the moment.</p>\r\n");
#nullable restore
#line 56 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n");
#nullable restore
#line 60 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
         foreach (var listing in Model.Item3.listings.Where(l => l.creatorName == Model.Item2.UserName))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dc1a272277fd76d1048180532ee8377371a8bd4a17957", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 62 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
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
#line 63 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 65 "D:\It-kariera\Emoty\Pine\Pine\Pine\Views\Account\UserPanel.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    $(document).ready(function () {
        $('form input').change(function () {
            $('form p').text(this.files.length + "" file(s) selected"");
        });
    });
</script>

<script>
    function resizePfp(img) {
        if ($(img).hasClass('enlarged')) {
            $(img).removeClass('enlarged');
            $(img).stop().animate({ width: 110, height: 110 }, 100);
        } else {
            $(img).addClass('enlarged')
            $(img).stop().animate({ width: 1000, height: 700 }, 100);
        }
    }
</script>");
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
