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
    public partial class Clientes : Form, PDFTabla
    {
        Cliente cliente = new Cliente();
        Db db = new Db();
        private int idCliente;
        PDFCreator creator = new PDFCreator();

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string idCliente = db.single("SELECT cedula FROM cliente WHERE cedula = @cedula");
            if (idCliente == "")
            {
                GetValue(); db.bind("cedula", txtCedula.Text);
                cliente.create();
                limpiarCampos(true);
                dgClientes.DataSource = cliente.all();
            }
            else
            {
                MessageBox.Show("Ya se encuentra esta cédula", "Sweet Shop Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GetValue();
            cliente.save(idCliente);
            limpiarCampos(true);
            dgClientes.DataSource = cliente.all();
        }

        private void GetValue()
        {
            cliente._cedula = txtCedula.Text;
            cliente._nombres = txtNombre.Text;
            cliente._apellidos = txtApellido.Text;
            cliente._direccion = txtDireccion.Text;
            cliente._nombre_ciudad = txtNombreCiudad.Text;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Desea eliminar este usuario", "Elminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                cliente.delete(idCliente);
                limpiarCampos(true);
                dgClientes.DataSource = cliente.all();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            creator.crearPDF("Registro de empleados", "", 3, this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(txtBuscar.Text, out x))
            {
                db.bind("idcliente", txtBuscar.Text);
                dgClientes.DataSource = db.query("SELECT * FROM cliente WHERE idcliente = @idcliente");
                if (dgClientes.RowCount == 0)
                {
                    limpiarCampos(true);
                    MessageBox.Show("No se encuentra", "Sweet Shop Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void limpiarCampos(bool habilitarBtn)
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtNombreCiudad.Text = "";
            if (habilitarBtn)
            {
                btnInsertar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        public void addCellTable()
        {
            creator.getTabla().AddCell("idCedula");
            creator.getTabla().AddCell("Cedula");
            creator.getTabla().AddCell("Nombre");
            creator.getTabla().AddCell("Apellido");
            creator.getTabla().AddCell("Direccion");
            creator.getTabla().AddCell("Nombre Ciudad");
            foreach (DataGridViewRow row in dgClientes.Rows)
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

        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            limpiarCampos(true);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgClientes.DataSource = cliente.all();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            creator.setSegundoParrafo("Lista de Clientes");
            creator.RutaAbrir = AlmacenamientoLocal.RutaPDF + "clientes" + fecha + ".pdf";
            creator.crearPDF("clientes" + fecha + ".pdf", "Clientes Sweet Shop" + fecha, 6, this);
        }

        private void dgClientes_SelectionChanged(object sender, EventArgs e)
        {
            habibilitarBtn();
            llenarCampos();
        }

        private void habibilitarBtn()
        {
            btnInsertar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void llenarCampos()
        {
            foreach (DataGridViewRow row in dgClientes.SelectedRows)
            {
                idCliente = (int)row.Cells[0].Value;
                txtCedula.Text = row.Cells[1].Value.ToString();
                txtNombre.Text = row.Cells[2].Value.ToString();
                txtApellido.Text = row.Cells[3].Value.ToString();
                txtDireccion.Text = row.Cells[4].Value.ToString();
                txtNombreCiudad.Text = row.Cells[5].Value.ToString();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaTexto(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaTexto(e);
        }

        private void txtNombreCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaTexto(e);
        }
    }
}