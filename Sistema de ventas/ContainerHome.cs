using System;
using System.Windows.Forms;
using Sistema_de_ventas.Conexiones;
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
            DialogResult result = MessageBox.Show("¿Quieres Salir?", "Sweet Shop Mensaje", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Hide();
                InicioSesion inicioSesion = new InicioSesion();
                inicioSesion.Show();
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
            if (AlmacenamientoLocal.Usuario._nivel.Equals("Vendedor"))
            {
                btnAdministrar.Visible = false;
                btnArticulos.Visible = false;
                btnProveedor.Visible = false;
            }
            else if (AlmacenamientoLocal.Usuario.Equals("Invitado"))
            {
                btnAdministrar.Visible = false;
                btnArticulos.Visible = false;
                btnProveedor.Visible = false;
                btnVentas.Visible = false;
            }

            lblNombreVendedor.Text = AlmacenamientoLocal.Usuario._nombre;
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.MdiParent = this;
            homeScreen.WindowState = FormWindowState.Normal;
            homeScreen.Show();

            // SetUsuario();
        }

        private static void SetUsuario()
        {
            Usuario usuario = new Usuario();
            usuario._idUsuario = 1;
            usuario._nombre = "Ivans";
            usuario._password = 1234.ToString();
            usuario._nivel = "Administrador";
            usuario._fecha = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"); ;
            AlmacenamientoLocal.Usuario = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.MdiParent = this;
            homeScreen.WindowState = FormWindowState.Normal;
            homeScreen.Show();
            homeScreen.Top = 0;
            homeScreen.Left = 0;
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.MdiParent = this;
            proveedores.WindowState = FormWindowState.Normal;
            proveedores.Show();
            proveedores.Top = 0;
            proveedores.Left = 0;
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
            Clientes clientes = new Clientes();
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
            TablaClientes devoluciones = new TablaClientes();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Quieres Salir?", "Sweet Shop Mensaje", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Hide();
                InicioSesion inicioSesion = new InicioSesion();
                inicioSesion.Show();
            }
        }
    }
}
