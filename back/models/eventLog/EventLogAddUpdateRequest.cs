using System.ComponentModel.DataAnnotations;

namespace back.models.EventLogs;

public class EventLogAddUpdateRequest : BaseRequest{

        /// <summary>
        /// parancs létrehozoója, az eredeti
        /// </summary>
        /// <value>int</value>
        [Required]
        public Guid CommandOriginId { get; set; }

        /// <summary>
        /// parancs szülője 'közvetlen kiadója'
        /// </summary>
        /// <value>int</value>
        [Required]
        public Guid CommandParentId { get; set; }

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
        public Guid TargetId { get; set; }

        /// <summary>
        /// Target id-ja
        /// </summary>
        /// <value>int</value>
        [Required]
        public Guid? SecondTargetId { get; set; }

        /// <summary>
        /// parancs típusa
        /// </summary>
        /// <value>1 string 50</value>
        [Required,MinLength(1),MaxLength(50)]
        public string CommandType { get; set; }

        /// <summary>
        /// Maga a lefuttatott sql parancs paraméterei
        /// </summary>
        /// <value>1 string 1000</value>
        [Required,MinLength(1),MaxLength(1000)]
        public string Command { get; set; }

        /// <summary>
        /// A szülő event id-ja
        /// </summary>
        /// <value>nullable int</value>
        public Guid? ParentEventLogId { get; set; }
        public Guid? ChildEventLogId { get; set; }
    }