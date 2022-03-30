namespace MinimalApi.Domain.Interfaces
{
    public interface IDeleteMarketItem
    {
        public IResult Delete(Guid id);
    }
}