using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thepos
{
    internal class ClsConfig
    {
        public static bool m_bTransData = false;
        public static string m_sDemoVer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string m_sVCATSupportVer = "1.0.1.3";
    }
}
