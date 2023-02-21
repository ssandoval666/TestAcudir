using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcudirTes2.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        ///<Summary>
        /// Nombre de Usuario
        ///</Summary>
        ///
        public string UserName { get; set; }

        ///<Summary>
        /// Contraseña
        ///</Summary>
        ///
        public string Password { get; set; }

        ///<Summary>
        /// Fecha de Creacion
        ///</Summary>
        ///
        public DateTime CreatedDate { get; set; }
    }
}
