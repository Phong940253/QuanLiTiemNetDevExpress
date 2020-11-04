using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLiTiemNet
{
    public partial class RibbonFormAddPhong : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        sendNewDataRow sendNewPhong;
        editData sendEditData;
        GridView gridView;
        int maPhong;
        xoaDataRow deleDataRow;
        getNewDataRow getNewDataRow;
        bool isEdit;
        getNewCode getNewCode;
        public RibbonFormAddPhong()
        {
            InitializeComponent();
        }
        public RibbonFormAddPhong(DataRow dataRow, getNewDataRow getNewRow, xoaDataRow deleDataRow, getNewCode getNewCode) : this()
        {
            this.dataRow = dataRow;
            this.getNewDataRow = getNewRow;
            this.deleDataRow = deleDataRow;
            this.getNewCode = getNewCode;
        }

        public RibbonFormAddPhong(bool isEdit, sendNewDataRow senderNew, editData senderEdit, DataRow dataRow, ref GridView gridView, int maPhong, xoaDataRow deleDataRow, getNewDataRow getNewRow, getNewCode getNewCode) : this(dataRow, getNewRow, deleDataRow, getNewCode)
        {
            this.sendNewPhong = senderNew;
            this.sendEditData = senderEdit;
            this.maPhong = maPhong;
            this.gridView = gridView;
            this.isEdit = isEdit;
        }


        private void loadDataRow()
        {
            textEditTenPhong.Text = dataRow["TENPHONG"]?.ToString();
            if (Convert.IsDBNull(dataRow["DONGIA"])) spinEditDonGia.Value = 0;
            else spinEditDonGia.Value = (decimal)dataRow["DONGIA"];
            comboBoxEditTrangThai.Text = dataRow["TRANGTHAI"]?.ToString();
            comboBoxEditLoaiPhong.Text = dataRow["LOAIPHONG"]?.ToString();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isEdit) dataRow["MAPHONG"] = maPhong;
            dataRow["TENPHONG"] = textEditTenPhong.Text;
            dataRow["DONGIA"] = spinEditDonGia.Value.ToString();
            dataRow["TRANGTHAI"] = string.IsNullOrEmpty(comboBoxEditTrangThai.Text) ? "Có thể sử dụng" : comboBoxEditTrangThai.Text;
            dataRow["LOAIPHONG"] = string.IsNullOrEmpty(comboBoxEditLoaiPhong.Text) ? "Phòng máy 1*" : comboBoxEditLoaiPhong.Text;
            if (isEdit) sendEditData(dataRow, ref gridView);
            else sendNewPhong(dataRow);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void RibbonFormAddPhong_FormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(textEditTenPhong.Text))
                lockSave();
            else
                unlockSave();
        }

        private void RibbonFormAddPhong_Load(object sender, EventArgs e)
        {
            setCaptionForm();
            lockSave();
            loadDataRow();
        }

        private void setCaptionForm()
        {
            string Caption = null;
            if (!Convert.IsDBNull(dataRow["TENPHONG"]))
            {
                Caption += dataRow["TENPHONG"]?.ToString();
            }
            this.Text += Caption ?? "Thêm phòng mới";
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEditTenPhong.Text = null;
            spinEditDonGia.Value = 0;
            comboBoxEditTrangThai.Text = null;
            comboBoxEditLoaiPhong.Text = null;
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiReset_ItemClick(sender, e);
            dataRow = getNewDataRow(5);
            isEdit = false;
            maPhong = getNewCode(5, "MAPHONG");
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
