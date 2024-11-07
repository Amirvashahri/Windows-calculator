using System;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        string input = string.Empty;
        string oprand1 = string.Empty;
        string oprand2 = string.Empty;
        char operation;
        double result = 0.0;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;  // Allow the form to capture keyboard input
            this.textBox1.KeyDown += new KeyEventHandler(txtDisplay_KeyDown);  // Make sure this is attached
        }


        private void Number_click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += (sender as Button).Text;
            this.textBox1.Text+=input;
        }
        //private void one_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += "1";
        //    this.textBox1.Text+=input;
        //}
        //private void two_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += "2";
        //    this.textBox1.Text+=input;
        //}
        //private void three_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += "3";
        //    this.textBox1.Text+=input;
        //}
        //private void four_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += "4";
        //    this.textBox1.Text+=input;
        //}
        //private void five_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += "5";
        //    this.textBox1.Text+=input;
        //}
        //private void six_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += "6";
        //    this.textBox1.Text+=input;
        //}
        //private void seven_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += "7";
        //    this.textBox1.Text+=input;
        //}
        //private void eight_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += "8";
        //    this.textBox1.Text+=input;
        //}
        //private void nine_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += "9";
        //    this.textBox1.Text+=input;
        //}

        //private void dot_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = "";
        //    input += ".";
        //    this.textBox1.Text+=input;
        //}

        /// <summary>
        /// This Methode Clear Current number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_Click(object sender, EventArgs e)
        {

            this.textBox1.Text = "";
            this.input = string.Empty;
            this.oprand1 = string.Empty;
            this.oprand2 = string.Empty;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            
            oprand1 = input;
            operation = (sender as Button).Text[0];
            input = string.Empty;
        }

        //private void minus_Click(object sender, EventArgs e)
        //{
        //    oprand1 = input;
        //    operation = '-';
        //    input = string.Empty;
        //}

        //private void division_Click(object sender, EventArgs e)
        //{
        //    oprand1 = input;
        //    operation = '/';
        //    input = string.Empty;
        //}

        //private void multi_Click(object sender, EventArgs e)
        //{
        //    oprand1 = input;
        //    operation = '*';
        //    input = string.Empty;
        //}
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void equals_Click(object sender, EventArgs e)
        {
            oprand2 = input;
            double num1, num2;
            double.TryParse(oprand1, out num1);
            double.TryParse(oprand2, out num2);
            this.textBox1.Text="";
            this.input = String.Empty;
            this.oprand1 = string.Empty;
            this.oprand2 = string.Empty;

            if (operation == '+')
            {
                result = num1 + num2;
                textBox1.Text = result.ToString();
            }
            else if (operation == '-')
            {
                result = num1 - num2;
                textBox1.Text = result.ToString();
            }
            else if (operation == '/')
            {
                if (num2 !=0)
                {
                    result = num1 /num2 ;
                    textBox1.Text = result.ToString();
                }
                else
                {
                    textBox1.Text = "DIV/Zero!";
                }
            }
            else if (operation == '*')
            {
                result = num1 * num2;
                textBox1.Text = result.ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SIN_Button_Click(object sender, EventArgs e)
        {
            double angle = double.Parse(textBox1.Text);

            // Convert degrees to radians (Math.Sin expects radians)
            double radians = angle * Math.PI / 180;
            double result = Math.Sin(radians);

            textBox1.Text = result.ToString();
        }

        private void COS_Button_Click(object sender, EventArgs e)
        {
            double angle = double.Parse(textBox1.Text);

            // Convert degrees to radians (Math.Cos expects radians)
            double radians = angle * Math.PI / 180;
            double result = Math.Cos(radians);

            textBox1.Text = result.ToString();
        }
        private void txtDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, operators (+, -, *, /), and the decimal point
            if (char.IsDigit(e.KeyChar) || "+-*/().".Contains(e.KeyChar.ToString()) || e.KeyChar == (char)Keys.Back)
            {
                // Allow these keys (backspace is handled by default)
                e.Handled = false;
            }
            else
            {
                // Block other characters
                e.Handled = true;
            }
        }
        private void txtDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            // If the Enter key is pressed, we evaluate the expression
            if (e.KeyCode == Keys.Enter)
            {
                // Get the expression from the TextBox
                string expression = textBox1.Text;

                // Sanitize (remove spaces) from the expression
                expression = expression.Replace(" ", "");

                try
                {
                    // Try to evaluate the expression
                    var result = EvaluateExpression(expression);

                    // Show the result in the TextBox
                    textBox1.Text = result.ToString();
                }
                catch (InvalidOperationException ex)
                {
                    // If there's an error (e.g., invalid expression), show a detailed error message
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Check if the "C" key is pressed (to clear the TextBox)
                if (e.KeyCode == Keys.C)
                {
                    // Clear the TextBox when "C" is pressed
                    textBox1.Clear();
                }

                // Check if Backspace key is pressed to remove the last character
                if (e.KeyCode == Keys.Back)
                {
                    if (textBox1.Text.Length > 0)
                    {
                        // Remove last character in TextBox
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                    }
                }
            }
        }
    

    
        public object EvaluateExpression(string expression)
        {
            // 1. Check if the expression contains only valid characters (digits, operators, and parentheses).
            foreach (char c in expression)
            {
                if (!char.IsDigit(c) && !"+-*/().".Contains(c.ToString()))  // Valid characters: digits, operators, and parentheses
                {
                    throw new InvalidOperationException("The expression contains invalid characters.");
                }
            }

            // 2. Create a new DataTable instance to compute the expression
            DataTable table = new DataTable();

            try
            {
                // 3. Use DataTable.Compute to evaluate the expression
                return table.Compute(expression, string.Empty);
            }
            catch (Exception ex)
            {
                // 4. If an error occurs during evaluation, throw an exception
                throw new InvalidOperationException("Error in evaluating the expression: " + ex.Message);
            }
        }

        private void TAN_Button_Click(object sender, EventArgs e)
        {
            try
            {
                double angle = double.Parse(textBox1.Text); // Get the value from the TextBox

                // Convert the angle from degrees to radians
                double radians = angle * Math.PI / 180;

                // Calculate the tangent of the angle
                double result = Math.Tan(radians);

                // Display the result in the TextBox
                textBox1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void COT_Button_Click(object sender, EventArgs e)
        {
            try
            {
                double angle = double.Parse(textBox1.Text); // Get the value from the TextBox

                // Convert the angle from degrees to radians
                double radians = angle * Math.PI / 180;

                // Calculate the tangent of the angle
                double tanResult = Math.Tan(radians);

                // Check if tan(x) is near 0 (i.e., undefined for cot(x))
                if (Math.Abs(tanResult) < 1e-10) // Epsilon for small values close to zero
                {
                    textBox1.Text = "Undefined"; // Display "Undefined" when cot(x) is undefined
                }
                else
                {
                    // Calculate cotangent (1 / tan(x))
                    double result = 1 / tanResult;
                    textBox1.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openParenthesis_Click(object sender, EventArgs e)
        {
            // Add '(' to the input string
            input += "(";
            textBox1.Text = input;
        }

        private void closeParenthesis_Click(object sender, EventArgs e)
        {
            // Add ')' to the input string
            input += ")";
            textBox1.Text = input;
        }
    }


}

