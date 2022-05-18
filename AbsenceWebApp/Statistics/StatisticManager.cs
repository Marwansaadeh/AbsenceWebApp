using AbsenceAppData;
using AbsenceWebApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.Statistics
{
    public class StatisticManager : IStatisticManager
    {
        
        public int GetAbsenceNumbersWithTypeA(int monthNumber, List<Absence> targetAbsence)
        {
          return  targetAbsence.Where(x => x.Date.Month == monthNumber && x.TypeName==TypeName.A.ToString()).Count();
        }

        public int GetContinuousAbsenceForRangeOfDays(int monthNumber, List<Absence> targetAbsence)
        {

            var absencesgroupbyList = targetAbsence.Where(x => x.Date.Month == monthNumber).OrderBy(x=>x.Date).GroupBy(x=>x.EmployeeId);
            int totalinContinuosintargetList = 0;

            foreach (var absenceGrouping in absencesgroupbyList)
            {
                DateTime startDate= new DateTime();
                DateTime endDate=new DateTime();

                if (absenceGrouping.Count()>=5)
                {
                    int counter = 0;
                    int numberofrowCounted= 0;
                    foreach (var item in absenceGrouping)
                    {
                        if (startDate== DateTime.MinValue)
                        {
                        startDate = item.Date;
                        endDate = item.Date.AddDays(4);
                        }
                        
                        if (numberofrowCounted == 5)
                        {
                            startDate = item.Date.AddDays(-1);
                            endDate = item.Date.AddDays(4);
                            numberofrowCounted = 0;
                            counter = 1;
                        }
                        if (item.Date >= startDate&& item.Date <= endDate)
                            counter++;

                        if (counter == 5)
                        {
                            totalinContinuosintargetList++;
                            break;
                        }
                        numberofrowCounted++;
                    }
                   
                }
            }
            return totalinContinuosintargetList;



        }

        public List<int> GetMonthStatisticBasedOnPrecentage(int monthNumber, List<Absence> targetAbsence)
        {
            return targetAbsence.Where(x => x.Date.Month == monthNumber && x.Percentage>=0.85).Select(x=>x.EmployeeId).GroupBy(x=>x).Select(x=>x.First()).ToList();
        }
    }
}
