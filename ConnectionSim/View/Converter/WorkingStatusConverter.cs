#line 1 "C://WorkingStatusConverter.cs"
using System;
using System.Globalization;
using System.Windows.Data;
using ConnectionSim.Logger;
using ConnectionSim.Model.Status;

namespace ConnectionSim.View.Converter
{
    /// <summary>
    /// 動作状態↔boolコンバーター
    /// </summary>
    [ValueConversion(typeof(Enum),typeof(bool))]
    public class WorkingStatusConverter: IValueConverter
    {
        public WorkingStatusConverter()
        {
            logger = ConnectionSim.Logger.Logger.GetInstance();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var status = (EWorkingStatus)value;
                return status == EWorkingStatus.Work;
            }
            catch
            {
                throw new NotSupportedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var status = (bool)value;
                return status ? EWorkingStatus.Work : EWorkingStatus.Stop;
            }
            catch
            {
                throw new NotSupportedException();
            }
        }

        private readonly ILogger logger;
    }
}