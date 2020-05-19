using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Apis.Auth.OAuth2;

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
            
            customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid);
        }

        public string GetJWTToken(string uid)
        {
            GenerateToken(uid);
            return customToken;
        }

       
    }
}
