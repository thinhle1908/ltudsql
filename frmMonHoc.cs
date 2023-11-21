using System;
using System.Windows.Forms;

namespace demo_sql
{
    public partial class frmMonHoc : Form
    {
        clsDataQLSV clsDataQLSV = new clsDataQLSV();

        public frmMonHoc()
        {
            InitializeComponent();
            dataGridView1.DataSource = clsDataQLSV.layDSMonHoc();

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                clsDataQLSV.themMonHoc(txtMaMonHoc.Text, txtTenMonHoc.Text, txtSoTiet.Text);
                dataGridView1.DataSource = clsDataQLSV.layDSMonHoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Them khong thanh cong");
            }

        }

        private void txtMaMonHoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iDong = e.RowIndex;
            if (iDong >= 0)
            {
                txtMaMonHoc.Text = dataGridView1.Rows[iDong].Cells[0].Value.ToString();
                txtTenMonHoc.Text = dataGridView1.Rows[iDong].Cells[1].Value.ToString();
                txtSoTiet.Text = dataGridView1.Rows[iDong].Cells[2].Value.ToString();
            }
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsDataQLSV.sapXepDsMonHoc();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource =      clsDataQLSV.timKiemMonHoc(txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Them khong thanh cong");
            }
        }
    }
}
