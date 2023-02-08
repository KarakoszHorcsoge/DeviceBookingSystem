using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Persons;

namespace back.models.Cards;

public class CardGetResponse: BaseResponse{
    
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
    public Guid OwnerId { get; set; }

    public Person Owner { get; set; }

    /// <summary>
    /// megjegyzés
    /// </summary>
    /// <value>string 255</value>
    public string Comment { get; set; }
}