using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }

        //public override string XMLPath { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public override Doctor ShowInfo(Doctor doctor)
        {
            Console.WriteLine($"Name: {doctor.Name}; Experiance: {doctor.Experiance}");
            return doctor;
        }

        public override Doctor CreateXML(Doctor doctor)
        {
            XDocument xdoc = XDocument.Load("C:\\Users\\admin\\source\\repos\\MyDoctorAppointment\\DoctorAppointment.Data\\MockedDatabase\\doctor.xml");
            XElement? root = xdoc.Element("Base");
            {
                root.Element("Doctor").Add(new XElement("Employee",
                        new XElement("Name", $"{doctor.Name}"),
                        new XElement("Surname", $"{doctor.Surname}"),
                        new XElement("phone", $"{doctor?.Phone}"),
                        new XElement("email", $"{doctor?.Email}"),
                        new XElement("doctorType", $"{doctor?.DoctorType}"),
                        new XElement("Experiance", $"{doctor.Experiance}"),
                        new XElement("salary", $"{doctor.Salary}")
                        ));

                xdoc.Save("C:\\Users\\admin\\source\\repos\\MyDoctorAppointment\\DoctorAppointment.Data\\MockedDatabase\\doctor.xml");
            }
            return doctor;
        }
        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
