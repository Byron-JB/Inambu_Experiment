using Domain.Entities;

namespace Infrastructure.Perisitence
{
    public static class Seeds
    {
        public static IReadOnlyList<tblUser> GetSeedUsers()
        {
            var listOfSeedUsers = new List<tblUser>
            {
                new tblUser
                {
                    strUserName = "Inspector1",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                },
                new tblUser
                {
                    strUserName = "Inspector2",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                },                
                new tblUser
                {
                    strUserName = "Inspector2",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                }
            };

            return listOfSeedUsers;
        }

        public static IReadOnlyList<tblProductionLine> GetSeedProductionLines()
        {
            var listOfSeedProductionLines = new List<tblProductionLine>
            {
                new tblProductionLine
                {
                    strLineName = "Line A",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                    
                },
                new tblProductionLine
                {
                    strLineName = "Line B",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                },
                new tblProductionLine
                {
                    strLineName = "Line C",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                }
            };
            return listOfSeedProductionLines;
        }

        public static IReadOnlyList<tblMeasurement> GetSeedMeasurements()
        {
            var listOfSeedMeasurements = new List<tblMeasurement>
            {
                new tblMeasurement
                {
                    dTemperature = 25.0m,
                    dHumidity = 50.0m,
                    dWeight = 10.0m,
                    dWidth = 5.0m,
                    dLength = 15.0m,
                    dDepth = 3.0m,
                    bIsWithinSpecification = true,
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null,
                },
                new tblMeasurement
                {
                    dTemperature = 30.0m,
                    dHumidity = 60.0m,
                    dWeight = 12.0m,
                    dWidth = 6.0m,
                    dLength = 16.0m,
                    dDepth = 4.0m,
                    bIsWithinSpecification = false,
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null
                }
            };
            return listOfSeedMeasurements;
        }
    }
}
