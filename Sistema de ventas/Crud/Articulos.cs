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
    public partial class Articulos : Form
    {
        public Articulos()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo._fecha_ingreso = DateTime.Now;
            //DateTime theDate = DateTime.Now;
            // theDate.ToString("yyyy-MM-dd H:mm:ss");

            MessageBox.Show("Dot Net Perls is super.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            
            DialogResult dr = MessageBox.Show("Are you happy now?", 
                "Mood Test", MessageBoxButtons.YesNo);
            switch(dr){
                case DialogResult.Yes: break;
                case DialogResult.No: break;
            }
        }
        
        private void dataGridView_SelectionChanged(object sender, EventArgs e) 
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) 
            {
                string value1 = row.Cells[0].Value.ToString();
                string value2 = row.Cells[1].Value.ToString();
                //...
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[0].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            /* dataGridView1.SelectedRows.Clear();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if(YOUR CONDITION)
                row.Selected = true;
            }*/
            // Despues de editar quitar selección
            dataGridView1.ClearSelection();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }
    }
}