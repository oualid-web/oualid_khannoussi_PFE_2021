//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gestion_riad_projet_fin_etude.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gerant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gerant()
        {
            this.Employé = new HashSet<Employé>();
        }
    
        public string Num_gerant { get; set; }
        public string Nom_gerant { get; set; }
        public string Prénom_gerant { get; set; }
        public string Numero_télé { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employé> Employé { get; set; }
    }
}
