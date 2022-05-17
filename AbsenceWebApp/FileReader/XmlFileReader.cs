using AbsenceAppData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace AbsenceWebApp.FileReader
{
    public class XmlFileReader : IXmlFileReader
    {
        public List<Absence> GetAbsencesFromXml(string FilePath)
        {
            XmlTextReader reader = new XmlTextReader(FilePath);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(FilePath);
            XmlNodeList Absencesnodes = xDoc.GetElementsByTagName("Employee");

            List<Absence> Absences = new List<Absence>();
            foreach (XmlNode Absence in Absencesnodes)
            {
                string id = Absence.Attributes.GetNamedItem("EmployeeId").Value;

                var startDate = new DateTime();
                var endDate = new DateTime();
                double precentage = 0;
                Int32 typeName = 0;
                foreach (XmlElement item in Absence)
                {

                    if (item.Name == "StartDate" && item.InnerText != "")
                    {
                        string ItemstartDate = item.InnerText;
                        startDate = Convert.ToDateTime(ItemstartDate, new CultureInfo("en-US"));
                    }
                    else if (item.Name == "EndDate" && item.InnerText != "")
                    {
                        string year = item.InnerText;
                        endDate = Convert.ToDateTime(year, new CultureInfo("en-US"));
                    }
                    else if (item.Name == "TypeId" && item.InnerText != "")
                    {
                        string typeId = item.InnerText;
                        typeName = Convert.ToInt32(typeId);
                    }
                    else if (item.Name == "Percentage" && item.InnerText != "")
                    {
                        string itemPercentage = item.InnerText;
                        precentage = Convert.ToDouble(itemPercentage, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    while (startDate <= endDate && typeName != 0 && precentage != 0)
                    {
                        var EmployeeAbsence = new Absence();
                        EmployeeAbsence.EmployeeId = Convert.ToInt32(id);
                        EmployeeAbsence.Date = startDate;
                        EmployeeAbsence.TypeName = typeName.ToString();
                        EmployeeAbsence.Percentage = precentage;

                        startDate = startDate.AddDays(1);
                        Absences.Add(EmployeeAbsence);
                    }

                }

            }
            return Absences;
        }

        public DateTime GetFileDate(string FilePath)
        {
            XmlTextReader reader = new XmlTextReader(FilePath);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(FilePath);
            XmlNodeList FileDateNode = xDoc.GetElementsByTagName("FileDate");
            return Convert.ToDateTime(FileDateNode[0].InnerText);  
        }
    }
}
