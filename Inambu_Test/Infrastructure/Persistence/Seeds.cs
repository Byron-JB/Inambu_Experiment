using Domain.Entities;

namespace Infrastructure.Perisitence
{
    public static class Seeds
    {
        public static IReadOnlyList<tblUserRoles> GetSeedUserRoles()
        {
            return new List<tblUserRoles>()
            {
                new tblUserRoles()
                {
                    IsActive = true,
                    CreatedBy  = -1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    strRoleName = "CEO"
                },
                new tblUserRoles()
                {
                    IsActive = true,
                    CreatedBy  = -1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    strRoleName = "Department Manager"
                },
                new tblUserRoles()
                {
                    IsActive = true,
                    CreatedBy  = -1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    strRoleName = "Finance Director"
                },
                new tblUserRoles()
                {
                    IsActive = true,
                    CreatedBy  = -1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    strRoleName = "General User"
                }
            };
        }

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
                    ModifiedDate = null,
                    iRoleId = 4
                },
                new tblUser
                {
                    strUserName = "Inspector2",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    iRoleId = 4
                },
                new tblUser
                {
                    strUserName = "Inspector3",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    iRoleId = 4
                },
                new tblUser
                {
                    strUserName = "Jeff Sidebottom",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    iRoleId = 1
                },
                new tblUser
                {
                    strUserName = "Alice Liddle",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    iRoleId = 3
                },
                new tblUser
                {
                    strUserName = "Bob Lockwood",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    iRoleId = 2
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
                    iLineId = 1
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
                    ModifiedDate = null,
                    iLineId = 1
                }
            };
            return listOfSeedMeasurements;
        }
    }
}
