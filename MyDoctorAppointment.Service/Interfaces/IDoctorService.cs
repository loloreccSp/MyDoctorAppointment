using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IDoctorService
    {
        Doctor Create(Doctor doctor);

        IEnumerable<DoctorViewModel> GetAll();

        Doctor? Get(int id);

        bool Delete(int id);

        Doctor Update(int id, Doctor doctor);
    }
}
