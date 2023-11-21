using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace demo_sql
{
    internal class clsDataQLSV
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=THINH\MSSQLSERVER01;Initial Catalog=quanlysinhvien;Integrated Security=True");
        //------ KHOA -------
        public clsDataQLSV()
        {
            try
            {
                sqlcon.Open();
                MessageBox.Show("Connect thanh cong");
            }
            catch (Exception ex)
            {
                throw ex;
                sqlcon.Close();
            }
        }
        public int insertKhoa(string strMaKhoa, string strTenKhoa)
        {
            int iKetQua;
            string sql = $"insert into KHOA(MAKHOA,TENKHOA) values (\'{strMaKhoa}\',\'{strTenKhoa} \')";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = sql;
            sqlCmd.Connection = sqlcon;

            try
            {
                iKetQua = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iKetQua;

        }

        public int insertKhoaSP(string strMaKhoa, string strTenKhoa)
        {
            int iKetQua = -1;
            string tenSP = $"themKhoaSP";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = tenSP;
            sqlCmd.Connection = sqlcon;
            sqlCmd.Parameters.AddWithValue("@MAKHOA", strMaKhoa);
            sqlCmd.Parameters.AddWithValue("@TENKHOA", strTenKhoa);

            try
            {
                iKetQua = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iKetQua;

        }

        public DataTable getDataKhoa()
        {
            DataTable dtKhoa = new DataTable();
            SqlDataAdapter daKhoa;
            string sql = "Select * From Khoa";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlcon;
            sqlCmd.CommandText = sql;
            daKhoa = new SqlDataAdapter(sqlCmd);
            daKhoa.Fill(dtKhoa);
            return dtKhoa;
        }
        public DataTable getDataKhoaSP()
        {
            DataTable dtKhoa = new DataTable();
            SqlDataAdapter daKhoa;
            string tenSP = "sp_LayDanhSachKhoa";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = sqlcon;
            sqlCmd.CommandText = tenSP;
            daKhoa = new SqlDataAdapter(sqlCmd);
            daKhoa.Fill(dtKhoa);
            return dtKhoa;
        }
        public int deleteKhoa(string strMaKhoa)
        {
            int iKetQua;
            string sql = $"Delete Khoa Where MAKHOA=\'{strMaKhoa}\'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = sql;
            sqlCmd.Connection = sqlcon;

            iKetQua = sqlCmd.ExecuteNonQuery();
            return iKetQua;
        }

        public int updateKhoa(string strMaKhoa, string strTenKhoa)
        {
            int iKetQua;
            string sql = $"UPDATE KHOA  SET TENKHOA = \'{strTenKhoa}\' WHERE MAKHOA = \'{strMaKhoa}\'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = sql;
            sqlCmd.Connection = sqlcon;

            iKetQua = sqlCmd.ExecuteNonQuery();
            return iKetQua;
        }
        //------ END KHOA -------
        //------MON HOC----------
        public DataTable layDSMonHoc()
        {
            DataTable dtMonHoc = new DataTable();
            SqlDataAdapter daMonHoc;
            string tenSP = "sp_LayDanhSachMonHoc";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = tenSP;

            daMonHoc = new SqlDataAdapter(sqlcmd);
            daMonHoc.Fill(dtMonHoc);
            return dtMonHoc;

        }
        public int themMonHoc(string strMaMH, string strTenMH, string strSoTiet)
        {
            int iSoTiet = int.Parse(strSoTiet);
            int iKetQua = -1;
            string tenSP = "sp_ThemMonHoc";


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = tenSP;
            sqlcmd.Connection = sqlcon;
            sqlcmd.Parameters.AddWithValue("@MAMH", strMaMH);
            sqlcmd.Parameters.AddWithValue("@TENMH", strTenMH);
            sqlcmd.Parameters.AddWithValue("@SOTIET", iSoTiet);

            try
            {
                iKetQua = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iKetQua;
        }

        public DataTable sapXepDsMonHoc()
        {
            DataTable dtMonHoc = new DataTable();
            SqlDataAdapter daMonHoc;
            string tenSP = "sp_SapXep";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = tenSP;

            daMonHoc = new SqlDataAdapter(sqlcmd);
            daMonHoc.Fill(dtMonHoc);
            return dtMonHoc;

        }

        public DataTable timKiemMonHoc(string strTenMH)
        {
            DataTable dtMonHoc = new DataTable();
            SqlDataAdapter daMonHoc;
            string tenSP = "TIMTENMONHOC";

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = tenSP;
            sqlcmd.Parameters.AddWithValue("@TENMH", strTenMH);

            daMonHoc = new SqlDataAdapter(sqlcmd);
            daMonHoc.Fill(dtMonHoc);
            return dtMonHoc;

        }

        //------END MONHOC-------
        //-----SINH VIEN -------
        public DataTable layDSSinhVien()
        {
            DataTable dtKetQua = new DataTable();
            SqlDataAdapter daKhoa;
            string tenSP = "selectSinhVien";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = sqlcon;
            sqlCmd.CommandText = tenSP;
            daKhoa = new SqlDataAdapter(sqlCmd);
            daKhoa.Fill(dtKetQua);
            return dtKetQua;
        }
        public void layDSMaKhoa(ComboBox cmbMaKhoa)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter daKhoa;
            string tenSP = "sp_LayDSMaKhoa";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = sqlcon;
            sqlCmd.CommandText = tenSP;
            daKhoa = new SqlDataAdapter(sqlCmd);
            daKhoa.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbMaKhoa.Items.Add(dt.Rows[i]["MAKHOA"].ToString());
            }

        }

    }
}
