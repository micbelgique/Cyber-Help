using SummerCamp.CyberHelp.DataServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.WebApi.Controllers
{
    public class BaseController
    {
        public Factory Factory { get; set; }
        protected Factory _factory = null;

        public BaseController()
        {
            _factory = new Factory();

        }

        protected Factory GetFactory()
        {
            if (_factory == null)
                _factory = new Factory();
            return _factory;

        }



            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://trasyscyberhelpnotification.servicebus.windows.net/TrasysCyberHelpHub/messages/");
            //request.Method = "POST";
            //request.ContentType = "application/json;charset=utf-8";
            //request.Headers["Authorization"] = "SharedAccessSignature sr=https%3a%2f%2ftrasyscyberhelpnotification.servicebus.windows.net%2ftrasyscyberhelphub&sig=evrTtnhFX4DGu7orTYkzbC2DhuagH0bHZhTuXfrCYh8%3D&se=63606257861&skn=DefaultFullSharedAccessSignature";
            //request.Headers["ServiceBusNotification-Format"] = "gcm";

            //string fullMessage = string.Concat("{\"data\":{\"message\":\"", message, "\"}}");
            //byte[] postBytes = Encoding.UTF8.GetBytes(fullMessage);
            //request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), new Tuple<HttpWebRequest, string>(request, fullMessage));
            //Stream postStream = request.GetRequestStreamAsync().Result;
            //postStream.Write(postBytes, 0, fullMessage.Length);
            //request.GetResponseAsync();

     

        private static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            //HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            Tuple<HttpWebRequest, string> test = (Tuple<HttpWebRequest, string>)asynchronousResult.AsyncState;
            HttpWebRequest request = (HttpWebRequest)test.Item1;

            // End the operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);

            string postData = test.Item2;

            // Convert the string into a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Write to the request stream.
            postStream.Write(byteArray, 0, postData.Length);

            // Start the asynchronous operation to get the response
            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }

        private static void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
        }


     
    }
}
