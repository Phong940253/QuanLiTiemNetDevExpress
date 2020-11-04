using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLiTiemNet
{
    public delegate void editData(DataRow dataRow, ref GridView gridView);
    public delegate void sendNewDataRow(DataRow dataRow);
    public delegate void xoaDataRow(object sender, ItemClickEventArgs e);
    public delegate DataRow getNewDataRow(int index);
    public delegate int getNewCode(int index, string column);

    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SqlConnection sqlConnection;
        SqlDataAdapter sqlDataNhanVien, sqlDataNguoiDung, sqlDataTaiKhoan, sqlDataMay, sqlDataThietBi, sqlDataPhong, sqlDataGiaoDich, sqlDataKhuyenMai;
        SqlCommandBuilder sqlCommandNhanVien, sqlCommandNguoiDung, sqlCommandTaiKhoan, sqlCommandMay, sqlCommandThietBi, sqlCommandPhong, sqlCommandGiaoDich, sqlCommandKhuyenMai;
        DataSet quanLiTiemNet = new DataSet();

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            setProfile(e.RowHandle);
        }

        string stringConnection;
        public RibbonForm1()
        {
            InitializeComponent();
            gridView1.CustomDrawGroupRow += GridView1_CustomDrawGroupRow;

        }

        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (navigationFrame1.SelectedPage == navigationPage1)
                deleteRowGridView(ref gridView1);
            else if (navigationFrame1.SelectedPage == navigationPage2)
                deleteRowGridView(ref gridView2);
            else if (navigationFrame1.SelectedPage == navigationPage3)
                deleteRowGridView(ref gridView3);
            else if (navigationFrame1.SelectedPage == navigationPage4)
                deleteRowGridView(ref gridView3);
            else if (navigationFrame1.SelectedPage == navigationPage5)
                deleteRowGridView(ref gridView3);
            else if (navigationFrame1.SelectedPage == navigationPage6)
                deleteRowGridView(ref gridView6);
            else if (navigationFrame1.SelectedPage == navigationPage7)
                deleteRowGridView(ref gridView3);
        }

        private void deleteRowGridView(ref GridView gridView)
        {
            try
            {
                gridView.DeleteSelectedRows();
                SaveDatabase(ref gridView);
                if (gridView == gridView1)
                    setProfile(gridView.GetSelectedRows()[0]);
                else if (gridView == gridView2)
                    ;
                else if (gridView == gridView3)
                    setTaiKhoan(gridView.GetSelectedRows()[0]);
                else if (gridView == gridView6)
                    ;
                updateRecord(ref gridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            getStringConnection();
            getSqlConnection();
            getDataSet();
            lockBarButton(1);
            loadTableNhanVien();
            loadTableNguoiDung();
            loadTableTaiKhoan();
            loadTablePhong();
            setProfile(0);
            setTaiKhoan(0);
            gridView1.SelectRow(1);
            updateRecord(ref gridView1);
        }

        private void navigationPane1_Click(object sender, EventArgs e)
        {

        }

        private void officeNavigationBar1_Click(object sender, EventArgs e)
        {
            if (officeNavigationBar1.SelectedItem.Text == "Nhân viên")
            {

            }
            else if (officeNavigationBar1.SelectedItem.Text == "Người dùng")
            {
                barButtonItemAddNguoiDung.Links[0].Visible = true;
                barButtonItemAddNhanVien.Links[0].Visible = false;
                barButtonItemAddTaiKhoan.Links[0].Visible = false;
            }
        }

        private void officeNavigationBar1_ItemClick(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "navigationPage1":
                    lockBarButton(1);
                    updateRecord(ref gridView1);
                    break;
                case "navigationPage2":
                    lockBarButton(2);
                    updateRecord(ref gridView2);
                    break;
                case "navigationPage3":
                    lockBarButton(3);
                    updateRecord(ref gridView3);
                    break;
                case "navigationPage6":
                    lockBarButton(6);
                    updateRecord(ref gridView6);
                    break;
                default:
                    break;
            }
        }
        private void lockBarButton(int index)
        {
            BarButtonItem[] barButtonItems = { barButtonItemAddNhanVien, barButtonItemAddNguoiDung, barButtonItemAddTaiKhoan, barButtonItemAddMay, barButtonItemAddThietBi, barButtonItemAddPhong };
            int i = 1;
            foreach (BarButtonItem BarButton in barButtonItems)
            {
                if (i++ != index) BarButton.Links[0].Visible = false;
            }
            barButtonItems[index - 1].Links[0].Visible = true;
        }

        private void barButtonItemAddNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            RibbonFormAddNhanVien addNhanVien = new RibbonFormAddNhanVien(false, addDataSetNhanVien, editDataSet, quanLiTiemNet.Tables[0].NewRow(), ref gridView1, barButtonItemDelete_ItemClick, GetNewDataRow);
            addNhanVien.Show();
        }

        private void gridView3_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            setTaiKhoan(e.RowHandle);
        }

        private void getSqlConnection()
        {
            sqlConnection = new SqlConnection(stringConnection);
        }

        private void getDataSet()
        {
            sqlDataNhanVien = new SqlDataAdapter("SELECT * FROM NHANVIEN", sqlConnection);
            sqlCommandNhanVien = new SqlCommandBuilder(sqlDataNhanVien);
            sqlDataNguoiDung = new SqlDataAdapter("SELECT * FROM NGUOIDUNG", sqlConnection);
            sqlCommandNguoiDung = new SqlCommandBuilder(sqlDataNguoiDung);
            sqlDataTaiKhoan = new SqlDataAdapter("SELECT * FROM TAIKHOAN", sqlConnection);
            sqlCommandTaiKhoan = new SqlCommandBuilder(sqlDataTaiKhoan);
            sqlDataMay = new SqlDataAdapter("SELECT * FROM MAY", sqlConnection);
            sqlCommandMay = new SqlCommandBuilder(sqlDataMay);
            sqlDataThietBi = new SqlDataAdapter("SELECT * FROM THIETBI", sqlConnection);
            sqlCommandThietBi = new SqlCommandBuilder(sqlDataThietBi);
            sqlDataPhong = new SqlDataAdapter("SELECT * FROM PHONG", sqlConnection);
            sqlCommandPhong = new SqlCommandBuilder(sqlDataPhong);
            sqlDataGiaoDich = new SqlDataAdapter("SELECT * FROM GIAODICH", sqlConnection);
            sqlCommandGiaoDich = new SqlCommandBuilder(sqlDataGiaoDich);
            sqlDataKhuyenMai = new SqlDataAdapter("SELECT * FROM KHUYENMAI", sqlConnection);
            sqlCommandKhuyenMai = new SqlCommandBuilder(sqlDataKhuyenMai);
            sqlDataNhanVien.Fill(quanLiTiemNet, "NHANVIEN");
            sqlDataNguoiDung.Fill(quanLiTiemNet, "NGUOIDUNG");
            sqlDataTaiKhoan.Fill(quanLiTiemNet, "TAIKHOAN");
            sqlDataThietBi.Fill(quanLiTiemNet, "THIETBI");
            sqlDataMay.Fill(quanLiTiemNet, "MAY");
            sqlDataPhong.Fill(quanLiTiemNet, "PHONG");
            sqlDataGiaoDich.Fill(quanLiTiemNet, "GIAODICH");
            sqlDataKhuyenMai.Fill(quanLiTiemNet, "KHUYENMAI");
        }

        private void getStringConnection()
        {
            stringConnection = ConfigurationManager.ConnectionStrings["QuanLiTiemNet.Properties.Settings.quanlitiemnetConnectionString"].ConnectionString;
        }

        private void loadTableNhanVien()
        {
            gridControl1.DataSource = quanLiTiemNet;
            gridControl1.DataMember = "NHANVIEN";
        }

        private void loadTableNguoiDung()
        {
            gridControl2.DataSource = quanLiTiemNet;
            gridControl2.DataMember = "NGUOIDUNG";
        }

        private void loadTableTaiKhoan()
        {
            gridControl3.DataSource = quanLiTiemNet;
            gridControl3.DataMember = "TAIKHOAN";
        }

        private void loadTablePhong()
        {
            gridControl6.DataSource = quanLiTiemNet;
            gridControl6.DataMember = "PHONG";
        }

        public void addDataSetNhanVien(DataRow dataRow)
        {
            try
            {
                quanLiTiemNet.Tables[0].Rows.Add(dataRow);
                SaveDatabase(ref gridView1);
            }
            catch (ArgumentException ex)
            {
            }

        }

        public void addDataSetNguoiDung(DataRow dataRow)
        {
            try
            {
                quanLiTiemNet.Tables[1].Rows.Add(dataRow);
                SaveDatabase(ref gridView2);
            }
            catch (ArgumentException ex)
            {
            }
        }
        public void addDataSetTaiKhoan(DataRow dataRow)
        {
            try
            {
                quanLiTiemNet.Tables[2].Rows.Add(dataRow);
                SaveDatabase(ref gridView3);
            }
            catch (ArgumentException ex)
            {
            }
        }

        public void addDataSetPhong(DataRow dataRow)
        {
            try
            {
                quanLiTiemNet.Tables[5].Rows.Add(dataRow);
                SaveDatabase(ref gridView6);
            }
            catch (ArgumentException ex)
            {
            }
        }


        public void editDataSet(DataRow dataRow, ref GridView gridView)
        {
            SaveDatabase(ref gridView);
        }

        private void SaveDatabase(ref GridView gridView)
        {
            try
            {
                if (gridView == gridView1)
                    sqlDataNhanVien.Update(quanLiTiemNet, "NHANVIEN");
                else if (gridView == gridView2)
                    sqlDataNguoiDung.Update(quanLiTiemNet, "NGUOIDUNG");
                else if (gridView == gridView3)
                    sqlDataTaiKhoan.Update(quanLiTiemNet, "TAIKHOAN");
                else if (gridView == gridView6)
                    sqlDataPhong.Update(quanLiTiemNet, "PHONG");
                updateRecord(ref gridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setPictureEditAvatarNhanVien(byte[] byteImage)
        {
            pictureEditAvatar.Image = (byteImage != null ? ProcessImage.byteArrayToImage(byteImage) : null);
        }

        private void setTenNhanVien(string ten)
        {
            if (ten != null)
                simpleLabelItem1.Text = ten;
        }

        private void barButtonItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (navigationFrame1.SelectedPage == navigationPage1)
            {
                editDataSet(gridView1);
            }
            else if (navigationFrame1.SelectedPage == navigationPage2)
            {
                editDataSet(gridView2);
            }
            else if (navigationFrame1.SelectedPage == navigationPage3)
            {
                editDataSet(gridView3);
            }
            else if (navigationFrame1.SelectedPage == navigationPage4)
            {
                editDataSet(gridView3);
            }
            else if (navigationFrame1.SelectedPage == navigationPage5)
            {
                editDataSet(gridView3);
            }
            else if (navigationFrame1.SelectedPage == navigationPage6)
            {
                editDataSet(gridView6);
            }
            else if (navigationFrame1.SelectedPage == navigationPage7)
            {
                editDataSet(gridView3);
            }
        }

        private void editDataSet(GridView gridView)
        {
            int rowHandle = gridView.FocusedRowHandle;

            if (gridView == gridView1)
            {
                RibbonFormAddNhanVien editNhanVien = new RibbonFormAddNhanVien(true, addDataSetNhanVien, editDataSet, gridView.GetDataRow(gridView.GetSelectedRows()[0]), ref gridView, barButtonItemDelete_ItemClick, GetNewDataRow);
                editNhanVien.Show();
                SaveDatabase(ref gridView);
            }
            else if (gridView == gridView2)
            {
                int indexMaNguoiDung = (int)gridView.GetDataRow(gridView.GetSelectedRows()[0])["MANGUOIDUNG"];
                RibbonFormAddNguoiDung editNguoiDung = new RibbonFormAddNguoiDung(true, addDataSetNguoiDung, editDataSet, gridView.GetDataRow(gridView.GetSelectedRows()[0]), ref gridView, indexMaNguoiDung, barButtonItemDelete_ItemClick, GetNewDataRow, GetNewCode);
                editNguoiDung.Show();
                SaveDatabase(ref gridView);
            }
            else if (gridView == gridView3)
            {
                int indexMaTaiKhoan = (int)gridView.GetDataRow(gridView.GetSelectedRows()[0])["MATK"];
                RibbonFormAddTaiKhoan editTaiKhoan = new RibbonFormAddTaiKhoan(true, addDataSetTaiKhoan, editDataSet, gridView.GetDataRow(gridView.GetSelectedRows()[0]), ref gridView, indexMaTaiKhoan, barButtonItemDelete_ItemClick, GetNewDataRow, GetNewCode);
                editTaiKhoan.Show();
                SaveDatabase(ref gridView);
            }
            else if (gridView == gridView6)
            {
                int indexMaPhong = (int)gridView.GetDataRow(gridView.GetSelectedRows()[0])["MAPHONG"];
                RibbonFormAddPhong editPhong = new RibbonFormAddPhong(true, addDataSetPhong, editDataSet, gridView.GetDataRow(gridView.GetSelectedRows()[0]), ref gridView, indexMaPhong, barButtonItemDelete_ItemClick, GetNewDataRow, GetNewCode);
                editPhong.Show();
                SaveDatabase(ref gridView);
            }

        }

        private void setChucVuNhanVien(string chucVu)
        {
            simpleLabelItem2.Text = (chucVu != null ? chucVu : "Trống");
        }

        private void barStaticItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void setProfile(int index)
        {
            DataRow dataRow = gridView1.GetDataRow(index);
            if (!Convert.IsDBNull(dataRow["ANH"]))
                setPictureEditAvatarNhanVien((byte[])dataRow["ANH"]);
            else
                setPictureEditAvatarNhanVien(null);
            setTenNhanVien(dataRow["HO"]?.ToString() + " " + dataRow["TENDEM"]?.ToString() + " " + dataRow["TEN"]?.ToString());
            setChucVuNhanVien(dataRow["CHUCVU"]?.ToString());
        }

        private void barButtonItemAddTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            int indexMaTaiKhoan = GetNewCode(2, "MATK");
            RibbonFormAddTaiKhoan addTaiKhoan = new RibbonFormAddTaiKhoan(false, addDataSetTaiKhoan, editDataSet, quanLiTiemNet.Tables[2].NewRow(), ref gridView3, indexMaTaiKhoan, barButtonItemDelete_ItemClick, GetNewDataRow, GetNewCode);
            addTaiKhoan.Show();
        }

        private void barButtonItemAddNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            int indexMaNguoiDung = GetNewCode(1, "MAPHONG");
            RibbonFormAddNguoiDung addNguoiDung = new RibbonFormAddNguoiDung(false, addDataSetNguoiDung, editDataSet, quanLiTiemNet.Tables[5].NewRow(), ref gridView6, indexMaNguoiDung, barButtonItemDelete_ItemClick, GetNewDataRow, GetNewCode);
            addNguoiDung.Show();
        }
        private void barButtonItemAddPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            int indexMaPhong = GetNewCode(5, "MAPHONG");
            RibbonFormAddPhong addPhong = new RibbonFormAddPhong(false, addDataSetPhong, editDataSet, quanLiTiemNet.Tables[5].NewRow(), ref gridView6, indexMaPhong, barButtonItemDelete_ItemClick, GetNewDataRow, GetNewCode);
            addPhong.Show();
        }

        public DataRow GetNewDataRow(int index)
        {
            return quanLiTiemNet.Tables[index].NewRow();
        }

        public int GetNewCode(int index, string column)
        {
            return (quanLiTiemNet.Tables[index].Rows.Count == 0 ? 1 : (int)quanLiTiemNet.Tables[index].Rows[quanLiTiemNet.Tables[index].Rows.Count - 1][column] + 1);
        }

        private void setTaiKhoan(int index)
        {
            DataRow dataRow = gridView3.GetDataRow(index);
            setMaTaiKhoan(dataRow["MATK"]?.ToString());
            setTenTaiKhoan(dataRow["TENTK"]?.ToString());
            setMatKhauTaiKhoan(dataRow["MATKHAU"]?.ToString());
            setTongTien(dataRow["TONGTIEN"]?.ToString());
            setLoaiTaiKhoan(dataRow["LOAI"]?.ToString());
            setTrangThaiTaiKhoan(dataRow["TRANGTHAI"]?.ToString());
            setNgayTaoTaiKhoan(dataRow["NGAYTAO"]?.ToString());
            setSoGioSuDung(dataRow["SOGIOSUDUNG"]?.ToString());
            setMaNguoiDung(dataRow["MANGUOIDUNG"]?.ToString());
            setSoTienSuDung(dataRow["SOTIENSUDUNG"]?.ToString());
            setNguoiTaoTaiKhoan(dataRow["NGUOITAO"]?.ToString());
        }

        private void setMaTaiKhoan(string s)
        {
            textEdit11.Text = s;
        }

        private void setTenTaiKhoan(string s)
        {
            textEdit2.Text = s;
        }

        private void setMatKhauTaiKhoan(string s)
        {
            textEdit3.Text = s;
        }

        private void setTongTien(string s)
        {
            spinEdit1.Text = s;
        }

        private void setTrangThaiTaiKhoan(string s)
        {
            textEdit31.Text = s;
        }

        private void setLoaiTaiKhoan(string s)
        {
            textEdit32.Text = s;
        }

        private void setSoGioSuDung(string s)
        {
            textEdit34.Text = s;
        }

        private void setMaNguoiDung(string s)
        {
            textEdit13.Text = s;
        }

        private void setSoTienSuDung(string s)
        {
            spinEdit2.Text = s;
        }

        private void setNgayTaoTaiKhoan(string s)
        {
            textEdit12.Text = s;
        }

        private void setNguoiTaoTaiKhoan(string s)
        {
            textEdit33.Text = s;
        }

        private void GridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            GridView view = sender as GridView;
            if (info.Column == colCHUCVU)
            {
                info.GroupText = info.GroupValueText + " (Số lượng = " + gridView1.GetChildRowCount(e.RowHandle) + ")";
            }
        }

        private void updateRecord(ref GridView gridView)
        {
            barStaticItem1.Caption = "Số lượng: " + gridView.DataRowCount;
        }
    }
}