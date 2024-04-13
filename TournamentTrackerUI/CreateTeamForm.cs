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
using Dapper;
using System.Data.SqlClient;
using System.Reflection;

namespace TournamentTrackerUI
{

    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = new List<PersonModel>();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        TextBox teamNameTextBox;

        Button CreateMemberButton;
        TextBox PersonPhoneNumberTextBox, PersonEmailAddressTextBox, PersonFirstNameTextBox, PersonLastNameTextBox;

        ComboBox addPersonDropdown;
        Button selectMemberButton;
        ListBox peopleInTeamListBox;





        static Color mainColor = Color.FromArgb(51, 153, 255);
        Font HeaderLabelsFont = new Font("Segoe UI", 20);
        public CreateTeamForm()
        {
            InitializeComponent();
            this.Load += CreateTeamForm_Load;

            
        }

        

        

        private void CreateTeamForm_Load(object sender, EventArgs e)
        {
            Label createTeamHeaderLabel = new Label();
            createTeamHeaderLabel.Text = "Create Team";
            createTeamHeaderLabel.ForeColor = mainColor;
            createTeamHeaderLabel.Location = new Point(250, 30);
            createTeamHeaderLabel.Size = new Size(200, 50);
            createTeamHeaderLabel.Font = HeaderLabelsFont;
            this.Controls.Add(createTeamHeaderLabel);

            Label teamNameHeader = new Label();
            teamNameHeader.Text = "Team Name";
            teamNameHeader.ForeColor = mainColor;
            teamNameHeader.Location = new Point(50, 100);
            teamNameHeader.Size = new Size(150, 50);
            this.Controls.Add(teamNameHeader);

            teamNameTextBox = new TextBox();
            teamNameTextBox.ForeColor = Color.Black;
            teamNameTextBox.Location = new Point(300, 100);
            teamNameTextBox.Size = new Size(300, 50);
            this.Controls.Add(teamNameTextBox);

            Label loadPersonLabel = new Label();
            loadPersonLabel.Text = "Select Team Member";
            loadPersonLabel.ForeColor = mainColor;
            loadPersonLabel.Location = new Point(50, 175);
            loadPersonLabel.Size = new Size(250, 50);
            this.Controls.Add(loadPersonLabel);

            addPersonDropdown = new ComboBox();
            addPersonDropdown.ForeColor = mainColor;
            addPersonDropdown.Location = new Point(300, 175);
            addPersonDropdown.Size = new Size(300, 200);
            this.Controls.Add(addPersonDropdown);

            selectMemberButton = new Button();
            selectMemberButton.ForeColor = mainColor;
            selectMemberButton.Location = new Point(200, 250);
            selectMemberButton.Size = new Size(250, 50);
            selectMemberButton.Text = "Add Member";
            selectMemberButton.UseVisualStyleBackColor = true;
            this.Controls.Add(selectMemberButton);
            selectMemberButton.Click += SelectMemberButton_Click;




            // all of the new person's labels

            Label createNewPersonHeaderLabel = new Label();
            createNewPersonHeaderLabel.Text = "Add New Member";
            createNewPersonHeaderLabel.ForeColor = mainColor;
            createNewPersonHeaderLabel.Location = new Point(250, 320);
            createNewPersonHeaderLabel.Size = new Size(250, 50);
            createNewPersonHeaderLabel.Font = HeaderLabelsFont;
            this.Controls.Add(createNewPersonHeaderLabel);


            Label PersonFirstNameLabel = new Label();
            PersonFirstNameLabel.Text = "First Name";
            PersonFirstNameLabel.ForeColor = mainColor;
            PersonFirstNameLabel.Location = new Point(50, 400);
            PersonFirstNameLabel.Size = new Size(150, 50);
            this.Controls.Add(PersonFirstNameLabel);


            Label PersonLastNameLabel = new Label();
            PersonLastNameLabel.Text = "Last Name";
            PersonLastNameLabel.ForeColor = mainColor;
            PersonLastNameLabel.Location = new Point(50, 450);
            PersonLastNameLabel.Size = new Size(150, 50);
            this.Controls.Add(PersonLastNameLabel);

            Label PersonEmailAddressLabel = new Label();
            PersonEmailAddressLabel.Text = "Email Address";
            PersonEmailAddressLabel.ForeColor = mainColor;
            PersonEmailAddressLabel.Location = new Point(50, 500);
            PersonEmailAddressLabel.Size = new Size(150, 50);
            this.Controls.Add(PersonEmailAddressLabel);


            Label PersonPhoneNumberLabel = new Label();
            PersonPhoneNumberLabel.Text = "Phone Number";
            PersonPhoneNumberLabel.ForeColor = mainColor;
            PersonPhoneNumberLabel.Location = new Point(50, 550);
            PersonPhoneNumberLabel.Size = new Size(150, 50);
            this.Controls.Add(PersonPhoneNumberLabel);

            // all of the new person's input boxes

            PersonFirstNameTextBox = new TextBox();
            PersonFirstNameTextBox.ForeColor = Color.Black;
            PersonFirstNameTextBox.Location = new Point(225, 400);
            PersonFirstNameTextBox.Size = new Size(350, 50);
            this.Controls.Add(PersonFirstNameTextBox);

            PersonLastNameTextBox = new TextBox();
            PersonLastNameTextBox.ForeColor = Color.Black;
            PersonLastNameTextBox.Location = new Point(225, 450);
            PersonLastNameTextBox.Size = new Size(350, 50);
            this.Controls.Add(PersonLastNameTextBox);

            PersonEmailAddressTextBox = new TextBox();
            PersonEmailAddressTextBox.ForeColor = Color.Black;
            PersonEmailAddressTextBox.Location = new Point(225, 500);
            PersonEmailAddressTextBox.Size = new Size(350, 50);
            this.Controls.Add(PersonEmailAddressTextBox);

            PersonPhoneNumberTextBox = new TextBox();
            PersonPhoneNumberTextBox.ForeColor = Color.Black;
            PersonPhoneNumberTextBox.Location = new Point(225, 550);
            PersonPhoneNumberTextBox.Size = new Size(350, 50);
            this.Controls.Add(PersonPhoneNumberTextBox);

            CreateMemberButton = new Button();
            CreateMemberButton.ForeColor = mainColor;
            CreateMemberButton.Location = new Point(200, 600);
            CreateMemberButton.Size = new Size(250, 50);
            CreateMemberButton.Text = "Create Member";
            CreateMemberButton.UseVisualStyleBackColor = true;
            this.Controls.Add(CreateMemberButton);
            CreateMemberButton.Click += CreateMemberButton_Click;


            // player's list box and remove player
            Label currentTeamMembersLabel = new Label();
            currentTeamMembersLabel.ForeColor = mainColor;
            currentTeamMembersLabel.Location = new Point(810, 100);
            currentTeamMembersLabel.Size = new Size(250, 35);
            currentTeamMembersLabel.Text = "Current Team Members";
            this.Controls.Add(currentTeamMembersLabel);

            peopleInTeamListBox = new ListBox();
            peopleInTeamListBox.ForeColor = mainColor;
            peopleInTeamListBox.Location = new Point(800, 150);
            peopleInTeamListBox.Size = new Size(250, 500);
            this.Controls.Add(peopleInTeamListBox);

            //calls to populate the drop downs and the list
            //CreateSampleData();
            PopulateAllPeopleDropDown();
            WireUpLists();

            Button removePersonButton = new Button();
            removePersonButton.ForeColor = mainColor;
            removePersonButton.Location = new Point(800, 650);
            removePersonButton.Size = new Size(250, 50);
            removePersonButton.Text = "Remove Member";
            removePersonButton.UseVisualStyleBackColor = true;
            this.Controls.Add(removePersonButton);
            removePersonButton.Click += RemovePersonButton_Click;
            

            Button finalCreateTeamButton = new Button();
            finalCreateTeamButton.ForeColor = mainColor;
            finalCreateTeamButton.Location = new Point(300, 675);
            finalCreateTeamButton.Size = new Size(400, 50);
            finalCreateTeamButton.Text = "Create Team";
            finalCreateTeamButton.UseVisualStyleBackColor = true;
            this.Controls.Add(finalCreateTeamButton);
            finalCreateTeamButton.Click += FinalCreateTeamButton_Click;

        }

        

        private void CreateMemberButton_Click(object sender, EventArgs e)
        {
            bool valid = ValidateForm();
            if (valid)
            {
                PersonModel person = new PersonModel();
                person.FirstName = PersonFirstNameTextBox.Text;
                person.LastName = PersonLastNameTextBox.Text;
                person.PhoneNumber = PersonPhoneNumberTextBox.Text;
                person.EmailAdress = PersonEmailAddressTextBox.Text;
                person = GlobalConfig.connection.CreatePerson(person);
                ResetValues();
                selectedTeamMembers.Add(person);
                WireUpLists();

            }
            else
            {
                MessageBox.Show("This form has invalid information");
            }
        }

        private bool ValidateForm()
        {
            bool valid = true;
            if (PersonFirstNameTextBox.Text.Length <= 0 || PersonFirstNameTextBox.Text.Length > 25)
            {
                valid = false;
            }
            if (PersonLastNameTextBox.Text.Length <= 0 || PersonLastNameTextBox.Text.Length > 25)
            {
                valid = false;
            }
            if (PersonPhoneNumberTextBox.Text.Length <= 0 || PersonPhoneNumberTextBox.Text.Length > 20)
            {
                valid = false;
            }
            if (PersonEmailAddressTextBox.Text.Length <= 0 || PersonEmailAddressTextBox.Text.Length > 35)
            {
                valid = false;
            }
            return valid;
        }

        private void ResetValues()
        {
            PersonFirstNameTextBox.Text = string.Empty;
            PersonLastNameTextBox.Text = string.Empty;
            PersonPhoneNumberTextBox.Text = string.Empty;
            PersonEmailAddressTextBox.Text = string.Empty;
        }

        private void SelectMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)addPersonDropdown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                addPersonDropdown.SelectedIndex = 0;
                selectedTeamMembers.Add(p);

                WireUpLists();
                
            }
            

        }

        private void WireUpLists()
        {
            addPersonDropdown.DataSource = null;
            addPersonDropdown.DataSource = availableTeamMembers;
            addPersonDropdown.DisplayMember = "FullName";
            addPersonDropdown.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            peopleInTeamListBox.DataSource = null;
            peopleInTeamListBox.DataSource = selectedTeamMembers;
            peopleInTeamListBox.DisplayMember = "FullName";
        }

        

        private void PopulateAllPeopleDropDown()
        {
            availableTeamMembers = GlobalConfig.connection.GetAllPerson();
        }

        private void RemovePersonButton_Click(object sender, EventArgs e)
        {

            PersonModel p = (PersonModel) peopleInTeamListBox.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);
                WireUpLists();
            }

        }

        private void FinalCreateTeamButton_Click(object sender, EventArgs e)
        {
            if (ValidateTeam())
            {
                TeamModel team = new TeamModel { TeamMembers = selectedTeamMembers, TeamName = teamNameTextBox.Text };
                team = GlobalConfig.connection.CreateTeam(team);
                ResetAllValues();
            }
            else
            {
                MessageBox.Show("This form has invalid information");
            }
            
        }

        private void ResetAllValues()
        {
            int count = selectedTeamMembers.Count;
            for(int i = 0; i < count; i++)
            {
                PersonModel person = selectedTeamMembers[0];
                selectedTeamMembers.Remove(person);
                availableTeamMembers.Add(person);
            }
            teamNameTextBox.Text = string.Empty;
            ResetValues();
            WireUpLists();
        }

        private bool ValidateTeam()
        {
            bool valid = true;
            if(selectedTeamMembers.Count == 0)
            {
                valid = false;
            }
            if(teamNameTextBox.Text.Length <= 0 || teamNameTextBox.Text.Length > 50) 
            {
                valid = false;
            }
            return valid;
        }
    }
}
