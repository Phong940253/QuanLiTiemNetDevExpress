using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;

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
            comboBoxEditMaNV.Text = dataRow["MANV"]?.ToString();
            comboBoxEditMaThietBi.Text = dataRow["MATB"].ToString();
            comboBoxEditMaTK.Text = dataRow["MATK"]?.ToString();
            spinEditTienThu.Text = dataRow["TIENTHU"]?.ToString();
            comboBoxEditLoaiGiaoDich.Text = dataRow["LOAI"]?.ToString();
            spinEditTienTra.Text = dataRow["TIENTRA"]?.ToString();
            memoEditNoiDungGiaoDich.Text = dataRow["NOIDUNGGIAODICH"]?.ToString();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isEdit) dataRow["MAGD"] = maGiaoDich;
            if (!string.IsNullOrEmpty(comboBoxEditMaKhuyenMai.Text))
                dataRow["MAKM"] = comboBoxEditMaKhuyenMai.Text;
            if (!string.IsNullOrEmpty(comboBoxEditMaNV.Text))
                dataRow["MANV"] = comboBoxEditMaNV.Text;
            if (!string.IsNullOrEmpty(comboBoxEditMaTK.Text))
                dataRow["MATK"] = comboBoxEditMaTK.Text;
            dataRow["TIENTHU"] = spinEditTienThu.Value.ToString();
            dataRow["TIENTRA"] = spinEditTienTra.Value.ToString();
            dataRow["LOAI"] = string.IsNullOrEmpty(comboBoxEditLoaiGiaoDich.Text) ? "Thường" : comboBoxEditLoaiGiaoDich.Text;
            dataRow["THOIGIAN"] = DateTime.Now;
            dataRow["NOIDUNGGIAODICH"] = memoEditNoiDungGiaoDich.Text;
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
            if (string.IsNullOrEmpty(comboBoxEditMaNV.Text))
                lockSave();
            else
                unlockSave();
        }

        private void RibbonFormAddGiaoDich_Load(object sender, EventArgs e)
        {
            setCaptionForm();
            lockSave();
            loadDataRow();
            fillMaiKhoan();
            fillMaNhanVien();
            fillMaThietBi();
        }
        private void fillMaNhanVien()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["QuanLiTiemNet.Properties.Settings.quanlitiemnetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MANV FROM NHANVIEN ORDER BY MANV ASC", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEditMaNV.Properties.Items.Add(reader[0].ToString());
                }
            }
        }
        private void fillMaiKhoan()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["QuanLiTiemNet.Properties.Settings.quanlitiemnetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MATK FROM TAIKHOAN ORDER BY MATK ASC", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEditMaTK.Properties.Items.Add(reader[0].ToString());
                }
            }
        }
        private void fillMaThietBi()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["QuanLiTiemNet.Properties.Settings.quanlitiemnetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MATHIETBI FROM THIETBI ORDER BY MATHIETBI ASC", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEditMaThietBi.Properties.Items.Add(reader[0].ToString());
                }
            }
        }
        private void setCaptionForm()
        {
            string Caption = null;
            if (!Convert.IsDBNull(dataRow["MAGD"]))
            {
                Caption += dataRow["LOAI"]?.ToString() + dataRow["MAGD"]?.ToString();
            }
            this.Text += Caption ?? "Giao dịch mới";
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            comboBoxEditMaNV.Text = null;
            comboBoxEditMaTK.Text = null;
            spinEditTienThu.Text = null;
            spinEditTienTra.Text = null;
            comboBoxEditLoaiGiaoDich.Text = null;
            comboBoxEditMaThietBi.Text = null;
            comboBoxEditMaKhuyenMai.Text = null;
            memoEditNoiDungGiaoDich.Text = null;
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiReset_ItemClick(sender, e);
            dataRow = getNewDataRow(2);
            isEdit = false;
            maGiaoDich = getNewCode(6, "MAGD");
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
