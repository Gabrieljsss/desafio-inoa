using System.Text.Json;

namespace PriceMonitor
{
    public class Asset
    {
        private string Symbol { get; set; }
        private decimal Open { get; set; }
        private decimal High { get; set; }
        private decimal Low { get; set; }
        public Price Price { get; set; }
        private long Volume { get; set; }
        private string LatestTradingDay { get; set; }
        private decimal PreviousClose { get; set; }
        private decimal Change { get; set; }
        private string ChangePercent { get; set; }

        public Asset()
        {
            Symbol = string.Empty;
            LatestTradingDay = string.Empty;
            ChangePercent = string.Empty;
        }

        public decimal PriceAsDecimal()
        {
            return Price.Value;
        }

        public static Asset FromHttpResponse(string data)
        {
            var doc = JsonDocument.Parse(data);
            var quote = doc.RootElement.GetProperty("Global Quote");
            return new Asset
            {
                Symbol = quote.GetProperty("01. symbol").GetString() ?? "",
                Open = decimal.TryParse(quote.GetProperty("02. open").GetString(), out var open) ? open : 0,
                High = decimal.TryParse(quote.GetProperty("03. high").GetString(), out var high) ? high : 0,
                Low = decimal.TryParse(quote.GetProperty("04. low").GetString(), out var low) ? low : 0,
                Price = new Price(quote.GetProperty("05. price").GetString() ?? "0"),
                Volume = long.TryParse(quote.GetProperty("06. volume").GetString(), out var volume) ? volume : 0,
                LatestTradingDay = quote.GetProperty("07. latest trading day").GetString() ?? "",
                PreviousClose = decimal.TryParse(quote.GetProperty("08. previous close").GetString(), out var previousClose) ? previousClose : 0,
                Change = decimal.TryParse(quote.GetProperty("09. change").GetString(), out var change) ? change : 0,
                ChangePercent = quote.GetProperty("10. change percent").GetString() ?? ""
            };
        }

    }

}