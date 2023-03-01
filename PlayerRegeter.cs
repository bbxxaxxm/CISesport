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
    public partial class PlayerRegeter : Form
    {
        player Player;
        public PlayerRegeter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = tbName.Text;
            string Lastname = tbLastname.Text;
            string ID = tbID.Text;
            string Major = tbMajor.Text;
            string Displayname = tbDisplay.Text;
            string Mail = tbMail.Text;
            string Tel = tbTel.Text;
            int Age = int.Parse(tbAge.Text);
            Player = new player()
            {
                Name = Name,
                Lastname = Lastname,
                ID = ID,
                Major = Major,
                Displayname = Displayname,
                Mail = Mail,
                Tel = Tel,
                Age = Age
            };
            this.DialogResult= DialogResult.OK;

        }
        public player getPlayer()
        {
            return Player;
        }
    }
}
