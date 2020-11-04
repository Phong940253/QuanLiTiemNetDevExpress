using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLiTiemNet
{
    public partial class RibbonFormAddTaiKhoan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        sendNewDataRow sendNewTaiKhoan;
        editData sendEditData;
        GridView gridView;
        int maTaiKhoan;
        xoaDataRow deleDataRow;
        getNewDataRow getNewDataRow;
        bool isEdit;
        getNewCode getNewCode;
        public RibbonFormAddTaiKhoan()
        {
            InitializeComponent();
        }
        public RibbonFormAddTaiKhoan(DataRow dataRow, getNewDataRow getNewRow, xoaDataRow deleDataRow, getNewCode getNewCode) : this()
        {
            this.dataRow = dataRow;
            this.getNewDataRow = getNewRow;
            this.deleDataRow = deleDataRow;
            this.getNewCode = getNewCode;
        }

        public RibbonFormAddTaiKhoan(bool isEdit, sendNewDataRow senderNew, editData senderEdit, DataRow dataRow, ref GridView gridView, int maTaiKhoan, xoaDataRow deleDataRow, getNewDataRow getNewRow, getNewCode getNewCode) : this(dataRow, getNewRow, deleDataRow, getNewCode)
        {
            this.sendNewTaiKhoan = senderNew;
            this.sendEditData = senderEdit;
            this.maTaiKhoan = maTaiKhoan;
            this.gridView = gridView;
            this.isEdit = isEdit;
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
            if (!isEdit) dataRow["MATK"] = maTaiKhoan;
            dataRow["TENTK"] = textEditTenTaiKhoan.Text;
            dataRow["MATKHAU"] = textEditMatKhau.Text;
            dataRow["TONGTIEN"] = spinEditTongSoTien.Value.ToString();
            dataRow["TRANGTHAI"] = string.IsNullOrEmpty(comboBoxEditTrangThai.Text) ? "UNLOCK" : comboBoxEditTrangThai.Text;
            dataRow["LOAI"] = string.IsNullOrEmpty(comboBoxEditLoaiTaiKhoan.Text) ? "Thường" : comboBoxEditLoaiTaiKhoan.Text;
            dataRow["SOTIENSUDUNG"] = "0";
            dataRow["SOGIOSUDUNG"] = "00:00:00";
            if (!string.IsNullOrEmpty(comboBoxEditMaNguoiDung.Text))
                dataRow["MANGUOIDUNG"] = comboBoxEditMaNguoiDung.Text;
            dataRow["NGAYTAO"] = DateTime.Now;
            if (isEdit) sendEditData(dataRow, ref gridView);
            else sendNewTaiKhoan(dataRow);
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

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEditTenTaiKhoan.Text = null;
            textEditMatKhau.Text = null;
            spinEditTongSoTien.Text = null;
            comboBoxEditTrangThai.Text = null;
            comboBoxEditLoaiTaiKhoan.Text = null;
            comboBoxEditMaNguoiDung.Text = null;
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiReset_ItemClick(sender, e);
            dataRow = getNewDataRow(2);
            isEdit = false;
            maTaiKhoan = getNewCode(2, "MATK");
        }

        private void bbiSaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiClose_ItemClick(sender, e);
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            deleDataRow(sender, e);
            bbiClose_ItemClick(sender, e);
        }
    }
}
