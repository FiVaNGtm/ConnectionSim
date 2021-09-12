using System;
using System.Runtime.CompilerServices;
using NLog;

namespace ConnectionSim.Logger.LogImp
{
    public class LoggerImplement : ILogger
    {
        public void Trace(string                    str        = "", [CallerFilePath] string filepath = "",
                          [CallerMemberName] string methodName = "") =>
                Logger.Log(LogLevel.Trace, filepath + " " + methodName + "関数 " + str);

        public void TraceStart(string                    str        = "", [CallerFilePath] string filepath = "",
                               [CallerMemberName] string methodName = "") =>
                Trace(str + StartStr, filepath, methodName);

        public void TraceEnd(string                    str        = "", [CallerFilePath] string filepath = "",
                             [CallerMemberName] string methodName = "") => Trace(str + EndStr, filepath, methodName);

        public void TraceCtorStart(string str = "", [CallerFilePath] string filepath = "") =>
                Logger.Log(LogLevel.Trace, filepath + " " + str + Ctor + StartStr);

        public void TraceCtorEnd(string str = "", [CallerFilePath] string filepath = "") =>
                Logger.Log(LogLevel.Trace, filepath + " " + str + Ctor + EndStr);

        public void Debug(string                    str        = "", [CallerFilePath] string filepath = "",
                          [CallerMemberName] string methodName = "") =>
                Logger.Log(LogLevel.Debug, filepath + " " + methodName + "関数 " + str);

        public void DebugStart(string                    str        = "", [CallerFilePath] string filepath = "",
                               [CallerMemberName] string methodName = "") =>
                Debug(str + StartStr, filepath, methodName);

        public void DebugEnd(string                    str        = "", [CallerFilePath] string filepath = "",
                             [CallerMemberName] string methodName = "") => Debug(str + EndStr, filepath, methodName);

        public void Info(string                    str        = "", [CallerFilePath] string filepath = "",
                         [CallerMemberName] string methodName = "") =>
                Logger.Log(LogLevel.Info, filepath + " " + methodName + "関数 " + str);

        public void InfoStart(string                    str        = "", [CallerFilePath] string filepath = "",
                              [CallerMemberName] string methodName = "") => Info(str + StartStr, filepath, methodName);

        public void InfoEnd(string                    str        = "", [CallerFilePath] string filepath = "",
                            [CallerMemberName] string methodName = "") => Info(str + EndStr, filepath, methodName);

        public void Warn(string                    str        = "", [CallerFilePath] string filepath = "",
                         [CallerMemberName] string methodName = "") =>
                Logger.Log(LogLevel.Warn, filepath + " " + methodName + "関数 " + str);

        public void WarnStart(string                    str        = "", [CallerFilePath] string filepath = "",
                              [CallerMemberName] string methodName = "") => Warn(str + StartStr, filepath, methodName);

        public void WarnEnd(string                    str        = "", [CallerFilePath] string filepath = "",
                            [CallerMemberName] string methodName = "") => Warn(str + EndStr, filepath, methodName);

        public void ErrorLog(string                    str        = "", [CallerFilePath] string filepath = "",
                             [CallerMemberName] string methodName = "") =>
                Logger.Log(LogLevel.Error, filepath + " " + methodName + "関数 " + str);

        public void ErrorStart(string                    str        = "", [CallerFilePath] string filepath = "",
                               [CallerMemberName] string methodName = "") =>
                ErrorLog(str + StartStr, filepath, methodName);

        public void ErrorEnd(string                    str        = "", [CallerFilePath] string filepath = "",
                             [CallerMemberName] string methodName = "") => ErrorLog(str + EndStr, filepath, methodName);

        public void Exception(Exception                 e, [CallerFilePath] string filepath = "", string str = "",
                              [CallerMemberName] string methodName = "") =>
                Logger.Error(e, filepath + " " + methodName + "関数 " + str);

        public void Fatal(string                    str        = "", [CallerFilePath] string filepath = "",
                          [CallerMemberName] string methodName = "") =>
                Logger.Log(LogLevel.Fatal, filepath + " " + methodName + "関数 " + str);


        public static LoggerImplement GetInstance() => Instance;

        private static readonly NLog.Logger     Logger   = LogManager.GetCurrentClassLogger();
        private static readonly LoggerImplement Instance = new();
        private LoggerImplement() { }
        private static readonly string StartStr = "開始";
        private static readonly string EndStr   = "終了";
        private static readonly string Ctor     = " コンストラクター";
    }
}