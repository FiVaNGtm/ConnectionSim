using System;
using System.Runtime.CompilerServices;

namespace ConnectionSim.Logger
{
    public interface ILogger
    {
        void Trace(string str = "", [CallerFilePath] string filepath = "", [CallerMemberName] string methodName = "");

        void TraceStart(string                    str        = "", [CallerFilePath] string filepath = "",
                        [CallerMemberName] string methodName = "");

        void TraceEnd(string                    str        = "", [CallerFilePath] string filepath = "",
                      [CallerMemberName] string methodName = "");

        void TraceCtorStart(string str = "", [CallerFilePath] string filepath = "");

        void TraceCtorEnd(string str = "", [CallerFilePath] string filepath = "");

        void Debug(string str = "", [CallerFilePath] string filepath = "", [CallerMemberName] string methodName = "");

        void DebugStart(string                    str        = "", [CallerFilePath] string filepath = "",
                        [CallerMemberName] string methodName = "");

        void DebugEnd(string                    str        = "", [CallerFilePath] string filepath = "",
                      [CallerMemberName] string methodName = "");

        void Info(string str = "", [CallerFilePath] string filepath = "", [CallerMemberName] string methodName = "");

        void InfoStart(string                    str        = "", [CallerFilePath] string filepath = "",
                       [CallerMemberName] string methodName = "");

        void InfoEnd(string str = "", [CallerFilePath] string filepath = "", [CallerMemberName] string methodName = "");

        void Warn(string    str = "", [CallerFilePath] string filepath = "", [CallerMemberName] string methodName = "");

        void WarnStart(string                    str        = "", [CallerFilePath] string filepath = "",
                       [CallerMemberName] string methodName = "");

        void WarnEnd(string str = "", [CallerFilePath] string filepath = "", [CallerMemberName] string methodName = "");

        void ErrorLog(string                    str        = "", [CallerFilePath] string filepath = "",
                      [CallerMemberName] string methodName = "");

        void ErrorStart(string                    str        = "", [CallerFilePath] string filepath = "",
                        [CallerMemberName] string methodName = "");

        void ErrorEnd(string                    str        = "", [CallerFilePath] string filepath = "",
                      [CallerMemberName] string methodName = "");

        void Exception(Exception                 e, string str = "", [CallerFilePath] string filepath = "",
                       [CallerMemberName] string methodName = "");

        void Fatal(string str, [CallerFilePath] string filepath = "", [CallerMemberName] string methodName = "");
    }
}