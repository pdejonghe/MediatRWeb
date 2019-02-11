using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MediatRWeb.Models;
using MediatRWeb.Notifications;

namespace MediatRWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator) => this.mediator = mediator;

        public async Task<IActionResult> Index()
        {
            var royaltyEvent = new RoyaltyEvent("Princess Elisabeth is born");
            await this.mediator.Publish(royaltyEvent);


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
