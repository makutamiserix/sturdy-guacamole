using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Webster.ManagedServices.Data
{
    public class DataManager : System.ComponentModel.Component
    {
        private MediaDataSetTableAdapters.QueriesTableAdapter queriesAdapter;
        private MediaDataSetTableAdapters.SelectSongTableAdapter selectSongAdapter;
        private MediaDataSetTableAdapters.SelectPlaylistTableAdapter selectPlaylistAdapter;

        private void InitializeComponent()
        {
            this.queriesAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.QueriesTableAdapter();
            this.selectPlaylistAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.SelectPlaylistTableAdapter();
            this.selectSongAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.SelectSongTableAdapter();
            // 
            // selectPlaylistAdapter
            // 
            this.selectPlaylistAdapter.ClearBeforeFill = true;
            // 
            // selectSongAdapter
            // 
            this.selectSongAdapter.ClearBeforeFill = true;

        }

        public DataManager() : base()
        {
            this.InitializeComponent();
        }

        public MemoryStream GetAudioStream(Guid songID)
        {
            var table = this.selectSongAdapter.GetData(songID);

            var row = table[0];

            return new MemoryStream(row.SongData);
        }

        public List<MemoryStream> GetAudioStreams(Guid playListID)
        {
            var table = this.selectPlaylistAdapter.GetData(playListID);

            List<MemoryStream> streams = new List<MemoryStream>(table.Count);

            for (int i = 0; i < table.Count; i++)
            {
                streams.Add(new MemoryStream(table[i].SongData));
            }

            return streams;
        }

        public byte[] GetRandomBytes(int size)
        {
            RNGCryptoServiceProvider rNG = new RNGCryptoServiceProvider();

            byte[] data = new byte[size];

            rNG.GetBytes(data);

            return data;
        }

        public string GetRandomInteger(byte[] value)
        {
            return BigInteger.Abs(new BigInteger(value)).ToString();
        }
    }
}
