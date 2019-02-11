using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWeb.Requests
{
    public class LiquorStore : IRequestHandler<CocktailRequest, Cocktail>
    {
        public Task<Cocktail> Handle(CocktailRequest request, CancellationToken cancellationToken)
        {
            switch (request.OrderName)
            {
                case "Gin Tonic": return Task.FromResult(new Cocktail("Gin Tonic - minimum quantity 12 - discount 10%"));
                case "Cuba Libre": return Task.FromResult(new Cocktail("Cuba Libre - minimum quantity 24 - discount 12%"));
                default: return Task.FromResult(new Cocktail("Sorry, we can't help you"));
            }
        }
    }
}
