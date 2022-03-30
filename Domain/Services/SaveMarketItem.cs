namespace MinimalApi.Domain.Services
{
    public class SaveMarketItem : ISaveMarketItem
    {
        protected AppDataContext _context;
        public SaveMarketItem(AppDataContext context)
        {
            _context = context;
        }

        public IResult Save(MarketItemDTO dto)
        {
            var marketItem = dto.MapTo();

            if (!dto.IsValid)
                return Results.BadRequest(dto.Notifications);

            _context.MarketItems.Add(marketItem);
            _context.SaveChanges();

            return Results.Created($"/v1/marketlist/{marketItem.Id}", marketItem);
        }
    }
}