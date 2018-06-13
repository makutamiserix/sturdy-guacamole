using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Webster.ManagedServices.Contracts
{
    [DataContract]
    public class Playlist
    {
        [DataMember] public Guid PlaylistID { get; set; }
        [DataMember] public string PlaylistName { get; set; }
    }
}
