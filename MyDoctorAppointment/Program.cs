using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using System.Xml.Serialization;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;

        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
        }

        public void Menu()
        {
            while (true) 
            {              
                Console.Write("*Enter 0 for exit* \t"  +
                    "Choose foramt type: ");
                Console.WriteLine("1 - JSON; 2 - XML");
                int formatChoose = Convert.ToInt32(Console.ReadLine());


                if (formatChoose is 1)
                {
                    Console.WriteLine("1 - Create doctor; 2 - Show info; *JSON*");
                    int actionChoose = Convert.ToInt32(Console.ReadLine());

                    switch (actionChoose)
                    {
                        case 1:
                            Doctor newdoc = new Doctor
                            {
                                Name = "Vasya",
                                Surname = "Bobrov",
                                Phone = "38097142573",
                                Email = "VasyaBobrov@gmai.com",
                                DoctorType = Domain.Enums.DoctorTypes.Dentist,
                                Experiance = 5,
                                Salary = 12000,
                            };
                            _doctorService.Create(newdoc);
                            Console.WriteLine("Doctor succsesfully created! *JSON*");
                            break;
                        case 2:
                            foreach (var item in _doctorService.GetAll())
                            {
                                Console.WriteLine($"Name: {item.Name};\t" +
                                    $"Surname: {item.Surname};\t" +
                                    $"Doctor type: {item.DoctorType};\t" +
                                    $"Phone: {item.Phone}\t" +
                                    $"Email: {item.Email}");
                            }
                            break;
                    }

                }
                else if (formatChoose is 2)
                {
                    Console.WriteLine("1 - Create doctor; 2 - Show info; *XML*");
                    int actionChoose = Convert.ToInt32(Console.ReadLine());

                    switch (actionChoose)
                    {
                        case 1:
                            Doctor newdoc = new Doctor
                            {
                                Name = "lololo",
                                Surname = "Bobskiy",
                                Phone = "3807419552",
                                Email = "BobskiyBob@gmail.com",
                                DoctorType = Domain.Enums.DoctorTypes.Dermatologist,
                                Experiance = 20,
                                Salary = 18000,
                            };
                            _doctorService.CreateXML(newdoc);
                            Console.WriteLine("Doctor succsesfully created! *XML*");
                            break;
                        case 2:
                            var serializer = new XmlSerializer(typeof(TempDoctorXML));
                            using (StreamReader reader = new StreamReader("C:\\Users\\admin\\source\\repos\\MyDoctorAppointment\\DoctorAppointment.Data\\MockedDatabase\\doctor.xml"))
                            {
                                var doctors = serializer.Deserialize(reader) as TempDoctorXML;
                                foreach (Employee employee in doctors.employees)
                                {
                                    Console.WriteLine($"Name: {employee.Name}; \t" +
                                        $"Surname: {employee.Surname}; \t" +
                                        $"Doctor type: {employee.DoctorType}; \t" +
                                        $"Phone: {employee.Phone}; \t" +
                                        $"Email: {employee.Email}");
                                }
                            }
                            break;

                    }
                }
                else if (formatChoose == 0)
                {
                    Console.WriteLine("Bye-Bye");
                    break;
                }
                else
                {
                    throw new Exception("Incorrect number");
                }
            }
        }
    }

    public static class Program
    {
        public static void Main()
        {
            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();
        }
    } 
}
