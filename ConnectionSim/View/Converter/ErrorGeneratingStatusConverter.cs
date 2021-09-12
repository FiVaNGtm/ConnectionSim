#line 1 "C://ErrorGeneratingStatusConverter.cs"
using System;
using System.Globalization;
using System.Windows.Data;
using ConnectionSim.Logger;
using ConnectionSim.Model.Status;

namespace ConnectionSim.View.Converter
{
    /// <summary>
    /// エラー発生状態↔boolコンバーター
    /// </summary>
    [ValueConversion(typeof(Enum),typeof(bool))]
    public class ErrorGeneratingStatusConverter : IValueConverter
    {
        public ErrorGeneratingStatusConverter()
        {
            logger = ConnectionSim.Logger.Logger.GetInstance();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var status = (EErrorGenaratingStatus)value;
                return status == EErrorGenaratingStatus.Work;
            }
            catch
            {
                logger.Fatal("エラー発生状態コンバート失敗To");
                throw new NotSupportedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var status = (bool)value;
                return status ? EErrorGenaratingStatus.Work : EErrorGenaratingStatus.Stop;
            }
            catch
            {
                logger.Fatal("エラー発生状態コンバート失敗Back");
                throw new NotSupportedException();
            }
        }

        private readonly ILogger logger;
    }
}