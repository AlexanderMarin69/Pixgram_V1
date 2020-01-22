using Microsoft.AspNetCore.Mvc;
using Pixgram_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pixgram_V1.ViewComponents
{
    public class CartWidgetViewComponent : ViewComponent
    {
        private Cart cart;

        public CartWidgetViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
