using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMICalculator
{
    public partial class BMICalculatorForm : Form
    {
        public TextBox ActiveTextBox { get; set; }
        public BMICalculatorForm()
        {
            InitializeComponent();
        }

        private void ActiveTextBox_click(object sender, EventArgs e)
        {
            ActiveTextBox = sender as TextBox;
        }

        private void BMICalculatorForm_Load(object sender, EventArgs e)
        {
            ActiveTextBox = HeightTextBox;
        }

        private void AllButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var tag = button.Tag.ToString();
            bool numericValue;
            int numericButton;
            numericValue = int.TryParse(tag, out numericButton);
            if (numericValue)
            {
                ActiveTextBox.Text += tag;
            }
            else if (tag == "clear")
            {
                HeightTextBox.Text = "";
                WeightTextBox.Text = "";
                ResultTextBox.Text = "";
                ScaleTextBox.Text = "";
            }
            else if (tag == "back")
            {
                if(ActiveTextBox.Text.Length != 0)
                {
                    ActiveTextBox.Text = ActiveTextBox.Text.Remove(ActiveTextBox.Text.Length - 1);
                }
                else
                {

                }
            }
        }
    }
}
