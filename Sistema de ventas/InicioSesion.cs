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
            /* Cambiar otro windows form */
            /* InicioSesion inicioSesion = new InicioSesion();
            inicioSesion.MdiParent = this.ParentForm;
            inicioSesion.Show();
            inicioSesion.Top = 0;
            inicioSesion.Left = 0;
            this.Dispose();*/
            // Create/Insert
            var db = new Db();

            db.query("Select * FROM usuario");
            
            Usuario orm = new Usuario();
            orm._nombre = txtNombre.Text;
            orm._password = txtClave.Text;
            orm._fecha = "12:00";

            int create = orm.create();
            
            db.bind(new string[] { "f", "test", "l", "test", "s", "F", "a", "33"});

            var created = db.nQuery("INSERT INTO `usuario` (`idUsuario`, `nombre`, `password`, `fecha`) VALUES(@f,@l,@s,@a)");

            var containerHome = new ContainerHome();
            containerHome.Show();
            this.Hide();
        }
    }
}
