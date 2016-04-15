using System.Net.Http;
using System.Text;

namespace WeChat.Core.Extensions
{
    public static class Functions
    {
        public static HttpResponseMessage XmlResponse(this object response)
        {
           
            var contenxt= response.SerializerToXml();
            var responseMessage =
              new HttpResponseMessage { Content = new StringContent(contenxt, Encoding.GetEncoding("UTF-8"), "application/xml") };
            return responseMessage;
        }


        public static HttpResponseMessage JsonResponse(this object response)
        {
            var contenxt = response.ToJson();
            var responseMessage =
              new HttpResponseMessage { Content = new StringContent(contenxt, Encoding.GetEncoding("UTF-8"), "application/json") };
            return responseMessage;
        }
    }
}