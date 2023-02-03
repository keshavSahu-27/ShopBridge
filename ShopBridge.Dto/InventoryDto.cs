using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShopBridge.Dto;

[DataContract]
public class InventoryDto
{
    [DataMember(Name = "id")]
    public long Id { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; } = "";

    [DataMember(Name = "description")]
    public string Description { get; set; } = "";

    [DataMember(Name = "price")]
    public float Price { get; set; }

    [DataMember(Name = "addedDate")]
    public DateTime AddedDate { get; set; }

    [DataMember(Name = "lastModified")]
    public DateTime LastModified { get; set; }
}

