using BEE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using System;
using RestSharp;
using Microsoft.Extensions.Logging;
using ZarinpalSandbox;

namespace pr.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private UserManager<User> userManager;

        private readonly ILogger<PaymentController> _logger;

        public PaymentController(UserManager<User> userManager)
        {
            this.userManager = userManager;

        }


        public async Task<IActionResult> pyment()
        {
            var listbasket = new List<int>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                listbasket = JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket")).ToList();
                var blc = new blcours();
                var courss = blc.searchbyids(listbasket);
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                blorder blo = new blorder();
                var listOrder = new List<Order_cours>();
                foreach (var item in courss)
                {
                    listOrder.Add(new Order_cours { coursId = item.id });
                }

                var order_user = new Order
                {
                    totalpric = (int)courss.Sum(s => s.price),
                    statustpayment = false,
                    cours = listOrder,
                    userid = user.Id
                };

                if (order_user != null)
                {
                   var order_res= blo.create(order_user);   
                    var payment = new Payment(order_user.totalpric);
                    var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order_res.Id}",
                        "https://localhost:44326/Home/OnlinePayment/" + order_res.Id, "mohamadrezakiani9@yahoo.com", "09104500086");
                    if (res.Result.Status == 100)
                    {
                        return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            return null;


        }



    }
}