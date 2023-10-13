using BusinessObjects;
using Repositories;
using DetailForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementWinApp_NguyenPhanManhKhai
{
    public partial class CartoonManagementApplication : Form
    {
        ICartoonRepository repository = new CartoonRepository();
        BindingSource source;

        public CartoonModel CartoonInfo { get; set; }

        private void ClearText()
        {
            txtCartoonID.Text = string.Empty;
            txtCartoonName.Text = string.Empty;
            txtCartoonType.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtDirector.Text = string.Empty;
            txtDuration.Text = string.Empty;
            txtLaunchDate.Text = string.Empty;
            txtProducer.Text = string.Empty;
            txtShortDescripition.Text = string.Empty;
            txtActors.Text = string.Empty;

        }

        private CartoonModel GetCartoonObject()
        {
            CartoonModel c = null;
            try
            {
                c = new CartoonModel()
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


            }
            catch (Exception e) { e.ToString(); }
            return c;
        }

        public void LoadCartoonList()
        {
            var Cartoon = repository.GetCartoonModels();
            try
            {
                source = new BindingSource();
                source.DataSource = Cartoon;

                txtCartoonID.DataBindings.Clear();
                txtCartoonName.DataBindings.Clear();
                txtCartoonType.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtDirector.DataBindings.Clear();
                txtDuration.DataBindings.Clear();
                txtLaunchDate.DataBindings.Clear();
                txtProducer.DataBindings.Clear();
                txtShortDescripition.DataBindings.Clear();
                txtActors.DataBindings.Clear();

                txtCartoonID.DataBindings.Add("text", source, "CartoonID");
                txtCartoonName.DataBindings.Add("text", source, "CartoonName");
                txtCartoonType.DataBindings.Add("text", source, "CartoonType");
                txtCountry.DataBindings.Add("text", source, "Country");
                txtDirector.DataBindings.Add("text", source, "Director");
                txtDuration.DataBindings.Add("text", source, "Duration");
                txtLaunchDate.DataBindings.Add("text", source, "LaunchDate");
                txtProducer.DataBindings.Add("text", source, "Producer");
                txtShortDescripition.DataBindings.Add("text", source, "ShortDescripition");
                txtActors.DataBindings.Add("text", source, "Actor");


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = source;

                if (Cartoon.Count() == 0)
                {
                    button3.Enabled = false;
                }
                else
                {
                    button3.Enabled = true;
                }




            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }


        public CartoonManagementApplication()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void txtCartoonID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var cartoon = GetCartoonObject();
                repository.Remove(cartoon.CartoonID);
                LoadCartoonList();

            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadCartoonList();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (checkBox1.Checked)
            {
                CartoonModification detail = new CartoonModification()
                {
                    Text = "Add new Cartoon",
                    InsertorUpdate = true,
                    CartoonRepository = repository,
                    CartoonModelInfo = GetCartoonObject(),



                };
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadCartoonList();
                    source.Position = source.Count - 1;
                }

            }
            else
            {
                CartoonModification detail = new CartoonModification()
                {
                    Text = "Add new Cartoon",
                    InsertorUpdate = false,
                    CartoonRepository = repository,


                };
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadCartoonList();
                    source.Position = source.Count - 1;
                }
            }
        }
    }
}
