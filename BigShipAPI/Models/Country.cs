using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBProject.Models
{
    [Table("Country", Schema = "dbo")]
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
            State = new HashSet<State>();
        }

        [Key]
        [Column("lcountryid")]
        public short Lcountryid { get; set; }
        [Required]
        [Column("lcountry")]
        [StringLength(250)]
        public string Lcountry { get; set; }
        [Column("addedon", TypeName = "datetime")]
        public DateTime Addedon { get; set; }

        [InverseProperty("Lcountry")]
        public virtual ICollection<City> City { get; set; }
        [InverseProperty("Lcountry")]
        public virtual ICollection<State> State { get; set; }
    }
}
