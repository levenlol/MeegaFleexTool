using System;
using System.Collections.Generic;
using System.Globalization;
using Nager.Date;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace MeegaFleeexTool.Timbrature
{
    public enum WorkDayType : uint
    {
        Normal,
        Vacation,
        Festivity,
        WeekEnd
    }

    public class DayDescriptor
    {
        private DayOfWeek day;
        private int orarioEntrata;
        private int orarioUscita;
        private int ritardi;
        private int giustificativi;
        private int actualWorked;
        private WorkDayType dayType;

        private const int MAX_ENTRATA = 10 * 60 + 30;
        private const int MIN_USCITA = 17 * 60;

        public DayOfWeek Day { get => day; }
        public int OrarioEntrata { get => orarioEntrata; }
        public int OrarioUscita { get => orarioUscita; }
        public int Ritardi { get => ritardi; }
        public int Giustificativi { get => giustificativi; }
        public int ActualWorked { get => actualWorked; }
        public WorkDayType DayType { get => dayType; }

        public DayDescriptor(DayOfWeek d, WorkDayType t, int late = 0, int rol = 0)
        {
            day = d;
            dayType = t;
            ritardi = late;
            giustificativi = rol;

            SetWorkedHours(0, 0);
        }

        public DayDescriptor(DayOfWeek d, int entrata, int uscita, WorkDayType t, int late = 0, int rol = 0)
        {
            day = d;
            dayType = t;
            ritardi = late;
            giustificativi = rol;

            SetWorkedHours(entrata, uscita);
        }

        public void SetRitardo(int late)
        {
            ritardi = late;
            ComputeWorkedHours();
        }

        public void AddRitardo(int late)
        {
            ritardi += late;
            ComputeWorkedHours();
        }

        public void SetGiustificativi(int rol)
        {
            giustificativi = rol;
            ComputeWorkedHours();
        }

        public void SetWorkedHours(int entrata, int uscita)
        {
            orarioEntrata = entrata;
            orarioUscita = uscita;

            ComputeWorkedHours();
        }

        public void SetWorkDayType(WorkDayType type)
        {
            dayType = type;
        }

        private void ComputeWorkedHours()
        {
            if(dayType == WorkDayType.Vacation || dayType == WorkDayType.Festivity)
            {
                // ferie o feste.
                actualWorked = 8 * 60;
                return;
            }

            int pausaPranzo = 0;
            if (orarioEntrata < 13 * 60 && orarioUscita > 14 * 60) // pausa pranzo tra le 13 e le 14 
            {
                pausaPranzo = 60;
            }

            actualWorked = orarioUscita - orarioEntrata - pausaPranzo - ritardi + giustificativi;
        }
    }

    public class MonthDescriptor
    {
        private List<DayDescriptor> days;
        public List<DayDescriptor> Days { get => days; }

        public MonthDescriptor(int year, int month)
        {
            int dayInMonth = DateTime.DaysInMonth(year, month);

            DateTime currentDay = new DateTime(year, month, 1);

            days = new List<DayDescriptor>(dayInMonth);

            for(int i = 0; i < dayInMonth; i++)
            {
                DayDescriptor d = new DayDescriptor(currentDay.DayOfWeek, GetWorkDayType(currentDay));
                days.Add(d);

                currentDay = currentDay.AddDays(1);
            }
        }

        public void SetEntrateUscite(int day, int entrata, int uscita)
        {
            days[day - 1].SetWorkedHours(entrata, uscita);
        }

        public void AddRitardoPranzo(int day, int ritardo)
        {
            days[day - 1].AddRitardo(ritardo);
        }

        public void SetGiustificativi(int day, int giustificativi)
        {
            days[day - 1].SetGiustificativi(giustificativi);
        }

        // Zucchetti code: FS | RL | 01
        private void SetWorkDayType(int day, string zString)
        {
            WorkDayType type = WorkDayType.Normal; // aka 01

            if (zString == "FS")
            {
                type = WorkDayType.Festivity;
            }
            else if(zString == "RL")
            {
                type = WorkDayType.WeekEnd;
            }

            days[day - 1].SetWorkDayType(type);
        }

        private WorkDayType GetWorkDayType(DateTime date)
        {
            bool holiday = DateSystem.IsPublicHoliday(date, CountryCode.IT);

            if (holiday)
                return WorkDayType.Festivity;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return WorkDayType.WeekEnd;

            return WorkDayType.Normal; // check for vacation
        }
    }

    public class TimbratureResume
    {
        class DayResume
        {
            public DayOfWeek day;
            public int workedMins;
            public int expectedWorkingHours;

            public DayResume(DayOfWeek d, int minsWorked = 0, int expectedMinsToWork = 8 * 60)
            {
                day = d;
                workedMins = minsWorked;
                expectedWorkingHours = expectedMinsToWork;
            }
        }

        private List<DayResume> resumesList;

        public TimbratureResume()
        {
            resumesList = new List<DayResume>();
        }

        public void AddTimbrature(int day)
        {
            for (int i = 0; i < 5; i++)
            {
                DayResume d = new DayResume((DayOfWeek)(i + 1));
                resumesList.Add(d);
            }
        }
    }

    public class TimbratureBuilder
    {
        private const string entrataXPath = ".//*[@title='Entrata']";
        private const string uscitaXPath = ".//*[@title='Uscita']";
        private const string giustificativiXPath = ".//*[@class='grid_cell gird_borderRB']";

        public const int WEEKLY_HOURS = 40;

        private MonthDescriptor monthDescriptor;
        public MonthDescriptor Month{ get => monthDescriptor; }


        public TimbratureBuilder(DateTime date)
        {
            monthDescriptor = new MonthDescriptor(date.Year, date.Month);
        }

        // hh:mm
        public TimbratureBuilder(DateTime date, ReadOnlyCollection<IWebElement> rows)
        {
            monthDescriptor = new MonthDescriptor(date.Year, date.Month);

            for (int i = 0; i < rows.Count; i++)
            {
                int day = -1;
                int.TryParse(rows[i].Text.Split(' ')[0], out day); // get day of the month.

                int entrata = GetEntrata(rows[i]);
                int uscita = GetUscita(rows[i]);
                int ritardo = GetRitardoPranzo(rows[i]);

                int giustificativi = GetGiustificativi(rows[i]);

                monthDescriptor.SetEntrateUscite(day, entrata, uscita);
                monthDescriptor.AddRitardoPranzo(day, ritardo);
                monthDescriptor.SetGiustificativi(day, giustificativi);
            }
        }

        private int GetEntrata(IWebElement element)
        {
            try
            {
                var a = element.FindElements(By.XPath(entrataXPath));
                return Utils.StringToMinutes(a[0].Text);
            }
            catch
            {
                return 0;
            }
        }

        private int GetUscita(IWebElement element)
        {
            try
            {
                var a = element.FindElements(By.XPath(uscitaXPath));
                int num = a.Count;

                return Utils.StringToMinutes(a[num - 1].Text);
            }
            catch
            {
                return 0;
            }
        }

        private int GetRitardoPranzo(IWebElement element)
        {
            try
            {
                var entrate = element.FindElements(By.XPath(entrataXPath));
                var uscite = element.FindElements(By.XPath(uscitaXPath));

                int totalRitardo = 0;

                if(entrate.Count > 1 && uscite.Count > 1)
                {
                    int entrataRitardo = Utils.StringToMinutes(uscite[0].Text);

                    totalRitardo += Math.Max(0, entrataRitardo - 14 * 60 + 15); 

                }
                else if(entrate.Count > 1 && uscite.Count == 1)
                {
                    int entrataRitardo = Utils.StringToMinutes(entrate[1].Text);

                    totalRitardo += Math.Max(0, entrataRitardo - 14 * 60 + 15);
                }

                return totalRitardo;
            }
            catch
            {
                return 0;
            }
        }

        private int GetGiustificativi(IWebElement element)
        {
            String[] SplitString = new String[] { "\r\n" };
            List<String> splitted = element.Text.Split(SplitString, StringSplitOptions.RemoveEmptyEntries).ToList();

            int giustificativi = 0;

            for(int i = 0; i < splitted.Count; i++)
            {
                if (splitted[i].StartsWith("Ferie", StringComparison.CurrentCultureIgnoreCase)
                    || splitted[i].StartsWith("rol", StringComparison.CurrentCultureIgnoreCase))
                {
                    List<String> giustificativiSplit = splitted[i].Split(' ').ToList();
                    if(giustificativiSplit.Count == 1)
                    {
                        giustificativi = 8 * 60; // complete working day
                        break;
                    }
                    else if(giustificativiSplit.Count > 1)
                    {
                        int entrata = 0;
                        int uscita = 0;
                        foreach(string current in giustificativiSplit)
                        {
                            int parsedValue = Utils.StringToMinutes(current);

                            if(parsedValue > 0)
                            {
                                if(entrata == 0)
                                {
                                    entrata = parsedValue;
                                }
                                else
                                {
                                    uscita = parsedValue;
                                }
                            }
                        }

                        if(entrata > 0 && uscita > 0)
                        {
                            giustificativi += uscita - entrata;
                        }
                    }
                }
                else if (splitted[i].StartsWith("Trasferta Estero", StringComparison.CurrentCultureIgnoreCase))
                {
                    giustificativi = 8 * 60;
                    break;
                }
            }

            return giustificativi;
        }

        public int ComputeCurrentWeek()
        {
            int totalWorkedHour = 0;
            int startIndex = Utils.GetFirstDayOfWeek(DateTime.Now) - 1;
            int endIndex = startIndex + 5;

            for(int i = startIndex; i <= endIndex; i++) // todo. might be between 2 months.
            {
                if(ShouldConsiderCurrentDayAsWorkDay(i))
                {
                    totalWorkedHour += monthDescriptor.Days[i].ActualWorked;
                }
            }

            return totalWorkedHour - WEEKLY_HOURS * 60;
        }

        private bool ShouldConsiderCurrentDayAsWorkDay(int day)
        {
            return monthDescriptor.Days.Count >= day && (monthDescriptor.Days[day].Day != DayOfWeek.Saturday && monthDescriptor.Days[day].Day != DayOfWeek.Sunday);
        }

        public void UpdateTimbrature(int day, int entrata, int uscita)
        {
            monthDescriptor.SetEntrateUscite(day, entrata, uscita);
        }
    }
}
