using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using ViaVarejo.Services.Friends.Domain;
using ViaVarejo.Services.Friends.WebCoreMVC.Models;

namespace ViaVarejo.Services.Friends.WebCoreMVC.Controllers
{
    public class FriendsController : Controller
    {
        private static string _urlBase;
        private static HttpClient _client;

        public FriendsController()
        {
            if (_client == null)
                Authentication();
        }

        private void Authentication()
        {
            var builder = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile($"appsettings.json");
            var config = builder.Build();

            _urlBase = config.GetSection("API_Access:UrlBase").Value;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage respToken = client.PostAsync(
                _urlBase + "login", new StringContent(
                    JsonConvert.SerializeObject(new
                    {
                        UserID = config.GetSection("API_Access:UserName").Value,
                        Password = config.GetSection("API_Access:Password").Value
                    }), Encoding.UTF8, "application/json")).Result;

            string conteudo =
                respToken.Content.ReadAsStringAsync().Result;

            if (respToken.StatusCode == HttpStatusCode.OK)
            {
                Token token = JsonConvert.DeserializeObject<Token>(conteudo);
                if (token.Authenticated)
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.AccessToken);

                    _client = client;
                }
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostFriends()
        {

            if (_client == null)
                Authentication();

            List<FriendViewModel> result = null;

            HttpResponseMessage responseCall = _client.GetAsync(_urlBase + "friends/getFriends").Result;
            if (responseCall.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<List<FriendViewModel>>(responseCall.Content.ReadAsStringAsync().Result);
            }


            dynamic response = new
            {
                Data = result
            };

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetFriends()
        {
            if (_client == null)
                Authentication();


            List<FriendViewModel> result = null;

            HttpResponseMessage responseCall = _client.GetAsync(_urlBase + "friends/getFriends").Result;
            if (responseCall.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<List<FriendViewModel>>(responseCall.Content.ReadAsStringAsync().Result);
            }

            return Ok(result);
        }

        public IActionResult UpdateFriend([FromBody]Friend friend)
        {
            if (_client == null)
                Authentication();

            string json = JsonConvert.SerializeObject(friend, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string result = string.Empty;

            HttpResponseMessage responseCall = _client.PutAsync(_urlBase + "friends/UpdateFriend", httpContent).Result;
            if (responseCall.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<string>(responseCall.Content.ReadAsStringAsync().Result);
            }

            return Ok(result);
        }

        public IActionResult AddFriend([FromBody]Friend friend)
        {
            if (_client == null)
                Authentication();

            string json = JsonConvert.SerializeObject(friend, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string result = string.Empty;

            HttpResponseMessage responseCall = _client.PostAsync(_urlBase + "friends/AddFriend", httpContent).Result;
            if (responseCall.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<string>(responseCall.Content.ReadAsStringAsync().Result);
            }

            return Ok(result);
        }

        
        [HttpGet]
        //[Produces("application/json")]
        [Route("Friends/GetThreeClosestFriends/{id}")]
        public IActionResult GetThreeClosestFriends([FromRoute]int id)
        {
            if (_client == null)
                Authentication();

            List<TreeFriendsViewModel> result = null;

            HttpResponseMessage responseCall = _client.GetAsync(_urlBase + "Friends/GetThreeClosestFriends/" + id.ToString()).Result;
            if (responseCall.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<List<TreeFriendsViewModel>>(responseCall.Content.ReadAsStringAsync().Result);
            }

            dynamic response = new
            {
                Data = result
            };

            return Ok(response);
        }

        public IActionResult DeleteFriend([FromBody]Friend friendId)
        {
            if (_client == null)
                Authentication();

            string result = string.Empty;

            HttpResponseMessage responseCall = _client.DeleteAsync(_urlBase + "Friends/DeleteFriend/" + friendId.Id.ToString()).Result;
            if (responseCall.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<string>(responseCall.Content.ReadAsStringAsync().Result);
            }

            return Ok(result);
        }

        private List<FriendViewModel> ProcessarDadosForm(List<FriendViewModel> lstElements, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };
                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getProperty(columName);
                        if (sortDirection == "asc")
                        {
                            return lstElements.OrderBy(prop.GetValue).Skip(skip)
                                .Take(pageSize).ToList();
                        }
                        else
                            return lstElements.OrderByDescending(prop.GetValue)
                                .Skip(skip).Take(pageSize).ToList();
                    }
                    else
                        return lstElements;
                }
            }
            return null;
        }

        private List<TreeFriendsViewModel> ProcessarDadosForm(List<TreeFriendsViewModel> lstElements, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };
                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getProperty(columName);
                        if (sortDirection == "asc")
                        {
                            return lstElements.OrderBy(prop.GetValue).Skip(skip)
                                .Take(pageSize).ToList();
                        }
                        else
                            return lstElements.OrderByDescending(prop.GetValue)
                                .Skip(skip).Take(pageSize).ToList();
                    }
                    else
                        return lstElements;
                }
            }
            return null;
        }

        private PropertyInfo getProperty(string name)
        {
            var properties = typeof(Models.FriendViewModel).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }
    }
}