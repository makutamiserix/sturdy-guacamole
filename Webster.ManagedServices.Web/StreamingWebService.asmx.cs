using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Services;
using Webster.ManagedServices.Contracts;

namespace Webster.ManagedServices.Web
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class StreamingWebService : System.Web.Services.WebService, IStreamingService
    {
        private Data.DataManager manager;

        public StreamingWebService() : base()
        {
            this.InitializeComponent();
        }

        [WebMethod]
        public Stream GetAudioStream(Guid songID)
        {
            return this.manager.GetAudioStream(songID);
        }

        [WebMethod]
        public Stream[] GetAudioStreams(Guid playListID)
        {
            return this.manager.GetAudioStreams(playListID).ToArray();
        }

        [WebMethod]
        public List<Playlist> GetPlaylists()
        {
            return this.manager.GetPlaylists();
        }

        [WebMethod]
        public List<Song> GetSongs()
        {
            return this.manager.GetSongs();
        }

        private void InitializeComponent()
        {
            this.manager = new Webster.ManagedServices.Data.DataManager();

        }
    }
}
