namespace Sistema_de_ventas.Conexiones
{
    class Usuario : SimpleORM
    {
        private int idUsuario;
        private string nombre;
        private string password;
        private string fecha;

        public int _idUsuario
        {
            get => idUsuario;
            set => idUsuario = value;
        }

        public string _nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string _password
        {
            get => password;
            set => password = value;
        }

        public string _fecha
        {
            get => fecha;
            set => fecha = value;
        }

        public Usuario()
        {
            table_ = "usuario";
            pk_ = "idUsuario";
        }
    }
}