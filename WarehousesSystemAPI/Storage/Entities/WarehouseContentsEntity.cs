using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models
{
    [Table("warehouse_contents")]
    public class WarehouseContentsEntity
    {
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("warehouse_id")]
        public int WarehouseId { get; set; }
        [Column("count")]
        public int Count { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductEntity ProductEntity { get; set; }

        [ForeignKey(nameof(WarehouseId))]
        public WarehouseEntity WarehouseEntity { get; set; }

        public WarehouseContentsEntity(int productId, int warehouseId, int count) 
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            Count = count;
        }

        public WarehouseContentsEntity()
        {

        }


    }
}
