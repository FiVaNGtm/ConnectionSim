using ConnectionSim.Logger.LogImp;

namespace ConnectionSim.Logger
{
    internal static class Logger
    {
        internal static ILogger GetInstance() => LoggerImplement.GetInstance();
    }
}