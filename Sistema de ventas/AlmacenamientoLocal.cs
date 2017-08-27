using Sistema_de_ventas.Conexiones;

namespace Sistema_de_ventas
{
    class AlmacenamientoLocal
    {
        private static Usuario _usuario;
        private static string rutaPDF = @"C:\Users\Ivans\source\repos\Sistema de ventas\Sistema de ventas\bin\Debug\";

        public static Usuario Usuario
        {
            get => _usuario;
            set => _usuario = value;
        }
        public static string RutaPDF {
            get => rutaPDF;
            set => rutaPDF = value;
        }
    }
}