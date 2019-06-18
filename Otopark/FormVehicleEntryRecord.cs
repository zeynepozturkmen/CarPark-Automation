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
    public partial class FormVehicleEntryRecord : Form
    {
        public FormVehicleEntryRecord()
        {
            InitializeComponent();
        }

        OtoparkEntities1 db = new OtoparkEntities1();

       

        private void FormVehicleEntryRecord_Load(object sender, EventArgs e)
        {

            CmbFillPlace();
            CmbFillCustomer();
            FillDataGrid(); 

        }

        //ComboBox'ta boş yerleri gösterme
        private void CmbFillPlace()
        {
            var EmptyPlace = db.Places.Where(x => x.EmptyOrFull == "Boş").Select(x => x).ToList();

           

            cmbEmptyPlace.DisplayMember = "PlaceName";
            cmbEmptyPlace.ValueMember = "PlaceID";
            cmbEmptyPlace.DataSource = EmptyPlace;

        }

        //ComboBox'ı tüm müşterilerle doldurma
        private void CmbFillCustomer()
        {
            var FillCustomer = db.Customers.Select(x => new
            {
                x.CustomerID,
               name=x.CustomerName+" "+x.CustomerSurname,
              
                x.CustomerTC
            }).ToList();
            cmbCustomerName.DisplayMember = "name";
            cmbCustomerName.ValueMember = "CustomerID";
            cmbCustomerName.DataSource = FillCustomer;
        }

     
        //ComboBox'tan seçilen müşteri adı değişince o müşteriye ait arabaların plakalarını alttaki comboBox'ta gösteriyor. 
        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CustomerID = Convert.ToInt32(cmbCustomerName.SelectedValue);

            var FindCustomer = db.Customers.Find(CustomerID);

            txtCustomerTC.Text = FindCustomer.CustomerTC;

            var FindVehicle = db.Vehicles.Where(x => x.CustomerID == CustomerID).Select(x => x).ToList();

            cmbNumberPlate.DisplayMember = "NumberPlate";
            cmbNumberPlate.ValueMember = "VehicleID";
            cmbNumberPlate.DataSource = FindVehicle;



            

        }


        //Kaydet butonuna basılınca ilişki tablosuna kayıt ekliyecek.
        private void btnSave_Click(object sender, EventArgs e)
        {
            Relationship rs = new Relationship();
            rs.CustomerID = (int)cmbCustomerName.SelectedValue;
            rs.VehicleID = (int)cmbNumberPlate.SelectedValue;
            rs.EntryDate = dateTimePicker1.Value;
            rs.PersonelID = FormGiris.id;
            rs.PlaceID = (int)cmbEmptyPlace.SelectedValue;

            int placeID = (int)cmbEmptyPlace.SelectedValue;
            var FindPlace = db.Places.Find(placeID);
            FindPlace.EmptyOrFull = "Dolu";


            db.Relationships.Add(rs);
            db.SaveChanges();

            MessageBox.Show("Kaydedildi");

            FillDataGrid();
        }

        //seçilen plaka değitiğinde araba bilgilerini alt taraftaki textBoxlara doldurma
        private void cmbNumberPlate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FindVehicleID = Convert.ToInt32(cmbNumberPlate.SelectedValue);
            var FindVehicle = db.Vehicles.Find(FindVehicleID);

            txtBrand.Text = FindVehicle.Brand;
            txtModel.Text = FindVehicle.Model;
            txtColor.Text = FindVehicle.Color;




        }


        //Müşterinin otoparka kaydedilen giriş bilgileri ile doldurma
        private void FillDataGrid()
        {

            var FillDataGrid = db.Relationships.Where(x=> x.ReleaseDate==null).Select(x => new
            {

                Ad= x.Customer.CustomerName + " " + x.Customer.CustomerSurname,
                TC=x.Customer.CustomerTC,
                Telefon=x.Customer.CustomerPhone,
                Plaka=x.Vehicle.NumberPlate,
                Marka=x.Vehicle.Brand,
                Model=x.Vehicle.Model,
                Renk=x.Vehicle.Color,
                GirişTarihi=x.EntryDate,
                Çıkış_Tarihi=x.ReleaseDate,
                Yer=x.Place.PlaceName,
                Ücret=x.Price,
            }).ToList();

            dataGridView1.DataSource = FillDataGrid;

        }

        //Geri butonu ile personel işlem seçim ekranı gelicek.
        private void btnBack_Click(object sender, EventArgs e)
        {
           // FormPersonelOperations f2 = new FormPersonelOperations();
            //f2.Show();
            this.Hide();
        }

        //Bul butonu
        private void btnFind_Click(object sender, EventArgs e)
        {


            try
            {
                var FindCustomer = db.Customers.Where(x => x.CustomerTC == mskTxtTC.Text).Select(x => x).FirstOrDefault();

                int CustomerID = FindCustomer.CustomerID;

                var FillDataGridRelationship = db.Relationships.Where(x => x.CustomerID == CustomerID && x.ReleaseDate==null).Select(x => new
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

        //Çıkış tarihleri boş olan  RelationShip tablosundaki tüm kayıtları listeleme
        private void btnList_Click(object sender, EventArgs e)
        {

            FillDataGrid();

        }
    }
}
