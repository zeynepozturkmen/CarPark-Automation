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
    public partial class FormPersonelOperations : Form
    {
        public FormPersonelOperations()
        {
            InitializeComponent();
        }

   


        OtoparkEntities1 db = new OtoparkEntities1();

        private void FormPersonelOperations_Load(object sender, EventArgs e)
        {
           

            var FindPersonel = db.Personels.Find(FormGiris.id);
            label1.Text = FindPersonel.PersonelName + " " + FindPersonel.PersonelSurname;

        }

    

        private void boşYerleriGösterToolStripMenuItem1_Click(object sender, EventArgs e)
        {

           

            FormPlace chForm1 = new FormPlace();

            //Child forma parent form atanır
            chForm1.MdiParent = this;

            //Child form penceresi görüntülenir.
            chForm1.WindowState = FormWindowState.Maximized;
            chForm1.Show();

           

        }

        private void müşteriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCustomerOperations chForm2 = new FormCustomerOperations();

            //Child forma parent form atanır
            chForm2.MdiParent = this;

            //Child form penceresi görüntülenir.

            chForm2.WindowState = FormWindowState.Maximized;

            chForm2.Show();

       
        }


        //Çıkış Butonu
        private void btnCikis_Click(object sender, EventArgs e)
        {
            FormGiris frm = new FormGiris();
            frm.Show();
            this.Hide();

        }


        //Otopark Çıkış İşlemleri
        private void otoparkÇıkışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVehicleExitOperation frm = new FormVehicleExitOperation();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();



        }

        private void FormPersonelOperations_Activated(object sender, EventArgs e)
        {
           
        }


        //Şifre değiştir butonu
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword chngpassword = new ChangePassword();
            chngpassword.Show();
        }
    }
}
