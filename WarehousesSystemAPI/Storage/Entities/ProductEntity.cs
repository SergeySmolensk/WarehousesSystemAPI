using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehousesSystemAPI.Models
{
    [Table("products")]
    public class ProductEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("product_name")]
        [StringLength(80)]
        public string ProductName { get; set; }

        [Column("cost")]
        public float CostPerUnit { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }
        
        [Column("manufacture_id")]
        public int ManufactureId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public CountryEntity CountryEntity { get; set; }

        [ForeignKey(nameof(ManufactureId))]
        public ManufacturyEntity ManufacturesEntity { get; set; }

        public ProductEntity(int id, string productName, float costPerUnit, int countryId, int manufactureId)
        {
            ProductName = productName;
            CostPerUnit = costPerUnit;
            CountryId = countryId;
            ManufactureId = manufactureId;
            Id = id;
        }
    }
}
