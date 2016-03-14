using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace pills_reminder
{
    class Timer
    {
        
        TimeSpan nextTime;
        Drug curDrug;
        public Timer ()
	    {
            DateTime dt = DateTime.Now;
            TimeSpan curTime = dt.TimeOfDay;
            GetFirstTime(curTime);
           

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
	    }

        void timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            TimeSpan curTime = dt.TimeOfDay;

            if ((int)nextTime.TotalMinutes == (int)curTime.TotalMinutes)
            {
                DrugInfo di = new DrugInfo(curDrug);
                di.Show();
                GetFirstTime(curTime);
            }

        }
        

        void GetFirstTime(TimeSpan curTime)
        {
            using (PillsReminderEntities pls = new PillsReminderEntities())
            {
                var tm = pls.WeekIntakes.Where(p => p.Id_person == App.curPnID);
                TimeSpan temp = new TimeSpan();
                foreach (var item in tm)
                {
                    //Если нет леккарства - 1 запуск
                  if(curDrug==null)
                  {
                      curDrug=item.Drug;
                      nextTime=item.Time;
                  }
                    //время приема наступило
                  if (nextTime.TotalMinutes - curTime.TotalMinutes < 0 && item.Time.TotalMinutes - curTime.TotalMinutes>0)
                  {
                      curDrug = item.Drug;
                      nextTime = item.Time;
                  }

                    //выбор наиближнего лекарства
                  if (item.Time.TotalMinutes - curTime.TotalMinutes < nextTime.TotalMinutes - curTime.TotalMinutes && item.Time.TotalMinutes - curTime.TotalMinutes > 0)
                  {
                      curDrug = item.Drug;
                      nextTime = item.Time;
                  }
                  
                }
            }

        }
       
    }
}
