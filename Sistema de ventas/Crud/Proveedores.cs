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
using System.Diagnostics;

namespace Sistema_de_ventas
{
    public partial class Proveedores : Form, PDFTabla
    {
        Proveedor proveedor = new Proveedor();
        Db db = new Db();
        private int idProveedor;
        PDFCreator creator = new PDFCreator();

        public Proveedores()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            GetValue();
            proveedor.create();
            limpiarCampos(true);
            dgProveedores.DataSource = proveedor.all();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GetValue();
            proveedor.save(idProveedor);
            limpiarCampos(true);
            dgProveedores.DataSource = proveedor.all();
        }

        private void GetValue()
        {
            proveedor._nombre = txtNombre.Text;
            proveedor._apellido = txtApellido.Text;
            proveedor._direccion = txtNombreComercial.Text;
            proveedor._nombre_comercial = txtDireccion.Text;
            proveedor._telefono = txTelefono.Text;
            proveedor._nombre_ciudad = txtNombreCiudad.Text;
            proveedor._usuario_idusuario = AlmacenamientoLocal.Usuario._idUsuario;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Desea eliminar esta usuario", "Elminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                proveedor.delete(idProveedor);
                limpiarCampos(true);
                dgProveedores.DataSource = proveedor.all();
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
                db.bind("idProveedor", txtBuscar.Text);
                dgProveedores.DataSource = db.query("SELECT * FROM proveedor WHERE idProveedor = @idProveedor");
                if (dgProveedores.RowCount == 0)
                {
                    limpiarCampos(true);
                    MessageBox.Show("No se encuentra", "Sweet Shop Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void limpiarCampos(bool habilitarBtn)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNombreComercial.Text = "";
            txtDireccion.Text = "";
            txTelefono.Text = "";
            txtNombreCiudad.Text = "";
            if (habilitarBtn)
            {
                btnInsertar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            /* if (stateDG)
            {
                limpiarCampos(true);
                stateDG = false;
            }
            else
            { */
            habibilitarBtn();
            llenarCampos();
            //}
        }

        private void habibilitarBtn()
        {
            btnInsertar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void llenarCampos()
        {
            int num = dgProveedores.RowCount;
            int row2 = dgProveedores.ColumnCount;
            foreach (DataGridViewRow row in dgProveedores.SelectedRows)
            {
                idProveedor = (int)row.Cells[0].Value;
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtApellido.Text = row.Cells[2].Value.ToString();
                txtNombreComercial.Text = row.Cells[3].Value.ToString();
                txtDireccion.Text = row.Cells[4].Value.ToString();
                txTelefono.Text = row.Cells[5].Value.ToString();
                txtNombreCiudad.Text = row.Cells[6].Value.ToString();
            }
        }

        public void addCellTable()
        {
            creator.getTabla().AddCell("idProveedor");
            creator.getTabla().AddCell("Nombre");
            creator.getTabla().AddCell("Apellido");
            creator.getTabla().AddCell("Comercio");
            creator.getTabla().AddCell("Dirección");
            creator.getTabla().AddCell("Teléfono");
            creator.getTabla().AddCell("Ciudad");
            creator.getTabla().AddCell("idUsuario");
            foreach (DataGridViewRow row in dgProveedores.Rows)
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

        private void Proveedores_Load(object sender, EventArgs e)
        {
            /* dgProveedores.DataSource = proveedor.all();
            stateDG = true; */
        }

        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            limpiarCampos(true);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("d-M-yyyy");
            creator.setSegundoParrafo("Lista de Proveedores ");
            creator.RutaAbrir = AlmacenamientoLocal.RutaPDF + "proveedores" + fecha + ".pdf";
            creator.crearPDF("proveedores" + fecha + ".pdf", "Proveedores Sweet Shop" + fecha, 8, this);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgProveedores.DataSource = proveedor.all();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }
    }
}
