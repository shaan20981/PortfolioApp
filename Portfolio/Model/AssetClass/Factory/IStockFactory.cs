namespace Portfolio.Model.AssetClass
{
    public interface IStockFactory
    {
        Stock CreateStock(AssetType assetType, decimal price, int quantity, int occurences);
    }
}