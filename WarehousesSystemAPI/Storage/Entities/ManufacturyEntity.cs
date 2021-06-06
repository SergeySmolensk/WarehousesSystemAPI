using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models
{
    [Table("manufactures")]
    public class ManufacturyEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("manufacture_id")]
        public int Id { get; set; }

        [Column("manufacture_name")]
        [StringLength(80)]
        public string ManufactureName { get; set; }
    }
}
