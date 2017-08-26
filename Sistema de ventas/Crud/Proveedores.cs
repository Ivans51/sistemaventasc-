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
    public partial class InsertProductos : Form, PDFTabla
    {
        Proveedor proveedor = new Proveedor();
        Db db = new Db();
        private int idProveedor;
        private bool stateDG = false;
        PDFCreator creator = new PDFCreator();
        
        public InsertProductos()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            GetValue();
            proveedor.create();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GetValue();
            proveedor.save(idProveedor);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Desea eliminar esta usuario", "Elminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                proveedor.delete(idProveedor);
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
                dgProveedores.DataSource = proveedor.find(x);
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
                btnEditar.Enabled = true;
                btnEliminar.Enabled = false;
                btnInsertar.Enabled = false;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
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
            foreach (DataGridViewRow row in dgProveedores.SelectedRows)
            {
                idProveedor = (int) row.Cells[0].Value;
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
    }
}
