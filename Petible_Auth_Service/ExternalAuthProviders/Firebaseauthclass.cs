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
    
    public class Firebaseauthclass
    {
        private string customToken;
        private string jwt;
        private FirebaseApp firebaseapp;
        HttpClient client = new HttpClient(); 

        public async void GenerateToken(LoginData data)
        {
            
            var info = new MockLoginInfo
            {
                email = data.email,
                password = data.password,
                returnSecureToken = true
            };
            var json = JsonConvert.SerializeObject(info);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var token = client.PostAsync("https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyCUCz3zW6Q21Qf4tuKmCL9vYT6AlygCH1M", content).Result;
            LoginData user;
            string result = await token.Content.ReadAsStringAsync();
            var customToken = JsonConvert.DeserializeObject<LoginInfo>(result);
			using (var client = new HttpClient())
			{
				var response = client.GetStringAsync(new Uri($"https://localhost:5001/api/v1/user/" + customToken.localId)).Result;
				user = JsonConvert.DeserializeObject<LoginData>(response);
			}

			customToken.role = user.role;
			jwt = JsonConvert.SerializeObject(customToken);  
        }

       

        public string GetJWTToken(LoginData data)
        {
            GenerateToken(data);
            return jwt;
        }
    }
}
