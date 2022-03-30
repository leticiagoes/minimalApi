namespace MinimalApi.Domain.Services
{
    public class DeleteMarketItem : IDeleteMarketItem
    {
        protected AppDataContext _context;
        public DeleteMarketItem(AppDataContext context)
        {
            _context = context;
        }

        public IResult Delete(Guid id)
        {
            var marketItem = _context.MarketItems.FirstOrDefault(a => a.Id == id);
            if (marketItem == null)
                return Results.NotFound();

            var mensagem = $"{marketItem.Nome} excluído com sucesso!";
            _context.MarketItems.Remove(marketItem);
            _context.SaveChanges();

            return Results.Ok(mensagem);
        }
    }
}