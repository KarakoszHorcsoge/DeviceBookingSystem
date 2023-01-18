
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models{
    /// <summary>
    /// Rendszergazdák
    /// </summary>
    [Table("Administrator")]
    public class Administrator : BaseModel{
        
        /// <summary>
        /// név
        /// </summary>
        /// <value>1 string 45</value>
        [Required,MinLength(1),MaxLength(45)]
        public string Name { get; set; }

        /// <summary>
        /// email cím
        /// </summary>
        /// <value>1 string 100</value>
        [Required,MinLength(1),MaxLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// authorotyId<br/>
        /// referálja az authoroty táblát
        /// </summary>
        /// <value>int</value>
        [Required]
        public int AuthorotyId{ get; set;}
        
        [ForeignKey("AuthorotyId")]
        public virtual Authoroty Authoroty {get;set;}
     }

}