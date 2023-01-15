using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models;

public class reception{
    /// <summary>
    /// Porta id-ja
    /// </summary>
    /// <value>int auto increment</value>
    [Key,Required,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReceptionId { get; set; }

    /// <summary>
    /// porta id-ja
    /// </summary>
    /// <value>1 string 50</value>
    [Required, MinLength(1),MaxLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Porta címe
    /// </summary>
    /// <value>1 string 100</value>
    [Required, MinLength(1),MaxLength(100)]
    public string Address { get; set; }

    /// <summary>
    /// létrehozási idő
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 255</value>
    [Required, MaxLength(255)]
    public string comment { get; set; }

    /// <summary>
    /// A portáért felelős rendszergazda
    /// </summary>
    /// <value>int</value>
    [Required,ForeignKey("administrator")]
    public int AdminId { get; set; }

    public virtual administrator Admin { get; set; }

    /// <summary>
    /// Készítő admin
    /// </summary>
    /// <value>int</value>
    [Required,ForeignKey("administrator")]
    public int CreatorId { get; set; }

    public virtual administrator Creator { get; set; }
}