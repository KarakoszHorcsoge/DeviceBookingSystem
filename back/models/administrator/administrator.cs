
using System.ComponentModel.DataAnnotations;

namespace back.models{

    public class administrator{
        /// <summary>
        /// adminisztrátor id
        /// </summary>
        /// <value>auto increment, int</value>
        [Required]
        public int AdministratorId { get; set; }

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
        /// létrehozási idő
        /// </summary>
        /// <value>Datetime</value>
        [Required]
        public DateTime CreationTime{ get; set;}

        /// <summary>
        /// authorotyId<br/>
        /// referálja az authoroty táblát
        /// </summary>
        /// <value>int</value>
        [Required]
        public int AuthorotyId{ get; set;}

        public virtual authoroty Authoroty {get;set;}

        /// <summary>
        /// létrehozó admin id-ja
        /// </summary>
        /// <value>nullable int</value>
        public int? Creator_id { get; set; }
    
        public virtual administrator? Creator { get; set; }
    }

}