using Otopark.TCKNServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark
{
    public partial class FormCustomerOperations : Form
    {
        public FormCustomerOperations()
        {
            InitializeComponent();
        }

        OtoparkEntities1 db = new OtoparkEntities1();
        static string tc;

        private void FormCustomerOperations_Load(object sender, EventArgs e)
        {
            this.Text = "FormCustomerOperations"; //Formun textini değiştirme
            FillDataGrid();
        }


        //Kaydet butonu
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mskCustomerTC.Text != "" && txtCustomerName.Text != "" && txtCustomerSurname.Text != "" && txtCustomerEmail.Text != "" && txtCustomerAddress.Text != "")
            {



                Regex r = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (r.IsMatch(txtCustomerEmail.Text))
                {
                    //MessageBox.Show("Geçerli");

                    long tckn = Convert.ToInt64(mskCustomerTC.Text);
                    string name = txtCustomerName.Text.ToUpper();
                    string surname = txtCustomerSurname.Text.ToUpper();
                    string birthDate = mskBirthYear.Text.Substring(9, 4);
                    int convertBirthDate = Convert.ToInt32(birthDate);

                    KPSPublicSoapClient client = new KPSPublicSoapClient();
                    bool sonuc = client.TCKimlikNoDogrula(tckn, name, surname, convertBirthDate);

                    if (sonuc == true)
                    {

                        try
                        {
                            //müşteri kayıt
                            Customer customer = new Customer();

                            customer.CustomerTC = mskCustomerTC.Text;
                            customer.CustomerName = txtCustomerName.Text;
                            customer.CustomerSurname = txtCustomerSurname.Text;
                            customer.CustomerPhone = mskCustomerPhone.Text;
                            customer.CustomerEMail = txtCustomerEmail.Text;
                            customer.CustomerAddress = txtCustomerAddress.Text;
                            customer.CustomerBirthYear = convertBirthDate;
                            customer.PersonelID = FormGiris.id;

                            tc = mskCustomerTC.Text; //maskedTextBox'a girilen tc yi static değişkene atama


                            db.Customers.Add(customer);
                            db.SaveChanges();

                            //maskedTextBox'a girilen tc'den müşteriyi bulma
                            var FindCustomer = db.Customers.Where(x => x.CustomerTC == tc).Select(x => x).FirstOrDefault();

                            //bulunan müşterinin id'sini bir değişkene atama
                            int id = FindCustomer.CustomerID;


                            //arac kayıt
                            Vehicle vehicle = new Vehicle();
                            vehicle.NumberPlate = txtNumberPlate.Text;
                            vehicle.Model = txtModel.Text;
                            vehicle.Brand = txtBrand.Text;
                            vehicle.Color = txtColor.Text;
                            vehicle.CustomerID = id;  //yukarı kısımda kaydedilen müşterinin Customer id'sini aracına ekleme.

                            db.Vehicles.Add(vehicle);
                            db.SaveChanges();


                            MessageBox.Show("Kayıt başarılı");
                            FillDataGrid();

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Girilen bilgilerde bir kişi bulunamadı,lütfen bilgileri kontrol edip tekrar deneyiniz.");
                    }

                }
                else
                {
                    MessageBox.Show("EMail hatalı");
                }

            }



            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }

        }


        private void FillDataGrid()
        {
            var FillDataGrid = db.Vehicles.Select(x => new
            {
                TC = x.Customer.CustomerTC,
                AdSoyad = x.Customer.CustomerName + " " + x.Customer.CustomerSurname,
                Tel=x.Customer.CustomerPhone,
                Email=x.Customer.CustomerEMail,
                Adres=x.Customer.CustomerAddress,
                Plaka=x.NumberPlate,
                Marka =x.Brand,
                Model =x.Model,
                Renk=x.Color,
      
            }).ToList();

            dataGridView1.DataSource = FillDataGrid;

        }

        //Bul butonu
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                var FindCustomer = db.Customers.Where(x => x.CustomerTC == mskFindCustomer.Text).Select(x => x).FirstOrDefault();

                int CustomerID = FindCustomer.CustomerID;

                var FillDataGridCustomerAndVehicle = db.Vehicles.Where(x => x.CustomerID == CustomerID).Select(x => new
                {
                    TC = x.Customer.CustomerTC,
                    AdSoyad = x.Customer.CustomerName + " " + x.Customer.CustomerSurname,
                    Tel = x.Customer.CustomerPhone,
                    Email = x.Customer.CustomerEMail,
                    Adres = x.Customer.CustomerAddress,
                    Plaka = x.NumberPlate,
                    Marka = x.Brand,
                    Model = x.Model,
                    Renk = x.Color,

                }).ToList();

                dataGridView1.DataSource = FillDataGridCustomerAndVehicle;
            }
            catch (Exception )
            {

                MessageBox.Show("Böyle bir kullanıcı bulunamadı lütfen tc'yi kontrol edip tekrar deneyiniz.");
            }
      

        }


        //Listeleme butonu
        private void btnList_Click(object sender, EventArgs e)
        {

            FillDataGrid();

        }
    }
}
