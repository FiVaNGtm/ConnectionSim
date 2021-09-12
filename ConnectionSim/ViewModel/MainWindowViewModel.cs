#line 1 "C://MainWindowViewModel.cs"

using System.Windows;
using System.Windows.Controls;
using ConnectionSim.Annotations;
using ConnectionSim.Logger;
using ConnectionSim.Model.Setting;
using ConnectionSim.Model.Status;
using ConnectionSim.ViewModel.Command;

namespace ConnectionSim.ViewModel
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// 動作切替ボタン押下コマンド
        /// </summary>
        public DelegateCommand<object?> WorkingButtonCommand { get; set; }

        /// <summary>
        /// エラー発生切替ボタン押下コマンド
        /// </summary>
        public DelegateCommand<object?> ErrorGenerateButtonCommand { get; set; }

        /// <summary>
        /// 動作状態
        /// </summary>
        public IStatus<EWorkingStatus> WorkingStatus { get; set; }

        /// <summary>
        /// エラー発生状態
        /// </summary>
        public IStatus<EErrorGenaratingStatus> ErrorGeneratingStatus { get; set; }

        public MainWindowViewModel()
        {
            logger = Logger.Logger.GetInstance();
            logger.TraceCtorStart(nameof(MainWindowViewModel));
            WorkingButtonCommand       = new DelegateCommand<object?>(ChangeWorkingStatus);
            ErrorGenerateButtonCommand = new DelegateCommand<object?>(ChangeErrorGenerateStatus);
            WorkingStatus              = Model.Status.WorkingStatus.GetInstance();
            ErrorGeneratingStatus      = Model.Status.ErrorGeneratingStatus.GetInstance();

            // TODO: 設定ファイル未完成
            //var setting = new SettingFileController();

            logger.Info("アプリケーション起動完了");
            logger.TraceCtorEnd(nameof(MainWindowViewModel));
        }

        ~MainWindowViewModel()
        {
            logger.Info("アプリケーション終了完了");
        }

        /// <summary>
        /// 動作切替ボタン押下時の処理
        /// </summary>
        /// <param name="obj"></param>
        private void ChangeWorkingStatus([CanBeNull] object obj)
        {
            logger.TraceStart();
            logger.InfoStart("動作切替ボタン押下処理");
            if(obj != null)
            {
                var status = (EWorkingStatus)obj;
                logger.Debug($"引数:{status}");

                // 動作切替
                WorkingStatus.StatusChange(status);
            }


            logger.InfoEnd("動作切替ボタン押下処理");
            logger.TraceEnd();
        }

        /// <summary>
        /// エラー発生状切替ボタン押下時の処理
        /// </summary>
        /// <param name="obj"></param>
        private void ChangeErrorGenerateStatus([CanBeNull] object obj)
        {
            logger.TraceStart();
            logger.InfoStart("エラー切替ボタン押下処理");
            if(obj != null)
            {
                var status = (EErrorGenaratingStatus)obj;
                logger.Debug($"引数:{status}");

                // エラー状態切替
                ErrorGeneratingStatus.StatusChange(status);
            }

            logger.InfoEnd("エラー切替ボタン押下処理");
            logger.TraceEnd();
        }

        private readonly ILogger logger;
    }
}