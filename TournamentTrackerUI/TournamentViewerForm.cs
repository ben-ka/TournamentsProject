using System;
using System.Drawing;
using System.Windows.Forms;
using TournamentTrackerLibrary.Models;
using TournamentTrackerLibrary.DataAccess;
using TournamentTrackerLibrary;

namespace TournamentTrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        static Color mainColor = Color.FromArgb(51, 153, 255);

        public TournamentViewerForm()
        {
            InitializeComponent();
            this.Load += TournamentViewerForm_Load;
        }

        private void TournamentViewerForm_Load(object sender, EventArgs e)
        {
            

            //the label of the tournament name
            Label headerLabel = new Label();
            headerLabel.ForeColor = mainColor;
            headerLabel.Text = "Tournament: ";
            headerLabel.Location = new Point(20, 30);
            headerLabel.Size = new Size(150, 50);
            this.Controls.Add(headerLabel);

            Label tournamentName = new Label();
            tournamentName.ForeColor = mainColor;
            tournamentName.Text = "<none>";
            tournamentName.Location = new Point(170, 30);
            tournamentName.Size = new Size(400, 30);
            this.Controls.Add(tournamentName);

            // the round label + combobox
            Label roundLabel = new Label();
            roundLabel.ForeColor = mainColor;
            roundLabel.Text = "Round";
            roundLabel.Location = new Point(20, 95);
            roundLabel.Size = new Size(100, 50);
            this.Controls.Add(roundLabel);


            ComboBox roundPicker = new ComboBox();
            roundPicker.ForeColor = mainColor;
            roundPicker.Location = new Point(120, 95);
            roundPicker.Size = new Size(400, 100);
            this.Controls.Add(roundPicker);


            // a checkbox that checks whether it should show only the unplayed games
            CheckBox checkUnplayed = new CheckBox();
            checkUnplayed.ForeColor = mainColor;
            checkUnplayed.Checked = true;
            checkUnplayed.Text = "Unplayed Only";
            checkUnplayed.Location = new Point(120, 150);
            checkUnplayed.Size = new Size(400, 40);
            this.Controls.Add(checkUnplayed);  
            
            // a listbox of all of the matchups in the current round picked
            ListBox matchupListBox = new ListBox();
            matchupListBox.ForeColor = mainColor;
            matchupListBox.Location = new Point(20, 200);
            matchupListBox.Size = new Size(250, 400);
            this.Controls.Add(matchupListBox);


            // once the user chose a matchup, an interface to change the game's score
            Label teamOneNameLabel = new Label();
            teamOneNameLabel.ForeColor = mainColor;
            teamOneNameLabel.Location = new Point(400, 200);
            teamOneNameLabel.Size = new Size(250, 40);
            teamOneNameLabel.Text = "<Team One Name>";
            this.Controls.Add(teamOneNameLabel);


            Label teamTwoNameLabel = new Label();
            teamTwoNameLabel.ForeColor = mainColor;
            teamTwoNameLabel.Location = new Point(750, 200);
            teamTwoNameLabel.Size = new Size(250, 40);
            teamTwoNameLabel.Text = "<Team Two Name>";
            this.Controls.Add(teamTwoNameLabel);

            Label teamOneScoreLabel = new Label();
            teamOneScoreLabel.ForeColor = mainColor;
            teamOneScoreLabel.Location = new Point(400, 270);
            teamOneScoreLabel.Size = new Size(70, 30);
            teamOneScoreLabel.Text = "Score";
            this.Controls.Add(teamOneScoreLabel);


            Label teamTwoScoreLabel = new Label();
            teamTwoScoreLabel.ForeColor = mainColor;
            teamTwoScoreLabel.Location = new Point(750, 270);
            teamTwoScoreLabel.Size = new Size(70, 30);
            teamTwoScoreLabel.Text = "Score";
            this.Controls.Add(teamTwoScoreLabel);

            TextBox teamOneScoreTextBox = new TextBox();
            teamOneScoreTextBox.ForeColor = mainColor;
            teamOneScoreTextBox.Location = new Point(480, 270);
            teamOneScoreTextBox.Size = new Size(100, 30);
            this.Controls.Add(teamOneScoreTextBox);


            TextBox teamTwoScoreTextBox = new TextBox();
            teamTwoScoreTextBox.ForeColor = mainColor;
            teamTwoScoreTextBox.Location = new Point(830, 270);
            teamTwoScoreTextBox.Size = new Size(100, 30);
            this.Controls.Add(teamTwoScoreTextBox);

            // saves the score of the currently updated matchup
            Button saveScore = new Button();
            saveScore.ForeColor = mainColor;
            saveScore.Location = new Point((teamOneScoreTextBox.Location.X + teamTwoScoreLabel.Location.X) / 2 - 20, 350);
            saveScore.Size = new Size(150, 50);
            saveScore.Text = "Save Score";
            saveScore.UseVisualStyleBackColor = true;
            this.Controls.Add(saveScore);





        }
    }
}
