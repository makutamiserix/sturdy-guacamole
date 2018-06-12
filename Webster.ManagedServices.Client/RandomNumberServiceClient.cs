using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Webster.ManagedServices.Contracts;

namespace Webster.ManagedServices.Client
{
    public class RandomNumberServiceClient : ClientBase<IRandomNumberService>, IRandomNumberService
    {
        public byte[] GetRandomBytes(int size)
        {
            return this.Channel.GetRandomBytes(size);
        }

        public string GetRandomInteger(byte[] value)
        {
            return this.Channel.GetRandomInteger(value);
        }
    }
}
