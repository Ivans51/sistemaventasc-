using Sistema_de_ventas.Conexiones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas.Crud
{
    public partial class TablaClientes : Form, PDFTabla
    {
        Cliente cliente = new Cliente();
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
                db.bind("idcliente", txtBuscar.Text);
                dgClientes.DataSource = db.query("SELECT * FROM cliente WHERE idcliente = @idcliente");
                if (dgClientes.RowCount == 0)
                {
                    MessageBox.Show("No se encuentra", "Sweet Shop Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TablaClientes_Load(object sender, EventArgs e)
        {
            dgClientes.DataSource = cliente.all();
        }

        public void addCellTable()
        {
            creator.getTabla().AddCell("idCliente");
            creator.getTabla().AddCell("Cédula");
            creator.getTabla().AddCell("Nombres");
            creator.getTabla().AddCell("Apellidos");
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            creator.setSegundoParrafo("Lista de Clientes");
            creator.RutaAbrir = AlmacenamientoLocal.RutaPDF + "clientes" + fecha + ".pdf";
            creator.crearPDF("clientes" + fecha + ".pdf", "Clientes Sweet Shop" + fecha, 6, this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }
    }
}
