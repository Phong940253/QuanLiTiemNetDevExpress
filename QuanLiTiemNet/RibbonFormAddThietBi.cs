using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLiTiemNet
{
    public partial class RibbonFormAddThietBi : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        sendNewDataRow sendNewThietBi;
        editData sendEditData;
        GridView gridView;
        int maThietBi;
        xoaDataRow deleDataRow;
        getNewDataRow getNewDataRow;
        bool isEdit;
        getNewCode getNewCode;
        public RibbonFormAddThietBi()
        {
            InitializeComponent();
        }
        public RibbonFormAddThietBi(DataRow dataRow, getNewDataRow getNewRow, xoaDataRow deleDataRow, getNewCode getNewCode) : this()
        {
            this.dataRow = dataRow;
            this.getNewDataRow = getNewRow;
            this.deleDataRow = deleDataRow;
            this.getNewCode = getNewCode;
        }

        public RibbonFormAddThietBi(bool isEdit, sendNewDataRow senderNew, editData senderEdit, DataRow dataRow, ref GridView gridView, int maThietBi, xoaDataRow deleDataRow, getNewDataRow getNewRow, getNewCode getNewCode) : this(dataRow, getNewRow, deleDataRow, getNewCode)
        {
            this.sendNewThietBi = senderNew;
            this.sendEditData = senderEdit;
            this.maThietBi = maThietBi;
            this.gridView = gridView;
            this.isEdit = isEdit;
        }


        private void loadDataRow()
        {
            textEditTenThietBi.Text = dataRow["TENTHIETBI"]?.ToString();
            comboBoxEditMaMay.Text = dataRow["MAMAY"].ToString();
            comboBoxEditTrangThai.Text = dataRow["TRANGTHAI"]?.ToString();
            spinEditGiaTien.Text = dataRow["GIATIEN"]?.ToString();
            memoEditThongTinThietBi.Text = dataRow["THONGTINTHIETBI"]?.ToString();
            comboBoxEditLoai.Text = dataRow["LOAI"]?.ToString();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isEdit) dataRow["MATHIETBI"] = maThietBi;
            dataRow["TENTHIETBI"] = textEditTenThietBi.Text;
            dataRow["GIATIEN"] = spinEditGiaTien.Value.ToString();
            dataRow["TRANGTHAI"] = string.IsNullOrEmpty(comboBoxEditTrangThai.Text) ? "Không sử dụng" : comboBoxEditTrangThai.Text;
            dataRow["LOAI"] = string.IsNullOrEmpty(comboBoxEditLoai.Text) ? "Khác" : comboBoxEditLoai.Text;
            if (!string.IsNullOrEmpty(comboBoxEditMaMay.Text))
                dataRow["MAMAY"] = comboBoxEditMaMay.Text;
            if (isEdit) sendEditData(dataRow, ref gridView);
            else sendNewThietBi(dataRow);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void RibbonFormAddThietBi_FormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(textEditTenThietBi.Text))
                lockSave();
            else
                unlockSave();
        }

        private void RibbonFormAddThietBi_Load(object sender, EventArgs e)
        {
            setCaptionForm();
            lockSave();
            loadDataRow();
            fillMaMay();
        }
        private void fillMaMay()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["QuanLiTiemNet.Properties.Settings.quanlitiemnetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MAMAY FROM MAY ORDER BY MAMAY ASC", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEditMaMay.Properties.Items.Add(reader[0].ToString());
                }
            }
        }
        private void setCaptionForm()
        {
            string Caption = null;
            if (!Convert.IsDBNull(dataRow["TENTHIETBI"]))
            {
                Caption += dataRow["TENTHIETBI"]?.ToString();
            }
            this.Text += Caption ?? "Thiết bị mới";
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEditTenThietBi.Text = null;
            comboBoxEditMaMay.Text = null;
            comboBoxEditTrangThai.Text = null;
            spinEditGiaTien.Value = 0;
            memoEditThongTinThietBi.Text = null;
            comboBoxEditLoai.Text = null;
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiSave_ItemClick(sender, e);
            bbiReset_ItemClick(sender, e);
            dataRow = getNewDataRow(4);
            isEdit = false;
            maThietBi = getNewCode(4, "MATHIETBI");
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
