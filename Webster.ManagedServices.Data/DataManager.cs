using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Webster.ManagedServices.Contracts;

namespace Webster.ManagedServices.Data
{
    public class DataManager : System.ComponentModel.Component
    {
        private MediaDataSetTableAdapters.QueriesTableAdapter queriesAdapter;
        private MediaDataSetTableAdapters.SelectSongTableAdapter selectSongAdapter;
        private MediaDataSetTableAdapters.PlaylistsTableAdapter playlistsAdapter;
        private MediaDataSetTableAdapters.SongsTableAdapter songsAdapter;
        private MediaDataSetTableAdapters.SelectPlaylistTableAdapter selectPlaylistAdapter;

        private void InitializeComponent()
        {
            this.queriesAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.QueriesTableAdapter();
            this.selectPlaylistAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.SelectPlaylistTableAdapter();
            this.selectSongAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.SelectSongTableAdapter();
            this.playlistsAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.PlaylistsTableAdapter();
            this.songsAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.SongsTableAdapter();
            // 
            // selectPlaylistAdapter
            // 
            this.selectPlaylistAdapter.ClearBeforeFill = true;
            // 
            // selectSongAdapter
            // 
            this.selectSongAdapter.ClearBeforeFill = true;
            // 
            // playlistsAdapter
            // 
            this.playlistsAdapter.ClearBeforeFill = true;
            // 
            // songsAdapter
            // 
            this.songsAdapter.ClearBeforeFill = true;

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

        private Song GetSong(MediaDataSet.SongsRow row)
        {
            return new Song()
            {
                SongID = row.SongID,
                SongFileName = row.SongFileName,
                OrderingIndex = row.OrderingIndex
            };
        }

        private Playlist GetPlaylist(MediaDataSet.PlaylistsRow row)
        {
            return new Playlist()
            {
                PlaylistID = row.PlayListID,
                PlaylistName = row.PlaylistName
            };
        }

        public List<Song> GetSongs()
        {
            var data = this.songsAdapter.GetData();

            List<Song> songs = new List<Song>(data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                songs.Add(this.GetSong(data[i]));
            }

            return songs;
        }

        public List<Playlist> GetPlaylists()
        {
            var data = this.playlistsAdapter.GetData();

            List<Playlist> playlists = new List<Playlist>(data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                playlists.Add(this.GetPlaylist(data[i]));
            }

            return playlists;
        }

        public byte[] GetAudioBytes(Guid songID)
        {
            return this.GetAudioStream(songID).ToArray();
        }
    }
}
