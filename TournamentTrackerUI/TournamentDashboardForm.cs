using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentTrackerLibrary.Models;
using TournamentTrackerLibrary.DataAccess;
using TournamentTrackerLibrary;

namespace TournamentTrackerUI
{
    public partial class TournamentDashboardForm : Form
    {
        static Color mainColor = Color.FromArgb(51, 153, 255);
        Font HeaderLabelsFont = new Font("Segoe UI", 20);
        public TournamentDashboardForm()
        {
            InitializeComponent();
            this.Load += TournamentDashboardForm_Load;
        }

        private void TournamentDashboardForm_Load(object sender, EventArgs e)
        {
            Label tournamentDashboardHeaderLabel = new Label();
            tournamentDashboardHeaderLabel.Text = "Tournament Dashboard";
            tournamentDashboardHeaderLabel.ForeColor = mainColor;
            tournamentDashboardHeaderLabel.Location = new Point(350, 30);
            tournamentDashboardHeaderLabel.Size = new Size(300, 50);
            tournamentDashboardHeaderLabel.Font = HeaderLabelsFont;
            this.Controls.Add(tournamentDashboardHeaderLabel);

            Label loadTournamentLabel = new Label();
            loadTournamentLabel.Text = "Load Existing Tournament";
            loadTournamentLabel.ForeColor = mainColor;
            loadTournamentLabel.Location = new Point(350, 175);
            loadTournamentLabel.Size = new Size(350, 50);
            loadTournamentLabel.Font = HeaderLabelsFont;
            this.Controls.Add(loadTournamentLabel);

            ComboBox loadTournamentDropdown = new ComboBox();
            loadTournamentDropdown.ForeColor = mainColor;
            loadTournamentDropdown.Location = new Point(250, 250);
            loadTournamentDropdown.Size = new Size(500, 200);
            this.Controls.Add(loadTournamentDropdown);

            //final load tournament button
            Button finalLoadTournamentButton = new Button();
            finalLoadTournamentButton.ForeColor = mainColor;
            finalLoadTournamentButton.Location = new Point(300, 350);
            finalLoadTournamentButton.Size = new Size(400, 50);
            finalLoadTournamentButton.Text = "Load Tournament";
            finalLoadTournamentButton.UseVisualStyleBackColor = true;
            this.Controls.Add(finalLoadTournamentButton);

            //final create tournament button

            Button finalCreateTournamentButton = new Button();
            finalCreateTournamentButton.ForeColor = mainColor;
            finalCreateTournamentButton.Location = new Point(230, 500);
            finalCreateTournamentButton.Size = new Size(550, 50);
            finalCreateTournamentButton.Text = "Create Tournament";
            finalCreateTournamentButton.UseVisualStyleBackColor = true;
            this.Controls.Add(finalCreateTournamentButton);


        }
    }
}
