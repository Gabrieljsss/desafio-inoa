public class Program
{
    public static async Task Main(string[] args)
    {
        DotNetEnv.Env.Load();
        FinanceDataService financeService = new FinanceDataService();
        MailService mailService = new MailService();

        if (args.Length < 3)
        {
            Console.WriteLine("Please provide the asset name, upper limit, and lower limit as arguments.");
            return;
        }

        string asset = args[0];
        Price upperLimit = new Price(args[1]);
        Price lowerLimit = new Price(args[2]);

        while (true)
        {
            Asset assetData = await financeService.GetAssetData(asset);
            if (assetData.Price.LessOrEquals(lowerLimit))
            {
                mailService.SendEmail("buy", asset, assetData.Price.Value);
            }
            if (assetData.Price.GreaterOrEquals(upperLimit))
            {
                mailService.SendEmail("sell", asset, assetData.Price.Value);
            }
            Console.WriteLine($"Monitoring asset: {asset}. Current price: {assetData.Price.Value}.");
            await Task.Delay(TimeSpan.FromMinutes(5));
        }
    }
}
