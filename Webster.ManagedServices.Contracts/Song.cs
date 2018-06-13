using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Webster.ManagedServices.Contracts
{
    [DataContract]
    public class Song
    {
        [DataMember] public Guid SongID { get; set; }
        [DataMember] public string SongFileName { get; set; }
        [DataMember] public byte[] SongData { get; set; }
    }
}
