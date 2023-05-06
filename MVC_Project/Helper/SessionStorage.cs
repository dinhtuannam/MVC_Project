using MVC_Project.Models;

namespace MVC_Project.Helper
{
    public class SessionStorage
    {
        public Cart_Index_VM GetCart(HttpContext context)
        {
            var data = context.Session.Get<Cart_Index_VM>("GioHang");
            if (data == null)
            {
                data = new Cart_Index_VM();
            }
            return data;
        }

        public void DeleteCart(HttpContext context)
        {
            var data = context.Session.Remove;
            context.Session.Clear();
        }
    }
}
