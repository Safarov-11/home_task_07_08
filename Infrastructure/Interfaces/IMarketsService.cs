using Domain.Entities;
using Domain.Entities.DTOs;

namespace Infrastructure.Interfaces;

public interface IMarketsService
{
    void AddMarket(Markets market);
    List<Markets> GetAllMarkets();
    void UpdateMarkets(Markets market);
    void DeleteMarket(int id);
    void AddDateTimeToMarket();
     void CreateNewColumnforUserId();
    void AddUserToMarket(int marketId, int UserId);
    SmallestPriceMarket MarketWithSmallesPrices();
    List<Markets> GetNewMarkets();
}
