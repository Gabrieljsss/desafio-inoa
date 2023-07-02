public class FinanceDataService
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<Asset> GetAssetData(string asset)
    {
        string apiKey= Environment.GetEnvironmentVariable("API_KEY")
                            ?? throw new ArgumentNullException("API_KEY environment variable is not set");
        string url = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={asset}&apikey=${apiKey}";
        HttpResponseMessage response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            return Asset.FromHttpResponse(responseBody);
        }
        throw new Exception($"Error: {response.StatusCode}");
    }
}

