using MediatR;

namespace MediatRWeb.Requests
{
    public class CocktailRequest : IRequest<Cocktail>
    {
        public string OrderName { get; }

        public CocktailRequest(string orderName) => OrderName = orderName;
    }
}
