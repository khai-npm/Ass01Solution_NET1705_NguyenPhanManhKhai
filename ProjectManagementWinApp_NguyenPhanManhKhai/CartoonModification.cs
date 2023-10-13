using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetailForm
{
    public partial class CartoonModification : Form
    {
        public CartoonModification()
        {
            InitializeComponent();
            Load += new EventHandler(Form1_load);

        }

        public ICartoonRepository CartoonRepository { get; set; }
        public bool InsertorUpdate { get; set; }
        public CartoonModel CartoonModelInfo { get; set; }

        public void Form1_load(Object sender, EventArgs e)
        {
            if (InsertorUpdate == true)
            {
                txtCartoonID.Text = CartoonModelInfo.CartoonID.ToString();
                txtCartoonName.Text = CartoonModelInfo.CartoonName;
                txtLaunchDate.Text = CartoonModelInfo.LaunchDate.ToString();
                txtCartoonType.Text = CartoonModelInfo.CartoonType;
                txtShortDescripition.Text = CartoonModelInfo.ShortDescripition;
                txtProducer.Text = CartoonModelInfo.Producer;
                txtDuration.Text = CartoonModelInfo.Duration.ToString();
                txtActors.Text = CartoonModelInfo.Actor;
                txtDirector.Text = CartoonModelInfo.Director;
                txtCountry.Text = CartoonModelInfo.Country;


            }
        }




        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            CartoonModel cartoon = new CartoonModel()
            {
                CartoonID = int.Parse(txtCartoonID.Text),
                CartoonName = txtCartoonName.Text,
                CartoonType = txtCartoonType.Text,
                Actor = txtActors.Text,
                Director = txtDirector.Text,
                Country = txtCountry.Text,
                Duration = int.Parse(txtDuration.Text),
                LaunchDate = txtLaunchDate.Text,
                Producer = txtProducer.Text,
                ShortDescripition = txtShortDescripition.Text,



            };
            if (InsertorUpdate == false)
            {
                // CartoonRepository.Create(cartoon);
                try
                {
                    CartoonRepository.Create(cartoon);
                    MessageBox.Show("[SUCCESS] new cartoon " + cartoon.CartoonName + "  registered ");
                }
                catch (Exception e3) { MessageBox.Show(e3.ToString()); }

            }

            else
                try
                {



                    CartoonRepository.Update(cartoon);
                    MessageBox.Show("[SUCCESS] cartoon " + cartoon.CartoonName + " infomation updated ");
                }
                catch (Exception e4) { MessageBox.Show(e4.ToString()); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
