using MediatR;
using MediatRWeb.Models;
using MediatRWeb.Notifications;
using MediatRWeb.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MediatRWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator) => this.mediator = mediator;

        public async Task<IActionResult> Index()
        {
            //Notifications ... 
            var royaltyEvent = new RoyaltyEvent("Princess Elisabeth is born");
            await this.mediator.Publish(royaltyEvent);

            //Send
            var cocktailRequest = new CocktailRequest("Gin Tonic");
            var cocktail = await this.mediator.Send(cocktailRequest);
            ViewData["Message"] = $"You have been served: {cocktail.PopularName}!";

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
