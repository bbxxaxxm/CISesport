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
    public partial class Team : Form
    {
        List<teamsClass> listTeam = new List<teamsClass>();
        public Team()
        {
            InitializeComponent();
        }

        private void newTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamAdd TA = new TeamAdd();
            TA.ShowDialog();
            if(TA.DialogResult == DialogResult.OK)
            {
                teamsClass teams = TA.getTeam();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(teams.TeamName,teams.Member[0].Name, teams.Member[1].Name, teams.Member[2].Name, teams.Member[3].Name, teams.Member[4].Name);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "Teams";
            saveFile.Filter = "Json|*.json";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                string json = JsonConvert.SerializeObject(listTeam, Formatting.Indented);
                File.WriteAllText(saveFile.FileName, json);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "Teams";
            openFile.Filter = "Json|*.json";
            openFile.ShowDialog();
            if (openFile.FileName != "")
            {
                listTeam = JsonConvert.DeserializeObject<List<teamsClass>>(File.ReadAllText(openFile.FileName));
                RefreshDataGrid();
            }
        }
        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (teamsClass team_ in listTeam)
            {
                dataGridView1.Rows.Add(team_.TeamName, team_.Member[0].Name, team_.Member[1].Name, team_.Member[2].Name, team_.Member[3].Name, team_.Member[4].Name);
            }
        }
    }
}
