using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportStore.Infrastructure;

namespace SportStore.Models
{
    public class SessionCart: Cart
    {
        private static readonly string dataId = "Cart";

        [JsonIgnore]
        public ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            var session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>(dataId) ?? new SessionCart();
            cart.Session = session;

            return cart;
        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson(dataId, this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson(dataId, this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove(dataId);
        }

    }
}
