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

namespace Sistema_de_ventas.Crud
{
    public partial class Usuarios : Form
    {
        Usuario usuario = new Usuario();
        Db db = new Db();
        private int idUsuario;
        private bool stateDG = false;
        
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombre = db.single("SELECT nombre FROM usuario WHERE nombre = @nombre", new string[] { "nombre", txtNombre.Text });
            if (nombre == null)
            {
                getValue();
                usuario.create();
                limpiarCampos(true);
                dgUsuarios.DataSource = usuario.all();
            } else
            {
                MessageBox.Show("El nombre usuario se encuentra en el sistema", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            getValue();
            usuario.save(idUsuario);
            dgUsuarios.ClearSelection();
            dgUsuarios.Refresh();
        }

        private void getValue()
        {
            usuario._nombre = txtNombre.Text;
            usuario._password = txtPassword.Text;
            usuario._nivel = cbNivel.Text;
            usuario._fecha = DateTime.Now;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Desea eliminar esta usuario", "Elminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                usuario.delete(idUsuario);
                dgUsuarios.ClearSelection();
                dgUsuarios.Refresh();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(txtBuscar.Text, out x))
            {
                dgUsuarios.DataSource = usuario.find(x);
            }
        }

        private void limpiarCampos(bool habilitarBtn)
        {
            txtNombre.Text = "";
            txtPassword.Text = "";
            cbNivel.Text = "";
            if (habilitarBtn)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = false;
                btnInsertar.Enabled = false;
            }
        }

        private void dgUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (stateDG)
            {
                limpiarCampos(true);
                stateDG = false;
            }
            else
            {
                habibilitarBtn();
                llenarCampos();
            }
        }

        private void habibilitarBtn()
        {
            btnInsertar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void llenarCampos()
        {
            foreach (DataGridViewRow row in dgUsuarios.SelectedRows) 
            {
                idUsuario = (int) row.Cells[0].Value;
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                cbNivel.Text = row.Cells[3].Value.ToString();
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            dgUsuarios.DataSource = usuario.all();
            stateDG = true;
        }
    }
}
