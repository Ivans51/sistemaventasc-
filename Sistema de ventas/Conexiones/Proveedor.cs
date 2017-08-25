namespace Sistema_de_ventas.Conexiones
{
    class Proveedor : SimpleORM
    {
        private int idproveedor;
        private string nombre;
        private string apellido;
        private string nombre_comercial;
        private string direccion;
        private string telefono;
        private string nombre_ciudad;
        private int usuario_idusuario;

        public int _idproveedor
        {
            get => idproveedor;
            set => idproveedor = value;
        }

        public string _nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string _apellido
        {
            get => apellido;
            set => apellido = value;
        }

        public string _nombre_comercial
        {
            get => nombre_comercial;
            set => nombre_comercial = value;
        }

        public string _direccion
        {
            get => direccion;
            set => direccion = value;
        }

        public string _telefono
        {
            get => telefono;
            set => telefono = value;
        }

        public string _nombre_ciudad
        {
            get => nombre_ciudad;
            set => nombre_ciudad = value;
        }

        public int _usuario_idusuario
        {
            get => usuario_idusuario;
            set => usuario_idusuario = value;
        }

        public Proveedor()
        {
            table_ = "proveedor";
            pk_ = "idproveedor";
        }
    }
}