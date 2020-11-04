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
        public RibbonFormAddPhong()
        {
            InitializeComponent();
        }
        public RibbonFormAddPhong(sendNewDataRow sender, DataRow dataRow, getNewDataRow getNewRow) : this()
        {
            this.sendNewPhong = sender;
            this.dataRow = dataRow;
            this.getNewDataRow = getNewRow;
        }

        public RibbonFormAddPhong(sendNewDataRow sender, DataRow dataRow, int maPhong, xoaDataRow deleDataRow, getNewDataRow getNewRow) : this(sender, dataRow, getNewRow)
        {
            this.maPhong = maPhong;
            this.deleDataRow = deleDataRow;
        }

        public RibbonFormAddPhong(editData sender, DataRow dataRow, ref GridView gridView, xoaDataRow deleDataRow, getNewDataRow getNewRow) : this()
        {
            this.sendEditData = sender;
            this.dataRow = dataRow;
            this.gridView = gridView;
            this.deleDataRow = deleDataRow;
        }


        private void loadDataRow()
        {
            textEditTenPhong.Text = dataRow["TENPHONG"]?.ToString();
            if (Convert.IsDBNull(dataRow["DONGIA"])) spinEditDonGia.Value = 0;
            else spinEditDonGia.Value = (int)dataRow["DONGIA"];
            comboBoxEditTrangThai.Text = dataRow["TRANGTHAI"]?.ToString();
            comboBoxEditLoaiPhong.Text = dataRow["LOAIPHONG"]?.ToString();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (sendEditData == null) dataRow["MAPHONG"] = maPhong;
            dataRow["TENPHONG"] = textEditTenPhong.Text;
            dataRow["DONGIA"] = spinEditDonGia.Value.ToString();
            dataRow["TRANGTHAI"] = string.IsNullOrEmpty(comboBoxEditTrangThai.Text) ? "Có thể sử dụng" : comboBoxEditTrangThai.Text;
            dataRow["LOAIPHONG"] = string.IsNullOrEmpty(comboBoxEditLoaiPhong.Text) ? "Phòng máy 1*" : comboBoxEditLoaiPhong.Text;
            if (sendEditData != null) sendEditData(dataRow, ref gridView);
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
            dataRow = getNewDataRow(ref gridView);
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
