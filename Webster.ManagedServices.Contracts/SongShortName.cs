using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Webster.ManagedServices.Contracts
{
    [DataContract]
    public class SongShortName
    {
        [DataMember] public Guid SongID { get; set; }
        [DataMember] public string ShortName { get; set; }
    }
}
