namespace Dominio
{
    public partial class Promocion
    {
        public Promocion(){}
        public string idpromocion{get; set;}
        public string fechaExpiracion {get; set;}
        public double descuento {get; set;}
        public string fkIdplato { get; set;}
    }
}