using System;
using System.Windows.Forms;

namespace demo_sql
{
    public partial class frmKhoa : Form
    {
        clsDataQLSV clsDataQLSV = new clsDataQLSV();
        public frmKhoa()
        {
            InitializeComponent();
            dataGridView1.DataSource = clsDataQLSV.getDataKhoaSP();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text == String.Empty || txtTenKhoa.Text == String.Empty)
            {
                MessageBox.Show("Vui long nhap du lieu");
                return;
            }
            try
            {
                clsDataQLSV.insertKhoaSP(txtMaKhoa.Text, txtTenKhoa.Text);
                dataGridView1.DataSource = clsDataQLSV.getDataKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Them khong thanh cong");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    clsDataQLSV.deleteKhoa(dataGridView1.SelectedRows[0].Cells["MAKHOA"].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Xóa dữ liệu khong thanh cong");
                }
            }
            dataGridView1.DataSource = clsDataQLSV.getDataKhoa();
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text == String.Empty || txtTenKhoa.Text == String.Empty)
            {
                return;
            }
            try
            {
                clsDataQLSV.updateKhoa(txtMaKhoa.Text, txtTenKhoa.Text);
                dataGridView1.DataSource = clsDataQLSV.getDataKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Sửa dữ liệu không thành công");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iDong = e.RowIndex;
            if (iDong >= 0)
            {
                txtMaKhoa.Text = dataGridView1.Rows[iDong].Cells[0].Value.ToString();
                txtTenKhoa.Text = dataGridView1.Rows[iDong].Cells[1].Value.ToString();
            }
        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
