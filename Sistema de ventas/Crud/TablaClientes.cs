using Sistema_de_ventas.Conexiones;
using System;
using System.Windows.Forms;

namespace Sistema_de_ventas.Crud
{
    public partial class TablaClientes : Form, PDFTabla
    {
        Factura factura = new Factura();
        Db db = new Db();
        PDFCreator creator = new PDFCreator();

        public TablaClientes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (Int32.TryParse(txtBuscar.Text, out x))
            {
                db.bind("idFactura", txtBuscar.Text);
                dgClientes.DataSource = db.query("SELECT * FROM factura WHERE idfactura = @idFactura");
                if (dgClientes.RowCount == 0)
                {
                    MessageBox.Show("No se encuentra", "Sweet Shop Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TablaClientes_Load(object sender, EventArgs e)
        {
            dgClientes.DataSource = factura.all();
        }

        public void addCellTable()
        {
            creator.getTabla().AddCell("IdFactura");
            creator.getTabla().AddCell("Nombre Empleado");
            creator.getTabla().AddCell("Articulos");
            creator.getTabla().AddCell("Fecha");
            creator.getTabla().AddCell("Total");
            creator.getTabla().AddCell("IVA");
            creator.getTabla().AddCell("Forma Pago");
            creator.getTabla().AddCell("IdUsuario");
            creator.getTabla().AddCell("IdCliente");
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            creator.setSegundoParrafo("Lista Factura");
            creator.RutaAbrir = AlmacenamientoLocal.RutaPDF + "factura" + fecha + ".pdf";
            creator.crearPDF("factura" + fecha + ".pdf", "Clientes Sweet Shop" + fecha, 9, this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        { 
            dgClientes.DataSource = factura.all();
        }
    }
}
