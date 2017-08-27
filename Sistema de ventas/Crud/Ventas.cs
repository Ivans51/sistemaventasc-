﻿using System;
using System.Windows.Forms;
using Sistema_de_ventas.Conexiones;
using System.Linq;
using System.Collections;
using System.Data;
using System.Collections.Generic;

namespace Sistema_de_ventas.Crud
{
    public partial class Ventas : Form
    {
        Db db = new Db();
        Factura factura = new Factura();
        DetalleFactura detalleFactura = new DetalleFactura();
        Cliente cliente = new Cliente();
        List<int> listArticulos = new List<int>();
        string articulos;
        private int idFactura;
        private int idDetalle;

        public Ventas()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            GetValue();
            int i = factura.create();
            GetValueDetalle(i);
            detalleFactura.create();
            var dialogResult = MessageBox.Show("Nombre Cliente no encontrado", "Mensaje Sweet Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
                Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GetValue();
            factura.save(idFactura);
            detalleFactura.save(idDetalle);
        }

        private void GetValue()
        {
            db.bind("cedula", txtCedula.Text);
            string idCliente = db.single("SELECT idcliente FROM cliente WHRE ");
            int x = 0;

            if (Int32.TryParse(idCliente, out x))
            {
                // you know that the parsing attempt
                // was successful
            }

            factura._nombre_empleado = AlmacenamientoLocal.Usuario._nombre;
            factura._articulos = articulos;
            factura._fecha_factura = DateTime.Now.ToString();
            factura._total_factura = Convert.ToDouble(lblTotalFactura.Text);
            factura._IVA = Convert.ToDouble(lblIVA.Text);
            factura._forma_pago = cbFormaPago.Text;
            factura._cliente_idcliente = x;
            factura._usuario_idusuario = AlmacenamientoLocal.Usuario._idUsuario;
        }

        private void GetValueDetalle(int i)
        {
            detalleFactura._cantidad = Convert.ToInt32(txtCantidad.Text);
            detalleFactura._total = Convert.ToDouble(lblTotalFactura.Text);
            detalleFactura._factura_idfactura = i;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            lblNombreEmpleado.Text = AlmacenamientoLocal.Usuario._nombre;
            lblFecha.Text = DateTime.Now.ToShortTimeString();
            int totalPagar = 0;

            // Para obtener todos los valores de un listbox en una variable de tipo string
            string text = "";
            foreach (var item in listBox1.Items)
            {
                text += item.ToString() + ", "; 
            }
            articulos = text;

            foreach (var item in listArticulos)
            {
                totalPagar = item;
            }
            double IVA = totalPagar * 0.12;
            lblIVA.Text = IVA.ToString();
            lblTotalFactura.Text = totalPagar.ToString();

            btnInsertar.Enabled = true;
        }

        private void btnBuscarCedula_Click(object sender, EventArgs e)
        {
            db.bind(new string[] { "cedula", txtCedula.Text });
            string nombreCliente = db.single("Select nombres FROM cliente WHERE cedula = @cedula");
            if (nombreCliente == "")
            {
                MessageBox.Show("Cedula no encontrado", "Mensaje Sweet Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblNombreCliente.Text = nombreCliente;
            }
        }

        private void btnIdArticulo_Click(object sender, EventArgs e)
        {
            db.bind(new string[] { "idarticulo", txtArticulo.Text, "nombre", txtArticulo.Text });
            string nombreArticulo = db.single("Select nombre FROM articulo WHERE idarticulo = @idarticulo OR nombre = @nombre");
            db.bind(new string[] { "idarticulo", txtArticulo.Text, "nombre", txtArticulo.Text });
            string precioVenta = db.single("Select precio_venta FROM articulo WHERE idarticulo = @idarticulo OR nombre = @nombre");
            db.bind(new string[] { "idarticulo", txtArticulo.Text, "nombre", txtArticulo.Text });
            string stock = db.single("Select stock FROM articulo WHERE idarticulo = @idarticulo OR nombre = @nombre");
            if (nombreArticulo == "")
            {
                MessageBox.Show("Artículo no encontrado", "Mensaje Sweet Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int x = 0;

                if (Int32.TryParse(precioVenta, out x))
                {
                    int precioRealVenta = x;
                }
                listBox1.Items.Add(nombreArticulo);
                listArticulos.Add(x);
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = "";
            lblIVA.Text = "";
            lblNombreCliente.Text = "";
            lblNombreEmpleado.Text = "";
            lblTotalFactura.Text = "";
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }

        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaTexto(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.entradaNumero(e);
        }
    }
}
