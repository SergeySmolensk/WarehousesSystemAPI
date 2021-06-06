using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models
{
    [Table("countries")]
    public class CountryEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("country_id")]
        public int Id { get; set; }

        [Column("country_name")]
        [StringLength(50)]
        public string Country { get; set; }
    }
}
