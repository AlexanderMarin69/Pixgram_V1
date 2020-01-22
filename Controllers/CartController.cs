using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pixgram_V1.Models;
using Pixgram_V1.ViewModels;
using vueproject.DB;

namespace Pixgram_V1.Controllers
{
    public class CartController : Controller
    {
        private readonly PixgramDbContext ctx;

        private Cart cart;

        public CartController(PixgramDbContext context, Cart cartService)
        {
            ctx = context;
            cart = cartService;
        }

        public IActionResult Index(string returnUrl)
        {
            var vm = new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };

            return View(vm);
        }

        public RedirectToActionResult AddToCart(int id, string returnUrl)
        {
            var p = ctx.FileUploads.FirstOrDefault(x => x.Id.Equals(id));
            if (p != null)
            {
                cart.AddProduct(p, 1);
            }

            return RedirectToAction(nameof(Index), new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int id, string returnUrl)
        {
            var p = ctx.FileUploads.FirstOrDefault(x => x.Id.Equals(id));
            if (p != null)
            {
                cart.RemoveCartRow(p);
            }

            return RedirectToAction(nameof(Index), new { returnUrl });
        }
    }
}