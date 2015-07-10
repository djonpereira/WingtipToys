using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WingtipToys.Logic;

namespace WingtipToys
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int productId;

            if (!string.IsNullOrWhiteSpace(rawId) && int.TryParse(rawId, out productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }
            }
            else {
                Debug.Fail("ERROR : We should never get here...");
                throw new Exception("ERROR: illegal operation");
            }
            Response.Redirect("ShoppingCart.aspx");
                
        }
    }
}