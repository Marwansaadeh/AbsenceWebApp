using AbsenceAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.FileReader
{
    public interface IExcelFileReader
    {
        List<Absence> GetAbsencesFromExcel(String FilePath);

    }
}
