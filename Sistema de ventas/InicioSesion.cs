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
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            /* Cambiar otro windows form */
            /* InicioSesion inicioSesion = new InicioSesion();
            inicioSesion.MdiParent = this.ParentForm;
            inicioSesion.Show();
            inicioSesion.Top = 0;
            inicioSesion.Left = 0;
            this.Dispose();*/

            ContainerHome containerHome = new ContainerHome();
            containerHome.Show();
            this.Hide();
        }
    }
}
