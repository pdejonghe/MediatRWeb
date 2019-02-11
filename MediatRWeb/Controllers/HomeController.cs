using MediatR;
using MediatRWeb.Models;
using MediatRWeb.Notifications;
using MediatRWeb.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using MediatRWeb.Core;

namespace MediatRWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;
        private Synchronizer<SimpleLog, SimpleLog, SimpleLog> SimpleLog { get; }

        public HomeController(IMediator mediator, SimpleLog simpleLog)
        {
            this.mediator = mediator;
            this.SimpleLog = new Synchronizer<SimpleLog, SimpleLog, SimpleLog>(simpleLog);
        }

        public async Task<IActionResult> Index()
        {
            //Notifications ... 
            var royaltyEvent = new RoyaltyEvent("Princess Elisabeth is born");
            await this.mediator.Publish(royaltyEvent);

            //Send ...
            var cocktailRequest = new CocktailRequest("Gin Tonic");
            var cocktail = await this.mediator.Send(cocktailRequest);
            //cocktailRequest = new CocktailRequest("Cuba Libre");
            //cocktail = await this.mediator.Send(cocktailRequest);

            ViewData["Message"] = $"You have been served: {cocktail.PopularName}!";
            this.SimpleLog.Read(log => ViewData["Log"] = log.GetLogEntries());

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
