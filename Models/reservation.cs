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
    
    public partial class reservation
    {
        public int Num_res { get; set; }
        public Nullable<System.DateTime> Dat_res { get; set; }
        public string Typpe_res { get; set; }
        public Nullable<int> Duré_res { get; set; }
        public Nullable<int> Nb_Adult { get; set; }
        public Nullable<int> Nb_Enfant { get; set; }
        public string Num_clt { get; set; }
        public string Num_empl { get; set; }
        public Nullable<decimal> Prix_res { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employé Employé { get; set; }
    }
}
