using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedrink_UWP.Model
{
    public class CommHandle
    {
        public static CommCode StringConvertToEnum(string str)
        {
            CommCode commCode = CommCode.ERROR;
            switch (str)
            {
                case "#TCPCONN":
                    commCode = CommCode.TCPCONN;
                    break;
                default:
                    commCode = CommCode.ERROR;
                    break;
            }
            return commCode;
        }

        
    }
    public enum CommCode
    {
        TCPCONN,
        AS,
        ERROR
    }

}
