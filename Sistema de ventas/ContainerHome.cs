using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_ventas.Crud;

namespace Sistema_de_ventas
{
    public partial class ContainerHome : Form
    {
        public ContainerHome()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void MDIMain_MdiChildActivate(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (this.ActiveMdiChild != f)
                    f.Hide();
            }
        }

        private void ContainerHome_Load(object sender, EventArgs e)
        {
            // lblNombreVendedor.Text = AlmacenamientoLocal.Usuario._nombre;
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.MdiParent = this;
            homeScreen.WindowState = FormWindowState.Normal;
            homeScreen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertProductos insertProductos = new InsertProductos();
            insertProductos.MdiParent = this;
            insertProductos.WindowState = FormWindowState.Normal;
            insertProductos.Show();
            insertProductos.Top = 0;
            insertProductos.Left = 0;
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            // createObjectBy(typeof(Provee))
        }

        Object createObjectBy(Type clazz)
        {
            // .. do construction work here
            Object theObject = Activator.CreateInstance(clazz);
            return theObject;
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            Articulos articulos = new Articulos();
            articulos.MdiParent = this;
            articulos.WindowState = FormWindowState.Normal;
            articulos.Show();
            articulos.Top = 0;
            articulos.Left = 0;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes ();
            clientes.MdiParent = this;
            clientes.WindowState = FormWindowState.Normal;
            clientes.Show();
            clientes.Top = 0;
            clientes.Left = 0;
        }

        private void btnVendedor_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.MdiParent = this;
            usuarios.WindowState = FormWindowState.Normal;
            usuarios.Show();
            usuarios.Top = 0;
            usuarios.Left = 0;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.MdiParent = this;
            ventas.WindowState = FormWindowState.Normal;
            ventas.Show();
            ventas.Top = 0;
            ventas.Left = 0;
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            Devoluciones devoluciones = new Devoluciones();
            devoluciones.MdiParent = this;
            devoluciones.WindowState = FormWindowState.Normal;
            devoluciones.Show();
            devoluciones.Top = 0;
            devoluciones.Left = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.MdiParent = this;
            ayuda.WindowState = FormWindowState.Normal;
            ayuda.Show();
            ayuda.Top = 0;
            ayuda.Left = 0;
        }
    }
}
