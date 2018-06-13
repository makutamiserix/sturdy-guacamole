using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Webster.ManagedServices.Contracts
{
    [ServiceContract]
    public interface IStreamingService
    {
        [OperationContract] Stream GetAudioStream(Guid songID);
        [OperationContract] Stream[] GetAudioStreams(Guid playListID);
        [OperationContract] List<Song> GetSongs();
        [OperationContract] List<Playlist> GetPlaylists();
    }
}
