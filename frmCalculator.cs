using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            textDisplay.Text = "0";
        }
        private void btnSubtrack_Click(object sender, EventArgs e) { textDisplay.Text += "-"; }

        private void textDisplay_TextChanged(object sender, EventArgs e)
        {
        }

        // تابع کمکی برای چسباندن اعداد و صفر
        private void AppendDigit(string digit)
        {
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = digit;
            }
            else
            {
                textDisplay.Text += digit;
            }
        }

        // دکمه‌های اعداد (۰ تا ۹)
        private void btn0_Click(object sender, EventArgs e) { AppendDigit("0"); }
        private void btn1_Click(object sender, EventArgs e) { AppendDigit("1"); }
        private void btn2_Click(object sender, EventArgs e) { AppendDigit("2"); }
        private void btn3_Click(object sender, EventArgs e) { AppendDigit("3"); }
        private void btn4_Click(object sender, EventArgs e) { AppendDigit("4"); }
        private void btn5_Click(object sender, EventArgs e) { AppendDigit("5"); }
        private void btn6_Click(object sender, EventArgs e) { AppendDigit("6"); }
        private void btn7_Click(object sender, EventArgs e) { AppendDigit("7"); }
        private void btn8_Click(object sender, EventArgs e) { AppendDigit("8"); }
        private void btn9_Click(object sender, EventArgs e) { AppendDigit("9"); }

        // دکمه ممیز
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!textDisplay.Text.EndsWith("."))
            {
                textDisplay.Text += ".";
            }
        }

        // دکمه‌های عملگر
        private void btnSum_Click(object sender, EventArgs e) { textDisplay.Text += "+"; }
        private void btnDubtrack_Click(object sender, EventArgs e) { textDisplay.Text += "-"; }
        private void btnMultiple_Click(object sender, EventArgs e) { textDisplay.Text += "×"; }
        private void btnDivide_Click(object sender, EventArgs e) { textDisplay.Text += "÷"; }

        // دکمه پاک کردن (C)
        private void btnClear_Click(object sender, EventArgs e)
        {
            textDisplay.Text = "0";
        }

        // دکمه مساوی (=) - بخش محاسبه هوشمند
        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = textDisplay.Text;

                // تبدیل علامت‌های ظاهری به علامت‌های استاندارد ریاضی سیستم
                expression = expression.Replace("×", "*");
                expression = expression.Replace("÷", "/");

                // محاسبه کل عبارت به صورت یکجا
                var result = new DataTable().Compute(expression, null);

                // نمایش جواب روی صفحه
                textDisplay.Text = result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid mathematical expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}