using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models
{
    [Table("warehouses")]
    public class WarehouseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("warehouse_id")]
        public int Id { get; set; }
        [Column("warehouse_name")]
        [StringLength(80)]
        public string WarehouseName { get; set; }
    }
}
