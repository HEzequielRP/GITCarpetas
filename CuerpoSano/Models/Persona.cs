using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CuerpoSano.Models;

namespace CuerpoSano.Models
{
    public abstract class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        [MaxLength(20, ErrorMessage = "El tipo de documento no puede superar los 20 caracteres")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio")]
        public int NumeroDocumento { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El teléfono celular es obligatorio")]
        public long TelCelular { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [MaxLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres")]
        public string Direccion { get; set; }

        //public virtual List<Clase> ListaClases { get; set; }

        /*public Persona()
        {
            //ListaClases = new List<Clase>();
        }*/

        public abstract void Altas();
        public abstract void Modificaciones();
        public abstract void Bajas();
        public abstract void Consultas();
    }
}