using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thepos
{
    internal class ClsLog
    {
        private static TextBox m_txtLog = null;

        public static void Init(TextBox param_textbox)
        {
            // Texbox Null이 아니면 텍스트박스에 로깅 함.
            if (param_textbox != null)
            {
                m_txtLog = param_textbox;
            }
        }

        public static void PrintLog(string param_msg, bool param_time = false)
        {

        }

        public static void PrintLog(string param_key, string param_value)
        {


        }

        public static void PrintLog(string param_key, string param_value, string param_length)
        {

        }
    }
}
