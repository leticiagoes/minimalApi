namespace MinimalApi.Domain.Interfaces
{
    public interface ISaveMarketItem
    {
        public IResult Save(MarketItemDTO dto);
    }
}