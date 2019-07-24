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
        public double BMIResult { get; set; }
        public bool NumericValue { get; set; }
        //public string tag = button.Tag.ToString();
        //public int NumericButton { get; set; }
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
            string tag = button.Tag.ToString();
            NumericValue = int.TryParse(tag, out int numericButton);
            if (NumericValue)
            {
                ActiveTextBox.Text += tag;
            }
            else if (tag == "clear")
            {
                ClearAll();
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
            else if(tag == "calculate")
            {
                CalculateBMI();
                DisplayScale();
            }
        }
        private void ClearAll()
        {
            HeightTextBox.Text = "";
            WeightTextBox.Text = "";
            ResultTextBox.Text = "";
            ScaleTextBox.Text = "";
        }
        private void CalculateBMI()
        {
            bool heightIsNumeric = int.TryParse(HeightTextBox.Text, out int yourHeight);
            bool weightIsNumeric = int.TryParse(WeightTextBox.Text, out int yourWeight);
            if (HeightTextBox.Text != "" && WeightTextBox.Text != "" && heightIsNumeric && weightIsNumeric)
            {
                double height = Convert.ToDouble(HeightTextBox.Text);
                double weight = Convert.ToDouble(WeightTextBox.Text);
                //double bmi;
                if (MetricButton.Checked == true)
                {
                    BMIResult = weight / (height * height / 10000);
                    ResultTextBox.Text = string.Format($"{BMIResult:F2}").ToString();
                }
                else if (ImperialButton.Checked == true)
                {
                    BMIResult = (weight * 703) / (height * height);
                    ResultTextBox.Text = string.Format($"{BMIResult:F2}").ToString();
                }
            }
            else
            {

            }
        }
        private void DisplayScale()
        {
            if(BMIResult >0 && BMIResult < 18.5)
            {
                ScaleTextBox.Text = "Underweight";
            }
            else if(BMIResult >=18.5 && BMIResult < 25)
            {
                ScaleTextBox.Text = "Normal";
            }
            else if (BMIResult >= 25 && BMIResult < 30)
            {
                ScaleTextBox.Text = "Overweight";
            }
            else if (BMIResult >= 30)
            {
                ScaleTextBox.Text = "Obese";
            }
        }
    }
}
