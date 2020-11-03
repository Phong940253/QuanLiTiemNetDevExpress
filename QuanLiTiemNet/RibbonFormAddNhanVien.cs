using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLiTiemNet
{

    public partial class RibbonFormAddNhanVien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        sendNewDataRow sendNewNhanVien;
        editData sendEditData;
        GridView gridView;
        xoaDataRow deleDataRow;
        public RibbonFormAddNhanVien()
        {
            InitializeComponent();
        }
        public RibbonFormAddNhanVien(sendNewDataRow sender, DataRow dataRow, xoaDataRow deleDataRow) : this()
        {
            this.sendNewNhanVien = sender;
            this.dataRow = dataRow;
            this.deleDataRow = deleDataRow;
        }

        public RibbonFormAddNhanVien(editData sender, DataRow dataRow, ref GridView gridView, xoaDataRow deleDataRow) : this()
        {
            this.sendEditData = sender;
            this.dataRow = dataRow;
            this.gridView = gridView;
            this.deleDataRow = deleDataRow;
        }

        private void loadDataRow()
        {
            textEditHo.Text = dataRow["HO"]?.ToString();
            textEditTenDem.Text = dataRow["TENDEM"].ToString();
            textEditTen.Text = dataRow["TEN"]?.ToString();
            textEditTaiKhoan.Text = dataRow["MANV"]?.ToString();
            textEditMatKhau.Text = dataRow["MATKHAU"]?.ToString();
            textEditSDT.Text = dataRow["SDT"]?.ToString();
            textEditEmail.Text = dataRow["EMAIL"]?.ToString();
            spinEditTienLuong.Text = dataRow["LUONG"]?.ToString();
            comboBoxEditChucVu.Text = dataRow["CHUCVU"]?.ToString();
            pictureEditAnh.Image = (!Convert.IsDBNull(dataRow["ANH"]) ? ProcessImage.byteArrayToImage((byte[])dataRow["ANH"]) : null);
            textEditDiaChi.Text = dataRow["DIACHI"]?.ToString();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dataRow["HO"] = textEditHo.Text;
            dataRow["TENDEM"] = textEditTenDem.Text;
            dataRow["TEN"] = textEditTen.Text;
            dataRow["MANV"] = textEditTaiKhoan.Text;
            dataRow["MATKHAU"] = textEditMatKhau.Text;
            dataRow["SDT"] = textEditSDT.Text;
            dataRow["EMAIL"] = textEditEmail.Text;
            dataRow["LUONG"] = spinEditTienLuong.Text;
            dataRow["CHUCVU"] = comboBoxEditChucVu.Text;
            dataRow["ANH"] = (pictureEditAnh.Image != null ? ProcessImage.ImageToByteArray(pictureEditAnh.Image, System.Drawing.Imaging.ImageFormat.Png) : null);
            dataRow["DIACHI"] = textEditDiaChi.Text;
            if (sendEditData != null) sendEditData(dataRow, ref gridView);
            else sendNewNhanVien(dataRow);
        }



        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiClose_ItemClick(sender, e);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void RibbonFormAddNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(textEditHo.Text) || string.IsNullOrEmpty(textEditTenDem.Text) ||
                string.IsNullOrEmpty(textEditTen.Text) || string.IsNullOrEmpty(textEditTaiKhoan.Text) ||
                string.IsNullOrEmpty(textEditSDT.Text) || string.IsNullOrEmpty(textEditDiaChi.Text) ||
                string.IsNullOrEmpty(spinEditTienLuong.Text) || string.IsNullOrEmpty(comboBoxEditChucVu.Text))
                lockSave();
            else
                unlockSave();
        }

        private void RibbonFormAddNhanVien_Load(object sender, EventArgs e)
        {
            setCaptionForm();
            lockSave();
            loadDataRow();
        }

        private void setCaptionForm()
        {
            string HoVaTen = null;
            if (!Convert.IsDBNull(dataRow["HO"]) && !Convert.IsDBNull(dataRow["TEN"]))
            {
                HoVaTen += dataRow["HO"]?.ToString();
                if (!Convert.IsDBNull(dataRow["TENDEM"]))
                    HoVaTen += " " + dataRow["TENDEM"]?.ToString();
                HoVaTen += " " + dataRow["TEN"]?.ToString();
            }
            this.Text += HoVaTen ?? "Nhân viên mới";
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiReset_ItemClick(sender, e);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleDataRow(sender, e);
        }
    }
}
