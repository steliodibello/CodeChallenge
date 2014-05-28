using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class RequestOtherSeats
{
    [DataMember]
    public int SeatsRequested { get; set; }
    [DataMember]
    public List<int> PreviousSeates { get; set; }

}