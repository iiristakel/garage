#pragma checksum "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1b2d18b76a36778e86eb8adf7717173a3224d47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payments_PartialDetailsDelete), @"mvc.1.0.view", @"/Views/Payments/PartialDetailsDelete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Payments/PartialDetailsDelete.cshtml", typeof(AspNetCore.Views_Payments_PartialDetailsDelete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1b2d18b76a36778e86eb8adf7717173a3224d47", @"/Views/Payments/PartialDetailsDelete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dcd7015f43c8070726f3c60fdfed5aed875584a", @"/Views/_ViewImports.cshtml")]
    public class Views_Payments_PartialDetailsDelete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BLL.App.DTO.Payment>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(35, 38, false);
#line 3 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
Write(Resources.Domain.Payment.PaymentString);

#line default
#line hidden
            EndContext();
            BeginContext(73, 70, true);
            WriteLiteral("</h4>\r\n<hr />\r\n<dl class=\"row\">\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(144, 40, false);
#line 7 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.Bill));

#line default
#line hidden
            EndContext();
            BeginContext(184, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(236, 46, false);
#line 10 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.Bill.InvoiceNr));

#line default
#line hidden
            EndContext();
            BeginContext(282, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(333, 49, false);
#line 13 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.PaymentMethod));

#line default
#line hidden
            EndContext();
            BeginContext(382, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(434, 64, false);
#line 16 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.PaymentMethod.PaymentMethodValue));

#line default
#line hidden
            EndContext();
            BeginContext(498, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(549, 42, false);
#line 19 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.Client));

#line default
#line hidden
            EndContext();
            BeginContext(591, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(643, 46, false);
#line 22 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.Client.Address));

#line default
#line hidden
            EndContext();
            BeginContext(689, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(740, 39, false);
#line 25 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.Sum));

#line default
#line hidden
            EndContext();
            BeginContext(779, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(831, 35, false);
#line 28 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.Sum));

#line default
#line hidden
            EndContext();
            BeginContext(866, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(917, 47, false);
#line 31 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.PaymentTime));

#line default
#line hidden
            EndContext();
            BeginContext(964, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(1016, 43, false);
#line 34 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Payments\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.PaymentTime));

#line default
#line hidden
            EndContext();
            BeginContext(1059, 18, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BLL.App.DTO.Payment> Html { get; private set; }
    }
}
#pragma warning restore 1591
