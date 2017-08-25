using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_ventas.Conexiones;

namespace Sistema_de_ventas
{
    public partial class InsertProductos : Form
    {
        public InsertProductos()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            proveedor._nombre = txtNombre.Text;
            proveedor._apellido = txtApellido.Text;
            proveedor._direccion = textBox3.Text;
            proveedor._nombre_comercial = textBox4.Text;
            proveedor._telefono = textBox5.Text;
            proveedor._nombre_ciudad = textBox6.Text;
            proveedor._usuario_idusuario = AlmacenamientoLocal.Usuario._idUsuario;
            proveedor.create();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
