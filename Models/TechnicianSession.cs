using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsSoft.Models
{
    public class TechnicianSession
    {
        private const string Key = "Technician";

        private ISession session;

        public TechnicianSession(ISession session) => this.session = session;

        public Technician GetTechnician() => session.GetObject<Technician>(Key);

        public void SetTechnician(Technician technician) => session.SetObject(Key, technician);
    }
}
