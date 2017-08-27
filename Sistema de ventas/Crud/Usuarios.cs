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
    public partial class Usuarios : Form, PDFTabla
    {
        Usuario usuario = new Usuario();
        Db db = new Db();
        private int idUsuario;
        private bool stateDG = false;
        PDFCreator creator = new PDFCreator();

        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombre = db.single("SELECT nombre FROM usuario WHERE nombre = @nombre", new string[] { "nombre", txtNombre.Text });
            if (nombre == "")
            {
                getValue();
                usuario.create();
                limpiarCampos(true);
                dgUsuarios.DataSource = usuario.all();
            } else
            {
                MessageBox.Show("El nombre usuario se encuentra en el sistema", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            getValue();
            usuario.save(idUsuario);
            limpiarCampos(true);
            dgUsuarios.DataSource = usuario.all();
        }

        private void getValue()
        {
            usuario._nombre = txtNombre.Text;
            usuario._password = txtPassword.Text;
            usuario._nivel = cbNivel.Text;
            usuario._fecha = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"); ;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Desea eliminar esta usuario", "Elminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                usuario.delete(idUsuario);
                limpiarCampos(true);
                dgUsuarios.DataSource = usuario.all();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            int x = 0;
            if (Int32.TryParse(txtBuscar.Text, out x))
            {
                db.bind("idusuario", txtBuscar.Text);
                dgUsuarios.DataSource = db.query("SELECT * FROM usuario WHERE idUsuario = @idUsuario");
                if (dgUsuarios.RowCount == 0)
                {
                    limpiarCampos(true);
                    MessageBox.Show("No se encuentra", "Sweet Shop Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void limpiarCampos(bool habilitarBtn)
        {
            txtNombre.Text = "";
            txtPassword.Text = "";
            cbNivel.Text = "";
            if (habilitarBtn)
            {
                btnInsertar.Enabled = true;
                btnEliminar.Enabled = false;
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
            btnEliminar.Enabled = true;
        }

        private void llenarCampos()
        {
            foreach (DataGridViewRow row in dgUsuarios.SelectedRows) 
            {
                idUsuario = (int) row.Cells[0].Value;
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                cbNivel.Text = row.Cells[4].Value.ToString();
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
        }

        public void addCellTable()
        {
            creator.getTabla().AddCell("idUsuario");
            creator.getTabla().AddCell("Nombre");
            creator.getTabla().AddCell("Password");
            creator.getTabla().AddCell("Fecha");
            creator.getTabla().AddCell("Nivel");
            foreach (DataGridViewRow row in dgUsuarios.Rows)
            {
                foreach (DataGridViewCell celli in row.Cells)
                {
                    try
                    {
                        creator.getTabla().AddCell(celli.Value.ToString());
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            creator.setSegundoParrafo("Lista de Usuarios");
            creator.RutaAbrir = AlmacenamientoLocal.RutaPDF + "usuarios" + fecha + ".pdf";
            creator.crearPDF("usuarios" + fecha + ".pdf", "Usuarios Sweet Shop" + fecha, 5, this);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgUsuarios.DataSource = usuario.all();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }
    }
}
