using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class BookSeats
{
    [DataMember]
    public string ClientName { get; set; }
    [DataMember]
    public List<int> SeatesToBook { get; set; }

}