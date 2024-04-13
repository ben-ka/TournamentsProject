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
    public partial class CreateTournamentForm : Form
    {
        static Color mainColor = Color.FromArgb(51, 153, 255);
        Font HeaderLabelsFont = new Font("Segoe UI", 20);
        Font smallerFont = new Font("Segoe UI", 12);

        public CreateTournamentForm()
        {
            InitializeComponent();
            this.Load += CreateTournamentForm_Load;
        }

        private void CreateTournamentForm_Load(object sender, EventArgs e)
        {
            Label createTournamentLabel = new Label();
            createTournamentLabel.Text = "Create Tournament";
            createTournamentLabel.ForeColor = mainColor;
            createTournamentLabel.Location = new Point(50, 30);
            createTournamentLabel.Size = new Size(200, 50);
            this.Controls.Add(createTournamentLabel);

            Label tournamentNameLabel = new Label();
            tournamentNameLabel.Text = "Tournament Name: ";
            tournamentNameLabel.ForeColor = mainColor;
            tournamentNameLabel.Location = new Point(50, 120);
            tournamentNameLabel.Size = new Size(200, 30);
            this.Controls.Add(tournamentNameLabel);

            TextBox tournamentNameTextBox = new TextBox();
            tournamentNameTextBox.ForeColor = Color.Black;
            tournamentNameTextBox.Location = new Point(250, 120);
            tournamentNameTextBox.Size = new Size(300, 50);
            this.Controls.Add(tournamentNameTextBox);

            Label entryFeeLabel = new Label();
            entryFeeLabel.ForeColor = mainColor;
            entryFeeLabel.Location = new Point(50, 200);
            entryFeeLabel.Size = new Size(150, 50);
            entryFeeLabel.Text = "Entry Fee: ";
            this.Controls.Add(entryFeeLabel);

            TextBox tournamentEntryFeeTextBox = new TextBox();
            tournamentEntryFeeTextBox.ForeColor = Color.Black;
            tournamentEntryFeeTextBox.Location = new Point(250, 200);
            tournamentEntryFeeTextBox.Size = new Size(300, 50);
            this.Controls.Add(tournamentEntryFeeTextBox);

            Label selectTeamLabel = new Label();
            selectTeamLabel.ForeColor = mainColor;
            selectTeamLabel.Location = new Point(50, 300);
            selectTeamLabel.Size = new Size(130, 30);
            selectTeamLabel.Text = "Select Team";
            this.Controls.Add(selectTeamLabel);


            LinkLabel createTeamLinkLabel = new LinkLabel();
            createTeamLinkLabel.ForeColor = mainColor;
            createTeamLinkLabel.Location = new Point(180, 305);
            createTeamLinkLabel.Size = new Size(200, 30);
            createTeamLinkLabel.Text = "Create New Team";
            createTeamLinkLabel.Font = smallerFont;
            this.Controls.Add(createTeamLinkLabel);

            ComboBox selectTeamDropDown = new ComboBox();
            selectTeamDropDown.ForeColor = mainColor;
            selectTeamDropDown.Location = new Point(50, 335);
            selectTeamDropDown.Size = new Size(250, 200);
            this.Controls.Add(selectTeamDropDown);

            Label orSymbol = new Label();
            orSymbol.ForeColor = mainColor;
            orSymbol.Text = "-Or-";
            orSymbol.Location = new Point(375, 320);
            orSymbol.Size = new Size(75, 30);
            this.Controls.Add(orSymbol);

            Button createPrizeButton = new Button();
            createPrizeButton.ForeColor = mainColor;
            createPrizeButton.Location = new Point(570, 315);
            createPrizeButton.Size = new Size(250, 50);
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = true;
            this.Controls.Add(createPrizeButton);

            ListBox teamListBox = new ListBox();
            teamListBox.ForeColor = mainColor;
            teamListBox.Location = new Point(50, 400);
            teamListBox.Size = new Size(350, 400);
            this.Controls.Add(teamListBox);

            Button removeTeamButton = new Button();
            removeTeamButton.ForeColor = mainColor;
            removeTeamButton.Location = new Point(135, 800);
            removeTeamButton.Size = new Size(165, 50);
            removeTeamButton.Text = "Remove Team";
            removeTeamButton.UseVisualStyleBackColor = true;
            this.Controls.Add(removeTeamButton);


            ListBox prizesListBox = new ListBox();
            prizesListBox.ForeColor = mainColor;
            prizesListBox.Location = new Point(520, 400);
            prizesListBox.Size = new Size(350, 400);
            this.Controls.Add(prizesListBox);

            Button removePrizeButton = new Button();
            removePrizeButton.ForeColor = mainColor;
            removePrizeButton.Location = new Point(620, 800);
            removePrizeButton.Size = new Size(165, 50);
            removePrizeButton.Text = "Remove Team";
            removePrizeButton.UseVisualStyleBackColor = true;
            this.Controls.Add(removePrizeButton);








        }
    }
}
