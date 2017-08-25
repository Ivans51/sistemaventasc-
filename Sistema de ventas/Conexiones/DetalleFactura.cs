using System.Collections.Generic;

namespace Sistema_de_ventas.Conexiones
{
    class DetalleFactura : SimpleORM
    {
        private int cod_factura;
        private int cantidad;
        private double total;
        private int factura_idfactura;

        public int _cod_factura
        {
            get => cod_factura;
            set => cod_factura = value;
        }

        public int _cantidad
        {
            get => cantidad;
            set => cantidad = value;
        }

        public double _total
        {
            get => total;
            set => total = value;
        }

        public int _factura_idfactura
        {
            get => factura_idfactura;
            set => factura_idfactura = value;
        }

        public char CPrefix
        {
            get => c_prefix;
            set => c_prefix = value;
        }

        public Dictionary<string, string> Properties1
        {
            get => Properties;
            set => Properties = value;
        }

        public DetalleFactura()
        {
            table_ = "detalle_factura";
            pk_ = "cod_factura";
        }
    }
}