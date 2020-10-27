using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace QuanLiTiemNet
{
    public partial class RibbonFormAddTaiKhoan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        sendNewNhanVien sendNewTaiKhoan;
        public RibbonFormAddTaiKhoan()
        {
            InitializeComponent();
        }
        public RibbonFormAddTaiKhoan(sendNewNhanVien sender, DataRow dataRow) : this()
        {
            this.sendNewTaiKhoan = sender;
            this.dataRow = dataRow;
        }

        private void loadDataRow()
        {
            textEditTenTaiKhoan.Text = dataRow["TENTK"]?.ToString();
            textEditMatKhau.Text = dataRow["MATKHAU"].ToString();
            spinEditTongSoTien.Text = dataRow["TONGTIEN"]?.ToString();
            comboBoxEditTrangThai.Text = dataRow["TRANGTHAI"]?.ToString();
            comboBoxEditLoaiTaiKhoan.Text = dataRow["LOAI"]?.ToString();
            comboBoxEditMaNguoiDung.Text = dataRow["MANGUOIDUNG"]?.ToString();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            dataRow["TENTK"] = textEditTenTaiKhoan.Text;
            dataRow["MATKHAU"] = textEditMatKhau.Text;
            dataRow["TONGTIEN"] = spinEditTongSoTien.Text;
            dataRow["TRANGTHAI"] = comboBoxEditTrangThai.Text;
            dataRow["LOAI"] = comboBoxEditLoaiTaiKhoan.Text;
            if (!string.IsNullOrEmpty(comboBoxEditMaNguoiDung.Text))
                dataRow["MANGUOIDUNG"] = comboBoxEditMaNguoiDung.Text;
            sendNewTaiKhoan(dataRow);
        }



        

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void RibbonFormAddTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void dxValidationProvider1_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {

        }
        private void lockSave()
        {
            bbiSave.Enabled = false;
            bbiSaveAndClose.Enabled = false;
            bbiSaveAndNew.Enabled = false;
        }

        private void unlockSave()
        {
            bbiSave.Enabled = true;
            bbiSaveAndClose.Enabled = true;
            bbiSaveAndNew.Enabled = true;
        }

        private void dxValidationProvider1_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
        }

        private void textEditValidate_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditTenTaiKhoan.Text))
                lockSave();
            else
                unlockSave();
        }

        private void RibbonFormAddTaiKhoan_Load(object sender, EventArgs e)
        {
            setCaptionForm();
            lockSave();
            loadDataRow();
        }

        private void setCaptionForm()
        {
            string Caption = null;
            if (!Convert.IsDBNull(dataRow["TENTK"]))
            {
                Caption += dataRow["TENTK"]?.ToString();
            }
            this.Text += Caption ?? "Tài khoản mới";
        }

        /*private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEditHo.Text = null;
            textEditTenDem.Text = null;
            textEditTen.Text = null;
            textEditTaiKhoan.Text = null;
            textEditMatKhau.Text = null;
            textEditSDT.Text = null;
            textEditEmail.Text = null;
            spinEditTienLuong.Text = null;
            comboBoxEditChucVu.Text = null;
            pictureEditAnh.Image = null;
            textEditDiaChi.Text = null;
        }*/

        /*private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiReset_ItemClick(sender, e);
        }*/



        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiReset_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiSaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

    }
}
