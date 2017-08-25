using System;

namespace Sistema_de_ventas.Conexiones
{
    class Factura : SimpleORM
    {
        private int idfactura;
        private string nombre_empleado;
        private DateTime fecha_factura;
        private double total_factura;
        private double IVA;
        private int forma_pago_idforma_pago;
        private string cliente_idcliente;
        private int articulo_idarticulo;
        private int usuario_idusuario;

        public int _idfactura
        {
            get => idfactura;
            set => idfactura = value;
        }

        public string _nombre_empleado
        {
            get => nombre_empleado;
            set => nombre_empleado = value;
        }

        public DateTime _fecha_factura
        {
            get => fecha_factura;
            set => fecha_factura = value;
        }

        public double _total_factura
        {
            get => total_factura;
            set => total_factura = value;
        }

        public double _IVA
        {
            get => IVA;
            set => IVA = value;
        }

        public int _forma_pago_idforma_pago
        {
            get => forma_pago_idforma_pago;
            set => forma_pago_idforma_pago = value;
        }

        public string _cliente_idcliente
        {
            get => cliente_idcliente;
            set => cliente_idcliente = value;
        }

        public int _articulo_idarticulo
        {
            get => articulo_idarticulo;
            set => articulo_idarticulo = value;
        }

        public int _usuario_idusuario
        {
            get => usuario_idusuario;
            set => usuario_idusuario = value;
        }

        public Factura()
        {
            table_ = "factura";
            pk_ = "idfactura";
        }
    }
}