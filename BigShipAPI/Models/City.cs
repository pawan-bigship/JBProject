using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("City", Schema = "dbo")]
    public partial class City
    {
        [Key]
        [Column("lcityid")]
        public int Lcityid { get; set; }
        [Column("lstateid")]
        public short? Lstateid { get; set; }
        [Column("lcountryid")]
        public short? Lcountryid { get; set; }
        [Required]
        [Column("lstate")]
        [StringLength(250)]
        public string Lstate { get; set; }
        [Required]
        [Column("ltype")]
        [StringLength(20)]
        public string Ltype { get; set; }
        [Column("ltin")]
        public byte Ltin { get; set; }
        [Column("lstatecode")]
        [StringLength(5)]
        public string Lstatecode { get; set; }
        [Column("addedon", TypeName = "datetime")]
        public DateTime Addedon { get; set; }

        [ForeignKey(nameof(Lcountryid))]
        [InverseProperty(nameof(Country.City))]
        public virtual Country Lcountry { get; set; }
        [ForeignKey(nameof(Lstateid))]
        [InverseProperty(nameof(State.City))]
        public virtual State LstateNavigation { get; set; }
    }
}
