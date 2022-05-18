using AbsenceAppData;
using AbsenceWebApp.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AbsenceTest
{
    [TestClass]
    public class StatisticTest
    {
        IStatisticManager statisticManager = new StatisticManager();

        [TestMethod]
        public void ContinuousAbsencForRangeOfDays_MatchData_ReturnTrue()
        {
            List<Absence> moq = new List<Absence>()
            {
                new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,01),
                    Percentage=0.80
                },
                 new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,02),
                    Percentage=0.80
                },
                  new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,03),
                    Percentage=0.80
                },
                   new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,04),
                    Percentage=0.80
                },
                    new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,31),
                    Percentage=0.80
                },
                     new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,08),
                    Percentage=0.80
                },
                      new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,9),
                    Percentage=0.80
                },
                       new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,10),
                    Percentage=0.80
                },
                        new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,11),
                    Percentage=0.80
                },
                       new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,12),
                    Percentage=0.80
                },
                                new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,08),
                    Percentage=0.80
                },
                                         new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,09),
                    Percentage=0.80
                },         new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,10),
                    Percentage=0.80
                },         new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,11),
                    Percentage=0.80
                },         new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,13),
                    Percentage=0.80
                },
                  new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,12),
                    Percentage=0.80
                },



            };
            int number = statisticManager.GetContinuousAbsenceForRangeOfDays(3, moq);
            Assert.IsTrue(number == 2);


        }

        [TestMethod]
        public void ContinuousAbsencForRangeOfDays_NotMatchData_ReturnFalse()
        {
            List<Absence> moq = new List<Absence>()
            {
                new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,01),
                    Percentage=0.80
                },
                 new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,02),
                    Percentage=0.80
                },
                  new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,03),
                    Percentage=0.80
                },
                   new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,04),
                    Percentage=0.80
                },
                    new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,31),
                    Percentage=0.80
                },
                     new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,08),
                    Percentage=0.80
                },
                      new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,9),
                    Percentage=0.80
                },
                       new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,10),
                    Percentage=0.80
                },
                        new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,11),
                    Percentage=0.80
                },
                       new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=1,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,12),
                    Percentage=0.80
                },
                                new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,08),
                    Percentage=0.80
                },
                                         new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,09),
                    Percentage=0.80
                },         new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,10),
                    Percentage=0.80
                },         new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,11),
                    Percentage=0.80
                },         new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,13),
                    Percentage=0.80
                },
                  new Absence()
                {
                    Id= new System.Guid(),
                    EmployeeId=2,
                    TypeName="A",
                    Date= new System.DateTime(2020,03,16),
                    Percentage=0.80
                },



            };
            int number = statisticManager.GetContinuousAbsenceForRangeOfDays(3, moq);
            Assert.IsFalse(number == 2);


        }
    }
}
