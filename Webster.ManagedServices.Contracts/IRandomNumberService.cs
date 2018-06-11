using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Webster.ManagedServices.Contracts
{
    [ServiceContract]
    public interface IRandomNumberService
    {
        [OperationContract] byte[] GetRandomBytes(int size);
        [OperationContract] string GetRandomInteger(byte[] value);
    }
}
