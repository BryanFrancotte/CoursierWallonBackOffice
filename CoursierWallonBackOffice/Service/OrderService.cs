using CoursierWallonBackOffice.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Service
{
    public class OrderService
    {
        public async Task<IEnumerable<OrderWithNbItems>> GetAllOrder(Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            var stringInput = await http.GetStringAsync(new Uri("http://apicoursier.azurewebsites.net/api/Order/GetAllWithNbItems"));
            OrderWithNbItems[] orders = JsonConvert.DeserializeObject<OrderWithNbItems[]>(stringInput);

            return orders;
        }
    }
}
