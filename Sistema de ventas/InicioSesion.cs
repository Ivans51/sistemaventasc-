using System;
using System.Windows.Forms;
using Sistema_de_ventas.Conexiones;

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
            var db = new Db();
            db.bind(new string[] {"nombre", txtNombre.Text, "password", txtClave.Text});
            string idUser = db.single("Select * FROM usuario WHERE nombre = @nombre AND password = @password");
            Usuario usuario = new Usuario();
            int x = 0;
            if (Int32.TryParse(idUser, out x))
            {
                usuario.find(x);                
            }

            if (usuario._nombre == txtNombre.Text && usuario._password == txtClave.Text)
            {

                AlmacenamientoLocal.Usuario = usuario;

                var containerHome = new ContainerHome();
                containerHome.Show();
                this.Hide();
            }
            else
            {
                const string message = "Error datos";
                MessageBox.Show(message);
            }
        }

        private void GetValue()
        {
            var db = new Db();

            db.query("Select * FROM usuario WHERE nombre ");

            Usuario orm = new Usuario();
            orm._nombre = txtNombre.Text;
            orm._password = txtClave.Text;
            orm._fecha = "12:00";

            int create = orm.create();

            db.bind(new string[] {"f", "test", "l", "test", "s", "F", "a", "33"});

            db.nQuery("INSERT INTO `usuario` (`idUsuario`, `nombre`, `password`, `fecha`) VALUES(@f,@l,@s,@a)");
        }
    }
}