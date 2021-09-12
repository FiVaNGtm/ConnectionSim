#line 1 "C://WorkingStatus.cs"
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ConnectionSim.Annotations;
using ConnectionSim.Logger;

namespace ConnectionSim.Model.Status
{
    /// <summary>
    /// 動作状態クラス
    /// </summary>
    internal sealed class WorkingStatus : IStatus<EWorkingStatus>, INotifyPropertyChanged
    {
        /// <summary>
        /// 動作状態
        /// </summary>
        public EWorkingStatus Status
        {
            get => status;
            set
            {
                status = value;
                StatusChanged?.Invoke(status);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 動作状態切替発生時処理
        /// </summary>
        /// <param name="workingStatus">切替前状態</param>
        public void StatusChange(EWorkingStatus workingStatus)
        {
            logger.TraceCtorStart(nameof(StatusChange));
            Status = workingStatus == EWorkingStatus.Work ? EWorkingStatus.Stop : EWorkingStatus.Work;
            logger.Info($"Status=>{Status}");
            logger.TraceCtorEnd(nameof(StatusChange));
        }

        private WorkingStatus()
        {
            logger = Logger.Logger.GetInstance();
            logger.TraceCtorStart(nameof(WorkingStatus));
            Status = EWorkingStatus.Stop;
            logger.TraceCtorEnd(nameof(WorkingStatus));
        }

        public event IStatus<EWorkingStatus>.StatusChangedEventHandler StatusChanged;

        internal static WorkingStatus GetInstance() => Instance;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static readonly WorkingStatus  Instance = new();
        private                 EWorkingStatus status;
        private readonly        ILogger        logger;
    }
}