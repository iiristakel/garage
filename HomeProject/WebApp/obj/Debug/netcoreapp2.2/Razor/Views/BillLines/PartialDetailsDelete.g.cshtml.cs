#pragma checksum "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c980656cc22fccf1207ebca9c13d00df01bdcab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BillLines_PartialDetailsDelete), @"mvc.1.0.view", @"/Views/BillLines/PartialDetailsDelete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BillLines/PartialDetailsDelete.cshtml", typeof(AspNetCore.Views_BillLines_PartialDetailsDelete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c980656cc22fccf1207ebca9c13d00df01bdcab", @"/Views/BillLines/PartialDetailsDelete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dcd7015f43c8070726f3c60fdfed5aed875584a", @"/Views/_ViewImports.cshtml")]
    public class Views_BillLines_PartialDetailsDelete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BLL.App.DTO.BillLine>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(36, 40, false);
#line 3 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
Write(Resources.Domain.BillLine.BillLineString);

#line default
#line hidden
            EndContext();
            BeginContext(76, 86, true);
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(163, 40, false);
#line 7 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayNameFor(model => model.Bill));

#line default
#line hidden
            EndContext();
            BeginContext(203, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(267, 46, false);
#line 10 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayFor(model => model.Bill.InvoiceNr));

#line default
#line hidden
            EndContext();
            BeginContext(313, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(376, 43, false);
#line 13 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayNameFor(model => model.Product));

#line default
#line hidden
            EndContext();
            BeginContext(419, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(483, 39, false);
#line 16 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayFor(model => model.Product));

#line default
#line hidden
            EndContext();
            BeginContext(522, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(585, 39, false);
#line 19 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayNameFor(model => model.Sum));

#line default
#line hidden
            EndContext();
            BeginContext(624, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(688, 35, false);
#line 22 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayFor(model => model.Sum));

#line default
#line hidden
            EndContext();
            BeginContext(723, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(786, 42, false);
#line 25 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(828, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(892, 38, false);
#line 28 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayFor(model => model.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(930, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(993, 51, false);
#line 31 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayNameFor(model => model.DiscountPercent));

#line default
#line hidden
            EndContext();
            BeginContext(1044, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1108, 47, false);
#line 34 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayFor(model => model.DiscountPercent));

#line default
#line hidden
            EndContext();
            BeginContext(1155, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1218, 51, false);
#line 37 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayNameFor(model => model.SumWithDiscount));

#line default
#line hidden
            EndContext();
            BeginContext(1269, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1333, 47, false);
#line 40 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\BillLines\PartialDetailsDelete.cshtml"
       Write(Html.DisplayFor(model => model.SumWithDiscount));

#line default
#line hidden
            EndContext();
            BeginContext(1380, 26, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BLL.App.DTO.BillLine> Html { get; private set; }
    }
}
#pragma warning restore 1591
