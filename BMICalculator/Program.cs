using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/*Assignment 4, BMI Calculator
 * MUHAMMAD SHIBLEE
 * 301064587
 * Last modified on 24 July, 2019
 */
namespace BMICalculator
{
    static class Program
    {
        public static WelcomeForm welcomeForm;
        public static BMICalculatorForm bmiCalculatorForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            welcomeForm = new WelcomeForm();
            bmiCalculatorForm = new BMICalculatorForm(); 
            //Application.EnableVisualStyles();
           
            Application.Run(new WelcomeForm());
        }
    }
}
