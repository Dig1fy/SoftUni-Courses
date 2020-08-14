using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType(nameof(Project))]
    public class XmlImportProjectsDto
    {
        [XmlElement("Name")]
        [Required, MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")] //COULD BE NULL
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TasksDto[] Tasks { get; set; }
    }
    [XmlType(nameof(Task))]
    public class TasksDto
    {
        [XmlElement("Name")]
        [Required, MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        public int LabelType { get; set; }
    }
}