using System;

namespace Sistema_de_ventas.Conexiones
{
    class Articulo : SimpleORM 
    {
        private int idArticulo;
        private string descripcion;
        private double precio_venta;
        private double precio_costo;
        private string stock;
        private DateTime fecha_ingreso;
        private int proveedor_idproveedor;

        public int _idarticulo
        {
            get => idArticulo;
            set => idArticulo = value;
        }

        public string _descripcion
        {
            get => descripcion;
            set => descripcion = value;
        }

        public double _precio_venta
        {
            get => precio_venta;
            set => precio_venta = value;
        }

        public double _precio_costo
        {
            get => precio_costo;
            set => precio_costo = value;
        }

        public string _stock
        {
            get => stock;
            set => stock = value;
        }

        public DateTime _fecha_ingreso
        {
            get => fecha_ingreso;
            set => fecha_ingreso = value;
        }

        public int _proveedor_idproveedor
        {
            get => proveedor_idproveedor;
            set => proveedor_idproveedor = value;
        }

        public Articulo()
        {
            table_ = "articulo";
            pk_ = "idarticulo";
        }
    }
}