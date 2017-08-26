using System;

namespace Sistema_de_ventas.Conexiones
{
    class Usuario : SimpleORM
    {
        private int idUsuario;
        private string nombre;
        private string password;
        private string nivel;
        private DateTime fecha;

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

        public DateTime _fecha
        {
            get => fecha;
            set => fecha = value;
        }
        public string _nivel
        {
            get => nivel;
            set => nivel = value;
        }

        public Usuario()
        {
            table_ = "usuario";
            pk_ = "idUsuario";
        }
    }
}