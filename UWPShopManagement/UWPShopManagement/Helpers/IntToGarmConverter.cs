using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWPShopManagement.Helpers
{
    public class IntToGarmConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int)
            {
                string gram = value.ToString() + "g";
                return gram;
            }
            else
            {
                throw new ArgumentException("参数必须int型:" + value.ToString());
            }   
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value.ToString().EndsWith("g"))
            {
                string str = value.ToString();
                string intStr = str.Remove(str.Length - 1);
                bool isSucceed = int.TryParse(intStr, out int result);
                if (isSucceed)
                {
                    return result;
                }
                throw new ArgumentException("转换为int失败:" + intStr);
            }
            throw new ArgumentException("参数不是以g结尾!" + value.ToString());
        }
    }
}
