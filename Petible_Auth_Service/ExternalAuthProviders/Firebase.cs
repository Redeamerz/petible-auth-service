using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using Petible_Auth_Service.Models;
using RestSharp;

namespace Petible_Auth_Service.ExternalAuthProviders
{
    
    public class Firebase
    {
        private string customToken;
        public Firebase()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("oathCredentials.json"),
                ServiceAccountId = "petible@oathtest-265121.iam.gserviceaccount.com",
            });
        }

        public async void GenerateToken(string uid)
        {
            UserData user;
            using(var client = new HttpClient())
            {
                var response = client.GetStringAsync(new Uri("http://localhost:5000/api/v1/user/0b1bb14f-945c-11ea-bab6-005056a73cc6")).Result;
                user = JsonConvert.DeserializeObject<UserData>(response);
            }
            var additionalClaims = new Dictionary<string, object>()
            {
                { user.role, true },
            };
            customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid, additionalClaims);
        }

        public string GetJWTToken(string uid)
        {
            GenerateToken(uid);
            return customToken;
        }

       
    }
}
