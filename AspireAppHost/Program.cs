namespace AspireAppHost
{
    internal class Program
    {
        const int OpenTelemetryPort = 4317;

        private static async Task Main(string[] args)
        {
            var builder = DistributedApplication.CreateBuilder(args);

            builder.Configuration["DOTNET_DASHBOARD_OTLP_ENDPOINT_URL"] = $"http://0.0.0.0:{OpenTelemetryPort}";            // supposed to be the gRPC listener
            builder.Configuration["DOTNET_DASHBOARD_OTLP_HTTP_ENDPOINT_URL"] = $"http://0.0.0.0:{OpenTelemetryPort + 1}";   // supposed to be the HTTP listener
            builder.Configuration["ASPIRE_ALLOW_UNSECURED_TRANSPORT"] = true.ToString();

            builder.Configuration["DOTNET_DASHBOARD_UNSECURED_ALLOW_ANONYMOUS"] = true.ToString();  // doesn't work?
            builder.Configuration["AppHost:BrowserToken"] = "";                                     // works!

            builder.Configuration["ASPNETCORE_URLS"] = "http://localhost:15277";

            var app = builder.Build();
            var t = app.RunAsync();

            await Task.Delay(1500);

            Console.WriteLine("*******************************************************************************");
            Console.WriteLine($"{builder.Configuration["ASPNETCORE_URLS"]}/structuredlogs");
            Console.WriteLine("*******************************************************************************");

            await t;
        }
    }
}