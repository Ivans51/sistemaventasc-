using System;
using System.Windows.Forms;
using Sistema_de_ventas.Conexiones;

namespace Sistema_de_ventas
{
    public partial class InicioSesion : Form
    {
        Usuario usuario = new Usuario();
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
            var db = new Db();
            db.bind(new string[] {"nombre", txtNombre.Text, "password", txtClave.Text});
            string idUser = db.single("Select * FROM usuario WHERE nombre = @nombre AND password = @password");
            int x = 0;
            if (Int32.TryParse(idUser, out x))
            {
                AlmacenamientoLocal.Usuario = (Usuario) usuario.find(x);
                AlmacenamientoLocal.Usuario._idUsuario = x;
            }

            if (usuario._nombre == txtNombre.Text && usuario._password == txtClave.Text)
            {
                var containerHome = new ContainerHome();
                containerHome.Show();
                Hide();
            }
            else
            {
                txtNombre.Text = "";
                txtClave.Text = "";
                txtNombre.Focus();
                MessageBox.Show("Datos incorrectos", "Sweet Shop Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}