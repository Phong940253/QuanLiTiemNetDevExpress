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
            else if (navigationFrame1.SelectedPage == navigationPage3)
                deleteRowGridView(ref gridView3);
            else if (navigationFrame1.SelectedPage == navigationPage3)
                deleteRowGridView(ref gridView3);
            else if (navigationFrame1.SelectedPage == navigationPage3)
                deleteRowGridView(ref gridView3);
            else if (navigationFrame1.SelectedPage == navigationPage3)
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
                default:
                    break;
            }
        }
        private void lockBarButton(int index)
        {
            BarButtonItem[] barButtonItems = { barButtonItemAddNhanVien, barButtonItemAddNguoiDung, barButtonItemAddTaiKhoan };
            int i = 1;
            foreach (BarButtonItem BarButton in barButtonItems)
            {
                if (i++ != index) BarButton.Links[0].Visible = false;
            }
            barButtonItems[index - 1].Links[0].Visible = true;
        }

        private void barButtonItemAddNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            RibbonFormAddNhanVien addNhanVien = new RibbonFormAddNhanVien(addDataSetNhanVien, quanLiTiemNet.Tables[0].NewRow());
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
            else if (navigationFrame1.SelectedPage == navigationPage3)
            {
                editDataSet(gridView3);
            }
            else if (navigationFrame1.SelectedPage == navigationPage3)
            {
                editDataSet(gridView3);
            }
            else if (navigationFrame1.SelectedPage == navigationPage3)
            {
                editDataSet(gridView3);
            }
            else if (navigationFrame1.SelectedPage == navigationPage3)
            {
                editDataSet(gridView3);
            }
        }

        private void editDataSet(GridView gridView)
        {
            int rowHandle = gridView.FocusedRowHandle;
            if (gridView == gridView1)
            {
                RibbonFormAddNhanVien editNhanVien = new RibbonFormAddNhanVien(editDataSet, quanLiTiemNet.Tables[0].Rows[gridView.GetSelectedRows()[0]], ref gridView);
                editNhanVien.Show();
                SaveDatabase(ref gridView);
            }
            else if (gridView == gridView2)
            {
                RibbonFormAddNguoiDung editNguoiDung = new RibbonFormAddNguoiDung(editDataSet, quanLiTiemNet.Tables[1].Rows[gridView.GetSelectedRows()[0]], ref gridView);
                editNguoiDung.Show();
                SaveDatabase(ref gridView);
            }
            else if (gridView == gridView3)
            {
                RibbonFormAddTaiKhoan editTaiKhoan = new RibbonFormAddTaiKhoan(editDataSet, quanLiTiemNet.Tables[2].Rows[gridView.GetSelectedRows()[0]], ref gridView);
                editTaiKhoan.Show();
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
            DataRow dataRow = quanLiTiemNet.Tables[0].Rows[index];
            if (!Convert.IsDBNull(dataRow["ANH"]))
                setPictureEditAvatarNhanVien((byte[])dataRow["ANH"]);
            else
                setPictureEditAvatarNhanVien(null);
            setTenNhanVien(dataRow["HO"]?.ToString() + " " + dataRow["TENDEM"]?.ToString() + " " + dataRow["TEN"]?.ToString());
            setChucVuNhanVien(dataRow["CHUCVU"]?.ToString());
        }

        private void barButtonItemAddTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            int indexMaTaiKhoan;
            indexMaTaiKhoan = quanLiTiemNet.Tables[2].Rows.Count == 1 ? 1 : (int)quanLiTiemNet.Tables[2].Rows[quanLiTiemNet.Tables[2].Rows.Count - 1]["MATK"] + 1;
            RibbonFormAddTaiKhoan addTaiKhoan = new RibbonFormAddTaiKhoan(addDataSetTaiKhoan, quanLiTiemNet.Tables[2].NewRow(), indexMaTaiKhoan);
            addTaiKhoan.Show();
        }

        private void barButtonItemAddNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            int indexMaNguoiDung;
            indexMaNguoiDung = quanLiTiemNet.Tables[1].Rows.Count == 1 ? 1 : (int)quanLiTiemNet.Tables[1].Rows[quanLiTiemNet.Tables[1].Rows.Count - 1]["MATK"] + 1;
            RibbonFormAddNguoiDung addNguoiDung = new RibbonFormAddNguoiDung(addDataSetNguoiDung, quanLiTiemNet.Tables[1].NewRow(), indexMaNguoiDung);
            addNguoiDung.Show();
        }

        private void setTaiKhoan(int index)
        {
            DataRow dataRow = quanLiTiemNet.Tables[2].Rows[index];
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
            textEdit4.Text = s;
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
            textEdit22.Text = s;
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