using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLiTiemNet
{
    public partial class RibbonFormAddGiaoDich : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        sendNewDataRow sendNewGiaoDich;
        editData sendEditData;
        GridView gridView;
        int maGiaoDich;
        xoaDataRow deleDataRow;
        getNewDataRow getNewDataRow;
        bool isEdit;
        getNewCode getNewCode;
        public RibbonFormAddGiaoDich()
        {
            InitializeComponent();
        }
        public RibbonFormAddGiaoDich(DataRow dataRow, getNewDataRow getNewRow, xoaDataRow deleDataRow, getNewCode getNewCode) : this()
        {
            this.dataRow = dataRow;
            this.getNewDataRow = getNewRow;
            this.deleDataRow = deleDataRow;
            this.getNewCode = getNewCode;
        }

        public RibbonFormAddGiaoDich(bool isEdit, sendNewDataRow senderNew, editData senderEdit, DataRow dataRow, ref GridView gridView, int maGiaoDich, xoaDataRow deleDataRow, getNewDataRow getNewRow, getNewCode getNewCode) : this(dataRow, getNewRow, deleDataRow, getNewCode)
        {
            this.sendNewGiaoDich = senderNew;
            this.sendEditData = senderEdit;
            this.maGiaoDich = maGiaoDich;
            this.gridView = gridView;
            this.isEdit = isEdit;
        }


        private void loadDataRow()
        {
            textEditTenGiaoDich.Text = dataRow["TENTK"]?.ToString();
            textEditMatKhau.Text = dataRow["MATKHAU"].ToString();
            spinEditTongSoTien.Text = dataRow["TONGTIEN"]?.ToString();
            comboBoxEditTrangThai.Text = dataRow["TRANGTHAI"]?.ToString();
            comboBoxEditLoaiGiaoDich.Text = dataRow["LOAI"]?.ToString();
            comboBoxEditMaNguoiDung.Text = dataRow["MANGUOIDUNG"]?.ToString();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isEdit) dataRow["MATK"] = maGiaoDich;
            dataRow["TENTK"] = textEditTenGiaoDich.Text;
            dataRow["MATKHAU"] = textEditMatKhau.Text;
            dataRow["TONGTIEN"] = spinEditTongSoTien.Value.ToString();
            dataRow["TRANGTHAI"] = string.IsNullOrEmpty(comboBoxEditTrangThai.Text) ? "UNLOCK" : comboBoxEditTrangThai.Text;
            dataRow["LOAI"] = string.IsNullOrEmpty(comboBoxEditLoaiGiaoDich.Text) ? "Thường" : comboBoxEditLoaiGiaoDich.Text;
            dataRow["SOTIENSUDUNG"] = "0";
            dataRow["SOGIOSUDUNG"] = "00:00:00";
            if (!string.IsNullOrEmpty(comboBoxEditMaNguoiDung.Text))
                dataRow["MANGUOIDUNG"] = comboBoxEditMaNguoiDung.Text;
            dataRow["NGAYTAO"] = DateTime.Now;
            if (isEdit) sendEditData(dataRow, ref gridView);
            else sendNewGiaoDich(dataRow);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void RibbonFormAddGiaoDich_FormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(textEditTenGiaoDich.Text))
                lockSave();
            else
                unlockSave();
        }

        private void RibbonFormAddGiaoDich_Load(object sender, EventArgs e)
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
            textEditTenGiaoDich.Text = null;
            textEditMatKhau.Text = null;
            spinEditTongSoTien.Text = null;
            comboBoxEditTrangThai.Text = null;
            comboBoxEditLoaiGiaoDich.Text = null;
            comboBoxEditMaNguoiDung.Text = null;
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiReset_ItemClick(sender, e);
            dataRow = getNewDataRow(2);
            isEdit = false;
            maGiaoDich = getNewCode(2, "MATK");
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
