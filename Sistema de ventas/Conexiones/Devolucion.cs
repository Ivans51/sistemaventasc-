using System;

namespace Sistema_de_ventas.Conexiones
{
    class Devolucion : SimpleORM
    {
        private int cod_detallefactura;
        private string movivo;
        private DateTime fecha_devolucion;
        private int cantidad;
        private int detalle_factura_cod_factura;
        private int articulo_idarticulo;

        public int _cod_detallefactura
        {
            get => cod_detallefactura;
            set => cod_detallefactura = value;
        }

        public string _movivo
        {
            get => movivo;
            set => movivo = value;
        }

        public DateTime _fecha_devolucion
        {
            get => fecha_devolucion;
            set => fecha_devolucion = value;
        }

        public int _cantidad
        {
            get => cantidad;
            set => cantidad = value;
        }

        public int _detalle_factura_cod_factura
        {
            get => detalle_factura_cod_factura;
            set => detalle_factura_cod_factura = value;
        }

        public int _articulo_idarticulo
        {
            get => articulo_idarticulo;
            set => articulo_idarticulo = value;
        }

        public Devolucion()
        {
            table_ = "devolucion";
            pk_ = "cod_detallefactura";
        }
    }
}