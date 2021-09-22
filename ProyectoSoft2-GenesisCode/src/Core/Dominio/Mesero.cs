using System;

namespace Dominio
{
    public partial class Mesero
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDocumento { get; set; }
        public string documento { get; set; }
        public string nivelAcademico { get; set; }
        public string emailEmpresa { get; set; }
        public string emailPersonal { get; set; }
        public string direccion { get; set; }
        public string barrio { get; set; }
        public string ciudad { get; set; }
        public string telefonoFijo { get; set; }
        public string telefonoCelular { get; set; }
        public bool estado { get; set; }
        public bool estudia { get; set; }
        public string genero { get; set; }
        public string fechaNacimiento { get; set; }

        /// <summary>
        /// </summary>
        /// 
        ///
        public Mesero(string Nombre, string Apellido, string TipoDocumento, string Documento,
                    string NivelAcademico, string EmailEmpresa, string EmailPersonal, string Direccion,
                    string Barrio, string Ciudad, string TelefonoFijo, string TelefonoCelular, bool Estado,
                    bool Estudia, string Genero, string FechaNacimiento)
        {
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.tipoDocumento = TipoDocumento;
            this.documento = Documento;
            this.nivelAcademico = NivelAcademico;
            this.emailEmpresa = EmailEmpresa;
            this.emailPersonal = EmailPersonal;
            this.direccion = Direccion;
            this.barrio = Barrio;
            this.ciudad = Ciudad;
            this.telefonoFijo = TelefonoFijo;
            this.telefonoCelular = TelefonoCelular;
            this.estado = Estado;
            this.estudia = Estudia;
            this.genero = Genero;
            string[] fecha = FechaNacimiento.Split('/');
            //int dd = String()
            this.fechaNacimiento = FechaNacimiento;
        }
    }
}