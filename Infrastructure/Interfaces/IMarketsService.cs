using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IMarketsService
{
    void AddMarket(Markets market);
    List<Markets> GetAllMarkets();
    void UpdateMarkets(Markets market);
    void DeleteMarket(int id);
    void AddDateTimeToMarket();
}
