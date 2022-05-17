using AbsenceAppData;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.FileReader
{
    public class ExcelFileReader : IExcelFileReader

    {
        public List<Absence> GetAbsencesFromExcel(string FilePath)
        {
            List<Absence> abscenssMainList = new List<Absence>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(FilePath, FileMode.Open, FileAccess.Read))
            {
                bool isFirst = true;

                using (var mainlistReader = ExcelReaderFactory.CreateCsvReader(stream))
                {

                    while (mainlistReader.Read())
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                            continue;
                        }
                        abscenssMainList.Add(new Absence()
                        {
                            EmployeeId = Convert.ToInt32(mainlistReader.GetValue(0)),
                            Date = Convert.ToDateTime(mainlistReader.GetValue(1).ToString()),
                            TypeName = (mainlistReader.GetValue(2).ToString()),
                            Percentage = Convert.ToDouble(mainlistReader.GetValue(3).ToString())

                        });
                    }
                }
            }

            return abscenssMainList;
        }
    }
}
