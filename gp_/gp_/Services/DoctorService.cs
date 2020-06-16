using gp_.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp_.Services
{
    public class DoctorService : IDoctorService
    {

        private static ConcurrentBag<DoctorModel> _docStore;

        static DoctorService()
        {
            _docStore = new ConcurrentBag<DoctorModel>();
        }


        public Task<bool> RegisterDoc(DoctorModel doctorModel)
        {
            _docStore.Add(doctorModel);
            return Task.FromResult(true);
        }
        public Task<bool> Isonline(string name) { return Task.FromResult(true); }

     /*   public Task<DoctorModel> GetDocByEmail(string email)
        {
            return Task.FromResult(_docStore.FirstOrDefault(u => u.Email == email));
            //  throw new NotImplementedException();
        }

        public Task UpdateUser(DoctorModel doc)
        {
            _docStore = new ConcurrentBag<DoctorModel>(_docStore.Where(u => u.Email != doc.Email)) { doc };
            return Task.CompletedTask;
            //  throw new NotImplementedException();
        }*/
    }
}
