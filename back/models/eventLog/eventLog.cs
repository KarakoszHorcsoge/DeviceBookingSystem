using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models{

    [Table("EventLog")]
    public class EventLog{
        /// <summary>
        /// event log id-ja
        /// </summary>
        /// <value>int autoincrement</value>
        [Required]
        public int EventLogId { get; set; }

        /// <summary>
        /// parancs létrehozoója, az eredeti
        /// </summary>
        /// <value>int</value>
        [Required]
        public int CommandOriginId { get; set; }
    
        public virtual Administrator CommandOrigin { get; set; }

        /// <summary>
        /// parancs szülője 'közvetlen kiadója'
        /// </summary>
        /// <value>int</value>
        [Required]
        public int CommandParentId { get; set; }

        public virtual Administrator CommandParent { get; set; }

        /// <summary>
        /// lefutási idő
        /// </summary>
        /// <value>Datetime</value>
        [Required]
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// Célpont típusa<br/>
        /// pl.: admin,person,personGroup stb
        /// </summary>
        /// <value>string</value>
        [Required,MinLength(1),MaxLength(20)]
        public string TargetType { get; set; }

        /// <summary>
        /// Target id-ja
        /// </summary>
        /// <value>int</value>
        [Required]
        public int TargetId { get; set; }

        public virtual object Target { get; set; }

        /// <summary>
        /// Target id-ja
        /// </summary>
        /// <value>int</value>
        [Required]
        public int SecondTargetId { get; set; }

        public virtual object SecondTarget { get; set; }

        /// <summary>
        /// parancs típusa
        /// </summary>
        /// <value>1 string 50</value>
        [Required,MinLength(1),MaxLength(50)]
        public string CommandType { get; set; }

        /// <summary>
        /// Maga a lefuttatott sql parancs
        /// </summary>
        /// <value>1 string 1000</value>
        [Required,MinLength(1),MaxLength(1000)]
        public string Command { get; set; }

        /// <summary>
        /// A szülő event id-ja
        /// </summary>
        /// <value>nullable int</value>
        public int? ParentEventLogId { get; set; }

        public virtual EventLog ParentEvent { get; set; }
    }

}