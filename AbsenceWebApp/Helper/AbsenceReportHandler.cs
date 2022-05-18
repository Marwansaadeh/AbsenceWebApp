using AbsenceAppData;
using AbsenceWebApp.FileReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.Helper
{
    public class AbsenceReportHandler : IAbsenceReportHandler
    {
        private readonly IXmlFileReader _xmlFileReader;
        private readonly IExcelFileReader _excelFileReader;

        public AbsenceReportHandler(

            IXmlFileReader xmlFileReader,
            IExcelFileReader excelFileReader
            )
        {
            _xmlFileReader = xmlFileReader;
            _excelFileReader = excelFileReader;
        }
        public List<Absence> AbsencesA { get; private set; }
        public List<Absence> AbsencesB { get; private set; }
        public List<Absence> StartData { get; private set; }

        public List<Absence> GetAbsenceReport(string fileA, string fileB, string StartData)
        {
            this.AbsencesA = _xmlFileReader.GetAbsencesFromXml(fileA).OrderBy(x => x.Date).ToList();
            
            DateTime AbsencesDateFileA = _xmlFileReader.GetFileDate(fileA);

            this.AbsencesB = _xmlFileReader.GetAbsencesFromXml(fileB).OrderBy(x => x.Date).ToList();
            DateTime AbsencesDateFileB = _xmlFileReader.GetFileDate(fileB);

            this.StartData = _excelFileReader.GetAbsencesFromExcel(StartData);

            if (AbsencesDateFileA < AbsencesDateFileB)
            {
                //Find new and updated Records

                List<Absence> UpdatedNewEmployeesFromFileA = this.GetUpdatedNewEmployee(this.AbsencesA);
                this.UpdateStartFile(UpdatedNewEmployeesFromFileA);

                List<Absence> UpdatedNewEmployeesFromFileB = this.GetUpdatedNewEmployee(this.AbsencesB);
                this.UpdateStartFile(UpdatedNewEmployeesFromFileB);
                return this.StartData;

            }
            else
            {
                List<Absence> UpdatedNewEmployeesFromFileB = this.GetUpdatedNewEmployee(this.AbsencesB);
                this.UpdateStartFile(UpdatedNewEmployeesFromFileB);
                List<Absence> UpdatedNewEmployeesFromFileA = this.GetUpdatedNewEmployee(this.AbsencesA);
                this.UpdateStartFile(UpdatedNewEmployeesFromFileA);
                this.StartData.Where(typeName => typeName.TypeName == "1").ToList().ForEach(typeName => typeName.TypeName = TypeName.A.ToString());
                this.StartData.Where(typeName => typeName.TypeName == "2"|| typeName.TypeName=="3").ToList().ForEach(typeName => typeName.TypeName = TypeName.B.ToString());

                return this.StartData;
            }



        }
   
       

        enum TypeName
        {
            A,
            B
        }
        private List<Absence> GetUpdatedNewEmployee(List<Absence> absences)
        {
            List<Absence> UpdatedNewEmployee = absences.Where(elA => !this.StartData.Any(StartDataItem => StartDataItem.Percentage == elA.Percentage
           && StartDataItem.EmployeeId == elA.EmployeeId && StartDataItem.TypeName == elA.TypeName && StartDataItem.Date == elA.Date)).ToList();
            return UpdatedNewEmployee;
        }

        private void UpdateStartFile(List<Absence> updatednewEmployee)
        {
            foreach (var emp in updatednewEmployee)
            {
                var removeditem = this.StartData.FirstOrDefault(x => x.Date == emp.Date && x.EmployeeId == emp.EmployeeId && emp.TypeName == emp.TypeName);
                this.StartData.Remove(removeditem);
                this.StartData.Add(emp);


            }
        }


    }
}
