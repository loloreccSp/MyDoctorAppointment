using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Extensions
{
    public static class Mapper
    {
        public static DoctorViewModel ConvertTo(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            string doctorType = doctor.DoctorType switch
            {
                DoctorTypes.Dentist => "Dentist",
                DoctorTypes.Dermatologist => "Dermatologist",
                DoctorTypes.FamilyDoctor => "FamilyDoctor",
                DoctorTypes.Paramedic => "Paramedic",
                _ => "Unknown",
            };
            return new DoctorViewModel()
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                Phone = doctor.Phone,
                DoctorType = doctorType,
                Experiance = doctor.Experiance,
                Salary = doctor.Salary
            };
        }
    }
}
