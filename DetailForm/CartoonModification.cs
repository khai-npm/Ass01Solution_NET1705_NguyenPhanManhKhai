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
        }

        public ICartoonRepository CartoonRepository { get; set; }
        public bool InsertorUpdate { get; set; }
        public CartoonModel CartoonModelInfo { get; set; }

        private void Form1_load(Object sender, EventArgs e)
        {
            if (InsertorUpdate == true)
            {
                txtCartoonID.Text = CartoonModelInfo.CartoonID.ToString();
                txtCartoonName.Text = CartoonModelInfo.CartoonName;
                txtLaunchDate.Text = CartoonModelInfo.LaunchDate.ToString();
                txtCartoonType.Text = CartoonModelInfo.CartoonType;
                txtShortDescripition.Text = CartoonModelInfo.ShortDescripition;
                txtProducer.Text = CartoonModelInfo.Producer;
                txtDuration.Text = CartoonModelInfo.Duration;
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
                Duration = txtDuration.Text,
                LaunchDate = txtLaunchDate.Text,
                Producer = txtProducer.Text,
                ShortDescripition = txtShortDescripition.Text,



            };
            if (InsertorUpdate == false)
            {
                // CartoonRepository.Create(cartoon);
                MessageBox.Show("thong tin nay duoc chay");
                CartoonRepository.Update(cartoon);

            }
            else CartoonRepository.Update(cartoon);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
