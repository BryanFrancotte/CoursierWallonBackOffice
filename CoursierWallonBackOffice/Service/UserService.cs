using CoursierWallonBackOffice.Constant;
using CoursierWallonBackOffice.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Service
{
    public class UserService
    {
        public async Task<Token> LoginUser(LoginUser loginUser)
        {
            Token token;
            var http = new HttpClient();
            string json = JsonConvert.SerializeObject(loginUser);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var stringInput = await http.PostAsync(new Uri(CoursierApi.URL_BASE + CoursierApi.URL_JWT), content);
                var content2 = await stringInput.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<Token>(content2);
            }
            catch (HttpRequestException e)
            {
                Console.Write(e);
                token = null;
            }
            return token;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers(Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            var stringInput = await http.GetStringAsync(new Uri(CoursierApi.URL_BASE + CoursierApi.URL_GetAllCoursier));
            ApplicationUser[] elements = JsonConvert.DeserializeObject<ApplicationUser[]>(stringInput);

            return elements;
        }

    }
}
