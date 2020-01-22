using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pixgram_V1.Infrastructure;

namespace Pixgram_V1.Models
{
    public class CartSession : Cart
    {
        [JsonIgnore] // No need to Deserialize or Serialize the ISession property 
        public ISession Session { get; private set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            CartSession cart = session.GetJson<CartSession>(customerCartKey) ?? new CartSession();
            cart.Session = session;
            return cart;
        }
        public override void AddProduct(FileUpload p, int quantity)
        {
            base.AddProduct(p, quantity);
            CommitToSession();
        }
        public override void RemoveCartRow(FileUpload p)
        {
            base.RemoveCartRow(p);
            CommitToSession();
        }
        public override void EmptyCart()
        {
            base.EmptyCart();
            Session.Remove(customerCartKey);
        }
        public void CommitToSession()
        {
            Session.SetJson(customerCartKey, this);
        }
    }
}
