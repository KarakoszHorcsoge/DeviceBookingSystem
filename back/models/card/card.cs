using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Persons;

namespace back.models.Cards;

/// <summary>
/// Kártyák
/// </summary>
[Table("Card")]
public class Card : BaseModel{
    

    /// <summary>
    /// Aktív-e a kártya
    /// </summary>
    /// <value>bool</value>
    public bool IsActive { get; set; }


    /// <summary>
    /// Lejárati Dátum
    /// </summary>
    /// <value>DateTime</value>
    public DateTime? ExperationDate { get; set; } 

    /// <summary>
    /// tulajdonos id
    /// </summary>
    /// <value>int</value>
    public Guid? OwnerId { get; set; }

    [ForeignKey("OwnerId")]
    public virtual Person Owner { get; set; }

     /// <summary>
    /// megjegyzés
    /// </summary>
    /// <value>string 255</value>
    [MaxLength(255)]
    public string Comment { get; set; }
}