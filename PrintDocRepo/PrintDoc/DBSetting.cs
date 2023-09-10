using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace PrintDoc
{
    class DBSetting
    {
        public static SqlConnection con;
        //public static string constring = @"Data Source=ALSHAMI-PC\SQL2008;Database=VansManagement;Initial Catalog=VansManagement;Integrated Security=True";
        // public static string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=VansManagement;Integrated Security=True";
        public static string pathDB = @"|DataDirectory|MohData.mdf";
        //@"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\truck system\truck Management system\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\DBTruck.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        // public static string constring = @"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\truck system\truck Management system\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\VansManagement.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        // public static string constring = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\VansManagement.mdf;Database=VansManagement;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public static string Constring = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\App_Data\MohData.mdf;Database=MohData;Integrated Security=True; User Instance=True";
        public static string constring
        {
            get
            {
                Constring = ConfigurationSettings.AppSettings["ConnnectionString"];
                return (Constring);

            }
            set
            {
                ConfigurationSettings.AppSettings["ConnnectionString"] = value;
            }
        }
        public static void CreateConnection()
        {

            try
            {
                con = new SqlConnection(ConfigurationSettings.AppSettings["ConnnectionString"]);
                constring = ConfigurationSettings.AppSettings["ConnnectionString"];
                if (con.State == ConnectionState.Closed)
                    con.Open();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }
    }
}
