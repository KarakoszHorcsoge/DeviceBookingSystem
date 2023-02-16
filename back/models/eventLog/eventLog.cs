using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.enums.eventTypes;
using back.enums.TargetTypes;
using back.models.Administrators;

namespace back.models.EventLogs;

    [Table("EventLog")]
    public class EventLog{
        /// <summary>
        /// event log id-ja
        /// </summary>
        /// <value>int autoincrement</value>
        [ Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// parancs létrehozoója, az eredeti
        /// </summary>
        /// <value>int</value>
        public Guid? CommandOriginId { get; set; }

        [ForeignKey("CommandOriginId")]
        public virtual Administrator CommandOrigin { get; set; }

        /// <summary>
        /// parancs szülője 'közvetlen kiadója'
        /// </summary>
        /// <value>int</value>
        public Guid? CommandParentId { get; set; }

        [ForeignKey("CommandParentId")]
        public virtual Administrator CommandParent { get; set; }

        /// <summary>
        /// lefutási idő
        /// </summary>
        /// <value>Datetime</value>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// Célpont típusa<br/>
        /// pl.: admin,person,personGroup stb
        /// </summary>
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
        [ MinLength(1),MaxLength(1000)]
        public string Command { get; set; }

        /// <summary>
        /// A szülő event id-ja
        /// </summary>
        /// <value>nullable int</value>
        // szarul generálja a migration filet
        public Guid? ParentEventLogId { get; set; }

        [ForeignKey("ParentEventLogId")]
        public virtual EventLog ParentEventLog { get; set; }

        /// <summary>
        /// A szülő event id-ja
        /// </summary>
        /// <value>nullable int</value>
        // szarul generálja a migration filet
        public Guid? ChildEventLogId { get; set; }

        [ForeignKey("ChildEventLogId")]
        public virtual EventLog ChildEventLog { get; set; }
    }