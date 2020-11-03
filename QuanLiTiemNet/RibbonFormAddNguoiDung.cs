using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLiTiemNet
{
    public partial class RibbonFormAddNguoiDung : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        sendNewNhanVien sendNewNguoiDung;
        editData sendEditData;
        GridView gridView;
        int maNguoiDung;
        public RibbonFormAddNguoiDung()
        {
            InitializeComponent();
        }
        public RibbonFormAddNguoiDung(sendNewNhanVien sender, DataRow dataRow) : this()
        {
            this.sendNewNguoiDung = sender;
            this.dataRow = dataRow;
        }

        public RibbonFormAddNguoiDung(sendNewNhanVien sender, DataRow dataRow, int maNguoiDung) : this(sender, dataRow)
        {
            this.maNguoiDung = maNguoiDung;
        }

        public RibbonFormAddNguoiDung(editData sender, DataRow dataRow, ref GridView gridView) : this()
        {
            this.sendEditData = sender;
            this.dataRow = dataRow;
            this.gridView = gridView;
        }


        private void loadDataRow()
        {
            textEditHo.Text = dataRow["HO"]?.ToString();
            textEditTenDem.Text = dataRow["TENDEM"]?.ToString();
            textEditTen.Text = dataRow["TEN"]?.ToString();
            textEditSDT.Text = dataRow["SDT"]?.ToString();
            textEditDiaChi.Text = dataRow["DIACHI"]?.ToString();
            textEditEmail.Text = dataRow["EMAIL"]?.ToString();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (sendEditData == null) dataRow["MATK"] = maNguoiDung;
            dataRow["HO"] = textEditHo.Text;
            dataRow["TENDEM"] = textEditTenDem.Text;
            dataRow["TEN"] = textEditTen.Text;
            dataRow["NGAYTAO"] = DateTime.Now;
            dataRow["SDT"] = textEditSDT.Text;
            dataRow["EMAIL"] = textEditEmail.Text;
            dataRow["DIACHI"] = textEditDiaChi.Text;
            if (sendEditData != null) sendEditData(dataRow, ref gridView);
            else sendNewNguoiDung(dataRow);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void RibbonFormAddNguoiDung_FormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(textEditTen.Text))
                lockSave();
            else
                unlockSave();
        }

        private void RibbonFormAddNguoiDung_Load(object sender, EventArgs e)
        {
            setCaptionForm();
            lockSave();
            loadDataRow();
        }

        private void setCaptionForm()
        {
            string HoVaTen = null;
            if (Convert.IsDBNull(dataRow["HO"]) && Convert.IsDBNull(dataRow["TENDEM"]) && !Convert.IsDBNull(dataRow["TEN"]))
                HoVaTen = dataRow["TEN"]?.ToString();
            else if (!Convert.IsDBNull(dataRow["HO"]) && !Convert.IsDBNull(dataRow["TEN"]))
            {
                HoVaTen += dataRow["HO"]?.ToString();
                if (!Convert.IsDBNull(dataRow["TENDEM"]))
                    HoVaTen += " " + dataRow["TENDEM"]?.ToString();
                HoVaTen += " " + dataRow["TEN"]?.ToString();
            }
            this.Text += HoVaTen ?? "Người dùng mới";
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEditHo.Text = null;
            textEditTenDem.Text = null;
            textEditTen.Text = null;
            textEditSDT.Text = null;
            textEditDiaChi.Text = null;
            textEditEmail.Text = null;
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiReset_ItemClick(sender, e);
            maNguoiDung++;
        }

        private void bbiSaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiClose_ItemClick(sender, e);
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
