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
        private bool stateDG = false;
        PDFCreator creator = new PDFCreator();

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cliente.all();
            stateDG = true;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            GetValue();
            cliente.create();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GetValue();
            cliente.save(idCliente);
        }

        private void GetValue()
        {
            cliente._nombres = txtNombre.Text;
            cliente._apellidos = txtApellido.Text;
            cliente._direccion = txtDireccion.Text;
            cliente._nombreciudad = txtNombreCiudad.Text;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Desea eliminar esta usuario", "Elminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                cliente.delete(idCliente);
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
                dataGridView1.DataSource = cliente.find(x);
            }
        }
        
        private void limpiarCampos(bool habilitarBtn)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtNombreCiudad.Text = "";
            if (habilitarBtn)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = false;
                btnInsertar.Enabled = false;
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
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                idCliente = (int) row.Cells[0].Value;
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtApellido.Text = row.Cells[2].Value.ToString();
                txtDireccion.Text = row.Cells[3].Value.ToString();
                txtNombreCiudad.Text = row.Cells[4].Value.ToString();
            }
        }

        public void addCellTable()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
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