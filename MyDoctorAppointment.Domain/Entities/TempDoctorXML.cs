

using System.Xml.Serialization;

namespace MyDoctorAppointment.Domain.Entities
{
    [XmlRoot("Base")]
    public class TempDoctorXML
    {
        [XmlArray("Doctor")]
        [XmlArrayItem("Employee")]
        public List<Employee> employees { get; set;  }
    }

    public class Employee
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Surname")]
        public string Surname { get; set; }

        [XmlElement("phone")]
        public string Phone { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("doctorType")]
        public string DoctorType { get; set; }

        [XmlElement("Experiance")]
        public int Experiance { get; set; }

        [XmlElement("salary")]
        public int Salary { get; set; }

    }
}
