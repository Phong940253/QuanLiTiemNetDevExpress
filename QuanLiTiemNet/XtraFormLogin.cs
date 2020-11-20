using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLiTiemNet
{
    public partial class XtraFormLogin : DevExpress.XtraEditors.XtraForm
    {
        login setMaNhanVien;
        public XtraFormLogin()
        {
            InitializeComponent();
        }

        public XtraFormLogin(login sender) : this()
        {
            setMaNhanVien = sender;
        }

        private void XtraFormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["QuanLiTiemNet.Properties.Settings.quanlitiemnetConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(stringConnection))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SELECT MATKHAU FROM NHANVIEN WHERE MANV = '" + textEdit11.Text + "'", sqlConnection);
                var password = command.ExecuteScalar();
                if (password?.ToString() == textEdit2.Text)
                {
                    setMaNhanVien(true, textEdit11.Text);
                    this.Close();
                }
                else
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}