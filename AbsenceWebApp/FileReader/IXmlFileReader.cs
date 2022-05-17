using AbsenceAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.FileReader
{
   public interface IXmlFileReader
    {
       List<Absence> GetAbsencesFromXml(String FilePath);
       DateTime GetFileDate(String FilePath);
    }
}
