using gp_.Models;
using System.Threading.Tasks;

namespace gp_.Services
{
    public interface IDoctorService
    {
        Task<DoctorModel> GetDocByEmail(string email);
        Task<bool> Isonline(string name);
        Task<bool> RegisterDoc(DoctorModel doctorModel);
        Task UpdateUser(DoctorModel doc);
    }
}