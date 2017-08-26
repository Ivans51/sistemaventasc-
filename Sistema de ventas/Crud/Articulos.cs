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
    public partial class Articulos : Form, PDFTabla
    {
        Articulo articulo = new Articulo();
        Db db = new Db();
        private int idArticulo;
        private bool stateDG = false;
        PDFCreator creator = new PDFCreator();
        
        public Articulos()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            GetValue();
            articulo.create();
            //DateTime theDate = DateTime.Now;
            // theDate.ToString("yyyy-MM-dd H:mm:ss");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
             GetValue();
            articulo.save(idArticulo);
        }

        private void GetValue()
        {
            articulo._descripcion = txtDescripcion.Text;
            articulo._precio_venta = Convert.ToDouble(txtPrecioVenta.Text);
            articulo._precio_costo = Convert.ToDouble(txtPrecioCosto.Text);
            articulo._stock = txtStock.Text;
            articulo._fecha_ingreso = DateTime.Now;
            // articulo._tipo_articulo_idtipo_articulo = txt
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e) 
        {
            foreach (DataGridViewRow row in dgArticulos.SelectedRows) 
            {
                string value1 = row.Cells[0].Value.ToString();
                string value2 = row.Cells[1].Value.ToString();
                //...
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Desea eliminar esta usuario", "Elminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                articulo.delete(idArticulo);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            creator.crearPDF("Registro de Artículos", "", 3, this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(txtBuscar.Text, out x))
            {
                dgArticulos.DataSource = articulo.find(x);
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
            foreach (DataGridViewRow row in dgArticulos.SelectedRows)
            {
                idArticulo = (int) row.Cells[0].Value;
                txtDescripcion.Text = row.Cells[1].Value.ToString();
                txtPrecioVenta.Text = row.Cells[2].Value.ToString();
                txtPrecioCosto.Text = row.Cells[3].Value.ToString();
                txtStock.Text = row.Cells[4].Value.ToString();
                txtProveedor.Text = row.Cells[6].Value.ToString();
            }
        }

        private void dgArticulos_SelectionChanged(object sender, EventArgs e)
        {

        }

        public void addCellTable()
        {
            foreach (DataGridViewRow row in dgArticulos.Rows)
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