using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchAPair
{
    public partial class Form1 : Form
    {

        Label firstClicked = null;
        Label secondClicked = null;

        Random random = new Random();

        List<string> symbols = new List<string>()
        {
            "!", "!","i", "i", "/", "/", "[", "[",
            "f", "f", "%", "%", "^", "^", "y", "y"
        };
        public Form1()
        {
            InitializeComponent();
            AssignIconToSquares();
        }

        private void AssignIconToSquares()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label symbolLabel = control as Label;
                if(symbolLabel != null)
                {
                    int randomNumber = random.Next(symbols.Count);
                    symbolLabel.Text = symbols[randomNumber];

                    symbolLabel.ForeColor = symbolLabel.BackColor;

                    symbols.RemoveAt(randomNumber);

                }
            }
        }

        private void label_click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if(clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                //clickedLabel.ForeColor = Color.Black;

                if(firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if(firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();

                
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label symbolLabel = control as Label;

                if(symbolLabel != null)
                {
                    if (symbolLabel.ForeColor == symbolLabel.BackColor)
                        return;
                }

            }

            MessageBox.Show("ICONIC! You matched all the icons", "Welldone!!!");
            Close();
        }
    }
}
