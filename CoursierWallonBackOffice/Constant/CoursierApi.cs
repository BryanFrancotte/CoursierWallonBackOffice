using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursierWallonBackOffice.Constant
{
    class CoursierApi
    {
        public const string URL_BASE = "http://apicoursier.azurewebsites.net/api/";

        public const string URL_JWT = "Jwt";

        public const string URL_GetAllOrderWithNumberItems = "Order/GetAllWithNbItems";
        public const string URL_GetAllOrderNotComfirmWithNbItems = "Order/GetAllNotComfirmWithNbItems";
        public const string URL_GetAllOrderConfirmWithNbItems = "Order/GetAllComfirmWithNbItems";
        public const string URL_EditOrder = "Order/Edit";
        public const string URL_DeleteOrderById = "Order/DeleteById/";
    }
}
