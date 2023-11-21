using System;
using System.Windows.Forms;

namespace demo_sql
{
    public partial class frmSinhVien : Form
    {
        clsDataQLSV clsDataQLSV = new clsDataQLSV();
        public frmSinhVien()
        {
            InitializeComponent();
            dataGridView1.DataSource = clsDataQLSV.layDSSinhVien();
            clsDataQLSV.layDSMaKhoa(cmbKhoa);
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
