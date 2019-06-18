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
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        OtoparkEntities1 db = new OtoparkEntities1();

        public static int id;

        //Giriş yap butonu
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (mskTCGiris.Text!="" && txtPassword.Text!="")
            {
                try
                {



                    var FindPersonel = db.Personels.Where(x => x.PersonelTC == mskTCGiris.Text && x.Password == txtPassword.Text).FirstOrDefault();


                    if (FindPersonel != null)
                    {

                        id = FindPersonel.PersonelID;
                        MessageBox.Show("Hoşgeldiniz. " + FindPersonel.PersonelName + " " + FindPersonel.PersonelSurname);
                        FormPersonelOperations f2 = new FormPersonelOperations();
                        f2.Show();
                        Hide();

                    }
                    else if (FindPersonel == null)
                    {

                        lblMessage.Visible = true;
                        lblMessage.Text = "Bilgileri hatalı girdiniz.";
                    }
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Lütfen tc ve şifrenizi giriniz.");
            }
          
        }


        //Kaydet butonu
        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (mskdTxtTC.Text != "" && txtName.Text != "" && txtSurname.Text != "" && txtEMail.Text != "" && txtAddress.Text != "")
            {
                Regex r = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (r.IsMatch(txtEMail.Text))
                {
                    //MessageBox.Show("Geçerli");


                    long tckn = Convert.ToInt64(mskdTxtTC.Text);
                    string name = txtName.Text.ToUpper();
                    string surname = txtSurname.Text.ToUpper();
                    string birthDate = mskBirthDate.Text.Substring(9,4);
                    int convertBirthDate = Convert.ToInt32(birthDate);

                    KPSPublicSoapClient client = new KPSPublicSoapClient();
                    bool sonuc = client.TCKimlikNoDogrula(tckn, name, surname, convertBirthDate);

                    if (sonuc == true)
                    {

                        try
                        {

                            Personel personel = new Personel();
                            personel.PersonelTC = mskdTxtTC.Text;
                            personel.PersonelName = txtName.Text;
                            personel.PersonelSurname = txtSurname.Text;
                            personel.PersonelPhone = mskdTextPhone.Text;
                            personel.PersonelAddress = txtAddress.Text;
                            personel.PersonelEMail = txtEMail.Text;
                            personel.PersonelBirthYear = convertBirthDate;

                            string tc = mskdTxtTC.Text;

                            personel.Password = tc.Substring(0, 5); //şifreye tc'nin ilk 5 hanesi verildi.

                            db.Personels.Add(personel);


                            db.SaveChanges();
                            MessageBox.Show("Kayıt başarılı,şifreniz tc nizin ilk 5 hanesidir.");
                            pctrBoxBlack.Visible = false;
                            pctrBoxBlue.Visible = true;

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }



                    }
                    else
                    {
                        MessageBox.Show("Girilen bilgilerde bir kişi bulunamadı,ltfen bilgileri kontrol edip tekrar deneyiniz.");
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

        //Çıkış butonu
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Şifreyi Göster 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                txtPassword.PasswordChar = '\0';
            }
            else if(checkBox1.Checked==false)
            {
                txtPassword.PasswordChar = '*';
            }
        }

        //Çıkış Butonu
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
