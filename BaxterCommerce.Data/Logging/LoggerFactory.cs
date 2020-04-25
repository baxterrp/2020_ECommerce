using Serilog;

namespace BaxterCommerce.Data.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static class LoggerFactory
    {
        public static ILogger CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .CreateLogger();

            return Log.Logger;
        }
    }
}
