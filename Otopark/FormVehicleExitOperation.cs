using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark
{
    public partial class FormVehicleExitOperation : Form
    {
        public FormVehicleExitOperation()
        {
            InitializeComponent();
        }

        OtoparkEntities1 db = new OtoparkEntities1();

        private void FormVehicleExitOperation_Load(object sender, EventArgs e)
        {
            FillCmbNumberPlate();
            FillDataGrid();

        }


        private void FillCmbNumberPlate()
        {

            var FillNumberPlate = db.Relationships.Where(x => x.ReleaseDate==null).Select(x => new
            {
                x.VehicleID,
                x.Vehicle.NumberPlate,
            }).ToList();

            cmbNumberPlate.DisplayMember = "NumberPlate";
            cmbNumberPlate.ValueMember = "VehicleID";
            cmbNumberPlate.DataSource = FillNumberPlate;

        }

        private void FillDataGrid()
        {
            var FillDataGrid = db.Relationships.Select(x => new
            {

                Ad = x.Customer.CustomerName + " " + x.Customer.CustomerSurname,
                TC = x.Customer.CustomerTC,
                Telefon = x.Customer.CustomerPhone,
                Plaka = x.Vehicle.NumberPlate,
                Marka = x.Vehicle.Brand,
                Model = x.Vehicle.Model,
                Renk = x.Vehicle.Color,
                GirişTarihi = x.EntryDate,
                Çıkış_Tarihi = x.ReleaseDate,
                Yer = x.Place.PlaceName,
                Ücret = x.Price,
            }).ToList();

            dataGridView1.DataSource = FillDataGrid;

        }


        //Ücret Hesapla Butonu
        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {

            var vehicle = db.Vehicles.Where(x => x.VehicleID == (int)cmbNumberPlate.SelectedValue).Select(x=> x).FirstOrDefault();
            int findVehicleID = vehicle.VehicleID; //VehicleID'yi bulduk

            var relation = db.Relationships.Where(x => x.VehicleID == findVehicleID && x.ReleaseDate==null).Select(x => x).FirstOrDefault();

 
            // DateTime dateTime1 = DateTime.Now; //şuanki zaman alındı
            DateTime releaseDate = dtpckrReleaseDate.Value; //çıkış tarihi şuan atılıyo
            DateTime entryDate = relation.EntryDate; //Bulunan kayıttaki giriş tarihi bir değişkene atıldı

            TimeSpan ts = releaseDate - entryDate ;

            txtPrice.Text = UcretHesapla(ts).ToString();

        }


        private int UcretHesapla(TimeSpan ts)
        {

           int convertTimeSpan = Convert.ToInt32(ts.TotalHours);
            int ucret = convertTimeSpan * 5;
            return ucret;
        }


        //Kaydet butonu
        private void btnSave_Click(object sender, EventArgs e)
        {

            var vehicle = db.Vehicles.Where(x => x.VehicleID == (int)cmbNumberPlate.SelectedValue).Select(x => x).FirstOrDefault();
            int findVehicleID = vehicle.VehicleID; //VehicleID'yi bulduk

            var relation = db.Relationships.Where(x => x.VehicleID == findVehicleID && x.ReleaseDate == null).Select(x => x).FirstOrDefault();

            relation.ReleaseDate = dtpckrReleaseDate.Value;
            relation.Price = Convert.ToInt32(txtPrice.Text);
            relation.Place.EmptyOrFull = "Boş";

            db.SaveChanges();

            MessageBox.Show("Kaydedildi.");

            FillCmbNumberPlate();
            FillDataGrid();

        }


        //TC ile kayıta erişim
        private void btnFind_Click(object sender, EventArgs e)
        {

            try
            {
                var FindCustomer = db.Customers.Where(x => x.CustomerTC == mskTxtTC.Text).Select(x => x).FirstOrDefault();

                int CustomerID = FindCustomer.CustomerID;

                var FillDataGridRelationship = db.Relationships.Where(x => x.CustomerID == CustomerID ).Select(x => new
                {
                    Ad = x.Customer.CustomerName + " " + x.Customer.CustomerSurname,
                    TC = x.Customer.CustomerTC,
                    Telefon = x.Customer.CustomerPhone,
                    Plaka = x.Vehicle.NumberPlate,
                    Marka = x.Vehicle.Brand,
                    Model = x.Vehicle.Model,
                    Renk = x.Vehicle.Color,
                    GirişTarihi = x.EntryDate,
                    Çıkış_Tarihi = x.ReleaseDate,
                    Yer = x.Place.PlaceName,
                    Ücret = x.Price,

                }).ToList();

                dataGridView1.DataSource = FillDataGridRelationship;
            }
            catch (Exception)
            {

                MessageBox.Show("Böyle bir kullanıcı bulunamadı lütfen tc'yi kontrol edip tekrar deneyiniz.");
            }



        }

        //Tüm kayıtları listeleme
        private void btnList_Click(object sender, EventArgs e)
        {

            FillDataGrid();

        }

  
    }
}
