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


namespace Petible_Auth_Service.ExternalAuthProviders
{
    
    public class Firebase
    {
        private string customToken;
        private FirebaseApp firebaseapp;
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
            //FirebaseApp instance = FirebaseApp.GetInstance("app");
            UserData user;
            using(var client = new HttpClient())
            {
                var response = client.GetStringAsync(new Uri($"http://localhost:5000/api/v1/user/" + uid)).Result;
                user = JsonConvert.DeserializeObject<UserData>(response);
            }
            var additionalClaims = new Dictionary<string, object>()
            {
                { "role", user.role },
            };
            customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid, additionalClaims);
            FirebaseApp.DefaultInstance.Delete();
        }

        public string GetJWTToken(string uid)
        {
            GenerateToken(uid);
            return customToken;
        }
    }
}
