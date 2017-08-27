using System;

namespace Sistema_de_ventas.Conexiones
{
    class Factura : SimpleORM
    {
        private int idfactura;
        private string nombre_empleado;
        private string articulos;
        private string fecha_factura;
        private double total_factura;
        private double IVA;
        private string forma_pago;
        private int cliente_idcliente;
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

        public string _fecha_factura
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

        public string _forma_pago
        {
            get => forma_pago;
            set => forma_pago = value;
        }

        public int _cliente_idcliente
        {
            get => cliente_idcliente;
            set => cliente_idcliente = value;
        }

        public int _usuario_idusuario
        {
            get => usuario_idusuario;
            set => usuario_idusuario = value;
        }
        public string _articulos {
            get => articulos;
            set => articulos = value;
        }

        public Factura()
        {
            table_ = "factura";
            pk_ = "idfactura";
        }
    }
}