using System;
using System.IO;
using System.Net;

namespace SportsBettingTracker.Client
{
    public class HTTPMethods
    {
        public void HTTPRequest(string url, string method, string data, string token)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = method;

            httpRequest.ContentType = "application/x-www-form-urlencoded";

            httpRequest.Headers["Authorization"] = $"Bearer {token}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            Console.WriteLine(httpResponse.StatusCode);

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        public string HTTPRequestToken(string email, string password)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44365/token");
            httpRequest.Method = "POST";

            httpRequest.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write($"grant_type=password&username={email}&password={password}");
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                string[] resultArray = result.Split('"');
                return resultArray[3];
            }
        }
    }
}
