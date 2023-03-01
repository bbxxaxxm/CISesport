using esport.Class;
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
    public partial class Findmem : Form
    {
        player players;
        public Findmem()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            foreach(player players in Player.Instance.listplayer)
            {
                dataGridView1.Rows.Add(players.Name, players.Lastname,players.ID, players.Major, players.Displayname, players.Mail, players.Tel, players.Age);
            }
        }
        public player GetPlayer()
        {
            return players;
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            player BB = Player.Instance.listplayer[dataGridView1.CurrentRow.Index];
            players = BB;
            this.DialogResult= DialogResult.OK;
        }
    }
}
