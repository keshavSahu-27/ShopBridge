using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Dal.Entities;
public class Inventory
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(20,ErrorMessage = "Name should not be more than 20 characters")]
    public string Name { get; set; } = "";

    [StringLength(20, ErrorMessage = "Description should not be more than 100 characters")]
    public string Description { get; set; } = "";

    [Required]
    [Range(0,double.MaxValue,ErrorMessage = "Must be greater than 0")]
    public float Price { get; set; }

    [Required]
    public DateTime AddedDate { get; set; }

    [Required]
    public DateTime LastModified { get; set; }
}

