using OpenTelemetry.Logs;

namespace OtelLogNoiseMaker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddHostedService<Worker>();
            builder.Logging.AddOpenTelemetry(options => 
                options.AddOtlpExporter()
            );
            var host = builder.Build();

            host.Run();
        }
    }
}