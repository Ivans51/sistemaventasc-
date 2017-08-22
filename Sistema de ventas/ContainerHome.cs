using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas
{
    public partial class ContainerHome : Form
    {
        public ContainerHome()
        {
            InitializeComponent();
        }

        private void ContainerHome_Load(object sender, EventArgs e)
        {
            // Investigar como abrir un form inicialmente
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.MdiParent = this;
            homeScreen.WindowState = FormWindowState.Normal;
            homeScreen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cambiar form
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Hide();

            InsertProductos insertProductos = new InsertProductos();
            insertProductos.Hide();
            insertProductos.WindowState = FormWindowState.Normal;
            insertProductos.Show();
            insertProductos.Top = 0;
            insertProductos.Left = 0;
        }
    }
}
