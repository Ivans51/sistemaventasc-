using Sistema_de_ventas.Conexiones;

namespace Sistema_de_ventas
{
    class AlmacenamientoLocal
    {
        private static Usuario _usuario;

        public static Usuario Usuario
        {
            get => _usuario;
            set => _usuario = value;
        }
    }
}