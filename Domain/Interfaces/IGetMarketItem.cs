namespace MinimalApi.Domain.Interfaces
{
    public interface IGetMarketItem
    {
        public IResult GetAll();
        public IResult GetById(Guid id);
    }
}