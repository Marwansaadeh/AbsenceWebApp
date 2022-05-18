using AbsenceAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.Statistics
{
    public interface IStatisticManager
    {
        List<int> GetMonthStatisticBasedOnPrecentage(int monthNumber, List<Absence> targetAbsence);
        int GetAbsenceNumbersWithTypeA (int monthNumber, List<Absence> targetAbsence);

        int GetcContinuousAbsencForRangeOfDays(int monthNumber, List<Absence> targetAbsence);

    }
}
