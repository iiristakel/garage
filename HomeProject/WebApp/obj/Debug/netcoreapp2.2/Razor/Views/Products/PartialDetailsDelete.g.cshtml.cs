#pragma checksum "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Products\PartialDetailsDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe341ca3daa19184db9c7c3e2975add0edb32ab6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_PartialDetailsDelete), @"mvc.1.0.view", @"/Views/Products/PartialDetailsDelete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/PartialDetailsDelete.cshtml", typeof(AspNetCore.Views_Products_PartialDetailsDelete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe341ca3daa19184db9c7c3e2975add0edb32ab6", @"/Views/Products/PartialDetailsDelete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dcd7015f43c8070726f3c60fdfed5aed875584a", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_PartialDetailsDelete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BLL.App.DTO.Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(35, 38, false);
#line 3 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Products\PartialDetailsDelete.cshtml"
Write(Resources.Domain.Product.ProductString);

#line default
#line hidden
            EndContext();
            BeginContext(73, 70, true);
            WriteLiteral("</h4>\r\n<hr />\r\n<dl class=\"row\">\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(144, 47, false);
#line 7 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Products\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(191, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(243, 43, false);
#line 10 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Products\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(286, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(337, 47, false);
#line 13 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Products\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.ProductCode));

#line default
#line hidden
            EndContext();
            BeginContext(384, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(436, 43, false);
#line 16 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Products\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.ProductCode));

#line default
#line hidden
            EndContext();
            BeginContext(479, 50, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class = \"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(530, 41, false);
#line 19 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Products\PartialDetailsDelete.cshtml"
   Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(571, 51, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(623, 37, false);
#line 22 "C:\Users\kalle\RiderProjects\Project\HomeProject\WebApp\Views\Products\PartialDetailsDelete.cshtml"
   Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(660, 18, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BLL.App.DTO.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
