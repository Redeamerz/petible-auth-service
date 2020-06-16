using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Jose;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using Petible_Auth_Service.Models;
using System.Text;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using JWT.Algorithms;
using Google.Apis.Json;
using JWT;
using JWT.Serializers;

namespace Petible_Auth_Service.ExternalAuthProviders
{
    
    public class Firebase
    {
        private string customToken;
        private string jwt;
        private FirebaseApp firebaseapp;
        HttpClient client = new HttpClient(); 

        public async Task<string> FirebaseLogin(LoginData data)
        {
            var json = JsonConvert.SerializeObject(data);
            
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyCUCz3zW6Q21Qf4tuKmCL9vYT6AlygCH1M")
            };
            var response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();

            LoginInfo user = JsonConvert.DeserializeObject<LoginInfo>(result);

            user.role = getRole(user, user.localId).role;
            return jwt = JsonConvert.SerializeObject(user);
        }

        public async Task<string> FirebaseRegister(LoginData data)
        {
            var json = JsonConvert.SerializeObject(data);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyCUCz3zW6Q21Qf4tuKmCL9vYT6AlygCH1M")
            };
            var response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();

            LoginInfo user = JsonConvert.DeserializeObject<LoginInfo>(result);

            UserTableModel model = new UserTableModel();
            model.email = data.email;
            model.role = data.role;
            model.id = user.localId;

            setRole(model);
            

            user.role = getRole(user, user.localId).role;
            return jwt = JsonConvert.SerializeObject(user);
        }

        private LoginInfo getRole(LoginInfo data, string id)
        {
            using (var client = new HttpClient())
            {
                var roleresponse = client.GetStringAsync(new Uri($"https://localhost:5001/api/v1/user/" + id)).Result;
                data = JsonConvert.DeserializeObject<LoginInfo>(roleresponse);
            }
            return data;
        }

        private void setRole(UserTableModel model)
        {
            
            using (var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage result = client.PutAsync("https://localhost:5001/api/v1/user", content).Result;              
            }
                  
        }
       
    }
}
