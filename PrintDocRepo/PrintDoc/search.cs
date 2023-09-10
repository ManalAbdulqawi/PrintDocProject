using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

namespace PrintDoc
{
    public partial class search : Form
    {
        int num;
        public SqlConnection conn;
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();
        SqlDataAdapter dataadapter;
        DataSet ds;
        string sql;
        int rowindex = -1;
        //Char[] d;
        //Char[] ary;
        //DateTimePicker dtporder;
       // SqlCommand newcelval;
      
       // string cloumname;
        //int newkey;

        //string newdata;
    
        public search()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            if (DBSetting.con == null)
            {
                DBSetting.CreateConnection();
            }
           // conn = DBSetting.con;
            
            //conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");
            //conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\newv3\\PrintDoc\\PrintDoc\\Datab.mdf;Integrated Security=True;User Instance=True;");
            //Data Source=.\SQLEXPRESS;AttachDbFilename=E:\newv3\PrintDoc\PrintDoc\Datab.mdf;Integrated Security=True;User Instance=True
            //conn.Open();
          //  conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\MohData.mdf;Integrated Security=True;User Instance=True;");
           // conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");

            if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                if (textBox1.Text != "")
                {


                   // if (conn.State == ConnectionState.Closed)
                    
                       // conn.Open();

                        sql = string.Format("select * from Table5 where BeneficiaryName like N'{0}%'", textBox1.Text);
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open(); 
                    dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                    
                   
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("لاتوجد بيانات  " ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        
                        conn.Close();
                    // dataGridView1.DataMember = "Table1";
                    // dataGridView1.DataMember = "Table1";
                }
                else
                    MessageBox.Show("الرجاء ادخال الأسم ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (checkBox2.Checked == true && checkBox3.Checked == false && checkBox1.Checked == false)
            {

                if (textBox2.Text != "")
                {


                    if (radioButton1.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'USD'", textBox2.Text);
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                        //conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                        // dataGridView1.DataMember = "Table1";
                    }
                    if (radioButton2.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'SAR'", textBox2.Text);
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                       // conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                        // dataGridView1.DataMember = "Table1";
                    }
                    if (radioButton3.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where  AmountNo = '{0}' and Currency = 'UAE'", textBox2.Text);
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                       // conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                    }

                }
                else
                    MessageBox.Show("الرجاء ادخال قيمة المبلغ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (checkBox3.Checked == true && checkBox2.Checked == false && checkBox1.Checked == false)
            {

                sql = string.Format("select * from Table5 where ENDate like '{0}'", dateTimePicker1.Value.Date.ToString("MM/dd/yyyy"));

                conn = DBSetting.con;
                if (conn.State == ConnectionState.Closed)
                
                    conn.Open();
                    dataadapter = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();

                    dataadapter.Fill(ds, "Table5");
                    dataGridView1.DataSource = ds.Tables[0];
                
                
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
                // dataGridView1.DataMember = "Table1";
                // dataGridView1.DataMember = "Table1";

            }
           
            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
            {

                if (textBox2.Text != "")
                {


                    if (radioButton1.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'USD' and  BeneficiaryName like N'{1}%'", textBox2.Text, textBox1.Text);
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                        //conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                    }
                    if (radioButton2.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'SAR'and  BeneficiaryName like N'{1}%'", textBox2.Text, textBox1.Text);
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                        //conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                        // dataGridView1.DataMember = "Table1";
                    }
                    if (radioButton3.Checked == true)
                    {
                       
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'UAE'and  BeneficiaryName like N'{1}%'", textBox2.Text, textBox1.Text);
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        DataSet ds = new DataSet();
                       
                       // conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                        // dataGridView1.DataMember = "Table1";
                    }

                }
                else
                    MessageBox.Show("الرجاء ادخال قيمة المبلغ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
            {

                if (textBox2.Text != "")
                {


                    if (radioButton1.Checked == true)
                    {
                       
                       sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'USD' and  ENDate = '{1}'", textBox2.Text, dateTimePicker1.Value.Date.ToString("MM/dd/yyyy"));
                       conn = DBSetting.con;
                       if (conn.State == ConnectionState.Closed)

                           conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                        //conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                    }
                    if (radioButton2.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'SAR'and   and  ENDate = '{1}'", textBox2.Text, dateTimePicker1.Value.Date.ToString("MM/dd/yyyy"));
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                       // conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                    }
                    if (radioButton3.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'UAE'and  and  ENDate = '{1}'", textBox2.Text, dateTimePicker1.Value.Date.ToString("MM/dd/yyyy"));
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                        //conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                        // dataGridView1.DataMember = "Table1";
                    }

                }
                else
                    MessageBox.Show("الرجاء ادخال قيمة المبلغ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
            {

                if (textBox1.Text != "")
                {



                    sql = string.Format("select * from Table5 where ENDate = '{0}' and  BeneficiaryName like N'{1}%'", dateTimePicker1.Value.Date.ToString("MM/dd/yyyy"), textBox1.Text);
                    conn = DBSetting.con;
                    if (conn.State == ConnectionState.Closed)

                        conn.Open();
                    dataadapter = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();

                   // conn.Open();
                    dataadapter.Fill(ds, "Table5");
                    dataGridView1.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                    // dataGridView1.DataMember = "Table1";
                    // dataGridView1.DataMember = "Table1";



                }
                else
                    MessageBox.Show("الرجاء ادخال الأسم ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
            {

                if (textBox2.Text != "" && textBox1.Text != "")
                {


                    if (radioButton1.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'USD' and  BeneficiaryName like N'{1}%' and ENDate = '{2}'", textBox2.Text, textBox1.Text, dateTimePicker1.Value.Date.ToString("MM/dd/yyyy"));
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                        //conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                        // dataGridView1.DataMember = "Table1";
                    }
                    if (radioButton2.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'SAR' and  BeneficiaryName like N'{1}%' and ENDate = '{2}'", textBox2.Text, textBox1.Text, dateTimePicker1.Value.Date.ToString("MM/dd/yyyy"));
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();

                        //conn.Open();
                        dataadapter.Fill(ds, "Table5");

                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                      
                    }
                    if (radioButton3.Checked == true)
                    {
                        sql = string.Format("select * from Table5 where AmountNo = '{0}' and Currency = 'UAE'and  BeneficiaryName like N'{1}%' and ENDate = '{2}'", textBox2.Text, textBox1.Text, dateTimePicker1.Value.Date.ToString("MM/dd/yyyy"));
                        conn = DBSetting.con;
                        if (conn.State == ConnectionState.Closed)

                            conn.Open();
                        dataadapter = new SqlDataAdapter(sql, conn);
                        ds = new DataSet();
                        //conn.Open();
                        dataadapter.Fill(ds, "Table5");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                    
                    }

                }
                else
                {
                    if (textBox1.Text == "")
                        MessageBox.Show("الرجاء ادخال الأسم ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (textBox2.Text == "")
                        MessageBox.Show("الرجاء ادخال قيمة المبلغ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox1.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                textBox2.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(@"img\", "instructions2 data.txt"));
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            //PrintDialog associate with PrintDocument;
            printDialog1.Document = printDocument1;


            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           //dataGridView1.Rows[0].ReadOnly = true;
            /*if (dataGridView1.Rows.Count > 1)
            {
                dataGridView1.ReadOnly = false;
                //dataGridView1.Rows[0].Cells[0].ReadOnly = true;
                dataGridView1.Columns[0].ReadOnly = true; 
                dataGridView1.Rows[0].ReadOnly = true;

                MessageBox.Show("بإمكانك تحديث بيانات الجدول \n من خلال تعديل بيانات الخلية المراد تحديثها", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else

                MessageBox.Show("لا توجد بيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


       */ }

        private void button3_Click(object sender, EventArgs e)
        {

            //Associate PrintPreviewDialog with PrintDocument.
            printPreviewDialog1.Document = printDocument1;

            // Show PrintPreview Dialog
            printPreviewDialog1.ShowDialog();
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        { }



        private void search_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mohDataDataSet4.Table5' table. You can move, or remove it, as needed.
           // this.table5TableAdapter.Fill(this.mohDataDataSet4.Table5);
            // TODO: This line of code loads data into the 'mohDataDataSet2.Table2' table. You can move, or remove it, as needed.
           // this.table2TableAdapter.Fill(this.mohDataDataSet2.Table2);
            this.currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.USA));
            this.currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.UAE));
            this.currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
           /* dtporder = new DateTimePicker();
            dtporder.Format = DateTimePickerFormat.Short;
            dtporder.Visible = false;
            dtporder.Width = 100;
            dataGridView1.Controls.Add(dtporder);
            dtporder.ValueChanged += this.dtporder_ValueChanged;
            dataGridView1.CellBeginEdit += this.dataGridView1_CellBeginEdit;
         //  dataGridView1_CellEndEdit += this.dataGridView1_CellEndEdit;*/
            ;

        }
       // private void dtporder_ValueChanged(object sender, EventArgs e)
        //{ dataGridView1.CurrentCell.Value = dtporder.Text; }

       /* private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if ((dataGridView1.Focused) && (dataGridView1.CurrentCell.ColumnIndex == 18))
                {
                    dataGridView1.CurrentCell.Value = dtporder.Value.Date;

                }
                else
                { dtporder.Visible = false; }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }



            newkey = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            cloumname = dataGridView1.Columns[e.ColumnIndex].DataPropertyName.ToString();

            newdata = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (newkey.ToString() != "0")
            {

                if (cloumname == "DebitAC" && (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToCharArray().Length != 14 && dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString() != ""))
                {
                    MessageBox.Show("فقط مسموح ادخال رقم مكون من 14 خانة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";

                }
                //dataGridView1.Rows[0].Cells[0].ReadOnly = true;

                else if (cloumname == "InterntionalTransfer" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True" && dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "True")
                {

                    {
                        MessageBox.Show(" غير مسموح أختيار حوالة دولية \n في حالة أختيار شيك مصرفي مُسبقاً    ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }

                }
                else if (cloumname == "Drift" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True" && dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
                {


                    MessageBox.Show(" غير مسموح أختيار شيك مصرفي \n في حالة أختيار حوالة دولية مُسبقاً    ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;


                }
                else if (cloumname == "RefNO" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToCharArray().Length != 11)
                {
                    MessageBox.Show("فقط مسموح ادخال رقم مكون من 11 خانة");
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }

                else if (cloumname == "TransferCurrenccy" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToCharArray().Length != 3)
                {
                    MessageBox.Show("فقط مسموح ادخال أحد رموز العملات التالية\n USD , AUE , SAR ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }
                else if (cloumname == "RemittancePurpose" && (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToCharArray().Length != 1 || dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToCharArray().Length == 1) && (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "1" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "2" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "3" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "4" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "5" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "6" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "7" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "8" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "9"))
                {
                    //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "1" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "2" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "3" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "4" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "5" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "6" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "7" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "8" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "9")
                    {//if()
                        MessageBox.Show("فقط مسموح ادخال رقم من 1 إلى 9 ");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }

                }

                //else if (cloumname == "Cash" && dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() =="False" &&((dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString() != " " && dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString() != " ") || (dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString() != "")))

                else if (cloumname == "Cash" && dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "True" && ((dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString() != " " && dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString() != "") || ((dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString() != " "))))
                {
                    //if 
                    //{
                    MessageBox.Show("غير مسموح أختيار نقدا مع وجود رقم الشيك \nأو القيد على حسابي / حسابنا رقم  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[10].Value = false;
                    //}
                }
                else if (cloumname == "DebitAC" && dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString() != " " && (dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString() != "" || dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "True"))
                {
                    MessageBox.Show("غير مسموح ادخال رقم القيد على حسابي/حسابنا رقم\nمع وجود رقم الشيك أو أختيار نقدا   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("غير مسموح ادخال رقم الشيك\nمع وجود رقم القيد على حسابي/حسابنا رقم أو أختيار نقدا   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[21].Value = "";
                }
                else if (cloumname == "ChequeNO" && dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString() != " " && (dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString() != "" || dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "True"))
                {
                    MessageBox.Show("غير مسموح ادخال رقم الشيك\nمع وجود رقم القيد على حسابي/حسابنا رقم أو أختيار نقدا   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dataGridView1.Rows[e.RowIndex].Cells[20].Value = "";
                }






                else
                {
                    // conn = new SqlConnection(" Data Source=.\\SQLEXPRESS;AttachDbFilename='" + Application.StartupPath + "\\MohData.mdf';Integrated Security=True;User Instance=True");
                    //conn = new SqlConnection(" Data Source=.\\SQLEXPRESS;AttachDbFilename='" + Application.StartupPath + "\\Datab.mdf';Integrated Security=True;User Instance=True");
                    // conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");
                    //conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");
                    if (DBSetting.con == null)
                    {
                        DBSetting.CreateConnection();
                    }
                    conn = DBSetting.con;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();


                    // if (cloumname == "BeneficiaryName" || cloumname == "BeneficiaryBank" || cloumname == "AddressPhoneNo" || cloumname == "BranchNameAddress" || cloumname == " RemitterName" || cloumname == " Nationality" || cloumname == " IDNoTypeDate" || cloumname == " Address" || cloumname == " OtherDetails" || cloumname == " Branch")
                    if (cloumname == "InterntionalTransfer" || cloumname == "DebitAC" || cloumname == "ChequeNO" || cloumname == "Drift" || cloumname == "TransferCurrenccy" || cloumname == "AmountInFiguers" || cloumname == "BeneficiaryACNo" || cloumname == "Cash" || cloumname == " PhoneNo" || cloumname == "RemittancePurpose" || cloumname == " Datee" || cloumname == "RefNO")
                    {



                        newcelval = new SqlCommand("UPDATE Table2 SET " + cloumname + "='" + newdata + "'WHERE ID = '" + newkey + "' ", conn);

                    }

                    else
                    {
                        newcelval = new SqlCommand("UPDATE Table2 SET " + cloumname + "=N'" + newdata + "'WHERE ID = '" + newkey + "' ", conn);
                    }
                    try
                    {
                        int rowefect = newcelval.ExecuteNonQuery();
                        MessageBox.Show(" تم التعيل بنجاح", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtporder.Visible = false;
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }*/
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowindex = e.RowIndex;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Cells[0].Value.ToString()!="0")
            {
                int newkey = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
               // conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");
               // conn = new SqlConnection(" Data Source=.\\SQLEXPRESS;AttachDbFilename='" + Application.StartupPath + "\\MohData.mdf';Integrated Security=True;User Instance=True");
               // conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + "\\MohData.mdf';Integrated Security=True;User Instance=True");
                //conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");
                if (DBSetting.con == null)
                {
                    DBSetting.CreateConnection();
                }
                conn = DBSetting.con;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                
                
                SqlCommand newcelval;
                newcelval = new SqlCommand("DELETE FROM Table5 WHERE ID = '" + newkey + "' ", conn);
                if (MessageBox.Show("هل أنت متأكد من الحذف ؟", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Cells[0].Value.ToString() != "0")
                    {
                        try
                        {
                            int rowefect = newcelval.ExecuteNonQuery();
                            MessageBox.Show(" تم الحذف بنجاح", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conn.Close();
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                }

            }
            else
                MessageBox.Show("لا توجد بيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 f1=new Form2();
            if (rowindex != -1 && dataGridView1.Rows[rowindex].Cells[0].Value.ToString() != "0")
            {

              f1.maskedTextBox1.Text=dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
              f1.textBox2.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
              if (dataGridView1.Rows[rowindex].Cells[4].Value.ToString() == "1")
              { f1.radioButton1.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[4].Value.ToString() == "2")
              { f1.radioButton2.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[4].Value.ToString() == "3")
              { f1.radioButton3.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[4].Value.ToString() == "4")
              { f1.radioButton4.Checked = true; }
              f1.textBox3.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
              f1.textBox4.Text = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
              f1.textBox5.Text = dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
              f1.textBox6.Text = dataGridView1.Rows[rowindex].Cells[8].Value.ToString();
              f1.textBox12.Text = dataGridView1.Rows[rowindex].Cells[10].Value.ToString();
              f1.cboCurrency.Text = dataGridView1.Rows[rowindex].Cells[9].Value.ToString();
              f1.textBox11.Text = dataGridView1.Rows[rowindex].Cells[11].Value.ToString();
              f1.textBox10.Text = dataGridView1.Rows[rowindex].Cells[12].Value.ToString();
              f1.textBox13.Text = dataGridView1.Rows[rowindex].Cells[13].Value.ToString();
              f1.textBox9.Text = dataGridView1.Rows[rowindex].Cells[14].Value.ToString();
              f1.textBox8.Text = dataGridView1.Rows[rowindex].Cells[15].Value.ToString();
              f1.textBox14.Text = dataGridView1.Rows[rowindex].Cells[16].Value.ToString();
              f1.textBox15.Text = dataGridView1.Rows[rowindex].Cells[17].Value.ToString();
              f1.textBox16.Text = dataGridView1.Rows[rowindex].Cells[19].Value.ToString();
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "1")
              { f1.radioButton9.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "2")
              { f1.radioButton8.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "3")
              { f1.radioButton7.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "4")
              { f1.radioButton14.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "0")
              { f1.radioButton10.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "5")
              { f1.radioButton13.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "6")
              { f1.radioButton12.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "7")
              { f1.radioButton11.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "8")
              { f1.radioButton15.Checked = true; }
              if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "9")
              { f1.radioButton16.Checked = true; }
              
              
            }
            else

                MessageBox.Show("لا توجد بيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Hide();
            f1.ShowDialog();
            //this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");
           // conn = new SqlConnection(" Data Source=.\\SQLEXPRESS;AttachDbFilename='" + Application.StartupPath + "\\MohData.mdf';Integrated Security=True;User Instance=True");
            //conn = new SqlConnection(" Data Source=.\\SQLEXPRESS;AttachDbFilename='" + Application.StartupPath + "\\Datab.mdf';Integrated Security=True;User Instance=True");
           //conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");

            if (DBSetting.con == null)
            {
                DBSetting.CreateConnection();
            }
            conn = DBSetting.con;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            
            sql = string.Format("select * from Table2 ");
            dataadapter = new SqlDataAdapter(sql, conn);
            ds = new DataSet();

            conn.Open();
            dataadapter.Fill(ds, "Table2");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
        string amntword;
            if ( rowindex != -1 && dataGridView1.Rows[rowindex].Cells[0].Value.ToString()!="0")
            {
                //Form2 f1 = new Form2();

                Font font = new Font("Times New Roman", 10f, FontStyle.Regular);
                Font font1 = new Font("Times New Roman", 9f, FontStyle.Regular);
                Font font2 = new Font("Times New Roman", 8f, FontStyle.Regular);
                StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft)
                {
                    FormatFlags = StringFormatFlags.DirectionRightToLeft
                };

                //if (dataGridView1.Rows[rowindex].Cells[19].Value.ToString() != "" && dataGridView1.Rows[rowindex].Cells[19].Value.ToString().ToCharArray().Length == 11)
               // {
                   // int num = 0;
                    //d = new Char[11];
                    //d = dataGridView1.Rows[rowindex].Cells[19].Value.ToString().ToCharArray();
                    //int index = 0;
                   // while (index < 11)
                    //{
                       // e.Graphics.DrawString(this.d[index].ToString(), font, Brushes.Black, (float)(0x11d + num), 109f);
                        //num += 0x13;
                        //index++;
                    //}


               // }
                //e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[22].Value.ToString(), font3, Brushes.Black, 760f, 132f, format);
                //التاريخ العربي
                string s1;
                s1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString().Substring(1, 1);
                if (s1 == "/")
                {
                    s1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString().Substring(0, 1);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)710f, (float)140);
                    s1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString().Substring(2, 2);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)660f, (float)140);
                    s1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString().Substring(5, 4);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)610f, (float)140);
                }
                else
                {
                    s1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString().Substring(0, 2);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)710f, (float)140);
                    s1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString().Substring(3, 2);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)660f, (float)140);
                    s1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString().Substring(6, 4);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)610f, (float)140);
                }
                s1 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString().Substring(1, 1);
                if (s1 == "/")
                {
                    s1 = dataGridView1.Rows[rowindex].Cells[12].Value.ToString().Substring(0, 1);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)540f, (float)140);
                    s1 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString().Substring(2, 2);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)490f, (float)140);
                    s1 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString().Substring(5, 4);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)440f, (float)140);
                }
                else
                {
                    s1 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString().Substring(0, 2);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)540f, (float)140);
                    s1 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString().Substring(3, 2);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)490f, (float)140);
                    s1 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString().Substring(6, 4);
                    e.Graphics.DrawString(s1, font, Brushes.Black, (float)440f, (float)140);
                }
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[3].Value.ToString(), font, Brushes.Black, (float)340f, (float)140, format);
                Image image = Image.FromFile(Application.StartupPath + @"\img\rr.png");
                Point point = new Point(752, 210);
                if (dataGridView1.Rows[rowindex].Cells[4].Value.ToString()=="1")
                {
                    e.Graphics.DrawImage(image, point);
                }

                if (dataGridView1.Rows[rowindex].Cells[4].Value.ToString() == "2")
                {
                    point = new Point(441, 210);
                    e.Graphics.DrawImage(image, point);
                }

                if (dataGridView1.Rows[rowindex].Cells[4].Value.ToString() == "3")
                {
                    point = new Point(300, 210);
                    e.Graphics.DrawImage(image, point);
                }
                if (dataGridView1.Rows[rowindex].Cells[4].Value.ToString() == "4")
                {
                    point = new Point(170, 210);
                    e.Graphics.DrawImage(image, point);
                }

                if (dataGridView1.Rows[rowindex].Cells[5].Value.ToString().Length < 40)
                { e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[5].Value.ToString(), font1, Brushes.Black, (float)670f, (float)248, format); }
                if (dataGridView1.Rows[rowindex].Cells[5].Value.ToString().Length >= 40)
                { e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[5].Value.ToString(), font2, Brushes.Black, (float)670f, (float)245, format); }
                if (dataGridView1.Rows[rowindex].Cells[6].Value.ToString().Length <= 30)
                { e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[6].Value.ToString(), font1, Brushes.Black, (float)250f, (float)245, format); }
                if (dataGridView1.Rows[rowindex].Cells[6].Value.ToString().Length > 30)
                { e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[6].Value.ToString(), font2, Brushes.Black, (float)250f, (float)245, format); }
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[7].Value.ToString(), font, Brushes.Black, (float)670f, (float)275, format);
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[8].Value.ToString(), font, Brushes.Black, (float)270f, (float)275, format);
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[9].Value.ToString(), font, Brushes.Black, (float)70f, (float)275, format);
               
                //e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[9].Value.ToString(), font, Brushes.Black, (float)670f, (float)310, format);

                if (dataGridView1.Rows[rowindex].Cells[9].Value.ToString() == "USD")
                    num = 0;
                if (dataGridView1.Rows[rowindex].Cells[9].Value.ToString() == "SAR")
                    num = 2;
                if (dataGridView1.Rows[rowindex].Cells[9].Value.ToString() == "UAE")
                    num = 1;
                
                try
                {
                    ToWord toWord = new ToWord(Convert.ToDecimal(dataGridView1.Rows[rowindex].Cells[8].Value.ToString()), currencies[num]);

                    amntword = toWord.ConvertToEnglish();

                }
                catch (Exception ex)
                {

                    amntword = String.Empty;
                }
                e.Graphics.DrawString(amntword, font, Brushes.Black, (float)670f, (float)310, format);
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[10].Value.ToString(), font, Brushes.Black, (float)670f, (float)375, format);
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[11].Value.ToString(), font, Brushes.Black, (float)620f, (float)405, format);
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[12].Value.ToString(), font, Brushes.Black, (float)650f, (float)435, format);
                if (dataGridView1.Rows[rowindex].Cells[13].Value.ToString().Length <= 30)
                { e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[13].Value.ToString(), font1, Brushes.Black, (float)650f, (float)465, format); }
                if (dataGridView1.Rows[rowindex].Cells[13].Value.ToString().Length > 30)
                { e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[13].Value.ToString(), font2, Brushes.Black, (float)650f, (float)465, format); }
                if (dataGridView1.Rows[rowindex].Cells[15].Value.ToString().Length <= 30)
                { e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[15].Value.ToString(), font1, Brushes.Black, (float)650f, (float)495, format); }
                if (dataGridView1.Rows[rowindex].Cells[15].Value.ToString().Length > 30)
                { e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[15].Value.ToString(), font2, Brushes.Black, (float)650f, (float)495, format); }
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[14].Value.ToString(), font, Brushes.Black, (float)270f, (float)460, format);
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[16].Value.ToString(), font, Brushes.Black, (float)300f, (float)490, format);
                e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[17].Value.ToString(), font, Brushes.Black, (float)740f, (float)555, format);
                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString()=="0")
                {
                    point = new Point(752, 627);
                    e.Graphics.DrawImage(image, point);
                }
                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "1")
                {
                    point = new Point(570, 627);
                    e.Graphics.DrawImage(image, point);
                }
                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "2")
                {
                    point = new Point(466, 627);
                    e.Graphics.DrawImage(image, point);
                    e.Graphics.DrawString(dataGridView1.Rows[rowindex].Cells[19].Value.ToString() , font, Brushes.Black, (float)380f, (float)630, format);
                }

                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "3")
                {
                    point = new Point(206, 627);
                    e.Graphics.DrawImage(image, point);
                }
                //////////////////////////////
                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "4")
                {
                    point = new Point(752, 655);
                    e.Graphics.DrawImage(image, point);
                }
                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "5")
                {
                    point = new Point(570, 655);
                    e.Graphics.DrawImage(image, point);
                }
                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "6")
                {
                    point = new Point(466, 655);
                    e.Graphics.DrawImage(image, point);
                }
               // e.Graphics.DrawString(textBox16.Text, font, Brushes.Black, (float)400f, (float)630, format);
                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "7")
                {
                    point = new Point(206, 655);
                    e.Graphics.DrawImage(image, point);
                }
                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "8")
                {
                    point = new Point(206, 685);
                    e.Graphics.DrawImage(image, point);
                }
                if (dataGridView1.Rows[rowindex].Cells[18].Value.ToString() == "9")
                {
                    point = new Point(752, 685);
                    e.Graphics.DrawImage(image, point);
                }    
                
                
            }

            else

                MessageBox.Show("لا توجد بيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             //conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\MohData.mdf;Integrated Security=True"); 
            if (DBSetting.con == null)
            {
                DBSetting.CreateConnection();
            }
            conn = DBSetting.con;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            
            //conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");
            // conn = new SqlConnection(" Data Source=.\\SQLEXPRESS;AttachDbFilename='" + Application.StartupPath + "\\Datab.mdf';Integrated Security=True;User Instance=True");
           // conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\newv3\\PrintDoc\\PrintDoc\\Datab.mdf;Integrated Security=True;User Instance=True;");
           // conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\MohData.mdf;Integrated Security=True;User Instance=True;");
            //ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["myconnectionstring"];
           // conn = new SqlConnection(cs.ConnectionString); 
            //conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\newv3\\PrintDoc\\PrintDoc\\MohData.mdf;Integrated Security=True;User Instance=True;");
            //conn.Open();
            sql = string.Format("select * from Table5 ");
            dataadapter = new SqlDataAdapter(sql, conn);
            ds = new DataSet();

          
            dataadapter.Fill(ds, "Table5");
      
            dataGridView1.DataSource = ds.Tables[0];
            
        
            conn.Close();
        

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            { e.Handled = true; }
        }

       


       



    }
}