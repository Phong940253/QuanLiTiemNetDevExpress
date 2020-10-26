using System;

namespace QuanLiTiemNet
{
    public partial class XtraForm : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm()
        {
            InitializeComponent();
        }

        private void XtraForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlitiemnetDataSet.TAIKHOAN' table. You can move, or remove it, as needed.
            //this.tAIKHOANTableAdapter.Fill(this.quanlitiemnetDataSet.TAIKHOAN);

        }

        /*private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                int currentMaTK = (int)this.quanlitiemnetDataSet.TAIKHOAN.Rows[quanlitiemnetDataSet.TAIKHOAN.Count - 1]["MATK"] + 1;
                this.quanlitiemnetDataSet.TAIKHOAN.AddTAIKHOANRow(currentMaTK, textEditTenTaiKhoan.Text, textEditMatKhau.Text, spinEditTongTien.Value, 0, "UNLOCK", comboBoxEditLoaiTaiKhoan.Text, System.DateTime.Parse(timeEditNgayTao.Text), 1, System.TimeSpan.Parse("00:00:00"), int.Parse(textEditMaNguoiDung.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tAIKHOANTableAdapter.Fill(this.quanlitiemnetDataSet.TAIKHOAN);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.tAIKHOANTableAdapter.Update(this.quanlitiemnetDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tAIKHOANBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void buttonTaiLai_Click(object sender, EventArgs e)
        {
            this.tAIKHOANTableAdapter.Fill(this.quanlitiemnetDataSet.TAIKHOAN);
        }*/
    }
}
