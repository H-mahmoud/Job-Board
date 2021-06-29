#pragma checksum "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c976211d77f99adc5a8f03159513573fe7ca47d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\_ViewImports.cshtml"
using Job_Board;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\_ViewImports.cshtml"
using Job_Board.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\_ViewImports.cshtml"
using Job_Board.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c976211d77f99adc5a8f03159513573fe7ca47d1", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95767e69e0c191f7f4334aec69484a44172ad689", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"" style=""margin: 20px 0px 20px 0px;"">
    <div class=""col-lg-4"">
        <div class=""card text-white bg-info mb-3"">
            <div class=""card-header"" style=""border-bottom: 1px solid rgb(255 255 255)"">Total Posts</div>
            <div class=""card-body"" style=""text-align: center;"">
                <span style=""font-size: 50px;"">");
#nullable restore
#line 11 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                                          Write(Model.TotalPosts);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" +</span>
            </div>
        </div>
    </div>
    <div class=""col-lg-4"">
        <div class=""card text-white bg-info mb-3"">
            <div class=""card-header"" style=""border-bottom: 1px solid rgb(255 255 255)"">Pending Posts</div>
            <div class=""card-body"" style=""text-align: center;"">
                <span style=""font-size: 50px;"">");
#nullable restore
#line 19 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                                          Write(Model.TotalPending);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" +</span>
            </div>
        </div>
    </div>
    <div class=""col-lg-4"">
        <div class=""card text-white bg-info mb-3"">
            <div class=""card-header"" style=""border-bottom: 1px solid rgb(255 255 255)"">Registered Users</div>
            <div class=""card-body"" style=""text-align: center;"">
                <span style=""font-size: 50px;"">");
#nullable restore
#line 27 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                                          Write(Model.TotalUsers);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" +</span>
            </div>
        </div>
    </div>
</div>
<div class=""row"" style=""margin: 60px 0px;"">
    <div class=""job_listing_area col-lg-12"" style=""padding: 0px;"">
        <h3>Recent Posts</h3>
        <div class=""job_lists m-0"">
            <div class=""row"">
");
#nullable restore
#line 37 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                 foreach (var item in Model.RecentPosts)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-lg-12 col-md-12"">
                    <div class=""single_jobs white-bg d-flex justify-content-between"">
                        <div class=""jobs_left d-flex align-items-center"">
                            <div class=""thumb"" style=""padding:0px;"">
                                <img");
            BeginWriteAttribute("src", " src=\"", 1875, "\"", 1910, 1);
#nullable restore
#line 43 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
WriteAttributeValue("", 1881, item.Recruter.ProfilePicture, 1881, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1911, "\"", 1917, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 80px; height: 80px;\">\r\n                            </div>\r\n                            <div class=\"jobs_conetent\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2083, "\"", 2111, 2);
            WriteAttributeValue("", 2090, "/Job/Details/", 2090, 13, true);
#nullable restore
#line 46 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
WriteAttributeValue("", 2103, item.Id, 2103, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><h4>");
#nullable restore
#line 46 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                                                               Write(item.Title.Substring(0, (item.Title.Length > 50 ? 50 : item.Title.Length)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4></a>\r\n                                <div class=\"links_locat d-flex align-items-center\">\r\n                                    <div class=\"location\">\r\n                                        <p> <i class=\"fa fa-map-marker\"></i> ");
#nullable restore
#line 49 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                                                                        Write(item.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </div>\r\n                                    <div class=\"location\">\r\n                                        <p> <i class=\"fa fa-clock-o\"></i> ");
#nullable restore
#line 52 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                                                                      Write(item.JobNature == Job_Board.Models.enums.JobNature.FullTime? "Full TIme": "Part TIme");

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </div>\r\n                                    <div class=\"location\">\r\n                                        <p> <i class=\"fa fa-list-alt\"></i> ");
#nullable restore
#line 55 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                                                                            if (@item.Category != null)

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                                                                                                  Write(item.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class=""jobs_right"">
                            <div class=""date"" style=""color:#AAB1B7;margin:0px;"">
                                <p><i class=""fa fa-calendar"" style=""margin-right:7px""></i> ");
#nullable restore
#line 63 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                                                                                      Write(item.PublishedAt.ToString("dd/mm/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 68 "C:\Users\Hassan\source\repos\Job-Board\Job-Board\Views\Admin\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\".card\").fadeIn(600);\r\n            $(\".job_lists\").fadeIn(600);\r\n        })\r\n    </script>\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
