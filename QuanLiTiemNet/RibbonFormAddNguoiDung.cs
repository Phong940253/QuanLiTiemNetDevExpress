﻿using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLiTiemNet
{
    public partial class RibbonFormAddNguoiDung : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataRow dataRow;
        sendNewDataRow sendNewNguoiDung;
        editData sendEditData;
        GridView gridView;
        int maNguoiDung;
        xoaDataRow deleDataRow;
        getNewDataRow getNewDataRow;
        bool isEdit;
        getNewCode getNewCode;

        public RibbonFormAddNguoiDung()
        {
            InitializeComponent();
        }
        public RibbonFormAddNguoiDung(DataRow dataRow, getNewDataRow getNewRow, xoaDataRow deleDataRow, getNewCode getNewCode) : this()
        {
            this.dataRow = dataRow;
            this.getNewDataRow = getNewRow;
            this.deleDataRow = deleDataRow;
            this.getNewCode = getNewCode;
        }

        public RibbonFormAddNguoiDung(bool isEdit, sendNewDataRow senderNew, editData senderEdit, DataRow dataRow, ref GridView gridView, int maNguoiDung, xoaDataRow deleDataRow, getNewDataRow getNewRow, getNewCode getNewCode) : this(dataRow, getNewRow, deleDataRow, getNewCode)
        {
            this.sendNewNguoiDung = senderNew;
            this.sendEditData = senderEdit;
            this.maNguoiDung = maNguoiDung;
            this.gridView = gridView;
            this.isEdit = isEdit;
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
            if (!isEdit) dataRow["MANGUOIDUNG"] = maNguoiDung;
            dataRow["HO"] = textEditHo.Text;
            dataRow["TENDEM"] = textEditTenDem.Text;
            dataRow["TEN"] = textEditTen.Text;
            dataRow["NGAYTAO"] = DateTime.Now;
            dataRow["SDT"] = textEditSDT.Text;
            dataRow["EMAIL"] = textEditEmail.Text;
            dataRow["DIACHI"] = textEditDiaChi.Text;
            if (isEdit) sendEditData(dataRow, ref gridView);
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
            dataRow = getNewDataRow(1);
            isEdit = false;
            maNguoiDung = getNewCode(1, "MANGUOIDUNG");
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
