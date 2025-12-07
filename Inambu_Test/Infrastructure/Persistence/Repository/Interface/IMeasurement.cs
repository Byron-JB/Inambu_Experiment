using Domain.Entities;

namespace Infrastructure.Persistence.Repository.Interface
{
    public interface IMeasurement
    {
        Task<int?> CreateMeasurement(tblMeasurement measurement);

        Task<tblMeasurement?> GetMeasurementById(int measurementId);

        Task<List<tblMeasurement?>> GetAllMeasurements();

        Task<bool> DeleteMeasurement(int measurementId);
        Task<bool> UpdateMeasurement(tblMeasurement measurement);
    }
}
