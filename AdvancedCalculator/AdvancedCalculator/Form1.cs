using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdvMathLib;

//Reece Spencer
//P445449
//14/9/17
// Version 2.4

namespace AdvCalculator
{
    public partial class AdvCalc : Form
    {
        public AdvCalc()
        {
            InitializeComponent();
        }

        bool equalPress = false;
        //tests if the equals button is pressed
        //replaces answer when numerical buttons are pressed
        public void EqualPressed()
        {
            if (equalPress)
            {
                Clear();
                equalPress = false;
            }
        }

        //enters text of button to display, to be read later
        private void btnNum1_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum1.Text;
        }

        //enters text of button to display, to be read later
        private void btnNum2_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum2.Text;
        }

        //enters text of button to display, to be read later
        private void btnNum3_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum3.Text;
        }

        //enters text of button to display, to be read later
        private void btnNum4_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum4.Text;
        }

        //enters text of button to display, to be read later
        private void btnNum5_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum5.Text;
        }

        //enters text of button to display, to be read later
        private void btnNum6_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum6.Text;
        }

        //enters text of button to display, to be read later
        private void btnNum7_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum7.Text;
        }

        //enters text of button to display, to be read later
        private void btnNum8_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum8.Text;
        }

        //enters text of button to display, to be read later
        private void btnNum9_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum9.Text;
        }

        //enters text of button to display, to be read later
        private void btnNum0_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnNum0.Text;
        }

        //clears the display and resets equal press
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtboxDisplay.Clear();
            equalPress = false;
        }

        //calls clear method (clears all data), and resets equal press
        private void btnEmpty_Click(object sender, EventArgs e)
        {
            Clear();
            equalPress = false;
        }

        //enters text of button to display, to be read later
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            EqualPressed();
            txtboxDisplay.Text += btnDecimal.Text;
        }

        double calcNumOne = 0;
        double calcNumTwo = 0;
        bool plusClick = false;
        bool minusClick = false;
        bool divideClick = false;
        bool multiplyClick = false;

        //if only negative sign was entered, it clears it
        // or tests if display isnt empty, then calculates data displayed with any other data (if any)
        //stores the display, then clears display and sets sign test as positive
        // or displays an error for missing number
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtboxDisplay.Text == "-")
            {
                txtboxDisplay.Text = "";
            }
            else if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                Equals();
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                txtboxDisplay.Clear();

                plusClick = true;
                minusClick = false;
                divideClick = false;
                multiplyClick = false;
                equalPress = false;
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty, then calculates data displayed with any other data (if any)
        //stores the display, then clears display and sets sign test as positive
        // or puts a negative sign for negative number input
        private void btnSub_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                Equals();
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                txtboxDisplay.Clear();

                plusClick = false;
                minusClick = true;
                divideClick = false;
                multiplyClick = false;
                equalPress = false;
            }
            else
            {
                EqualPressed();
                txtboxDisplay.Text += btnSub.Text;
            }
        }

        //tests if display isnt empty, then calculates data displayed with any other data (if any)
        //stores the display, then clears display and sets sign test as positive
        // or displays an error for missing number
        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                Equals();
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                txtboxDisplay.Clear();

                plusClick = false;
                minusClick = false;
                divideClick = true;
                multiplyClick = false;
                equalPress = false;
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty, then calculates data displayed with any other data (if any)
        //stores the display, then clears display and sets sign test as positive
        // or displays an error for missing number
        private void btnMult_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                Equals();
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                txtboxDisplay.Clear();

                plusClick = false;
                minusClick = false;
                divideClick = false;
                multiplyClick = true;
                equalPress = false;
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty, sets the equal check to positive
        //displays the result of the previous calculation, and resets entry and sign entry
        // or displays an error for missing number
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                equalPress = true;
                Equals();
                txtboxDisplay.Text = calcNumTwo.ToString();
                calcNumOne = 0;
                plusClick = false;
                minusClick = false;
                divideClick = false;
                multiplyClick = false;
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty, tests for which sign was pressed to calculate accordingly
        // or displays an error for missing number
        private void Equals()
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                if (plusClick == true)
                {
                    calcNumTwo = Arithmetic.Add(calcNumOne, DoubleParse(txtboxDisplay.Text));
                }
                else if (minusClick == true)
                {
                    calcNumTwo = Arithmetic.Sub(calcNumOne, DoubleParse(txtboxDisplay.Text));
                }
                else if (divideClick == true)
                {
                    calcNumTwo = Arithmetic.Div(calcNumOne, DoubleParse(txtboxDisplay.Text));
                }
                else if (multiplyClick == true)
                {
                    calcNumTwo = Arithmetic.Mult(calcNumOne, DoubleParse(txtboxDisplay.Text));
                }
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty
        // then it tests if the number is 0 or over, if so it calcuates the square root, then displays result
        // or displays an error saying number must be positive
        //or displays an error for missing number
        private void btnSQRT_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                if (calcNumOne >= 0)
                {
                    txtboxDisplay.Text = Algebraic.SquareRoot(calcNumOne);
                }
                else
                {
                    MessageBox.Show("Number must be positive", "Error Message");
                    txtboxDisplay.Text = "0";
                }
                equalPress = true;
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty
        // then it tests if the number is 0 or over, if so it calcuates the cube root, then displays result
        // or displays an error saying number must be positive
        //or displays an error for missing number
        private void btnCubeRT_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                if (calcNumOne >= 0)
                {
                    txtboxDisplay.Text = Algebraic.CubeRoot(calcNumOne);
                }
                else
                {
                    MessageBox.Show("Number must be positive", "Error Message");
                    txtboxDisplay.Text = "0";
                }
                equalPress = true;
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty, gets the number and inverses it, then displays result
        //or displays an error for missing number
        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                equalPress = true;
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                txtboxDisplay.Text = Algebraic.Inverse(calcNumOne);
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty, gets the number and finds Tan, then displays result
        //or displays an error for missing number
        private void btnTan_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                equalPress = true;
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                txtboxDisplay.Text = Trigonometric.Tan(calcNumOne);
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty, gets the number and finds Sin, then displays result
        //or displays an error for missing number
        private void btnSin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                equalPress = true;
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                txtboxDisplay.Text = Trigonometric.Sin(calcNumOne);
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tests if display isnt empty, gets the number and finds Cos, then displays result
        //or displays an error for missing number
        private void btnCos_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtboxDisplay.Text))
            {
                equalPress = true;
                calcNumOne = DoubleParse(txtboxDisplay.Text);
                txtboxDisplay.Text = Trigonometric.Cos(calcNumOne);
            }
            else
            {
                MessageBox.Show("Missing number", "Error Message");
            }
        }

        //tries to parse, if it succeeds then it returns parsed number
        //if fails displays an error for Invalid number and returns 0
        private double DoubleParse(string input)
        {
            double parsedDouble = 0.0;
            if(double.TryParse(input, out parsedDouble))
            {
                return parsedDouble;
            }
            else
            {
                MessageBox.Show("Invalid Number", "Error Message");
                return 0;
            }
        }

        //comes up with a message box when button is pressed, asking to proceed if so then app exits
        // if not, then it closes message box
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        //clears display
        private void clearentryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtboxDisplay.Clear();
        }

        //calls clear method, clearing all data
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //clear method clears all data
        public void Clear()
        {
            txtboxDisplay.Clear();
            calcNumOne = 0;
            calcNumTwo = 0;
            plusClick = false;
            minusClick = false;
            divideClick = false;
            multiplyClick = false;
        }
    }
}
