using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcudirTes2.Models
{
        public partial class People
        {

        ///<Summary>
        /// Id de usuario
        ///</Summary>
        ///
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int UserId { get; set; }

        ///<Summary>
        /// Nombre
        ///</Summary>
        ///
        public string FirstName { get; set; }

        ///<Summary>
        /// Apellido
        ///</Summary>
        ///
        public string LastName { get; set; }

        ///<Summary>
        /// Nombre de Usuario
        ///</Summary>
        ///
        public string UserName { get; set; }

        ///<Summary>
        /// Correo Electronico
        ///</Summary>
        ///
        public string Email { get; set; }

        ///<Summary>
        /// Contraseña
        ///</Summary>
        ///
        public string Password { get; set; }

        public bool Activo { get; set; }

        ///<Summary>
        /// Fecha de Creacion
        ///</Summary>
        ///
        public DateTime CreatedDate { get; set; }
    }
    }