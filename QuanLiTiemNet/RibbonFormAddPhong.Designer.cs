using System;
using DevExpress.XtraBars;

namespace QuanLiTiemNet
{
    partial class RibbonFormAddPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonFormAddPhong));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.textEditTenPhong = new DevExpress.XtraEditors.TextEdit();
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.comboBoxEditLoaiPhong = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditTrangThai = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spinEditDonGia = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider2 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout)).BeginInit();
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLoaiPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditTrangThai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.mainRibbonControl.SearchEditItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiDelete,
            this.bbiClose,
            this.barButtonItem1});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 11;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(530, 143);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Lưu";
            this.bbiSave.Id = 2;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Lưu và đóng";
            this.bbiSaveAndClose.Id = 3;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            this.bbiSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndClose_ItemClick);
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "Lưu và Mới";
            this.bbiSaveAndNew.Id = 4;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            this.bbiSaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndNew_ItemClick);
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "Nhập mới";
            this.bbiReset.Id = 5;
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
            this.bbiReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReset_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Xóa";
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Đóng";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "In";
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "Trang chính";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSave);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndClose);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndNew);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Lưu";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiReset);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Sửa";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Xóa";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Hành động";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Đóng";
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.dxValidationProvider1.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.dxValidationProvider1_ValidationFailed);
            this.dxValidationProvider1.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.dxValidationProvider1_ValidationSucceeded);
            // 
            // textEditTenPhong
            // 
            this.textEditTenPhong.Location = new System.Drawing.Point(95, 42);
            this.textEditTenPhong.MenuManager = this.mainRibbonControl;
            this.textEditTenPhong.Name = "textEditTenPhong";
            this.textEditTenPhong.Size = new System.Drawing.Size(168, 20);
            this.textEditTenPhong.StyleController = this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout;
            this.textEditTenPhong.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Tên phòng không được trống";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.textEditTenPhong, conditionValidationRule1);
            this.textEditTenPhong.TextChanged += new System.EventHandler(this.textEditValidate_EditValueChanged);
            // 
            // RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout
            // 
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.Controls.Add(this.comboBoxEditLoaiPhong);
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.Controls.Add(this.comboBoxEditTrangThai);
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.Controls.Add(this.spinEditDonGia);
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.Controls.Add(this.textEditTenPhong);
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 143);
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.Name = "RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout";
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 91, 650, 400);
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.Root = this.layoutControlGroup2;
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(530, 122);
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.TabIndex = 2;
            // 
            // comboBoxEditLoaiPhong
            // 
            this.comboBoxEditLoaiPhong.Location = new System.Drawing.Point(338, 66);
            this.comboBoxEditLoaiPhong.MenuManager = this.mainRibbonControl;
            this.comboBoxEditLoaiPhong.Name = "comboBoxEditLoaiPhong";
            this.comboBoxEditLoaiPhong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLoaiPhong.Properties.Items.AddRange(new object[] {
            "Phòng máy 1*",
            "Phòng máy 2*",
            "Phòng máy 3*",
            "Phòng máy 4*",
            "Phòng máy 5*",
            "Phòng bếp",
            "Phòng ăn",
            "Sảnh",
            "Phòng thiết bị",
            "Phòng chờ"});
            this.comboBoxEditLoaiPhong.Size = new System.Drawing.Size(168, 20);
            this.comboBoxEditLoaiPhong.StyleController = this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout;
            this.comboBoxEditLoaiPhong.TabIndex = 7;
            // 
            // comboBoxEditTrangThai
            // 
            this.comboBoxEditTrangThai.Location = new System.Drawing.Point(95, 66);
            this.comboBoxEditTrangThai.MenuManager = this.mainRibbonControl;
            this.comboBoxEditTrangThai.Name = "comboBoxEditTrangThai";
            this.comboBoxEditTrangThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditTrangThai.Properties.Items.AddRange(new object[] {
            "Có thể sử dụng",
            "Không thể sử dụng"});
            this.comboBoxEditTrangThai.Size = new System.Drawing.Size(168, 20);
            this.comboBoxEditTrangThai.StyleController = this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout;
            this.comboBoxEditTrangThai.TabIndex = 6;
            // 
            // spinEditDonGia
            // 
            this.spinEditDonGia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditDonGia.Location = new System.Drawing.Point(338, 42);
            this.spinEditDonGia.MenuManager = this.mainRibbonControl;
            this.spinEditDonGia.Name = "spinEditDonGia";
            this.spinEditDonGia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditDonGia.Properties.IsFloatValue = false;
            this.spinEditDonGia.Properties.Mask.EditMask = "c0";
            this.spinEditDonGia.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spinEditDonGia.Size = new System.Drawing.Size(168, 20);
            this.spinEditDonGia.StyleController = this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout;
            this.spinEditDonGia.TabIndex = 5;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup6});
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(530, 122);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.CustomizationFormText = "layoutControlGroup6";
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(510, 102);
            this.layoutControlGroup6.Text = "Thông tin cơ bản";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHtmlStringInCaption = true;
            this.layoutControlItem1.Control = this.textEditTenPhong;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem1.Text = "Tên phòng <b><color=red>*</color></b>";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(486, 12);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.comboBoxEditTrangThai;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem3.Text = "Trạng thái";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.spinEditDonGia;
            this.layoutControlItem2.Location = new System.Drawing.Point(243, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem2.Text = "Phụ phí phòng";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.comboBoxEditLoaiPhong;
            this.layoutControlItem4.Location = new System.Drawing.Point(243, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem4.Text = "Loại phòng";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
            // 
            // dxValidationProvider2
            // 
            this.dxValidationProvider2.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // RibbonFormAddPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(530, 265);
            this.Controls.Add(this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "RibbonFormAddPhong";
            this.Ribbon = this.mainRibbonControl;
            this.Text = "Quản lí tiệm nét - ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RibbonFormAddPhong_FormClosing);
            this.Load += new System.EventHandler(this.RibbonFormAddPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout)).EndInit();
            this.RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLoaiPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditTrangThai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider2;
        private DevExpress.XtraLayout.LayoutControl RibbonFormAddNguoiDungNhanVienlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLoaiPhong;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditTrangThai;
        private DevExpress.XtraEditors.SpinEdit spinEditDonGia;
        private DevExpress.XtraEditors.TextEdit textEditTenPhong;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}