#pragma checksum "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "949a5c74678488a7b27b6444a05d5def411e2eea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clients_PartialDetailsDelete), @"mvc.1.0.view", @"/Views/Clients/PartialDetailsDelete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Clients/PartialDetailsDelete.cshtml", typeof(AspNetCore.Views_Clients_PartialDetailsDelete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"949a5c74678488a7b27b6444a05d5def411e2eea", @"/Views/Clients/PartialDetailsDelete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dcd7015f43c8070726f3c60fdfed5aed875584a", @"/Views/_ViewImports.cshtml")]
    public class Views_Clients_PartialDetailsDelete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BLL.App.DTO.Client>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(34, 36, false);
#line 3 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
Write(Resources.Domain.Client.ClientString);

#line default
#line hidden
            EndContext();
            BeginContext(70, 70, true);
            WriteLiteral("</h4>\r\n<hr />\r\n<dl class=\"row\">\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(141, 47, false);
#line 7 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.ClientGroup));

#line default
#line hidden
            EndContext();
            BeginContext(188, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(240, 48, false);
#line 10 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.ClientGroup.Name));

#line default
#line hidden
            EndContext();
            BeginContext(288, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(339, 47, false);
#line 13 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(386, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(438, 43, false);
#line 16 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(481, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(532, 43, false);
#line 19 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(575, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(627, 39, false);
#line 22 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(666, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(717, 41, false);
#line 25 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(758, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(810, 37, false);
#line 28 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(847, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(898, 49, false);
#line 31 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.ContactPerson));

#line default
#line hidden
            EndContext();
            BeginContext(947, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(999, 45, false);
#line 34 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Clients\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.ContactPerson));

#line default
#line hidden
            EndContext();
            BeginContext(1044, 18, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BLL.App.DTO.Client> Html { get; private set; }
    }
}
#pragma warning restore 1591
