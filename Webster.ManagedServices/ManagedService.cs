using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Webster.ManagedServices.Contracts;

namespace Webster.ManagedServices
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public partial class ManagedService : Component, IRandomNumberService
    {
        public ManagedService()
        {
            InitializeComponent();
        }

        public ManagedService(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public byte[] GetRandomBytes(int size)
        {
            return this.manager.GetRandomBytes(size);
        }

        public string GetRandomInteger(byte[] value)
        {
            return this.manager.GetRandomInteger(value);
        }
    }
}
