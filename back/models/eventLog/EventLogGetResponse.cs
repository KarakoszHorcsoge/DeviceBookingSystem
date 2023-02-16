using System.ComponentModel.DataAnnotations;
using back.enums.eventTypes;
using back.enums.TargetTypes;
using back.models.Administrators;

namespace back.models.EventLogs;

public class EventLogGetResponse {

        /// <summary>
        /// parancs létrehozoója, az eredeti
        /// </summary>
        /// <value>int</value>
        public Guid? CommandOriginId { get; set; }

        public Administrator CommandOrigin { get; set; }

        /// <summary>
        /// parancs szülője 'közvetlen kiadója'
        /// </summary>
        /// <value>int</value>
        public Guid? CommandParentId { get; set; }

        public Administrator CommandParent { get; set; }

        /// <summary>
        /// lefutási idő
        /// </summary>
        /// <value>Datetime</value>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// Célpont típusa<br/>
        /// pl.: admin,person,personGroup stb
        /// </summary>
        /// <value>enum</value>
        public TargetType TargetType { get; set; }

        /// <summary>
        /// Target id-ja
        /// </summary>
        /// <value>int</value>
        public Guid? TargetId { get; set; }

        /// <summary>
        /// Célpont típusa<br/>
        /// pl.: admin,person,personGroup stb
        /// </summary>
        /// <value>enum</value>
        public TargetType? SecondTargetType { get; set; }

        /// <summary>
        /// Target id-ja
        /// </summary>
        /// <value>int</value>
        public Guid? SecondTargetId { get; set; }

        /// <summary>
        /// parancs típusa
        /// </summary>
        public eventType CommandType { get; set; }

        /// <summary>
        /// Maga a lefuttatott sql parancs
        /// </summary>
        /// <value>1 string 1000</value>
        public string Command { get; set; }

        /// <summary>
        /// A szülő event id-ja
        /// </summary>
        /// <value>nullable int</value>
        public Guid? ParentEventLogId { get; set; }
    
        public virtual EventLog ParentEventLog { get; set; }

        /// <summary>
        /// A szülő event id-ja
        /// </summary>
        /// <value>nullable int</value>
        public Guid? ChildEventLogId { get; set; }

        public virtual EventLog ChildEventLog { get; set; }
    }