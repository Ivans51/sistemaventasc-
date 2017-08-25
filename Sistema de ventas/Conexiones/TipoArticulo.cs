namespace Sistema_de_ventas.Conexiones
{
    class TipoArticulo : SimpleORM
    {
        private int idtipo_articulo;
        private string descripcion_articulo;

        public int _idtipo_articulo
        {
            get => idtipo_articulo;
            set => idtipo_articulo = value;
        }

        public string _descripcion_articulo
        {
            get => descripcion_articulo;
            set => descripcion_articulo = value;
        }

        public TipoArticulo()
        {
            table_ = "tipo_articulo";
            pk_ = "idtipo_articulo";
        }
    }
}