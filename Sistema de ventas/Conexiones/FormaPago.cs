namespace Sistema_de_ventas.Conexiones
{
    class FormaPago : SimpleORM
    {
        private int idforma_pago;
        private string descripcion;

        public int _idforma_pago
        {
            get => idforma_pago;
            set => idforma_pago = value;
        }

        public string _descripcion
        {
            get => descripcion;
            set => descripcion = value;
        }

        public FormaPago()
        {
            table_ = "forma_pago";
            pk_ = "idforma_pago";
        }
    }
}