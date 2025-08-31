using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thepos
{
    internal class ClsDate
    {
        //현재날짜 (YY)
        public static string GetNow_YY()
        {
            string strDate = string.Format("{0}", DateTime.Now.Year.ToString("#0000").Substring(0, 2));
            return strDate;
        }

        //현재날짜 (YYMMDD)
        public static string GetNow_YYMMDD()
        {
            string strDate = string.Format("{0}{1}{2}",
                DateTime.Now.Year.ToString("#0000").Substring(2, 2),
                DateTime.Now.Month.ToString("#00"),
                DateTime.Now.Day.ToString("#00")
                );
            return strDate;
        }

        //현재날짜 (YYYYMMDD)
        public static string GetNow_YYYYMMDD()
        {
            string strDate = string.Format("{0}{1}{2}",
                DateTime.Now.Year.ToString("#0000"),
                DateTime.Now.Month.ToString("#00"),
                DateTime.Now.Day.ToString("#00"));
            return strDate;
        }

        //현재날짜 (YYMMDDHH)
        public static string GetNow_YYMMDDHH()
        {
            string strDate = string.Format("{0}{1}{2}{3}",
                DateTime.Now.Year.ToString("#0000").Substring(2, 2),
                DateTime.Now.Month.ToString("#00"),
                DateTime.Now.Day.ToString("#00"),
                DateTime.Now.Hour.ToString("#00")
                );
            return strDate;
        }

        //현재날짜 (YYYYMMDDHHMMSS)
        public static string GetNow_YYYYMMDDHHMMSS()
        {
            string strDate = string.Format("{0}{1}{2}{3}{4}{5}",
                DateTime.Now.Year.ToString("#0000"),
                DateTime.Now.Month.ToString("#00"),
                DateTime.Now.Day.ToString("#00"),
                DateTime.Now.Hour.ToString("#00"),
                DateTime.Now.Minute.ToString("#00"),
                DateTime.Now.Second.ToString("#00"));
            return strDate;
        }

        //현재날짜 (YYMMDDHHMMSS)
        public static string GetNow_YYMMDDHHMMSS()
        {
            string strDate = string.Format("{0}{1}{2}{3}{4}{5}",
                DateTime.Now.Year.ToString("#0000").Substring(2, 2),
                DateTime.Now.Month.ToString("#00"),
                DateTime.Now.Day.ToString("#00"),
                DateTime.Now.Hour.ToString("#00"),
                DateTime.Now.Minute.ToString("#00"),
                DateTime.Now.Second.ToString("#00"));
            return strDate;
        }

        //현재날짜 (YYYYMMDDHHMM)
        public static string GetNow_YYYYMMDDHHMM()
        {
            string strDate = string.Format("{0}{1}{2}{3}{4}",
                DateTime.Now.Year.ToString("#0000"),
                DateTime.Now.Month.ToString("#00"),
                DateTime.Now.Day.ToString("#00"),
                DateTime.Now.Hour.ToString("#00"),
                DateTime.Now.Minute.ToString("#00"));
            return strDate;
        }

        //현재시간 (HH:MM:ss.hhh)
        public static string GetNow_HHMMsshh()
        {
            string strDate = string.Format("{0}:{1}:{2}.{3}",
                DateTime.Now.Hour.ToString("#00"),
                DateTime.Now.Minute.ToString("#00"),
                DateTime.Now.Second.ToString("#00"),
                DateTime.Now.Millisecond.ToString("#000"));
            return strDate;
        }
    }
}
