using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPShopManagement.Models;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPShopManagement.Helpers
{
    public class StatusToStringConverter : IValueConverter
    {
        //根据Arduino的状态转换为对应的提示图案
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is M_ArduinoMarkA m_ArduinoMarkA)
            {
                string result = "";
                if (!m_ArduinoMarkA.IsConnect)
                {
                    result = "未连接";
                }
                return result;
            }
            else
            {
                throw new ArgumentException("参数不为Arduino:" + value.ToString());
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
