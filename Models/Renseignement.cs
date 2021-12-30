using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FicheConstat.Models
{
    public class Renseignement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date constat (date)")]
        public DateTime Date  { get; set; }

        [Display(Name = "Numéro d'inventaire (Inventory Number)")]
        public string? NumeroInventaire { get; set; }

        [Display(Name = "Numéro de série (Serial Number)")]

        public string? NumeroSerie { get; set; }

        [Display(Name = "Numéro ticket")]
        public string? NumTicket { get; set; }


        [Display(Name = "Intervenant (Technician)")]
        public string? Intervenant { get; set; }

        [Display(Name = "Nature Constat (Incident type)")]
        public string? Constat { get; set; }

        [Display(Name = "Priorité (priority)")]
        public string? Priorite { get; set; }

        [ Display(Name = "ID utilisateur (User ID)")]
        public string? IdUser { get; set; }

        [Display(Name = "Noms utilisateur (Name)")]
        public string? Noms { get; set; }

        [Display(Name = "Designation Matériel")]
        public string? Materiel { get; set; }

        [Display(Name = "Emplacement (Location)")]
        public string? Location { get; set; }


        [Display(Name = "Descriptif du problème rencontré")]
        public string? DescriptionProbleme { get; set; }
        [Display(Name = "Decision et remarque du departement informatique")]
        public string? DecisionRemarqueIT { get; set; }
    }
}
