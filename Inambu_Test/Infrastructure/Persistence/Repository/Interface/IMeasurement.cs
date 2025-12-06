using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository.Interface
{
    public interface IMeasurement
    {
        Task<int?> CreateMeasurement(tblMeasurement measurement);

        Task<List<tblMeasurement?>> GetAllMeasurements();
    }
}
