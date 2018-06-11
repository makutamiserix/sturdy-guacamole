using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Webster.ManagedServices.Contracts
{
    public interface IStreamingService
    {
        [OperationContract] Stream GetAudioStream();
        [OperationContract] Stream[] GetAudioStreams(Guid playListID);
    }
}
