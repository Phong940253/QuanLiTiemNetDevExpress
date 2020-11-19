using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLiTiemNet
{
    public partial class RibbonFormAddMay : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        sendNewDataRow sendNewMay;
        editData sendEditData;
        GridView gridView;
        int maMay;
        xoaDataRow deleDataRow;
        getNewDataRow getNewDataRow;
        bool isEdit;
        getNewCode getNewCode;
        public RibbonFormAddMay()
        {
            InitializeComponent();
        }
        public RibbonFormAddMay(DataRow dataRow, getNewDataRow getNewRow, xoaDataRow deleDataRow, getNewCode getNewCode) : this()
        {
            this.dataRow = dataRow;
            this.getNewDataRow = getNewRow;
            this.deleDataRow = deleDataRow;
            this.getNewCode = getNewCode;
        }

        public RibbonFormAddMay(bool isEdit, sendNewDataRow senderNew, editData senderEdit, DataRow dataRow, ref GridView gridView, int maMay, xoaDataRow deleDataRow, getNewDataRow getNewRow, getNewCode getNewCode) : this(dataRow, getNewRow, deleDataRow, getNewCode)
        {
            this.sendNewMay = senderNew;
            this.sendEditData = senderEdit;
            this.maMay = maMay;
            this.gridView = gridView;
            this.isEdit = isEdit;
        }

        private void loadDataRow()
        {
            comboBoxEditMaTaiKhoan.Text = dataRow["MATK"]?.ToString();
            comboBoxEditMaPhong.Text = dataRow["MAPHONG"]?.ToString();
            timeSpanEditThoiGianSuDung.Text = dataRow["THOIGIANSUDUNG"]?.ToString();
            if (Convert.IsDBNull(dataRow["GIATIEN"])) spinEditGiaTien.Value = 0;
            else spinEditGiaTien.Value = (decimal)dataRow["GIATIEN"];
            if (Convert.IsDBNull(dataRow["SOTIEN"])) spinEditSoTien.Value = 0;
            else spinEditSoTien.Value = (decimal)dataRow["SOTIEN"];
            comboBoxEditTrangThai.Text = dataRow["TRANGTHAI"]?.ToString();
            comboBoxEditLoaiMay.Text = dataRow["LOAIMAY"]?.ToString();
            memoEditThongSoMay.Text = dataRow["THONGSOMAY"]?.ToString();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isEdit) dataRow["MAMAY"] = maMay;
            dataRow["TRANGTHAI"] = string.IsNullOrEmpty(comboBoxEditTrangThai.Text) ? "Không sử dụng" : comboBoxEditTrangThai.Text;
            if (!string.IsNullOrEmpty(comboBoxEditMaTaiKhoan.Text))
                dataRow["MATK"] = int.Parse(comboBoxEditMaTaiKhoan.Text);
            dataRow["MAPHONG"] = comboBoxEditMaPhong.Text;
            dataRow["GIATIEN"] = spinEditGiaTien.Value.ToString();
            dataRow["SOTIEN"] = spinEditSoTien.Value.ToString();
            dataRow["LOAIMAY"] = string.IsNullOrEmpty(comboBoxEditLoaiMay.Text) ? "Thường" : comboBoxEditLoaiMay.Text;
            dataRow["THONGSOMAY"] = memoEditThongSoMay.Text = dataRow["THONGSOMAY"]?.ToString();
            dataRow["THOIGIANSUDUNG"] = string.IsNullOrEmpty(timeSpanEditThoiGianSuDung.Text) ? "00:00:00" : timeSpanEditThoiGianSuDung.Text;
            if (isEdit) sendEditData(dataRow, ref gridView);
            else sendNewMay(dataRow);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void RibbonFormAddMay_FormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(comboBoxEditMaPhong.Text) || spinEditGiaTien.Value == 0)
                lockSave();
            else
                unlockSave();
        }

        private void RibbonFormAddMay_Load(object sender, EventArgs e)
        {
            setCaptionForm();
            lockSave();
            loadDataRow();
            fillMaTaiKhoan();
            fillMaPhong();
        }
        private void fillMaTaiKhoan()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["QuanLiTiemNet.Properties.Settings.quanlitiemnetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MATK FROM TAIKHOAN ORDER BY MATK ASC", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEditMaTaiKhoan.Properties.Items.Add(reader[0].ToString());
                }
            }
        }
        private void fillMaPhong()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["QuanLiTiemNet.Properties.Settings.quanlitiemnetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MAPHONG FROM PHONG ORDER BY MAPHONG ASC", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEditMaPhong.Properties.Items.Add(reader[0].ToString());
                }
            }
        }

        private void setCaptionForm()
        {
            string Caption = null;
            if (!Convert.IsDBNull(dataRow["MAMAY"]))
            {
                Caption += dataRow["MAMAY"]?.ToString();
            }
            this.Text += Caption ?? "Thêm máy mới";
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            comboBoxEditMaTaiKhoan.Text = null;
            comboBoxEditMaPhong.Text = null;
            timeSpanEditThoiGianSuDung.Text = null;
            spinEditGiaTien.Value = 0;
            spinEditSoTien.Value = 0;
            comboBoxEditTrangThai.Text = null;
            comboBoxEditLoaiMay.Text = null;
            memoEditThongSoMay.Text = null;
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiReset_ItemClick(sender, e);
            dataRow = getNewDataRow(3);
            isEdit = false;
            maMay = getNewCode(3, "MAMAY");
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

        private void memoEditThongSoMay_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
