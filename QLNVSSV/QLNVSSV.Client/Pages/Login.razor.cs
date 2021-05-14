using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using QLNVSSV.Client.Features;
using QLNVSSV.Models.AuthenModel;
using QLNVSSV.Models.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLNVSSV.Client.Pages
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string password { get; set; }
    }
    public partial class Login
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        private bool isSuscess=false;

        private LoginModel user = new();
        public async Task LoginAction()
        {
            var authen=new AuthenticateResponse();
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync("http://localhost:37919/api/User/authenticate", data);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();

                    authen = (AuthenticateResponse)JsonConvert.DeserializeObject(result.Result, typeof(AuthenticateResponse));
                    if (authen.Id > 0)
                    {
                        isSuscess = true;
                    }
                }
            }
            
           await new LocalStorageService(JSRuntime).SetItem("Token", authen.JwtToken);
        }

        private EventCallback<bool> callbackLogin;
        
    }
}
