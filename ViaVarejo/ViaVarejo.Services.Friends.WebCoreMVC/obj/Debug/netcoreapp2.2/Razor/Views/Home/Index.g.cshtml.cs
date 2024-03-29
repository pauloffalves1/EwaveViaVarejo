#pragma checksum "C:\Users\Paulo\source\repos\ViaVarejo\ViaVarejo.Services.Friends.WebCoreMVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fc346f2362fe3ceb8173be9fddf8472d2f9573c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Paulo\source\repos\ViaVarejo\ViaVarejo.Services.Friends.WebCoreMVC\Views\_ViewImports.cshtml"
using ViaVarejo.Services.Friends.WebCoreMVC;

#line default
#line hidden
#line 2 "C:\Users\Paulo\source\repos\ViaVarejo\ViaVarejo.Services.Friends.WebCoreMVC\Views\_ViewImports.cshtml"
using ViaVarejo.Services.Friends.WebCoreMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fc346f2362fe3ceb8173be9fddf8472d2f9573c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38120c6c9be00794f44129ca359ce32fd66142c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Paulo\source\repos\ViaVarejo\ViaVarejo.Services.Friends.WebCoreMVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 829, true);
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col"">
            <h1>Amigos mais próximos</h1>
        </div>
    </div>
    <div class=""row"">
        <div class=""col"">
            <label for=""ddlFriendsDropdown"" class=""col-form-label"">Qual amigo você se encontra ?:</label>
            <select id=""ddlFriendsDropdown"" class=""form-control""></select>
        </div>
    </div>
    <div class=""row"">
        <div class=""col"">
            <table id=""example"" class=""display cell-border"" style=""width:100%"">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nome</th>
                        <th>Distância (Km)</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</div>

");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(892, 1728, true);
                WriteLiteral(@"
<script>

    function LoadComboAmigos() {

        $.ajax({
            type: ""GET"",
            url: ""Friends/GetFriends"",
            contentType: ""application/json; charset=utf-8"",
            success: function (data) {
                $.each(data, function (index, value) {
                    $('#ddlFriendsDropdown').append('<option value=""' + value.id + '"">' + value.name + '</option>');
                });
            }
        });
    }

    function carregaDataTable(data) {

        //let friendJson = {
        //    ""id"": data
        //};

        var table = $(""#example"").dataTable({
            ""destroy"": true,
            ""processing"": false,
            ""serverSide"": true,
            ""ajax"": {
                ""url"": ""Friends/GetThreeClosestFriends/"" + data,
                ""method"": ""GET""
            },
            ""columns"": [
                { ""data"": ""id"" },
                { ""data"": ""name"" },
                { ""data"": ""distance"" }
            ],
        ");
                WriteLiteral(@"    ""searching"": false,
            ""sorting"": false,
            ""ordering"": false,
            ""paging"": false,
            ""pagingType"": ""full_numbers"",
            ""pageLength"": 10,
            ""DisplayStart"": 0
        });
    }

    $(document).ready(function () {

        $(""#example"").dataTable({
            ""searching"": false,
            ""sorting"": false,
            ""ordering"": false,
            ""paging"": false,
            ""pagingType"": ""full_numbers"",
            ""pageLength"": 10
        });

        LoadComboAmigos();

        $('#ddlFriendsDropdown').on('change', function () {

            carregaDataTable(this.value);

        });
    });
</script>
");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
