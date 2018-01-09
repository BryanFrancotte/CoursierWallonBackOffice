using CoursierWallonBackOffice.Constant;
using CoursierWallonBackOffice.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Service
{
    public class UserService
    {
        public async Task<int> LoginUser(LoginUser loginUser)
        {
            Token token;
            int resultCode = 0;
            var http = new HttpClient();
            string json = JsonConvert.SerializeObject(loginUser);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var stringInput = await http.PostAsync(new Uri(CoursierApi.URL_BASE + CoursierApi.URL_JWT), content);
                HttpStatusCode statusCode = stringInput.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var stringToken = await stringInput.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<Token>(stringToken);

                    if (VerificationIsAdmin(token.TokenString))
                    {
                        resultCode = 200;
                        Token.tokenCurrent = token;
                    }
                    else
                    {
                        resultCode = 401;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                resultCode = 0;
            }
            return resultCode;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers(Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            var stringInput = await http.GetStringAsync(new Uri(CoursierApi.URL_BASE + CoursierApi.URL_GetAllCoursier));
            ApplicationUser[] elements = JsonConvert.DeserializeObject<ApplicationUser[]>(stringInput);

            return elements;
        }

        public bool VerificationIsAdmin(String token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            var role = tokenS.Claims.SingleOrDefault(claim => claim.Type == "Role").Value;

            return (role != null && role == "ADMIN");
        }

    }
}
