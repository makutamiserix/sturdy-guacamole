using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace Webster.ManagedServices
{
    [RunInstaller(true)]
    public partial class ManagedServicesInstaller : System.Configuration.Install.Installer
    {
        public ManagedServicesInstaller()
        {
            InitializeComponent();
        }
    }
}
