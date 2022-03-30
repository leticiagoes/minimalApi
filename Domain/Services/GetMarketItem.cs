namespace MinimalApi.Domain.Services
{
    public class GetMarketItem : IGetMarketItem
    {
        protected AppDataContext _context;
        public GetMarketItem(AppDataContext context)
        {
            _context = context;
        }

        public IResult GetAll()
        {
            var marketList = _context.MarketItems;
            return marketList is not null ? Results.Ok(marketList.OrderBy(o => o.Nome)) : Results.NotFound();
        }

        public IResult GetById(Guid id)
        {
            var marketItem = _context.MarketItems.FirstOrDefault(a => a.Id == id);
            if (marketItem == null)
                return Results.NotFound();

            return Results.Ok(marketItem);
        }
    }
}