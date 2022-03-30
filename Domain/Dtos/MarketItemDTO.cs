using Flunt.Notifications;
using Flunt.Validations;

namespace MinimalApi.Domain.Dtos
{
    public class MarketItemDTO : Notifiable<Notification>
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public MarketItem MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Informe o nome do item de mercado")
                .IsGreaterThan(Quantidade, 0, "Informe uma quantidade maior que 0"));

            return new MarketItem(Guid.NewGuid(), Nome, Quantidade);
        }
    }
}