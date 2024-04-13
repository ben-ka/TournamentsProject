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
    public partial class CreatePrizeForm : Form
    {
        private TextBox placeNumberTextBox; // Initialized in CreatePrizeForm_Load
        private TextBox placeNameTextBox; // Initialized in CreatePrizeForm_Load
        private TextBox prizeAmountTextBox; // Initialized in CreatePrizeForm_Load
        private TextBox prizePercentageTextBox; // Initialized in CreatePrizeForm_Load

        private Button finalCreatePrizeButton; // Initialized in CreatePrizeForm_Load


        static Color mainColor = Color.FromArgb(51, 153, 255);
        Font HeaderLabelsFont = new Font("Segoe UI", 20);


        public CreatePrizeForm()
        {
            InitializeComponent();
            this.Load += CreatePrizeForm_Load;
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel prizeModel = new PrizeModel();
                prizeModel.PlaceNumber =  int.Parse(placeNumberTextBox.Text);
                prizeModel.PlaceName = placeNameTextBox.Text;
                prizeModel.PrizeAmount = 0;
                prizeModel.PrizePercentage = 0;

                if(prizeAmountTextBox.Text.Length > 0)
                {
                    prizeModel.PrizeAmount = decimal.Parse(prizeAmountTextBox.Text);
                }

                if(prizePercentageTextBox.Text.Length > 0)
                {
                    prizeModel.PrizePercentage = double.Parse(prizePercentageTextBox.Text);
                }
               
                GlobalConfig.connection.CreatePrize(prizeModel);
                
                ResetValues();


            }
            else
            {
                MessageBox.Show("This form has invalid information");
            }

            

        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberTextBox.Text, out placeNumber);
            if (!placeNumberValidNumber || placeNumber < 1)
            {
                output = false;
            }

            if (placeNameTextBox.Text.Length == 0)
            {
                output = false;
            }


            decimal prizeAmount = 0;
            if (prizeAmountTextBox.Text != "0")
            {

                bool prizeAmountValid = decimal.TryParse(prizeAmountTextBox.Text, out prizeAmount);
                if (!prizeAmountValid || prizeAmount < 0)
                {
                    output = false;
                }
            }
            double prizePercentage = 0;
            if (prizePercentageTextBox.Text != "0")
            {

                bool prizePercentageValid = double.TryParse(prizePercentageTextBox.Text, out prizePercentage);
                if (!prizePercentageValid || prizePercentage < 0 || prizePercentage > 100)
                {
                    output = false;
                }
            }

            if (prizePercentage <= 0 && prizeAmount <= 0)
            {
                output = false;
            }

            if(prizeAmountTextBox.Text != "0" && prizePercentageTextBox.Text != "0")
            {
                output = false;
            }


            return output;
        }

        private void ResetValues()
        {
            placeNameTextBox.Text = string.Empty;
            placeNumberTextBox.Text = string.Empty;
            prizeAmountTextBox.Text = "0";
            prizePercentageTextBox.Text = "0";
        }

        private void CreatePrizeForm_Load(object sender, EventArgs e)
        {
            Label createPrizeHeaderLabel = new Label();
            createPrizeHeaderLabel.Text = "Create Prize";
            createPrizeHeaderLabel.ForeColor = mainColor;
            createPrizeHeaderLabel.Location = new Point(250, 30);
            createPrizeHeaderLabel.Size = new Size(200, 50);
            createPrizeHeaderLabel.Font = HeaderLabelsFont;
            this.Controls.Add(createPrizeHeaderLabel);

            // all of the prizes labels
            Label placeNumberLabel = new Label();
            placeNumberLabel.Text = "Place Number";
            placeNumberLabel.ForeColor = mainColor;
            placeNumberLabel.Location = new Point(50, 150);
            placeNumberLabel.Size = new Size(150, 50);
            this.Controls.Add(placeNumberLabel);


            Label placeNameLabel = new Label();
            placeNameLabel.Text = "Place Name";
            placeNameLabel.ForeColor = mainColor;
            placeNameLabel.Location = new Point(50, 225);
            placeNameLabel.Size = new Size(150, 50);
            this.Controls.Add(placeNameLabel);

            Label prizeAmountLabel = new Label();
            prizeAmountLabel.Text = "Prize Amount";
            prizeAmountLabel.ForeColor = mainColor;
            prizeAmountLabel.Location = new Point(50, 300);
            prizeAmountLabel.Size = new Size(150, 50);
            this.Controls.Add(prizeAmountLabel);

            Label orSymbol = new Label();
            orSymbol.ForeColor = mainColor;
            orSymbol.Text = "-Or-";
            orSymbol.Location = new Point(225, 375);
            orSymbol.Size = new Size(75, 30);
            this.Controls.Add(orSymbol);

            Label prizePercentageLabel = new Label();
            prizePercentageLabel.Text = "Prize Percentage";
            prizePercentageLabel.ForeColor = mainColor;
            prizePercentageLabel.Location = new Point(50, 450);
            prizePercentageLabel.Size = new Size(175, 50);
            this.Controls.Add(prizePercentageLabel);


            // all of the prizes input boxes
            placeNumberTextBox = new TextBox();
            placeNumberTextBox.ForeColor = Color.Black;
            placeNumberTextBox.Location = new Point(225, 150);
            placeNumberTextBox.Size = new Size(350, 50);
            this.Controls.Add(placeNumberTextBox);

            placeNameTextBox = new TextBox();
            placeNameTextBox.ForeColor = Color.Black;
            placeNameTextBox.Location = new Point(225, 225);
            placeNameTextBox.Size = new Size(350, 50);
            this.Controls.Add(placeNameTextBox);

            prizeAmountTextBox = new TextBox();
            prizeAmountTextBox.ForeColor = Color.Black;
            prizeAmountTextBox.Text = "0";
            prizeAmountTextBox.Location = new Point(225, 300);
            prizeAmountTextBox.Size = new Size(350, 50);
            this.Controls.Add(prizeAmountTextBox);

            prizePercentageTextBox = new TextBox();
            prizePercentageTextBox.Text = "0";
            prizePercentageTextBox.ForeColor = Color.Black;
            prizePercentageTextBox.Location = new Point(225, 450);
            prizePercentageTextBox.Size = new Size(350, 50);
            this.Controls.Add(prizePercentageTextBox);

            //final create prize button
            finalCreatePrizeButton = new Button();
            finalCreatePrizeButton.ForeColor = mainColor;
            finalCreatePrizeButton.Location = new Point(100, 620);
            finalCreatePrizeButton.Size = new Size(400, 50);
            finalCreatePrizeButton.Text = "Create Prize";
            finalCreatePrizeButton.UseVisualStyleBackColor = true;
            finalCreatePrizeButton.Click += CreatePrizeButton_Click;
            this.Controls.Add(finalCreatePrizeButton);
        }

        
    }
}
