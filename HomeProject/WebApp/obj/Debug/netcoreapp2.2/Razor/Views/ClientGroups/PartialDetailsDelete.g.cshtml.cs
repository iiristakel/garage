#pragma checksum "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\ClientGroups\PartialDetailsDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0800fc73209f7580b3a55082a8d9fdd403bfd1eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ClientGroups_PartialDetailsDelete), @"mvc.1.0.view", @"/Views/ClientGroups/PartialDetailsDelete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ClientGroups/PartialDetailsDelete.cshtml", typeof(AspNetCore.Views_ClientGroups_PartialDetailsDelete))]
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
#line 1 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0800fc73209f7580b3a55082a8d9fdd403bfd1eb", @"/Views/ClientGroups/PartialDetailsDelete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dcd7015f43c8070726f3c60fdfed5aed875584a", @"/Views/_ViewImports.cshtml")]
    public class Views_ClientGroups_PartialDetailsDelete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Domain.ClientGroup>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 87, true);
            WriteLiteral("\r\n<h4>ClientGroup</h4>\r\n<hr />\r\n<dl class=\"row\">\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(115, 40, false);
#line 7 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\ClientGroups\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(155, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(207, 36, false);
#line 10 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\ClientGroups\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(243, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(294, 47, false);
#line 13 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\ClientGroups\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(341, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(393, 43, false);
#line 16 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\ClientGroups\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(436, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(487, 51, false);
#line 19 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\ClientGroups\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.DiscountPercent));

#line default
#line hidden
            EndContext();
            BeginContext(538, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(590, 47, false);
#line 22 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\ClientGroups\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.DiscountPercent));

#line default
#line hidden
            EndContext();
            BeginContext(637, 18, true);
            WriteLiteral("\r\n    </dd>\r\n</dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Domain.ClientGroup> Html { get; private set; }
    }
}
#pragma warning restore 1591
