using System.ComponentModel.DataAnnotations;

namespace back.models.EventLogs;

public class EventLogGetResponse {

        /// <summary>
        /// parancs létrehozoója, az eredeti
        /// </summary>
        /// <value>int</value>
        public Guid CommandOriginId { get; set; }

        /// <summary>
        /// parancs szülője 'közvetlen kiadója'
        /// </summary>
        /// <value>int</value>
        public Guid CommandParentId { get; set; }

        /// <summary>
        /// lefutási idő
        /// </summary>
        /// <value>Datetime</value>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// Célpont típusa<br/>
        /// pl.: admin,person,personGroup stb
        /// </summary>
        /// <value>string</value>
        public string TargetType { get; set; }

        /// <summary>
        /// Target id-ja
        /// </summary>
        /// <value>int</value>
        public int TargetId { get; set; }

        /// <summary>
        /// Target id-ja
        /// </summary>
        /// <value>int</value>
        public int? SecondTargetId { get; set; }

        /// <summary>
        /// parancs típusa
        /// </summary>
        /// <value>1 string 50</value>
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
    }