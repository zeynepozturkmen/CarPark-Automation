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
    public partial class FormPlace : Form
    {
        public FormPlace()
        {
            InitializeComponent();
        }


        OtoparkEntities1 db = new OtoparkEntities1();

      

        private void FormPlace_Load(object sender, EventArgs e)
        {
            int PlaceID = 1; //PlaceID PrimaryKey'dir.Ve 1'den 60'e kadar numaralandırılmıştır.
                             //Yani A1-A10 =10 Tane
                             //B1-B5 =10 Tane olup F1-F10 'e kadar toplamda 60 tane olmaktadır.

            //int leftL = 70;
            //int topL = 24;
            //int topB = 42;
            //int leftB = 70;

            //int topL = 24;
            //int topB = 50;
            //int leftL = 42;
            //int leftB = 100;

            int topL = 15;
            int leftL = 24;
            int topB = 40;
            int leftB = 55;


            for (int i = 0; i < 6; i++)
            {
                string[] Place = { "A", "B", "C","D","E","F"}; //Yer Adları label'da gösterebilmek için diziye atıldı.

                Label lbl = new Label();
                lbl.Text = Place[i]; //Label'ın textine dizideki yer adları(A,B,C vs.) atıldı.
                lbl.Width = 30; //Label'ın genişligi 50 px.
                lbl.Location = new Point(leftL, topB * (i + 1)); //Labelin form uzerinde konumlandırılması
                groupBox1.Controls.Add(lbl); //Labelin groupBox içine atılması.

                for (int j = 0; j < 10; j++)
                {
                    Label label = new Label();
                    label.Text = (j + 1).ToString();
                    label.Width = 30;
                    label.Location = new Point(leftB * (j + 1), topL);
                    groupBox1.Controls.Add(label);

                    Button btn = new Button();

                    var place = db.Places.Find(PlaceID); 
                    btn.Text = place.EmptyOrFull; //butonun textine boş dolu yazısı atılıyor
                    if (place.EmptyOrFull == "Boş")
                    {
                        btn.BackColor = Color.Green;
                        btn.Name ="btn"+(i+j).ToString();
                        


                    }
                    else if(place.EmptyOrFull=="Dolu")
                    {
                        btn.BackColor = Color.Red;
                    }

                    PlaceID++;

                    btn.Width = 50;
                    btn.Location = new Point(leftB * (j + 1), topB * (i + 1));

                    btn.Click += Btn_Click;

                    groupBox1.Controls.Add(btn);

                 

                }

            }


          

          
        }

        private void Btn_Click(object sender, EventArgs e)
        {
     

            Button btn = (Button)sender;

            if (btn.Text=="Boş")
            {
         
                FormVehicleEntryRecord f2 = new FormVehicleEntryRecord();
                f2.Show();
                this.Hide();


            }

            



        }

  
    }
}
