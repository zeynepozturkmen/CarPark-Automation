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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        OtoparkEntities1 db = new OtoparkEntities1();


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPassword!=null && txtConfirmPassword!=null)
            {
                var FindPersonel = db.Personels.Find(FormGiris.id);
                if (txtNewPassword.Text==txtConfirmPassword.Text)
                {
                    FindPersonel.Password = txtNewPassword.Text;
                    db.SaveChanges();
                    MessageBox.Show("Şifre başarıyla değiştirildi");
                }
                else
                {
                    MessageBox.Show("Şifreler uyuşmuyor,tekrar kontrol ediniz.");
                }


            }


        }


        //Şifreyi Göster
        private void chckBxSifreyiGoster_CheckedChanged(object sender, EventArgs e)
        {

            if (chckBxSifreyiGoster.Checked)
            {
                txtNewPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';


            }
            else
            {
                txtNewPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }


        }


        //Geri Butonu
        private void btnBack_Click(object sender, EventArgs e)
        {
            //FormPersonelOperations frm = new FormPersonelOperations();
            //frm.Show();
            this.Hide();
        }
    }
}
