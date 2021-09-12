#line 1 "C://MainWindow.xaml.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConnectionSim.Logger;
using NLog.Targets.Wrappers;

namespace ConnectionSim.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            logger.Info("アプリケーション終了");
        }

        private void SettingButton_OnClick(object sender, RoutedEventArgs e)
        {
            logger.InfoStart("設定画面表示ボタン押下処理");
            SettingFrame.Visibility = SettingFrame.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            logger.Info($"設定画面表示状態=>{SettingFrame.Visibility}");
            logger.InfoEnd("設定画面表示ボタン押下処理");
        }

        private readonly ILogger logger = Logger.Logger.GetInstance();
    }
}
