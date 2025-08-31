using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace thepos
{
    public class PublicEventArgs : EventArgs
    {
        public string TAG { get; private set; }

        public PublicEventArgs(string tag)
        {
            TAG = tag;
        }
    }

    public class ClsSecureDLL
    {
        // DLL 파일 전체경로



#if X64
        public string m_strSecureDLL = string.Format("{0}{1}", "C:\\NHNKCPSecureVCAT\\", "libKCPSecure64.dll");
        //public string m_strSecureDLL = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "libKCPSecure64.dll");
#else
        public string m_strSecureDLL = string.Format("{0}{1}", "C:\\NHNKCPSecureVCAT\\", "libKCPSecure.dll");
        //public string m_strSecureDLL = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "libKCPSecure.dll");
#endif


        // DLL 파일 연결 포인터
        private IntPtr m_pSecureDLL;

        // DLL 파일 연결 성공여부
        private bool m_bLoad = false;

        // 버퍼
        byte[] m_cGetData = new byte[4096 + 1];

        // =============================================
        // API 함수
        // =============================================
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void _KCP_VCatRun();
        private _KCP_VCatRun KCP_VCatRun;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_VCatSetup();
        private _KCP_VCatSetup KCP_VCatSetup;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_TransData();
        private _KCP_TransData KCP_TransData;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_TransData_Modal();
        private _KCP_TransData_Modal KCP_TransData_Modal;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_TransCancel();
        private _KCP_TransCancel KCP_TransCancel;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_InitData();
        private _KCP_InitData KCP_InitData;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_SetData(string strKey, string strValue);
        private _KCP_SetData KCP_SetData;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_SetByte(string strKey, byte[] strValue, int nValueLen);
        private _KCP_SetByte KCP_SetByte;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_GetData(string strKey, [MarshalAs(UnmanagedType.LPArray)] byte[] strValue);
        private _KCP_GetData KCP_GetData;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_GetListCount(string strListName);
        private _KCP_GetListCount KCP_GetListCount;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_GetListData(int nIndex, string strListName, string strKey, [MarshalAs(UnmanagedType.LPArray)] byte[] strValue);
        private _KCP_GetListData KCP_GetListData;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_GetObjData(string strObjName, string strKey, [MarshalAs(UnmanagedType.LPArray)] byte[] strValue);
        private _KCP_GetObjData KCP_GetObjData;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_SignToBMPFile(int nEncSignLen, string strEncSign, string strFilePath);
        private _KCP_SignToBMPFile KCP_SignToBMPFile;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_SignToBMPData(int nEncSignLen, string strEncSign, [MarshalAs(UnmanagedType.LPArray)] byte[] strDecSign);
        private _KCP_SignToBMPData KCP_SignToBMPData;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_BMPFileToSign(string strFilePath, [MarshalAs(UnmanagedType.LPArray)] byte[] strEncSign);
        private _KCP_BMPFileToSign KCP_BMPFileToSign;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int _KCP_BMPDataToSign(byte[] strInData, [MarshalAs(UnmanagedType.LPArray)] byte[] strEncSign);
        private _KCP_BMPDataToSign KCP_BMPDataToSign;

        // =============================================

        public ClsSecureDLL()
        {
        }

        ~ClsSecureDLL()
        {
            FreeLibrary();
        }

        /// <summary>
        /// libKCP.dll를 로드한다.
        /// </summary>
        /// <returns></returns>
        public bool LoadLibrary()
        {
            IntPtr pRetPtr;

            try
            {
                if (!m_bLoad && File.Exists(m_strSecureDLL))
                {
                    m_pSecureDLL = ClsWin32Api.LoadLibrary(m_strSecureDLL);

                    // ===============================================================
                    // SecureVCAT 실행
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_VCatRun");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_VCatRun = (_KCP_VCatRun)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_VCatRun));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_VCatRun Load Fail");
                        return false;
                    }

                    // ===============================================================
                    // SecureVCAT 설치 확인
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_VCatSetup");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_VCatSetup = (_KCP_VCatSetup)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_VCatSetup));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_VCatSetup Load Fail");
                        return false;
                    }

                    // ===============================================================
                    // 초기화
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_InitData");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_InitData = (_KCP_InitData)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_InitData));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_InitData Load Fail");
                        return false;
                    }

                    // ===============================================================
                    // 전송
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_TransData");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_TransData = (_KCP_TransData)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_TransData));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_TransData Load Fail");
                        return false;
                    }

                    // ===============================================================
                    // 전송 취소
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_TransCancel");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_TransCancel = (_KCP_TransCancel)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_TransCancel));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_TransCancel Load Fail");
                        return false;
                    }

                    // ===============================================================
                    // 데이터 설정
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_SetData");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_SetData = (_KCP_SetData)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_SetData));
                    }
                    else
                    {

                        ClsLog.PrintLog("KCP_SetData Load Fail");
                        return false;
                    }

                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_SetByte");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_SetByte = (_KCP_SetByte)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_SetByte));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_SetByte Load Fail");
                        return false;
                    }
                    // ===============================================================
                    // 데이터 가져오기
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_GetData");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_GetData = (_KCP_GetData)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_GetData));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_GetData Load Fail");
                        return false;
                    }

                    // ===============================================================
                    // 데이터 가져오기
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_GetData");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_GetData = (_KCP_GetData)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_GetData));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_GetData Load Fail");
                        return false;
                    }

                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_GetListCount");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_GetListCount = (_KCP_GetListCount)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_GetListCount));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_GetListCount Load Fail");
                        return false;
                    }

                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_GetListData");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_GetListData = (_KCP_GetListData)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_GetListData));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_GetListData Load Fail");
                        return false;
                    }

                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_GetObjData");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_GetObjData = (_KCP_GetObjData)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_GetObjData));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_GetObjData Load Fail");
                        return false;
                    }

                    // ===============================================================
                    // 암호화된 서명 데이터 BITMAP 파일 생성
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_SignToBMPFile");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_SignToBMPFile = (_KCP_SignToBMPFile)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_SignToBMPFile));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_SignToBMPFile Load Fail");
                        return false;
                    }
                    // ===============================================================
                    // 암호화된 서명 데이터 이미지데이터 변형 
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_SignToBMPData");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_SignToBMPData = (_KCP_SignToBMPData)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_SignToBMPData));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_SignToBMPData Load Fail");
                        return false;
                    }
                    // ===============================================================
                    // 이미지 암호화된 서명데이터 변형
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_BMPFileToSign");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_BMPFileToSign = (_KCP_BMPFileToSign)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_BMPFileToSign));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_BMPFileToSign Load Fail");
                        return false;
                    }
                    // ===============================================================
                    // BMP파일버퍼 -> 서명데이터
                    // ===============================================================
                    pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_BMPDataToSign");
                    if ((UInt64)pRetPtr != 0)
                    {
                        KCP_BMPDataToSign = (_KCP_BMPDataToSign)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_BMPDataToSign));
                    }
                    else
                    {
                        ClsLog.PrintLog("KCP_BMPDataToSign Load Fail");
                        return false;
                    }

                    // ===============================================================
                    // 전송(모달방식) - SecureDLL이 2.1.0.0 이상일 경우만 로드한다.
                    // ===============================================================
                    if (GetSecureDllVer() >= 2100)
                    {
                        pRetPtr = ClsWin32Api.GetProcAddress(m_pSecureDLL, "KCP_TransData_Modal");
                        if ((UInt64)pRetPtr != 0)
                        {
                            KCP_TransData_Modal = (_KCP_TransData_Modal)Marshal.GetDelegateForFunctionPointer(pRetPtr, typeof(_KCP_TransData_Modal));
                        }
                        else
                        {
                            ClsLog.PrintLog("KCP_TransData_Modal Load Fail");
                            return false;
                        }
                    }

                    m_bLoad = true;
                }
                else if (!File.Exists(m_strSecureDLL))
                {
                    ClsLog.PrintLog("libKCPSecure.dll File does not exist");
                }
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return m_bLoad;
        }

        // 라이브러리 언로드
        private void FreeLibrary()
        {
            try
            {
                if (m_bLoad)
                {
                    ClsWin32Api.FreeLibrary(m_pSecureDLL);
                    m_bLoad = false;
                }
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
        }

        /// <summary>
        /// SecureVCAT을 실행한다.
        /// </summary>
        /// <returns></returns>
        public int VCatRun()
        {
            if (!LoadLibrary())
                return -99;

            KCP_VCatRun();

            return 0;
        }

        /// <summary>
        /// SecureVCAT을 설치여부를 확인한다.
        /// </summary>
        /// <returns></returns>
        public int VCatSetup()
        {
            if (!LoadLibrary())
                return -99;

            return KCP_VCatSetup();
        }

        /// <summary>
        /// 데이터를 초기화한다.
        /// </summary>
        /// <returns></returns>
        public int InitData()
        {
            if (!LoadLibrary())
                return -99;

            return KCP_InitData();
        }

        /// <summary>
        /// 전문을 SecureVCAT에 전달한다.
        /// </summary>
        /// <returns></returns>
        public int TransData_Modal()
        {
            if (!LoadLibrary())
                return -99;

            int nRet = 0;

            try
            {
                // SecureDLL 2.1.0.0 이상 버전이면서 TransData_Modal 함수 호출 할 경우
                if (GetSecureDllVer() >= 2100 && !ClsConfig.m_bTransData)
                    nRet = KCP_TransData_Modal();
                // TransData 함수 호출 할 경우
                else
                    nRet = KCP_TransData();

                if (nRet == -99)
                {
                    ClsLog.PrintLog("================================ ");
                    ClsLog.PrintLog(" [ 전문 응답 ] { SecureVCAT 통신 진행 중 }", true);
                    ClsLog.PrintLog("================================ ");
                }
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
            return nRet;
        }

        /// <summary>
        /// POS에서 사용자 취소를 날린다.
        /// </summary>
        /// <returns></returns>
        public int TransCancel()
        {
            if (!LoadLibrary())
                return -99;

            return KCP_TransCancel();
        }

        /// <summary>
        /// 데이터 설정
        /// </summary>
        /// <param name="strKey">키</param>
        /// <param name="strValue">값</param>
        /// <returns></returns>
        public int SetData(string strKey, string strValue)
        {
            if (!LoadLibrary())
                return -99;

            int nRet = 0;

            try
            {
                nRet = KCP_SetData(strKey, strValue);
                if (!string.IsNullOrEmpty(strValue)) ClsLog.PrintLog(strKey, strValue);

            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return nRet;
        }


        /// <summary>
        /// 데이터 설정
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public int SetByte(string strKey, byte[] strValue)
        {
            if (!LoadLibrary())
                return -99;

            int nRet = 0;

            try
            {
                nRet = KCP_SetByte(strKey, strValue, strValue.Length);
                ClsLog.PrintLog(strKey, ClsString.ToString(strValue));

            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return nRet;
        }

        /// <summary>
        /// 데이터 설정
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="strValue"></param>
        /// <param name="nValueLen"></param>
        /// <returns></returns>
        public int SetByte(string strKey, byte[] strValue, int nValueLen)
        {
            if (!LoadLibrary())
                return -99;

            int nRet = 0;

            try
            {
                nRet = KCP_SetByte(strKey, strValue, nValueLen);
                ClsLog.PrintLog(strKey, ClsString.ToString(strValue), nValueLen.ToString());
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return nRet;
        }

        /// <summary>
        /// 데이터 반환
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public string GetData(string strKey)
        {
            string strValue = string.Empty;

            if (!LoadLibrary())
                return strValue;

            int nRet = 0;

            try
            {
                System.Array.Clear(m_cGetData, 0x00, m_cGetData.Length);
                nRet = KCP_GetData(strKey, m_cGetData);

                if (nRet > 0)
                    strValue = ClsString.GetEucKr(m_cGetData);

                if (!string.IsNullOrEmpty(strValue)) ClsLog.PrintLog(strKey, strValue);
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return strValue;
        }

        /// <summary>
        /// 리스트 카운트 반환
        /// </summary>
        /// <param name="strListName"></param>
        /// <returns></returns>
        public int GetListCount(string strListName)
        {
            if (!LoadLibrary())
                return -99;

            int nRet = 0;

            try
            {
                nRet = KCP_GetListCount(strListName);
                ClsLog.PrintLog(string.Format("{0} list count: {1}", strListName, nRet));
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return nRet;
        }

        /// <summary>
        /// 리스트 데이터 반환
        /// </summary>
        /// <param name="nIndex"></param>
        /// <param name="strListName"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public string GetListData(int nIndex, string strListName, string strKey)
        {
            string strValue = string.Empty;

            if (!LoadLibrary())
                return strValue;

            int nRet = 0;

            try
            {
                Array.Clear(m_cGetData, 0x00, m_cGetData.Length);
                nRet = KCP_GetListData(nIndex, strListName, strKey, m_cGetData);

                if (nRet > 0)
                    strValue = ClsString.GetEucKr(m_cGetData);

                if (!string.IsNullOrEmpty(strValue)) ClsLog.PrintLog(strKey, strValue);
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return strValue;
        }

        /// <summary>
        /// 오브젝트 데이터 반환
        /// </summary>
        /// <param name="strObjName"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public string GetObjData(string strObjName, string strKey)
        {
            string strValue = string.Empty;

            if (!LoadLibrary())
                return strValue;

            int nRet = 0;

            try
            {
                System.Array.Clear(m_cGetData, 0x00, m_cGetData.Length);

                nRet = KCP_GetObjData(strObjName, strKey, m_cGetData);

                if (nRet > 0)
                    strValue = ClsString.GetEucKr(m_cGetData);

                if (!string.IsNullOrEmpty(strValue)) ClsLog.PrintLog(strKey, strValue);
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return strValue;
        }

        /// <summary>
        /// 암호화된 서명 데이터 BITMAP 파일 생성
        /// </summary>
        /// <param name="nEncSignLen"></param>
        /// <param name="strEncSign"></param>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public void SignToBMPFile(int nEncSignLen, string strEncSign, string strFilePath)
        {

            if (!LoadLibrary())
                return;

            int nRet = 0;

            try
            {
                nRet = KCP_SignToBMPFile(nEncSignLen, strEncSign, strFilePath);

                if (nRet > 0)
                    ClsLog.PrintLog("SignToBMPFile to BMP File 완료");
                else
                    ClsLog.PrintLog("SignToBMPFile to BMP File 실패 오류코드{0}", nRet.ToString());
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }
        }

        /// <summary>
        /// 암호화된 서명 데이터 이미지데이터 변형 
        /// </summary>
        /// <param name="strObjName"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public string SignToBMPData(int nEncSignLen, string strEncSign)
        {
            string strValue = string.Empty;

            if (!LoadLibrary())
                return strValue;

            int nRet = 0;

            try
            {
                System.Array.Clear(m_cGetData, 0x00, m_cGetData.Length);

                nRet = KCP_SignToBMPData(nEncSignLen, strEncSign, m_cGetData);

                if (nRet > 0)
                    strValue = Convert.ToBase64String(m_cGetData);

                ClsLog.PrintLog(strValue);
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return strValue;
        }


        /// <summary>
        /// 이미지 암호화된 서명데이터 변형
        /// </summary>
        /// <param name="strObjName"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public string BMPFileToSign(string strFilePath)
        {
            string strValue = string.Empty;

            if (!LoadLibrary())
                return strValue;

            int nRet = 0;

            try
            {
                System.Array.Clear(m_cGetData, 0x00, m_cGetData.Length);

                nRet = KCP_BMPFileToSign(strFilePath, m_cGetData);

                if (nRet > 0)
                    strValue = ClsString.GetEucKr(m_cGetData);

                ClsLog.PrintLog(strValue);
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return strValue;
        }

        /// <summary>
        /// BMP 바이너리 데이터를 암호화된 서명데이터로 변형
        /// </summary>
        /// <param name="strObjName"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public string BMPDataToSign(byte[] strInData)
        {
            string strValue = string.Empty;

            if (!LoadLibrary())
                return strValue;

            int nRet = 0;

            try
            {
                System.Array.Clear(m_cGetData, 0x00, m_cGetData.Length);

                nRet = KCP_BMPDataToSign(strInData, m_cGetData);

                if (nRet > 0)
                    strValue = ClsString.GetEucKr(m_cGetData);

                ClsLog.PrintLog(strValue);
            }
            catch (Exception ex)
            {
                ClsLog.PrintLog(ex.ToString());
            }

            return strValue;
        }

        /// <summary>
        /// SecureDLL 버전 반환
        /// </summary>
        /// <returns></returns>
        public int GetSecureDllVer()
        {
            int ver = -1;

            try
            {
                if (File.Exists(m_strSecureDLL))
                {
                    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(m_strSecureDLL);
                    string fileVer = fileVersionInfo.ProductVersion.Replace(".", "");
                    ver = Convert.ToInt32(fileVer);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return ver;
        }
    }
}
