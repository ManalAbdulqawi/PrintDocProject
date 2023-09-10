using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

namespace PrintDoc
{
    public partial class Form2 : Form
    {
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();

       //قاعدة البيانات التعريفات الاساسية
        public SqlDataAdapter datadapter;
        public DataTable datable;
        public DataSet ds;
        public static int curec = 0;
        public static int totalrec = 0;
        public SqlConnection conn;
        private void intiacommand()
        {//selectproc_per
            SqlCommand selectcomnd = new SqlCommand("selectproc1", conn);
            selectcomnd.CommandType = CommandType.StoredProcedure;
            datadapter.SelectCommand = selectcomnd;

            //insert
            SqlCommand insertcomnd = new SqlCommand("insertproc1", conn);

            insertcomnd.CommandType = CommandType.StoredProcedure;
            datadapter.InsertCommand = insertcomnd;
            Addparams(datadapter.InsertCommand, "ID",


 "ARDate",
 "ENDate",
 "Branch",
 "TransferType",
 "CustomerName",
 "CustomerAddData",
 "AccountNo",
 "AmountNo",
 "Currency",
 "BeneficiaryName",


 "BeneficiaryAddData",
 "BeneficiaryBank",
 "BankAddData",
 "BeneficiaryACNo",
 "IntermedatiarBank",
 "SwiftCode",
 "Details",

 "PurposeTransfer",
"OtherPuposeTrans");


        }
        private void Addparams(SqlCommand cmd, params string[] cols)
        {
            foreach (string col in cols)
            { cmd.Parameters.Add("@" + col, SqlDbType.NChar, 0, col); }

        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Associate PrintPreviewDialog with PrintDocument.
            printPreviewDialog1.Document = printDocument1;

            // Show PrintPreview Dialog
            printPreviewDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //PrintDialog associate with PrintDocument;
            printDialog1.Document = printDocument1;


            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Times New Roman", 10f, FontStyle.Regular);
            Font font1 = new Font("Times New Roman", 9f, FontStyle.Regular);
            Font font2 = new Font("Times New Roman", 8f, FontStyle.Regular);
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft)
            {
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            string s = this.dateTimePicker1.Value.Date.ToString();
            //ToShortDateString();
            //textBox2.Text=s;
            string s1;
            //s.Substring(1, 1);
            // if (s1 == "/")
            {
                // s1 = s.Substring(0, 1);
                s1 = this.dateTimePicker1.Value.Date.Day.ToString();
                e.Graphics.DrawString(s1, font, Brushes.Black, (float)540f, (float)140);
                // s1 = s.Substring(2, 2);
                s1 = this.dateTimePicker1.Value.Date.Month.ToString();
                e.Graphics.DrawString(s1, font, Brushes.Black, (float)490f, (float)140);
                // s1 = s.Substring(5, 4);
                s1 = this.dateTimePicker1.Value.Date.Year.ToString();
                e.Graphics.DrawString(s1, font, Brushes.Black, (float)440f, (float)140);
            }
            /*   else
               {
                   s1 = s.Substring(0, 2);
                   e.Graphics.DrawString(s1, font, Brushes.Black, (float)540f, (float)140);
                   s1 = s.Substring(3, 2);
                   e.Graphics.DrawString(s1, font, Brushes.Black, (float)490f, (float)140);
                   s1 = s.Substring(6, 4);
                   e.Graphics.DrawString(s1, font, Brushes.Black, (float)440f, (float)140);
               }*/

            s1 = maskedTextBox1.Text.Substring(1, 1);
            if (s1 == "/")
            {
                s1 = maskedTextBox1.Text.Substring(0, 1);
                e.Graphics.DrawString(s1, font, Brushes.Black, (float)710f, (float)140);
                s1 = maskedTextBox1.Text.Substring(2, 2);
                e.Graphics.DrawString(s1, font, Brushes.Black, (float)660f, (float)140);
                s1 = maskedTextBox1.Text.Substring(5, 4);
                e.Graphics.DrawString(s1, font, Brushes.Black, (float)610f, (float)140);
            }
            else
            {
                s1 = maskedTextBox1.Text.Substring(0, 2);
                e.Graphics.DrawString(s1, font, Brushes.Black, (float)710f, (float)140);
                s1 = maskedTextBox1.Text.Substring(3, 2);
                e.Graphics.DrawString(s1, font, Brushes.Black, (float)660f, (float)140);
                s1 = maskedTextBox1.Text.Substring(6, 4);
                e.Graphics.DrawString(s1, font, Brushes.Black, (float)610f, (float)140);
            }
            e.Graphics.DrawString(textBox2.Text, font, Brushes.Black, (float)340f, (float)140, format);
            Image image = Image.FromFile(Application.StartupPath + @"\img\rr.png");
            Point point = new Point(752, 210);
            if (this.radioButton1.Checked)
            {
                e.Graphics.DrawImage(image, point);
            }

            if (this.radioButton2.Checked)
            {
                point = new Point(441, 210);
                e.Graphics.DrawImage(image, point);
            }

            if (this.radioButton3.Checked)
            {
                point = new Point(300, 210);
                e.Graphics.DrawImage(image, point);
            }
            if (this.radioButton4.Checked)
            {
                point = new Point(170, 210);
                e.Graphics.DrawImage(image, point);
            }
            if (textBox3.Text.Length < 40)
            { e.Graphics.DrawString(textBox3.Text, font1, Brushes.Black, (float)670f, (float)248, format); }
            if (textBox3.Text.Length >= 40)
            { e.Graphics.DrawString(textBox3.Text, font2, Brushes.Black, (float)670f, (float)245, format); }
            if (textBox4.Text.Length <= 30)
            { e.Graphics.DrawString(textBox4.Text, font1, Brushes.Black, (float)250f, (float)245, format); }
            if (textBox4.Text.Length > 30)
            { e.Graphics.DrawString(textBox4.Text, font2, Brushes.Black, (float)250f, (float)245, format); }
            e.Graphics.DrawString(textBox5.Text, font, Brushes.Black, (float)670f, (float)275, format);
            e.Graphics.DrawString(textBox6.Text, font, Brushes.Black, (float)270f, (float)275, format);

            //e.Graphics.DrawString(cboCurrency.Text, font, Brushes.Black, (float)70f, (float)275, format);
            if (this.cboCurrency.SelectedValue.ToString() == "0")
            {
                e.Graphics.DrawString("USD", font, Brushes.Black, (float)70f, (float)275, format);
                //e.Graphics.DrawString("U.S. dollar", font4, Brushes.Black, (float)715f, (float)295f);
            }
            if (this.cboCurrency.SelectedValue.ToString() == "2")
            {
                e.Graphics.DrawString("SAR", font, Brushes.Black, (float)70f, (float)275, format);
                //e.Graphics.DrawString("Saudi Riyal", font4, Brushes.Blue, (float)715f, (float)295f);
            }
            if (this.cboCurrency.SelectedValue.ToString() == "1")
            {
                e.Graphics.DrawString("UAE", font, Brushes.Black, (float)70f, (float)275, format);
               // e.Graphics.DrawString("UAE Dirham", font4, Brushes.Blue, (float)715f, (float)295f);
            }
            e.Graphics.DrawString(textBox7.Text, font, Brushes.Black, (float)670f, (float)310, format);
            e.Graphics.DrawString(textBox12.Text, font, Brushes.Black, (float)670f, (float)375, format);
            e.Graphics.DrawString(textBox11.Text, font, Brushes.Black, (float)620f, (float)405, format);
            e.Graphics.DrawString(textBox10.Text, font, Brushes.Black, (float)650f, (float)435, format);
            if (textBox13.Text.Length <= 30)
            { e.Graphics.DrawString(textBox13.Text, font1, Brushes.Black, (float)650f, (float)465, format); }
            if (textBox13.Text.Length > 30)
            { e.Graphics.DrawString(textBox13.Text, font2, Brushes.Black, (float)650f, (float)465, format); }
            if (textBox8.Text.Length <= 30)
            { e.Graphics.DrawString(textBox8.Text, font1, Brushes.Black, (float)650f, (float)495, format); }
            if (textBox8.Text.Length > 30)
            { e.Graphics.DrawString(textBox8.Text, font2, Brushes.Black, (float)650f, (float)495, format); }
            e.Graphics.DrawString(textBox9.Text, font, Brushes.Black, (float)270f, (float)460, format);
            e.Graphics.DrawString(textBox14.Text, font, Brushes.Black, (float)300f, (float)490, format);
            e.Graphics.DrawString(textBox15.Text, font, Brushes.Black, (float)740f, (float)555, format);
            if (this.radioButton10.Checked)
            {
                point = new Point(752, 627);
                e.Graphics.DrawImage(image, point);
            }
            if (this.radioButton9.Checked)
            {
                point = new Point(570, 627);
                e.Graphics.DrawImage(image, point);
            }
            if (this.radioButton8.Checked)
            {
                point = new Point(466, 627);
                e.Graphics.DrawImage(image, point);
                e.Graphics.DrawString(textBox16.Text, font, Brushes.Black, (float)380f, (float)630, format);
            }
           
            if (this.radioButton7.Checked)
            {
                point = new Point(206, 627);
                e.Graphics.DrawImage(image, point);
            }
            //////////////////////////////
            if (this.radioButton14.Checked)
            {
                point = new Point(752, 655);
                e.Graphics.DrawImage(image, point);
            }
            if (this.radioButton13.Checked)
            {
                point = new Point(570, 655);
                e.Graphics.DrawImage(image, point);
            }
            if (this.radioButton12.Checked)
            {
                point = new Point(466, 655);
                e.Graphics.DrawImage(image, point);
            }
           // e.Graphics.DrawString(textBox16.Text, font, Brushes.Black, (float)400f, (float)630, format);
            if (this.radioButton11.Checked)
            {
                point = new Point(206, 655);
                e.Graphics.DrawImage(image, point);
            }
            if (this.radioButton16.Checked)
            {
                point = new Point(206, 685);
                e.Graphics.DrawImage(image, point);
            }
            if (this.radioButton15.Checked)
            {
                point = new Point(752, 685);
                e.Graphics.DrawImage(image, point);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DateTimeFormatInfo DTFormat = new CultureInfo("ar-sa", false).DateTimeFormat;
            DTFormat.Calendar = new HijriCalendar();
            DTFormat.ShortDatePattern = "dd/mm/yyyy";

            string myDate = DateTime.Today.Date.ToString("D", DTFormat);
            maskedTextBox1.Text = myDate;

            //////////////
            this.currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.USA));
            this.currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.UAE));
            this.currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
            this.cboCurrency.DataSource = this.currencies;

            this.cboCurrency_DropDownClosed(null, null);
 
        }

        private void cboCurrency_DropDownClosed(object sender, EventArgs e)
        {
            textBox6_TextChanged(null, null);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ToWord toWord = new ToWord(Convert.ToDecimal(textBox6.Text), currencies[Convert.ToInt32(cboCurrency.SelectedValue)]);
                //  txtEnglishWord.Text = toWord.ConvertToEnglish();
                if (radioButton5.Checked == true)
                {
                    textBox7.Text = toWord.ConvertToArabic();
                }
                if (radioButton6.Checked == true)
                {
                    textBox7.Text = toWord.ConvertToEnglish();
                }
            }
            catch (Exception ex)
            {
                // txtEnglishWord.Text = String.Empty;
                textBox7.Text = String.Empty;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ToWord toWord = new ToWord(Convert.ToDecimal(textBox6.Text), currencies[Convert.ToInt32(cboCurrency.SelectedValue)]);
                //  txtEnglishWord.Text = toWord.ConvertToEnglish();
                if (radioButton5.Checked == true)
                {
                    textBox7.Text = toWord.ConvertToArabic();
                }
                if (radioButton6.Checked == true)
                {
                    textBox7.Text = toWord.ConvertToEnglish();
                }
                
            }
            catch (Exception ex)
            {
                // txtEnglishWord.Text = String.Empty;
                textBox7.Text = String.Empty;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ToWord toWord = new ToWord(Convert.ToDecimal(textBox6.Text), currencies[Convert.ToInt32(cboCurrency.SelectedValue)]);
                //  txtEnglishWord.Text = toWord.ConvertToEnglish();
                if (radioButton5.Checked == true)
                {
                    textBox7.Text = toWord.ConvertToArabic();
                }
                if (radioButton6.Checked == true)
                {
                    textBox7.Text = toWord.ConvertToEnglish();
                }
            }
            catch (Exception ex)
            {
                // txtEnglishWord.Text = String.Empty;
                textBox7.Text = String.Empty;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DBSetting.con == null)
            {
                DBSetting.CreateConnection();
            }
            conn = DBSetting.con;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            try
            {
            //    conn.Open();
                datadapter = new SqlDataAdapter();
                intiacommand();
                


                ds = new DataSet();
                datadapter.Fill(ds, "Table5");
                datable = ds.Tables["Table5"];
                DataRow row = datable.NewRow();
                datable.Rows.Add(row);
                totalrec = datable.Rows.Count;
               curec = totalrec -1;
                //////////////////
               
               SqlCommand command = new SqlCommand("select max(ID) from Table5 ", conn);
               int lastId = (int)command.ExecuteScalar();
               row["ID"] = lastId + 1;
                   
                row.BeginEdit();
                row["ARDate"] = maskedTextBox1.Text;
                row["ENDate"] = this.dateTimePicker1.Value.Date.ToString("MM/dd/yyyy");
                row["Branch"] = textBox2.Text;
                if (radioButton1.Checked == true)
                { row["TransferType"] = '1'; }
                if (radioButton2.Checked == true)
                { row["TransferType"] = '2'; }
                if (radioButton3.Checked == true)
                { row["TransferType"] = '3'; }
                if (radioButton4.Checked == true)
                { row["TransferType"] = '4'; }
                row["CustomerName"] = textBox3.Text;
                row["CustomerAddData"] = textBox4.Text;
                row["AccountNo"] = textBox5.Text;
                row["AmountNo"] = textBox6.Text;
                if (this.cboCurrency.SelectedValue.ToString() == "0")
                {
                    row["Currency"] = "USD";

                }
                if (this.cboCurrency.SelectedValue.ToString() == "2")
                {
                    row["Currency"] = "SAR";

                }
                if (this.cboCurrency.SelectedValue.ToString() == "1")
                {
                    row["Currency"] = "UAE";

                }
                row["BeneficiaryName"] = textBox12.Text;
                row["BeneficiaryAddData"] = textBox11.Text;
                row["BeneficiaryBank"] = textBox10.Text;
                row["BankAddData"] = textBox13.Text;
                row["BeneficiaryACNo"] = textBox9.Text;
                row["IntermedatiarBank"] = textBox8.Text;
                row["SwiftCode"] = textBox14.Text;
                row["Details"] = textBox15.Text;
               
                if (radioButton10.Checked == true)
                { row["PurposeTransfer"] = '0'; }
                if (radioButton9.Checked == true)
                { row["PurposeTransfer"] = '1'; }
                if (radioButton8.Checked == true)
                { row["PurposeTransfer"] = '2';
                row["OtherPuposeTrans"] = textBox16.Text;
                }
                if (radioButton7.Checked == true)
                { row["PurposeTransfer"] = '3'; }
                if (radioButton14.Checked == true)
                { row["PurposeTransfer"] = '4'; }
                if (radioButton13.Checked == true)
                { row["PurposeTransfer"] = '5'; }
                if (radioButton12.Checked == true)
                { row["PurposeTransfer"] = '6'; }
                if (radioButton11.Checked == true)
                { row["PurposeTransfer"] = '7'; }
                if (radioButton15.Checked == true)
                { row["PurposeTransfer"] = '8'; }
                if (radioButton16.Checked == true)
                { row["PurposeTransfer"] = '9'; }
                



                row.EndEdit();

                datadapter.Update(ds, "Table5");
                ds.AcceptChanges();
                MessageBox.Show("لقد تم حفـظ البيانات", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting the help desk request! Please " +
                        "try again later, and/or change the entered data!    /r/n/r/n" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            search f2 = new search();
            this.Hide();
            //f2.MdiParent = this;
            f2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(@"img\", "Instruction.txt"));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo DTFormat = new CultureInfo("ar-sa", false).DateTimeFormat;
            DTFormat.Calendar = new HijriCalendar();
            DTFormat.ShortDatePattern = "dd/mm/yyyy";

            string myDate = DateTime.Today.Date.ToString("D", DTFormat);
            maskedTextBox1.Text = myDate;
            textBox2.Text = "";

            radioButton1.Checked = false;

            radioButton2.Checked = false;

            radioButton3.Checked = false;

            radioButton4.Checked = false;
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox12.Text ="";
            cboCurrency.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox13.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";

            radioButton9.Checked = false;

            radioButton8.Checked = false;

            radioButton7.Checked = false;
            
            radioButton14.Checked = false;
           
            radioButton10.Checked = false;

            radioButton13.Checked = false;

            radioButton12.Checked = false;

            radioButton11.Checked = false;

            radioButton15.Checked = false;

            radioButton16.Checked = false;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox3.Text == "") && (this.textBox2.Text != ""))
                {
                    this.textBox3.Focus();
                }
                else
                {
                    this.textBox2.Focus();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox4.Text == "") && (this.textBox3.Text != ""))
                {
                    this.textBox4.Focus();
                }
                else
                {
                    this.textBox3.Focus();
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox5.Text == "") && (this.textBox4.Text != ""))
                {
                    this.textBox5.Focus();
                }
                else
                {
                    this.textBox4.Focus();
                }
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox6.Text == "") && (this.textBox5.Text != ""))
                {
                    this.textBox6.Focus();
                }
                else
                {
                    this.textBox5.Focus();
                }
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox12.Text == "") && (this.textBox6.Text != ""))
                {
                    this.textBox12.Focus();
                }
                else
                {
                    this.textBox6.Focus();
                }
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox11.Text == "") && (this.textBox12.Text != ""))
                {
                    this.textBox11.Focus();
                }
                else
                {
                    this.textBox12 .Focus();
                }
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox10.Text == "") && (this.textBox11.Text != ""))
                {
                    this.textBox10.Focus();
                }
                else
                {
                    this.textBox11.Focus();
                }
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox13.Text == "") && (this.textBox10.Text != ""))
                {
                    this.textBox13.Focus();
                }
                else
                {
                    this.textBox10.Focus();
                }
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox9.Text == "") && (this.textBox13.Text != ""))
                {
                    this.textBox9.Focus();
                }
                else
                {
                    this.textBox13.Focus();
                }
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox8.Text == "") && (this.textBox9.Text != ""))
                {
                    this.textBox8.Focus();
                }
                else
                {
                    this.textBox9.Focus();
                }
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox14.Text == "") && (this.textBox8.Text != ""))
                {
                    this.textBox14.Focus();
                }
                else
                {
                    this.textBox8.Focus();
                }
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((this.textBox15.Text == "") && (this.textBox14.Text != ""))
                {
                    this.textBox15.Focus();
                }
                else
                {
                    this.textBox14.Focus();
                }
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
                textBox16.Enabled = true;
            else
            {
                textBox16.Enabled = false;
                textBox16.Text = "";
            }
        }
       
    }
}
