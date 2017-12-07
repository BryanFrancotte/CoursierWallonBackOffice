using CoursierWallonBackOffice.Constant;
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
            var stringInput = await http.GetStringAsync(new Uri(CoursierApi.URL_BASE + CoursierApi.URL_GetAllOrderWithNumberItems));
            OrderWithNbItems[] orders = JsonConvert.DeserializeObject<OrderWithNbItems[]>(stringInput);

            return orders;
        }

        public async Task<int> DeleteOrderById(long orderNumber, Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            HttpResponseMessage response = await http.DeleteAsync(new Uri(CoursierApi.URL_BASE + CoursierApi.URL_DeleteOrderById + orderNumber));
            if (response.IsSuccessStatusCode)
            {
                return HttpResponseCode.HTTP_OK;
            }
            else
            {
                return HttpResponseCode.HTTP_NOT_FOUND;
            }
        }
    }
}
