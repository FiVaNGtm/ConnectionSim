#line 1 "C:\ApiAccessor.sc"
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Interop;
using ConnectionSim.Logger;
using ConnectionSim.Model.Status;

namespace ConnectionSim.Model.Infrastructure.Api
{
    public class ApiAccessor
    {
        public ObservableCollection<string> ReceiveData { get; set; } = new();
        public ObservableCollection<string> SendData    { get; set; } = new();

        public ApiAccessor()
        {
            Logger.TraceCtorStart();
            WorkingStatus.StatusChanged         += WorkingStatusOnStatusChanged;
            ErrorGeneratingStatus.StatusChanged += ErrorGeneratingStatusOnStatusChanged;
            Logger.TraceCtorEnd();
        }

        /// <summary>
        /// 動作切替ボタンが押下された
        /// </summary>
        /// <param name="status"></param>
        private async void WorkingStatusOnStatusChanged(EWorkingStatus status)
        {
            Logger.TraceStart();

            switch(status)
            {
                case EWorkingStatus.Work: 
                    await StartAsync();
                    break;
                case EWorkingStatus.Stop:
                    Stop();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }

            Logger.TraceEnd();
        }

        /// <summary>
        /// エラー発生状態切替ボタンが押下された
        /// </summary>
        /// <param name="status"></param>
        private void ErrorGeneratingStatusOnStatusChanged(EErrorGenaratingStatus status)
        {
            Logger.TraceStart();

            switch(status)
            {
                case EErrorGenaratingStatus.Work:
                    break;
                case EErrorGenaratingStatus.Stop:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }

            Logger.TraceEnd();
        }

        private async Task StartAsync()
        {
            Logger.TraceStart();
            lock(ConnectionLock)
            {
                HttpListener = new HttpListener();
                HttpListener.Prefixes.Add("http://localhost:8080/");
                HttpListener.Start();
                _ = HttpListener.BeginGetContext(Callback, HttpListener);
            }

            Logger.TraceEnd();
        }

        private async Task Stop()
        {
            Logger.TraceStart();
            lock(ConnectionLock)
            {
                HttpListener.Close();
            }
            Logger.TraceEnd();
        }

        private void Callback(IAsyncResult ar)
        {
            try
            {
                if(ar.IsCompleted) return;
                HttpListenerContext ctx = HttpListener.EndGetContext(ar);
                StreamReader r = new StreamReader(ctx.Request.InputStream);
                StreamWriter w = new StreamWriter(ctx.Response.OutputStream);

                var received = r.ReadToEnd();
                w.Write(received);
                w.Flush();

                w.Close();
                r.Close();

            }
            catch (HttpListenerException e)
            {
                
            }


        }


        private HttpListener          HttpListener   { get; set; }
        private object                ConnectionLock { get; set; } = new();
        private WorkingStatus         WorkingStatus         = WorkingStatus.GetInstance();
        private ErrorGeneratingStatus ErrorGeneratingStatus = ErrorGeneratingStatus.GetInstance();
        private ILogger               Logger                = ConnectionSim.Logger.Logger.GetInstance();
    }
}