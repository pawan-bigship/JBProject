using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("State", Schema = "dbo")]
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
        }

        [Key]
        [Column("lstateid")]
        public short Lstateid { get; set; }
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
        [InverseProperty(nameof(Country.State))]
        public virtual Country Lcountry { get; set; }
        [InverseProperty("LstateNavigation")]
        public virtual ICollection<City> City { get; set; }
    }
}
