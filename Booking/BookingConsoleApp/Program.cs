using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
 

namespace BookingConsoleApp
{
    class Program
    {


        static string serviceNamespace = ConfigurationManager.AppSettings["serviceNamespace"];
        static string acsHostUrl = ConfigurationManager.AppSettings["acsHostUrl"];
        static string realm = ConfigurationManager.AppSettings["realm"];
        static string uid = ConfigurationManager.AppSettings["uid"];
        static string pwd = ConfigurationManager.AppSettings["pwd"];
        static string serviceUrl = ConfigurationManager.AppSettings["serviceUrl"];
        
        private static string token = string.Empty;
        private static string headerValue = string.Empty;




        static void Main(string[] args)
        {

               token = GetTokenFromACS(realm);
               headerValue = string.Format("WRAP access_token=\"{0}\"", token);

            var seatsRequested = RequestSeats();

            var returnedSeats = GetNumbers(seatsRequested);

             
           var reBookString =  RequestAlternativeSeats(returnedSeats);

           var rebookedSeats = GetNumbers(reBookString);

             ServiceBookSeats(rebookedSeats);
           

            Console.ReadLine();

        }


        private static string RequestSeats()
        {
            WebClient client = new WebClient();

            client.Headers.Add("Authorization", headerValue);

            Stream stream = client.OpenRead(serviceUrl + "/getAvaliableSeats/2");

            StreamReader reader = new StreamReader(stream);
            String response = reader.ReadToEnd();
            Console.WriteLine("I have preAssigned the following seats: " +response);

            return response;
        }

        public  static List<int> GetNumbers(string input)
        {
            var getinput = new List<int>();


            foreach (var s in input.Split(','))
            {
                getinput.Add(Int32.Parse(ExtractNumbers(s)));
            }
            return getinput;
        }

        private static string RequestAlternativeSeats(List<int> getinput)
        {
            Stream stream;
            WebClient Proxy1 = new WebClient();
            Proxy1.Headers["Content-type"] = "application/json";
            Proxy1.Headers.Add("Authorization", headerValue);

            MemoryStream ms = new MemoryStream();

            var req = new RequestOtherSeats();
            req.SeatsRequested = 2;
            req.PreviousSeates = getinput;

            DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof (RequestOtherSeats));
            serializerToUplaod.WriteObject(ms, req);
            byte[] data = Proxy1.UploadData(serviceUrl + "/getOtherAvaliableSeats", "POST", ms.ToArray());
            stream = new MemoryStream(data);


            StreamReader reader2 = new StreamReader(stream);
            String response2 = reader2.ReadToEnd();
            Console.WriteLine("I have Reassigned the following seats " + response2);
            return response2;
        }


        private static void ServiceBookSeats(List<int> input)
        {
            Stream stream;
            WebClient Proxy1 = new WebClient();
            Proxy1.Headers["Content-type"] = "application/json";
            Proxy1.Headers.Add("Authorization", headerValue);

            MemoryStream ms = new MemoryStream();

            var req = new BookSeats();
            req.ClientName = "Stelio di bello";
            req.SeatesToBook = input;

            DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(BookSeats));
            serializerToUplaod.WriteObject(ms, req);
            Proxy1.UploadData(serviceUrl + "/bookSeats", "POST", ms.ToArray());
          
            Console.WriteLine("Your Reservation is confirmed!");
        }

        static string ExtractNumbers(string expr)
        {
            return string.Join(null, System.Text.RegularExpressions.Regex.Split(expr, "[^\\d]"));
        }

      

        private static string GetTokenFromACS(string scope)
        {
            string wrapPassword = pwd;
            string wrapUsername = uid;

            // request a token from ACS
            WebClient client = new WebClient();
            client.BaseAddress = string.Format("https://{0}.{1}", serviceNamespace, acsHostUrl);

            NameValueCollection values = new NameValueCollection();
            values.Add("wrap_name", wrapUsername);
            values.Add("wrap_password", wrapPassword);
            values.Add("wrap_scope", scope);

            byte[] responseBytes = client.UploadValues("WRAPv0.9/", "POST", values);

            string response = Encoding.UTF8.GetString(responseBytes);

            
           // Console.WriteLine("\nreceived token from ACS: {0}\n", response);

            return System.Web.HttpUtility.UrlDecode(
                response
                .Split('&')
                .Single(value => value.StartsWith("wrap_access_token=", StringComparison.OrdinalIgnoreCase))
                .Split('=')[1]);
        }

    }

}
