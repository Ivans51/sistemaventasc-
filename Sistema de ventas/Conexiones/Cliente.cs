﻿namespace Sistema_de_ventas.Conexiones
{
    class Cliente : SimpleORM
    {
        private int idcliente;
        private string cedula;
        private string nombres;
        private string apellidos;
        private string direccion;
        private string nombre_ciudad;

        public int _idcliente
        {
            get => idcliente;
            set => idcliente = value;
        }

        public string _cedula {
            get => cedula;
            set => cedula = value;
        }

        public string _nombres
        {
            get => nombres;
            set => nombres = value;
        }

        public string _apellidos
        {
            get => apellidos;
            set => apellidos = value;
        }

        public string _direccion
        {
            get => direccion;
            set => direccion = value;
        }

        public string _nombre_ciudad
        {
            get => nombre_ciudad;
            set => nombre_ciudad = value;
        }

        public Cliente()
        {
            table_ = "cliente";
            pk_ = "idcliente";
        }
    }
}