using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWPShopManagement.Helpers
{
    public class ModeToStringConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string result = "";
            if (value is int mode)
            {
                if (mode ==10)
                {
                    result = "建立连接";
                }else if (mode == 11)
                {
                    result = "连接中...";
                }
                else
                {
                    result = "断开链接";
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
