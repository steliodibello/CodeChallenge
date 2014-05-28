using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Bookings.Service
{
    [ServiceContract]
  interface IBookingService
    {
      

      [WebGet(UriTemplate = "/getAvaliableSeats/{availableSeats}",
              RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
      [OperationContract]
      List<int> GetAvaliableSeats(string availableSeats);



      [WebInvoke(UriTemplate = "/getOtherAvaliableSeats",
            Method = "POST",
         RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json)]
      [OperationContract]
      List<int> GetOtherAvaliableSeats(RequestOtherSeats req);


          [WebInvoke(UriTemplate = "/bookSeats",
            Method = "POST",
         RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json)]
      [OperationContract]
      void BookSeats(BookSeats req);
    }

    }