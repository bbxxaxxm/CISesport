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
    public partial class TeamAdd : Form
    {
        teamsClass team;
        List<player> listplay = new List<player>();
        public TeamAdd()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                player player = new player();
                player.Name = "";
                player.Lastname = "";
                player.ID = "";
                player.Major = "";
                player.Displayname = "";
                player.Mail = "";
                player.Tel = "";
                player.Age = 0;
                listplay.Add(player);

            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string TeamName = tbTeam.Text;
            team = new teamsClass();
            team.TeamName = TeamName;
            team.Member = this.listplay;
            this.team = team;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonFind(object sender, EventArgs e)
        {
            Button BTN = (Button)sender;
            if (BTN.Name == "buttonFind1")
            {
                FindMember(0,tbMem1);
            }
            else if (BTN.Name == "buttonFind2")
            {
                FindMember(1, tbMem2);
            }
            else if (BTN.Name == "buttonFind3")
            {
                FindMember(2, tbMem3);
            }
            else if (BTN.Name == "buttonFind4")
            {
                FindMember(3, tbMem4);
            }
            else if (BTN.Name == "buttonFind5")
            {
                FindMember(4, tbMem5);
            }
        }
        private void FindMember(int index, TextBox textBox)
        {
            Findmem FM = new Findmem();
            FM.ShowDialog();
            if (FM.DialogResult == DialogResult.OK)
            {
                listplay[index] = FM.GetPlayer();
                textBox.Text = FM.GetPlayer().Name;
            }
        }
        public teamsClass getTeam()
        {
            return this.team;
        }
    }
}
