using esport.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esport
{
    public partial class Player : Form
    {
        public static Player Instance;
        public List<player> listplayer = new List<player>();
        public Player()
        {
            InitializeComponent();
            Instance = this;
        }

        private void newPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerRegeter PRT = new PlayerRegeter();
            PRT.ShowDialog();
            if(PRT.DialogResult == DialogResult.OK )
            {
                listplayer.Add(PRT.getPlayer());
                RefreshPlayer();
            }
        }
        private void RefreshPlayer()
        {
            dataGridView1.Rows.Clear();
            foreach(player player_ in listplayer)
            {
                dataGridView1.Rows.Add(player_.Name, player_.Lastname, player_.ID, player_.Major, player_.Displayname, player_.Mail, player_.Tel, player_.Age);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "Player";
            saveFile.Filter = "Json|*.json";
            saveFile.ShowDialog();
            if(saveFile.FileName != "")
            {
                string json = JsonConvert.SerializeObject(listplayer, Formatting.Indented);
                File.WriteAllText(saveFile.FileName, json);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "Players";
            openFile.Filter = "Json|*.json";
            openFile.ShowDialog();
            if (openFile.FileName != "")
            {
                listplayer = JsonConvert.DeserializeObject<List<player>>(File.ReadAllText(openFile.FileName));
                RefreshPlayer();
            }
        }

        private void manageTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Team TM = new Team();
            TM.ShowDialog();
        }
    }
}
