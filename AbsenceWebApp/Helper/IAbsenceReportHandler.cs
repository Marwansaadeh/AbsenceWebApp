using AbsenceAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.Helper
{
    public interface  IAbsenceReportHandler
    {
        List<Absence> GetAbsenceReport(string fileA, string fileB, string StartData);
    }
}
