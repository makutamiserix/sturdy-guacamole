using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webster.ManagedServices.Data
{
    public class DataManager : System.ComponentModel.Component
    {
        private MediaDataSetTableAdapters.QueriesTableAdapter queriesAdapter;
        private MediaDataSetTableAdapters.SelectPlaylistTableAdapter selectPlaylistAdapter;

        private void InitializeComponent()
        {
            this.queriesAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.QueriesTableAdapter();
            this.selectPlaylistAdapter = new Webster.ManagedServices.Data.MediaDataSetTableAdapters.SelectPlaylistTableAdapter();
            // 
            // selectPlaylistAdapter
            // 
            this.selectPlaylistAdapter.ClearBeforeFill = true;

        }

        public DataManager() : base()
        {
            this.InitializeComponent();
        }


    }
}
