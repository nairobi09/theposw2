using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static thepos2.thepos;

namespace thepos2
{
    internal class couponTM
    {
        String TM_URL = "https://gateway.ticketmanager.ai/";


        public int requestPmCertView(String tCouponNo)
        {
            var baseAddress = new Uri(TM_URL);

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["barcode_no"] = tCouponNo;

                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                mHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", mCouponMID);
                var response = mHttpClient.PostAsync(TM_URL + "extra/ticket/v1/info", data).Result;
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return 0;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return -1;
            }

        }



        public int requestPmCertAuth(String tCouponNo)
        {
            var baseAddress = new Uri(TM_URL);

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["barcode_no"] = tCouponNo;

                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                mHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", mCouponMID);
                var response = mHttpClient.PostAsync(TM_URL + "extra/ticket/v1/use", data).Result;
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return 0;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return -1;
            }

        }


    }
}
