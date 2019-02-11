using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWeb.Requests
{
    public class BarTender : IRequestHandler<CocktailRequest, Cocktail>
    {
        public Task<Cocktail> Handle(CocktailRequest request, CancellationToken cancellationToken)
        {
            switch(request.OrderName)
            {
                case "Gin Tonic": return Task.FromResult(new Cocktail("G & T"));
                case "Cuba Libre": return Task.FromResult(new Cocktail("Free Cuba"));
                default: return Task.FromResult(new Cocktail("I went through the desert on a horse with no name"));
            } 
        }
    }
}
