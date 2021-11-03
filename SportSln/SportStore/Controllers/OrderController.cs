using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Checkout() => View(new Order());
    }
}
