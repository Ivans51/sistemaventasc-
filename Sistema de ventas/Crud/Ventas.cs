using System;
using System.Windows.Forms;
using Sistema_de_ventas.Conexiones;

namespace Sistema_de_ventas.Crud
{
    public partial class Ventas : Form, PDFTabla
    {
        Factura factura = new Factura();
        DetalleFactura detalleFactura = new DetalleFactura();
        Cliente cliente = new Cliente();
        
        Db db = new Db();
        private int idFactura;
        private int idDetalle;
        private int idFormaPago;
        private bool stateDG = false;
        PDFCreator creator = new PDFCreator();
        public Ventas()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            GetValue();
            int i = factura.create();
            GetValueDetalle(i);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GetValue();
            factura.save(idFactura);
            detalleFactura.save(idDetalle);
        }

        private void GetValue()
        {
            factura._nombre_empleado = AlmacenamientoLocal.Usuario._nombre;
            factura._fecha_factura = DateTime.Now;
            factura._total_factura = Convert.ToDouble(lblTotalFactura.Text);
            // factura._IVA = Iva
            factura._forma_pago = Convert.ToInt32(cbFormaPago.Text);
            // factura._cliente_idcliente =
            factura._articulo_idarticulo = Convert.ToInt32(lblIdArticulo.Text);
            factura._usuario_idusuario = AlmacenamientoLocal.Usuario._idUsuario;
        }

        private void GetValueDetalle(int i)
        {
            detalleFactura._cantidad = Convert.ToInt32(txtCantidad.Text);
            detalleFactura._total = Convert.ToDouble(txtTotal.Text);
            detalleFactura._factura_idfactura = i;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Desea eliminar esta usuario", "Elminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                factura.delete(idFactura);
                detalleFactura.delete(idFactura);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            creator.crearPDF("Factura Sweet Shop", "", 7, this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(txtBuscar.Text, out x))
            {
                dgVentas.DataSource = cliente.find(x);
            }
        }

        private void dgVentas_SelectionChanged(object sender, EventArgs e)
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
        
        private void limpiarCampos(bool habilitarBtn)
        {
            txtCantidad.Text = "";
            txtTotal.Text = "";
            lblFecha.Text = "";
            lblIdArticulo.Text = "";
            lblNombreEmpleado.Text = "";
            lblTotalFactura.Text = "";
            cbFormaPago.Text = "";
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
            foreach (DataGridViewRow row in dgVentas.SelectedRows) 
            {
                idFactura = (int) row.Cells[0].Value;
                idDetalle = idFactura;
                lblNombreEmpleado.Text = row.Cells[1].Value.ToString();
                lblFecha.Text = row.Cells[2].Value.ToString();
                lblTotalFactura.Text = row.Cells[3].Value.ToString();
                //lblIVA.Text = row.Cells[4].Value.ToString();
                cbFormaPago.Text = row.Cells[5].Value.ToString();
                // lblIdCliente.Text = row.Cells[6].Value.ToString();
                lblIdArticulo.Text = row.Cells[7].Value.ToString();
            }
        }
        
        public void addCellTable()
        {
            foreach (DataGridViewRow row in dgVentas.Rows)
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
