#pragma checksum "C:\Users\Paulo\source\repos\ViaVarejo\ViaVarejo.Services.Friends.WebCoreMVC\Views\Friends\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2253bd950923d7fbd4886693f9998ee9b070f1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Friends_Index), @"mvc.1.0.view", @"/Views/Friends/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Friends/Index.cshtml", typeof(AspNetCore.Views_Friends_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2253bd950923d7fbd4886693f9998ee9b070f1a", @"/Views/Friends/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38120c6c9be00794f44129ca359ce32fd66142c", @"/Views/_ViewImports.cshtml")]
    public class Views_Friends_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 3360, true);
            WriteLiteral(@"<div class=""container"">


    <div class=""row"">
        <div class=""col"">
            <h1>Gerenciamento de Amigos</h1>
        </div>
    </div>
    <div class=""row"">
        <div class=""col"">
            <button type=""button"" id=""btnAddFriend"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#modalFriend"">Adicionar Amigo</button>
        </div>
    </div>
    <div class=""row"">
        <div class=""col"">
            <table id=""example"" class=""display cell-border"" style=""width:100%"">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nome</th>
                        <th>Latitude</th>
                        <th>Longitude</th>
                        <th>Ações</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <div class=""modal fade"" id=""modalFriend"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modalFriend"" aria-hidden=""true"">
        <div class=""modal-dial");
            WriteLiteral(@"og modal-dialog-centered modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""modalFriendLabel"">Modal title</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">

                    <div class=""form-group"">
                        <input type=""hidden"" id=""hddFriendId"" />
                        <label for=""txtName"" class=""col-form-label"">Nome:</label>
                        <input type=""text"" class=""form-control"" id=""txtName"">
                    </div>
                    <div class=""form-group"">
                        <label for=""txtLatitude"" class=""col-form-label"">Latitude:</label>
                        <input type=""text"" class=""form-control disabled"" id=""txtLatitude"">
         ");
            WriteLiteral(@"           </div>
                    <div class=""form-group"">
                        <label for=""txtLongitude"" class=""col-form-label"">Longitude:</label>
                        <input type=""text"" class=""form-control disabled"" id=""txtLongitude"">
                    </div>
                    <div class=""form-group"">
                        <fieldset>


                            <div>
                                <label for=""txtEndereco"" class=""col-form-label"">Endereço:</label>
                                <input type=""text"" class=""form-control"" id=""txtEndereco"" name=""txtEndereco"" />
                            </div>
                            <div>
                                &nbsp;
                            </div>

                            <div id=""mapa"" style=""height: 300px; width: 765px"">
                            </div>

                        </fieldset>
                    </div>
                </div>
                <div class=""modal-footer"">
            ");
            WriteLiteral(@"        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    <button type=""button"" id=""btnAddUpdateFriend"" class=""btn btn-primary"">Save changes</button>
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(3378, 7888, true);
                WriteLiteral(@"
    <script type=""text/javascript"" src=""http://maps.googleapis.com/maps/api/js?key=AIzaSyADb4782XFzmf3rfsoBH97fmyoO-I9gBts""></script>

    <script>
        
        $(document).ready(function () {

            carregaDataTable();

            $('#example').on('click', '#btnAtualizar', function (e) {
                e.preventDefault();
                var table = $('#example').DataTable();
                var data = table.row($(this).closest('tr')).data()
                $('#txtLatitude').val(data.latitude);
                $('#txtLongitude').val(data.longitude);
                $('#txtName').val(data.name);
                $('#hddFriendId').val(data.id);

                $('#btnAddUpdateFriend').html('Atualizar Amigo');

                GetAddress(data.latitude, data.longitude)
            });

            $('#example').on('click', '#btnExcluir', function (e) {
                e.preventDefault();
                var table = $('#example').DataTable();
                var data = table");
                WriteLiteral(@".row($(this).closest('tr')).data()

                var elequer = confirm(""Deseja realmente excluir o Amigo "" + data.id);

                if (elequer == true) {
                    //alert(""QUER EXCLUIR o usuario"" + data.id);

                    let friendJson = {
                        ""id"": data.id
                    };

                    $.ajax({
                        type: ""DELETE"",
                        contentType: ""application/json; charset=utf-8"",
                        url: ""Friends/DeleteFriend/"",
                        dataType: ""json"",
                        data: JSON.stringify(friendJson),
                        success: function (response) {
                            $('#modalFriend').modal('hide');
                            carregaDataTable();
                        }
                    });
                }

            });

            $('#btnAddFriend').click(function (e) {
                e.preventDefault();

                $('#txtLatitude'");
                WriteLiteral(@").val('');
                $('#txtLongitude').val('');
                $('#txtName').val('');
                $('#txtEndereco').val('');

                $('#btnAddUpdateFriend').html('Adicionar Amigo');
            });

            $('#btnAddUpdateFriend').click(function (e) {
                e.preventDefault();

                if ($('#btnAddUpdateFriend').html() == ""Atualizar Amigo"") {

                    let friendJson = {
                        ""id"": $('#hddFriendId').val(),
                        ""latitude"": $('#txtLatitude').val(),
                        ""longitude"": $('#txtLongitude').val(),
                        ""name"": $('#txtName').val()
                    };

                    $.ajax({
                        type: ""PUT"",
                        contentType: ""application/json; charset=utf-8"",
                        url: ""Friends/UpdateFriend"",
                        dataType: ""json"",
                        data: JSON.stringify(friendJson),
                    ");
                WriteLiteral(@"    success: function (response) {
                            $('#modalFriend').modal('hide');
                            carregaDataTable();
                        }
                    });
                }
                else {

                    let friendJson = {
                        ""latitude"": $('#txtLatitude').val(),
                        ""longitude"": $('#txtLongitude').val(),
                        ""name"": $('#txtName').val()
                    };

                    $.ajax({
                        type: ""POST"",
                        contentType: ""application/json; charset=utf-8"",
                        url: ""Friends/AddFriend"",
                        dataType: ""json"",
                        data: JSON.stringify(friendJson),
                        success: function (response) {
                            $('#modalFriend').modal('hide');
                            carregaDataTable();
                        }
                    });
                }
  ");
                WriteLiteral(@"          });


            function GetAddress(lat, lng) {
                var latlng = new google.maps.LatLng(lat, lng);
                var geocoder = geocoder = new google.maps.Geocoder();
                geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (results[1]) {
                            $('#txtEndereco').val(results[1].formatted_address);
                            carregarNoMapa(results[1].formatted_address);
                        }
                    }
                });
            }

            function carregaDataTable() {
                var table = $(""#example"").dataTable({
                    ""destroy"": true,
                    ""processing"": false,
                    ""serverSide"": true,
                    ""ajax"": {
                        ""url"": ""Friends/PostFriends"",
                        ""method"": ""POST"",
                        ""contentType");
                WriteLiteral(@""": ""application/json""
                    },
                    ""columns"": [
                        { ""data"": ""id"" },
                        { ""data"": ""name"" },
                        { ""data"": ""latitude"" },
                        { ""data"": ""longitude"" },
                        {
                            ""data"": null,
                            ""targets"": -1,
                            ""defaultContent"": ""<button id='btnAtualizar' type='button' class='btn btn-primary' data-toggle='modal' data-target='#modalFriend'>Editar</button>"" + ""  "" +
                                ""<button id='btnExcluir' type='button' class='btn btn-danger'>Excluir</button>""
                        }
                    ],
                    ""searching"": false,
                    ""sorting"": false,
                    ""ordering"": false,
                    ""paging"": false,
                    ""pagingType"": ""full_numbers"",
                    ""pageLength"": 10
                });
            }

        ");
                WriteLiteral(@"    function carregarNoMapa(endereco) {
                var options = {
                    zoom: 16,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                map = new google.maps.Map(document.getElementById(""mapa""), options);
                geocoder = new google.maps.Geocoder();
                marker = new google.maps.Marker({
                    map: map,
                    draggable: true,
                });

                geocoder.geocode({ 'address': endereco }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (results[0]) {
                            var latitude = results[0].geometry.location.lat();
                            var longitude = results[0].geometry.location.lng();

                            $('#txtEndereco').val(results[0].formatted_address);
                            $('#txtLatitude').val(latitude);
                            $('#txtLongitude");
                WriteLiteral(@"').val(longitude);

                            var location = new google.maps.LatLng(latitude, longitude);
                            marker.setPosition(location);
                            map.setCenter(location);
                            map.setZoom(16);
                        }
                    }
                });
            }

            //$(""#txtEndereco"").change(function () {
            //    if ($(this).val() != """")
            //        carregarNoMapa($(this).val());
            //})

            $(""#txtEndereco"").blur(function () {
                if ($(this).val() != """")
                    carregarNoMapa($(this).val());
            })
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