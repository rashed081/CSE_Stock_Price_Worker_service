namespace CSEData.Scrapper
{
    public interface IScrapper
    {
        Task<List<Dictionary<string, string>>> GetCurrentPriceAsync();
    }
}