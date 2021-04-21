//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vVuelos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.flight_tickets = new HashSet<flight_tickets>();
            this.log_book = new HashSet<log_book>();
            this.cards1 = new HashSet<card>();
        }
    
        public int id { get; set; }
        [MinLength(3,ErrorMessage ="El usuario debe tener al menos 3 caracteres")]
        public string username { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [PasswordPropertyText]
        [StringLength(16,MinimumLength = 8, ErrorMessage = "Contraseņa debe tener entre 8 y 16 caracteres")]
        public string old_password { get; set; }
        [PasswordPropertyText]
        [StringLength(16, MinimumLength = 8,ErrorMessage = "Contraseņa debe tener al menos 8 caracteres")]
        public string new_password { get; set; }

        public string first_name { get; set; }

        public string middle_name { get; set; }

        public string last_name { get; set; }

        public string second_last_name { get; set; }
        public int rol_id_FK { get; set; }
        public string consecutive_country_id { get; set; }

        public string security_question1 { get; set; }

        public string answer1 { get; set; }
    
        public virtual country country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<flight_tickets> flight_tickets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<log_book> log_book { get; set; }
        public virtual role role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<card> cards1 { get; set; }
    }
}
