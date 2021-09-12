#line 1 "C://ErrorGenerationStatus.cs"
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ConnectionSim.Annotations;
using ConnectionSim.Logger;

namespace ConnectionSim.Model.Status
{
    /// <summary>
    /// エラー発生状態クラス
    /// </summary>
    internal sealed class ErrorGeneratingStatus : IStatus<EErrorGenaratingStatus>, INotifyPropertyChanged
    {
        public EErrorGenaratingStatus Status
        {
            get => status;
            set
            {
                status = value;
                StatusChanged?.Invoke(status);
                OnPropertyChanged();
            }
        }

        public void StatusChange(EErrorGenaratingStatus errorStatus)
        {
            logger.TraceStart();
            Status = errorStatus == EErrorGenaratingStatus.Work ? EErrorGenaratingStatus.Stop : EErrorGenaratingStatus.Work;
            logger.Info($"Status=>{Status}");
            logger.TraceEnd();
        }

        private ErrorGeneratingStatus()
        {
            logger = ConnectionSim.Logger.Logger.GetInstance();
            logger.TraceCtorStart(nameof(ErrorGeneratingStatus));
            Status = EErrorGenaratingStatus.Stop;
            logger.TraceCtorEnd(nameof(ErrorGeneratingStatus));
        }

        internal static ErrorGeneratingStatus GetInstance() => Instance;

        public event IStatus<EErrorGenaratingStatus>.StatusChangedEventHandler StatusChanged;
        public event PropertyChangedEventHandler                               PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static readonly ErrorGeneratingStatus  Instance = new();
        private                 EErrorGenaratingStatus status;
        private readonly        ILogger                logger;
    }
}