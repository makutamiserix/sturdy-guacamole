using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Webster.ManagedServices.Contracts;

namespace Webster.ManagedServices
{
    public partial class ManagedHostServer : ServiceBase
    {
        public ManagedHostServer()
        {
            InitializeComponent();

            this.host = new ServiceHost(typeof(ManagedService));
        }

        private ServiceHost host;

        protected override void OnStart(string[] args)
        {
            host.Open();
        }

        protected override void OnStop()
        {
            if (this.host != null)
            {
                this.host.Close();
            }
        }
    }
}
