using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thepos2
{
    public static class ClsString
    {
        public static string FS = "\x1c";
        public static string SI = "\x0f";
        public static string STX = "\x02";
        public static string ETX = "\x03";

        public enum Align
        {
            left,
            right
        }

        #region " 체크 함수 "

        public static bool CheckNumber(string letter)
        {
            bool IsCheck = true;

            Regex numRegex = new Regex(@"[0-9]");
            bool ismatch = numRegex.IsMatch(letter);

            if (!ismatch)
            {
                IsCheck = false;
            }

            return IsCheck;
        }

        #endregion

        #region " Null 처리 "

        /// <summary>
        /// 문자열 Null 함수
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Nvl(object obj)
        {
            try
            {
                string str = obj.ToString().Trim().Trim('\0');

                if (string.IsNullOrEmpty(str) || Convert.IsDBNull(str))
                {
                    return string.Empty;
                }
                return str;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string Nvl(object obj, string defaultValue)
        {
            try
            {
                string str = obj.ToString().Trim().Trim('\0');

                if (string.IsNullOrEmpty(str) || Convert.IsDBNull(str))
                {
                    return defaultValue;
                }
                return str;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Integer형 Null 처리 함수
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Int32 NvlToInt32(object obj)
        {
            try
            {
                int valueTemp;
                var result = Int32.TryParse(obj.ToString(), out valueTemp);

                if (result & !(obj == DBNull.Value))
                {
                    return valueTemp;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Int32 NvlToInt32(object obj, Int32 defaultValue)
        {
            try
            {
                int valueTemp;
                var result = Int32.TryParse(obj.ToString(), out valueTemp);

                if (result & !(obj == DBNull.Value))
                {
                    return valueTemp;
                }
                return defaultValue;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Long형 Null 처리 함수
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Int64 NvlToInt64(object obj)
        {
            try
            {
                long valueTemp;
                var result = Int64.TryParse(obj.ToString(), out valueTemp);

                if (result & !(obj == DBNull.Value))
                {
                    return valueTemp;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Int64 NvlToInt64(object obj, Int64 defaultValue)
        {
            try
            {
                long valueTemp;
                var result = Int64.TryParse(obj.ToString(), out valueTemp);

                if (result & !(obj == DBNull.Value))
                {
                    return valueTemp;
                }
                return defaultValue;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Boolean형 Null 처리함수
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool NvlToBool(object obj)
        {
            try
            {
                bool valueTemp;
                var result = bool.TryParse(Nvl(obj), out valueTemp);

                if (obj == DBNull.Value)
                {
                    return false;
                }

                if (!result)
                {
                    return Nvl(obj).ToUpper().Equals("Y");
                }
                return valueTemp;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Boolean형 Null 처리함수
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool NvlToBool(object obj, bool defaultValue)
        {
            try
            {
                bool valueTemp;
                var result = bool.TryParse(Nvl(obj), out valueTemp);

                if (obj == DBNull.Value || Nvl(obj).Equals(""))
                {
                    return defaultValue;
                }

                if (!result)
                {
                    return Nvl(obj).Equals("1") || Nvl(obj).ToUpper().Equals("Y");
                }
                return valueTemp;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string ToYN(bool bYN)
        {
            try
            {
                if (bYN)
                    return "Y";
                else
                    return "N";
            }
            catch (Exception)
            {
                return "N";
            }
        }

        /// <summary>
        /// Decimal형 Null 처리 함수 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal NvlToDec(object obj)
        {
            try
            {
                decimal valueTemp;
                var result = decimal.TryParse(ParseMoney(obj.ToString(), false), out valueTemp);

                if (result & !(obj == DBNull.Value))
                {
                    return valueTemp;
                }
                return 0m;
            }
            catch (Exception)
            {
                return 0m;
            }
        }

        /// <summary> 
        /// 통화형 문자열에서 구분자/소수점을 제거 
        /// </summary> 
        /// <param name="money">예) 10,000.00</param> 
        /// <param name="trimPoint">소수점 제거 여부</param>
        /// <returns>10000.00</returns> 
        /// <remarks></remarks> 
        public static string ParseMoney(string money, bool trimPoint)
        {
            try
            {
                var moneyTemp = money.Replace(",", "");
                if (trimPoint)
                {
                    if (moneyTemp.IndexOf(".") > -1)
                    {
                        moneyTemp = moneyTemp.Substring(0, moneyTemp.IndexOf("."));
                    }
                }
                return moneyTemp;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary> 
        /// 숫자를 통화형으로 반환 
        /// </summary> 
        /// <param name="money">예) 10000</param> 
        /// <returns>10,000</returns> 
        /// <remarks></remarks> 
        public static string MaskMoney(long money)
        {
            try
            {
                return NvlToDec(money).ToString("#,0");
            }
            catch (Exception)
            {
                return "0";
            }
        }

        #endregion

        #region " Enum 처리 "

        /// <summary>
        /// enum description 정보를 반환
        /// </summary>
        /// <param name="value">enum</param>
        /// <returns></returns>
        public static string EnumToDesc(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] descriptions = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (descriptions != null && descriptions.Length > 0) ? descriptions[0].Description : fi.Name;
        }

        /// <summary>
        /// enum을 int형으로 반환
        /// </summary>
        /// <param name="value">enum</param>
        /// <returns></returns>
        public static int EnumToInt(Enum value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// enum description 정보를 반환
        /// </summary>
        /// <param name="value">enum</param>
        /// <returns></returns>
        public static string ToEDesc(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] descriptions = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (descriptions != null && descriptions.Length > 0) ? descriptions[0].Description : fi.Name;
        }

        /// <summary>
        /// enum을 int형으로 반환
        /// </summary>
        /// <param name="value">enum</param>
        /// <returns></returns>
        public static int ToEInt(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static T GetValueFromDescription<T>(string desc, T defaultValue)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == desc)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == desc)
                        return (T)field.GetValue(null);
                }
            }

            //return (T)type.GetField(defaultValue).GetValue(null);
            return defaultValue;
        }

        public static T GetValueFromDescription<T>(int nNum, T defaultValue)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if ((int)field.GetValue(null) == nNum)
                        return (T)field.GetValue(null);
                }
            }

            //return (T)type.GetField(defaultValue).GetValue(null);
            return defaultValue;
        }

        #endregion

        #region " 문자열 처리 " 

        // 6번째 자리부터 "0" 으로 치환
        public static string CardNo6to0(string param_s_cardno)
        {
            string strRet = string.Empty;

            if (param_s_cardno.Length >= 6)
            {
                strRet += param_s_cardno.Substring(0, 6);
                strRet += "000000";

                if (param_s_cardno.Length > 12)
                    strRet += param_s_cardno.Substring(12);
            }

            return strRet;
        }


        ///// <summary>
        ///// 문자를 바이트 단위로 특정위치에서 잘라낸다
        ///// </summary>        
        public static string SubStringB(string str, int nStart, int nLen, bool trim = false)
        {
            try
            {
                if (str != null && str != string.Empty)
                {
                    Encoding euckr = Encoding.GetEncoding(51949);

                    byte[] abyBuf = euckr.GetBytes(str);
                    int nBuf = abyBuf.Length;

                    if (nStart < nBuf)
                    {
                        int nCopyStart = 0;
                        int nCopyLen = 0;

                        // 시작 위치를 결정한다.
                        if (nStart >= 1)
                        {
                            while (true)
                            {
                                if (abyBuf[nCopyStart] >= 0x80)
                                {
                                    nCopyStart++;
                                }

                                nCopyStart++;

                                if (nCopyStart >= nStart)
                                {
                                    if (nCopyStart > nStart)
                                    {
                                        nLen--;
                                    }

                                    break;
                                }
                            }
                        }

                        // 길이를 결정한다.
                        int nI = 0;

                        //데이타보다 길이가 크면...
                        if (nLen > nBuf - nStart)
                            nLen = nBuf - nStart;

                        while (nI < nLen)
                        {
                            if (abyBuf[nCopyStart + nI] >= 0x80)
                            {
                                nI++;
                            }

                            nI++;
                        }

                        nCopyLen = (nI <= nLen) ? nI : nI - 2;

                        if (nCopyLen >= 1)
                        {
                            if (trim)
                                return euckr.GetString(abyBuf, nCopyStart, nCopyLen).Trim();
                            else
                                return euckr.GetString(abyBuf, nCopyStart, nCopyLen);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// 문자열을 입력받아서 아스키코드로 변환
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static int Asc(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Argument Length Zero");
            }
            var ch = str[0];
            return Asc(ch);
        }

        /// <summary>
        /// 문자를 아스키코드로 변환
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static int Asc(char chr)
        {
            int num;
            var num2 = Convert.ToInt32(chr);

            if (num2 < 0x80)
            {
                return num2;
            }

            try
            {
                byte[] buffer;
                var fileIOEncoding = Encoding.Default;
                var chars = new[] { chr };
                if (fileIOEncoding.IsSingleByte)
                {
                    buffer = new byte[1];
                    fileIOEncoding.GetBytes(chars, 0, 1, buffer, 0);
                    return buffer[0];
                }
                buffer = new byte[2];
                if (fileIOEncoding.GetBytes(chars, 0, 1, buffer, 0) == 1)
                {
                    return buffer[0];
                }
                if (BitConverter.IsLittleEndian)
                {
                    var num4 = buffer[0];
                    buffer[0] = buffer[1];
                    buffer[1] = num4;
                }
                num = BitConverter.ToInt16(buffer, 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return num;
        }


        public static object ByteToStructure(byte[] data, Type type)
        {
            IntPtr buff = Marshal.AllocHGlobal(data.Length);    // 배열의 크기만큼 비관리 메모리 영역에 메모리를 할당한다.
            Marshal.Copy(data, 0, buff, data.Length);           // 배열에 저장된 데이터를 위에서 할당한 메모리 영역에 복사한다.
            object obj = Marshal.PtrToStructure(buff, type);    // 복사된 데이터를 구조체 객체로 변환한다.
            Marshal.FreeHGlobal(buff);                          // 비관리 메모리 영역에 할당했던 메모리를 해제함

            //if (Marshal.SizeOf(obj) != data.Length)// (((PACKET_DATA)obj).TotalBytes != data.Length) // 구조체와 원래의 데이터의 크기 비교
            //{
            //    return null; // 크기가 다르면 null 리턴
            //}

            Array.Clear(data, 0, data.Length);

            return obj; // 구조체 리턴
        }

        public static byte[] StructureToByte(object obj)
        {
            int datasize = Marshal.SizeOf(obj);                 // 구조체에 할당된 메모리의 크기를 구한다.
            IntPtr buff = Marshal.AllocHGlobal(datasize);       // 비관리 메모리 영역에 구조체 크기만큼의 메모리를 할당한다.
            Marshal.StructureToPtr(obj, buff, false);           // 할당된 구조체 객체의 주소를 구한다.
            byte[] data = new byte[datasize];                   // 구조체가 복사될 배열
            Marshal.Copy(buff, data, 0, datasize);              // 구조체 객체를 배열에 복사
            Marshal.FreeHGlobal(buff);                          // 비관리 메모리 영역에 할당했던 메모리를 해제함

            return data; // 배열을 리턴
        }

        public static string ToString(byte[] data)
        {
            //byte[] sTemp = new byte[data.Length];
            //Array.Copy(data, sTemp, sTemp.Length);
            //Array.Clear(data, 0, data.Length);

            return Encoding.Default.GetString(data).TrimEnd('\0');
        }

        public static byte[] ToByte(string data)
        {
            //string sTemp = data;

            //string[] blank = new string[] { ClsString.RndString(), "**********", "" };
            //for (int nIndex = 0; nIndex < blank.Length; nIndex++)
            //{
            //    data = blank[nIndex];
            //}

            return Encoding.Default.GetBytes(data);
        }

        public static byte[] ToByte(char[] data)
        {
            //char[] sTemp = new char[data.Length];
            //Array.Copy(data, sTemp, sTemp.Length);
            //Array.Clear(data, 0, data.Length);

            return Encoding.Default.GetBytes(data);
        }

        /// <summary>
        /// Byte 수만큼 좌측으로 문자를 채움
        /// </summary>
        public static string BytePadLeft(string str, int len, char paddingChar)
        {
            if (String.IsNullOrEmpty(str))
                return string.Empty;

            return "".PadLeft(len - GetByteSize(str), paddingChar) + str;
        }

        /// <summary>
        /// Byte 수만큼 우측으로 문자를 채움
        /// </summary>        
        public static string BytePadRight(string str, int len, char paddingChar)
        {
            if (String.IsNullOrEmpty(str))
                return string.Empty;

            return str + "".PadRight(len - GetByteSize(str), paddingChar);
        }

        // <summary>
        /// 마스킹 처리
        /// </summary>
        public static string GetMaskData(string str, int nPreLen)
        {
            string strRet = string.Empty;

            int nLen = GetByteSize(str);

            if (nLen > nPreLen)
            {
                strRet = str.Substring(0, nPreLen).PadRight(nLen, '*');
            }
            else
            {
                strRet = str;
            }

            return strRet;
        }

        /// <summary>
        /// Byte 수만큼 마스킹 처리
        /// </summary>        
        public static string MaskStyle(string str, int strLen, string strStyle, HorizontalAlignment position)
        {
            int n = 0;

            if (strLen <= 0) return "";

            for (var i = 1; i <= str.Length; i++)
            {
                if (Asc(SubStringB(str, i, 1)) < 0)
                    n += 2;
                else
                    n += 1;
            }

            n = strLen - n;

            if (n < 0)
            {
                return SubStringB(str, 1, strLen);
            }

            switch (position)
            {
                case HorizontalAlignment.Left:
                    return str + StrDup(n, strStyle);
                case HorizontalAlignment.Right:
                    return StrDup(n, strStyle) + str;
                default:
                    n = Convert.ToInt32(Math.Floor(n / (double)2));
                    return BytePadRight((StrDup(n, strStyle) + str), strLen, strStyle[0]);
            }
        }

        private static string StrDup(int number, string character)
        {
            if (number < 0)
            {
                throw new ArgumentException("Argument Number Zero");
            }
            if (string.IsNullOrEmpty(character))
            {
                throw new ArgumentException("Argument Character Length Zero");
            }
            return new string(character[0], number);
        }

        #endregion

        #region " 마스킹 카드번호 "

        public static string MaskZeroPadding(string sData, Align aAlign, int nLen)
        {
            string rtn = "";

            int len = GetByteSize(sData);
            string tmp = new string("0"[0], nLen - len);

            if (aAlign == Align.left)
            {
                rtn = sData + tmp;
            }
            else if (aAlign == Align.right)
            {
                rtn = tmp + sData;
            }

            return rtn;
        }

        public static string MaskCardNo(string card_no)
        {
            string rtn = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(card_no))
                    return string.Empty;

                if (card_no.Length == 10 || card_no.Length == 11)
                {
                    rtn = card_no;
                }
                else
                {
                    rtn = ClsString.MaskStyle(card_no.Substring(0, 6), card_no.Length, "*", HorizontalAlignment.Left);
                }

                return rtn;
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return string.Empty;
        }

        #endregion

        #region " Convert 함수 "

        /// <summary>
        /// 금액 앞에 "0"  제거
        /// </summary>
        public static string TrimAMT(string param_s_amt)
        {
            string strRet = param_s_amt.TrimStart('0');

            if (strRet.Length <= 0) strRet = "0";

            return strRet;
        }

        /// <summary>
        /// Encoding 함수 (euc-kr)
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string GetEucKr(string sData)
        {
            try
            {
                Encoding euckr = Encoding.GetEncoding(51949);

                return euckr.GetString(euckr.GetBytes(sData));
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return string.Empty;
        }

        /// <summary>
        /// Encoding 함수 (euc-kr)
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static byte[] GetEucKrB(string sData)
        {
            try
            {
                Encoding euckr = Encoding.GetEncoding(51949);

                return euckr.GetBytes(sData);
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return new byte[0];
        }

        /// <summary>
        /// Encoding 함수 (euc-kr)
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string GetEucKr(byte[] param_c_data, int param_n_index = 0, int param_n_len = 0)
        {
            try
            {
                string toString = "";

                if (param_n_len > 0)
                    toString = Encoding.GetEncoding("EUC-KR").GetString(param_c_data, param_n_index, param_n_len);
                else
                    toString = Encoding.GetEncoding("EUC-KR").GetString(param_c_data);

                return toString.Trim('\0');

            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return string.Empty;
        }

        /// <summary>
        /// Encoding 함수 (utf-8)
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string GetUTF8(string sData)
        {
            try
            {
                Encoding utf8 = Encoding.UTF8;

                return utf8.GetString(utf8.GetBytes(sData)).TrimEnd('\0');
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return string.Empty;
        }

        /// <summary>
        /// Encoding 함수 (utf-8)
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static byte[] GetUTF8B(string sData)
        {
            try
            {
                Encoding utf8 = Encoding.UTF8;

                return utf8.GetBytes(sData);
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return new byte[0];
        }

        /// <summary>
        /// Encoding 함수 (utf-8)
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string GetUTF8(byte[] param_c_data, int param_n_index = 0, int param_n_len = 0)
        {
            try
            {
                Encoding utf8 = Encoding.UTF8;

                if (param_n_len > 0)
                    return utf8.GetString(param_c_data, param_n_index, param_n_len).TrimEnd('\0');
                else
                    return utf8.GetString(param_c_data).TrimEnd('\0');
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return string.Empty;
        }

        /// <summary>
        /// 문자 길이 체크 (유니코드 2byte, 아스키 1byte)
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int GetByteSize(string strValue)
        {
            char[] obj = strValue.ToCharArray();  // 입력 String을 char[]로 변경

            int nRet = 0; // 바이트 길이를 계산할 변수

            for (int i = 0; i < obj.Length; i++)
            {
                // 상위 1바이트를 가져온다
                byte oF = (byte)((obj[i] & 0xff00) >> 8);

                // 하위 1바이트를 가져온다
                byte oB = (byte)(obj[i] & 0x00ff);
                if (oF == 0) // 상위 1바이트가 0이면 알파벳
                    nRet++;
                else
                    nRet += 2;
            }

            return nRet;
        }

        /// <summary>
        /// Base64 Decoding 처리
        /// </summary>        
        public static byte[] Base64_Decode(string param_s_data)
        {
            try
            {
                // URL 인코딩되면서 + 가 공백으로 변경될수 있다..
                param_s_data = param_s_data.Trim();
                param_s_data = param_s_data.Replace(' ', '+');

                // base64 디코딩시 데이터의 4배수 체크후 아닐경우 4배수가 될때까지 "=" 데이터 추가
                for (int i = 0; i < (ClsString.GetByteSize(param_s_data) % 4); i++)
                {
                    param_s_data += "=";
                }

                return Convert.FromBase64String(param_s_data);
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return new byte[0];
        }


        /// <summary>
        /// Base64 Encoding, Decoding 처리
        /// </summary>
        /// <param name="parma_b_flag">인코딩 및 디코딩 여부[true : 인코딩, false : 디코딩]</param>
        /// <param name="param_s_data">변환할 데이터</param>
        /// <param name="param_b_strhex">핵사 스트링 반환 여부</param>
        /// <returns></returns>
        public static string Base64(bool parma_b_flag, string param_s_data, bool param_b_strhex = false)
        {
            try
            {
                byte[] buff;

                // 인코딩
                if (parma_b_flag)
                {
                    buff = GetEucKrB(param_s_data);
                    return Convert.ToBase64String(buff);
                }
                // 디코딩
                else
                {
                    // base64 디코딩시 데이터의 4배수 체크후 아닐경우 4배수가 될때까지 "=" 데이터 추가
                    for (int i = 0; i < (ClsString.GetByteSize(param_s_data) % 4); i++)
                    {
                        param_s_data += "=";
                    }

                    buff = Convert.FromBase64String(param_s_data);

                    // 헥사스트링
                    if (param_b_strhex)
                        return ByteArrayToHexString(buff);
                    // 일반문자열
                    return GetEucKr(buff);
                }
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return string.Empty;
        }

        /// <summary>
        /// Base64 Encoding, Decoding 처리
        /// </summary>
        /// <param name="nIdx"></param>
        /// <param name="ConverData"></param>
        /// <returns></returns>
        public static string Base64(bool parma_b_flag, Byte[] param_s_data, int param_n_len, bool param_b_strhex = false)
        {
            try
            {
                // 인코딩
                if (parma_b_flag)
                {
                    return Convert.ToBase64String(param_s_data, 0, param_n_len);
                }
                // 디코딩
                else
                {
                    byte[] buff;

                    string strEncode = GetEucKr(param_s_data, 0, param_n_len);

                    // base64 디코딩시 데이터의 4배수 체크후 아닐경우 4배수가 될때까지 "=" 데이터 추가
                    for (int i = 0; i < (ClsString.GetByteSize(strEncode) % 4); i++)
                    {
                        strEncode += "=";
                    }

                    buff = Convert.FromBase64String(strEncode);

                    // 헥사스트링
                    if (param_b_strhex)
                        return ByteArrayToHexString(buff);
                    // 일반분자열
                    return GetEucKr(buff);
                }
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return string.Empty;
        }


        #endregion

        #region " 문자열 변환 "

        // byte 배열 -> hexString 변환
        public static string ByteArrayToHexString(byte[] buffer)
        {
            var encData = new StringBuilder();
            foreach (var b in buffer)
            {
                encData.Append(string.Format("{0:X}", b).PadLeft(2, '0'));
            }
            return encData.ToString();
        }

        // hexString -> byte 배열 변환
        public static byte[] HexStringToByteArray(string hexStr)
        {
            hexStr = hexStr.Trim();
            var buffer = new byte[hexStr.Length / 2];

            for (var i = 0; i <= hexStr.Length - 1; i += 2)
            {
                buffer[i / 2] = Convert.ToByte(hexStr.Substring(i, 2), 16);
            }

            return buffer;
        }

        // hexString -> 옵션에 따라 Decimal형 또는 Char형 String 변환
        public static string HexStringToConvert(int nIdx, string hexStr)
        {
            string sTmp = string.Empty;
            string[] hexSplit = hexStr.Split(' ');
            foreach (string hex in hexSplit)
            {
                int val = Convert.ToInt32(hex, 16);

                if (nIdx == 0)
                    sTmp += val.ToString();
                else if (nIdx == 1)
                {
                    string stringval = Char.ConvertFromUtf32(val);
                    sTmp += stringval;
                }
            }

            return sTmp;
        }

        // 전화번호 형식으로 리턴
        public static string ConvertCallNo(string param_s_no)
        {
            if (string.IsNullOrEmpty(param_s_no))
                return param_s_no;

            if (param_s_no.IndexOf('-') >= 0)
                return param_s_no;

            string strRet = string.Empty; ;

            if (param_s_no.Length == 8)
                strRet = Regex.Replace(param_s_no, @"(\d{4})(\d{4})", "$1-$2");
            else if (param_s_no.Length == 9)
                strRet = Regex.Replace(param_s_no, @"(\d{2})(\d{3})(\d{4})", "$1-$2-$3");
            else if (param_s_no.Length == 10)
            {
                if (param_s_no.Substring(0, 2) == "02")
                    strRet = Regex.Replace(param_s_no, @"(\d{2})(\d{4})(\d{4})", "$1-$2-$3");
                else
                    strRet = Regex.Replace(param_s_no, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
            }
            else if (param_s_no.Length == 11)
                strRet = Regex.Replace(param_s_no, @"(\d{3})(\d{4})(\d{4})", "$1-$2-$3");
            else if (param_s_no.Length == 12)
                strRet = Regex.Replace(param_s_no, @"(\d{4})(\d{4})(\d{4})", "$1-$2-$3");
            else
                return param_s_no;

            return strRet;
        }

        // 전표출력 정렬
        public static string PrintAlignCenter(string strMsg)
        {
            int nPad = 0;
            string Msg = "";

            int Len = GetByteSize(strMsg);

            if (Len > 0 && Len <= 22)
                nPad = (24 - Len) / 2;

            Msg = "".PadRight(nPad) + strMsg;

            return Msg;
        }

        // 전표출력 정렬
        public static string PrintAlign(string sLeft, string sRight, int nWidth = 48)
        {
            string Msg = "";

            // 왼쪽길이
            int sLLen = GetByteSize(sLeft);
            // 오른쪽길이
            int sRLen = GetByteSize(sRight);

            // 공백
            int sBLen = nWidth - (sLLen + sRLen);

            if (sBLen > 0)
                Msg = string.Format("{0}{1}{2}", sLeft, "".PadRight(sBLen), sRight);
            else
                Msg = string.Format("{0}{1}", sLeft, sRight);

            return Msg;
        }

        // 전표출력 정렬
        public static string PrintAlignMoney(string sTitle, string sAmt, bool isCancel, int nWidth = 48)
        {
            string Msg = "";

            // 왼쪽길이
            int sLLen = GetByteSize(sTitle);

            string strWon;
            if (Convert.ToInt64(sAmt) == 0)
                strWon = "0 원";
            else
            {
                if (isCancel)
                    strWon = string.Format("-{0:#,000} 원", Convert.ToDecimal(sAmt, CultureInfo.InvariantCulture.NumberFormat));
                else
                    strWon = string.Format("{0:#,000} 원", Convert.ToDecimal(sAmt, CultureInfo.InvariantCulture.NumberFormat));
            }

            // 오른쪽길이
            int sRLen = GetByteSize(strWon);

            // 공백
            int sBLen = nWidth - (sLLen + sRLen);

            if (sBLen > 0)
                Msg = string.Format("{0}{1}{2}", sTitle, "".PadRight(sBLen), strWon);
            else
                Msg = string.Format("{0}{1}", sTitle, strWon);

            return Msg;
        }


        #endregion
    }
}
