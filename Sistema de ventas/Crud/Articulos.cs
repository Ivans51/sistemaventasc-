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
using System.Globalization;

namespace Sistema_de_ventas.Crud
{
    public partial class Articulos : Form, PDFTabla
    {
        Articulo articulo = new Articulo();
        Proveedor proveedor = new Proveedor();
        Db db = new Db();
        private int idArticulo;
        PDFCreator creator = new PDFCreator();

        public Articulos()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            db.bind("nombre", txtNombre.Text);
            string nombreArticulo = db.single("SELECT nombre FROM articulo WHERE nombre = @nombre");
            if (nombreArticulo == "")
            {
                GetValue();
                articulo.create();
                limpiarCampos(true);
                dgArticulos.DataSource = articulo.all();
            }
            else
            {
                MessageBox.Show("Este nombre ya se encuentra registrado", "Sweet Shop Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GetValue();
            articulo.save(idArticulo);
            limpiarCampos(true);
            dgArticulos.DataSource = articulo.all();
        }

        private void GetValue()
        {
            articulo._nombre = txtNombre.Text;
            articulo._descripcion = txtDescripcion.Text;
            articulo._precio_venta = Convert.ToDouble(txtPrecioVenta.Text);
            articulo._precio_costo = Convert.ToDouble(txtPrecioCosto.Text);
            articulo._stock = txtStock.Text;
            articulo._fecha_ingreso = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            articulo._proveedor_idproveedor = Convert.ToInt32(txtProveedor.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Desea eliminar este artículo", "Elminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                articulo.delete(idArticulo);
                limpiarCampos(true);
                dgArticulos.DataSource = articulo.all();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(txtBuscar.Text, out x))
            {
                db.bind("idArticulo", txtBuscar.Text);
                dgArticulos.DataSource = db.query("SELECT * FROM articulo WHERE idArticulo = @idArticulo");
                if (dgArticulos.RowCount == 0)
                {
                    limpiarCampos(true);
                    MessageBox.Show("No se encuentra", "Sweet Shop Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void limpiarCampos(bool habilitarBtn)
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioVenta.Text = "";
            txtPrecioCosto.Text = "";
            txtStock.Text = "";
            txtProveedor.Text = "";
            if (habilitarBtn)
            {
                btnInsertar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
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
                idArticulo = (int)row.Cells[0].Value;
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtDescripcion.Text = row.Cells[2].Value.ToString();
                txtPrecioVenta.Text = row.Cells[3].Value.ToString();
                txtPrecioCosto.Text = row.Cells[4].Value.ToString();
                txtStock.Text = row.Cells[5].Value.ToString();
                txtProveedor.Text = row.Cells[7].Value.ToString();
                /* db.bind("idProveedor", idProveedor);
                db.single("SELECT nombre FROM proveedor WHERE idProveedor = @idProveedor");*/
            }
        }

        private void dgArticulos_SelectionChanged(object sender, EventArgs e)
        {
            habibilitarBtn();
            llenarCampos();
        }

        public void addCellTable()
        {
            creator.getTabla().AddCell("idArticulo");
            creator.getTabla().AddCell("Nombre");
            creator.getTabla().AddCell("Descripción");
            creator.getTabla().AddCell("PrecioVenta");
            creator.getTabla().AddCell("PrecioCosto");
            creator.getTabla().AddCell("Stock");
            creator.getTabla().AddCell("FechaIngreso");
            creator.getTabla().AddCell("idProveedor");
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            creator.setSegundoParrafo("Lista de Artículos");
            creator.RutaAbrir = AlmacenamientoLocal.RutaPDF + "articulos" + fecha + ".pdf";
            creator.crearPDF("articulos" + fecha + ".pdf", "Artículos Sweet Shop" + fecha, 8, this);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgArticulos.DataSource = articulo.all();
        }

        private void btnIdArticulo_Click(object sender, EventArgs e)
        {
            db.bind(new string[] { "nombre", txtProveedor.Text });
            string nombreProveedor = db.single("Select nombre FROM proveedor WHERE idProveedor = @nombre");
            if (nombreProveedor == "")
            {
                MessageBox.Show("Proveedor no encontrado", "Mensaje Sweet Shop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Proveedor " + nombreProveedor, "Mensaje Sweet Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnInsertar.Enabled = true;
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            limpiarCampos(true);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaTexto(e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }

        private void txtPrecioCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }
    }
}