using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day35_02
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter SDA;
        DataSet DSet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=.\\SQLEXPRESS;database=test; user id=sa; pwd=alencia;");
            SDA = new SqlDataAdapter();
            DSet = new DataSet();
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            string strSelect = "SELECT * FROM testTable01 WHERE name = @name";
            SDA.SelectCommand = new SqlCommand(strSelect, conn);
            SDA.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar);
            SDA.SelectCommand.Parameters["@name"].Value = INPUT_Name.Text;
            DSet.Clear();
            if (SDA.Fill(DSet, "testTable01") != 0)
            {
                dataGridView1.DataSource = DSet.Tables["testTable01"];
            }
            else MessageBox.Show("찾는 데이터가 없습니다", "오류");
        }
    }
}
