using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Webster.ManagedServices.Contracts;

namespace Webster.ManagedServices.Client
{
    public class StreamingServiceClient : ClientBase<IStreamingService>, IStreamingService
    {
        public Stream GetAudioStream(Guid songID)
        {
            return this.Channel.GetAudioStream(songID);
        }

        public Stream[] GetAudioStreams(Guid playListID)
        {
            return this.Channel.GetAudioStreams(playListID);
        }
    }
}
