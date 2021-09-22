namespace DTO
{
    //https://www.netmentor.es/entrada/trabajando-con-fechas
    public class CalendarioDto

    {
        public CalendarioDto (string tipo, string fecha, int numeroSemana, string seleccionTurno){
            this.tipo = tipo;
            this.fecha = fecha;
            this.numeroSemana = numeroSemana;
            this.seleccionTurno = seleccionTurno;
        
        }
        public string tipo { get; set; }
        public string fecha { get; set; }
        public int numeroSemana {get; set;}
        public string seleccionTurno{ get; set;}
      
    }
}
