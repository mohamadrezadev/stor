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
      
        public PaymentController( UserManager<User> userManager)
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

                HttpContext.Session.SetString("Coursessuser", JsonConvert.SerializeObject(listOrder));

                var order_user = new Order
                {
                    totalpric = (int)courss.Sum(s => s.price),
                    statustpayment = false,
                    cours = listOrder,
                    userid = user.Id
                };

                if (order_user != null)
                {
                    var order_res = blo.create(order_user);
                    var _Pyament = new Payment(order_user.totalpric);
                    var callbackUrl = Url.ActionLink(nameof(Verify), "Payment",new {order_res.Id},
                        protocol: Request.Scheme);
                    var Result = await _Pyament.PaymentRequest(
                        "testPayment", callbackUrl, mobile: "09104500086");
                    if (Result.Status != 100)
                    {
                        return BadRequest(Result);
                    }
                    string readirectrl = $"https://sandbox.zarinpal.com/pg/StartPay/{Result.Authority}";
                    return Redirect(readirectrl);


                }
            }

            return null;


        }

        public async Task<IActionResult> Verify(int orderid, string callbackUrlFront)
        {
            string Status = HttpContext.Request.Query["Status"];
            string Authority = HttpContext.Request.Query["authority"];
            if (Status != "" & Status.ToString().ToLower() == "ok" && Authority != "")
            {
                //var pay = _paymentService.GetPayment(paymentId);
                var user = await userManager.FindByNameAsync(User.Identity.Name);

               // user.list_courss.Add();
                HttpContext.Session.Remove("basket");
                return Redirect("http://localhost:18063/Profile");
            }

            return BadRequest();

        }
    }
}



