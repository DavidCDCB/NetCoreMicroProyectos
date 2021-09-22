namespace DTO{


    public class MeseroDto{

        public MeseroDto(string nombre , string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }

}