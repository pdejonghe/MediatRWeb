namespace MediatRWeb.Requests
{
    public class Cocktail
    {
        public string PopularName { get; }

        public Cocktail(string popularName) => PopularName = popularName;
    }
}
