using System.ComponentModel.DataAnnotations;

namespace back.models;

public class card{
    /// <summary>
    /// Kártyaszám
    /// </summary>
    /// <value>int</value>
    [Required]
    public int CardId { get; set; }

    /// <summary>
    /// Aktív-e a kártya
    /// </summary>
    /// <value>bool</value>
    [Required]
    public bool IsActive { get; set; }


    /// <summary>
    /// Lejárati Dátum
    /// </summary>
    /// <value>DateTime</value>
    public DateTime ExperationDate { get; set; } 

    /// <summary>
    /// tulajdonos id
    /// </summary>
    /// <value>int</value>
    [Required]
    public int OwnerId { get; set; }

    public virtual person Owner { get; set; }

    /// <summary>
    /// Létrehozási Idő
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime CreationTime { get; set; }

        /// <summary>
    /// megjegyzés
    /// </summary>
    /// <value>string 255</value>
    [Required,MaxLength(255)]
    public string comment { get; set; }

    /// <summary>
    /// Létrehozó admin id-ja
    /// </summary>
    /// <value>int</value>
    [Required]
    public int CreatorId { get; set; }

    public virtual administrator Creator { get; set; }
}