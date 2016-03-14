using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pills_reminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer tm;
        DataTable drugsInfo { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DrugInfo di = new DrugInfo(new Drug()
            {
                DrugName = "lala",
                Dose = "50",
                AddInf = "gfsdjgkdfngsdfglksdfngosdnfgjdfgjsdflgsdfkgnsdofg"
            });
            di.Show();
            DrTableCreate();
            var drugs = GetFullDrList();
            TableToDGBinding(drugs);
            DGInfo.ItemsSource = drugsInfo.AsDataView();
            tm = new Timer();
        }

        void DrTableCreate()
        {
            drugsInfo = new DataTable();
            drugsInfo.Columns.Add("Название");
            drugsInfo.Columns.Add("Время", typeof(TimeSpan));
            drugsInfo.Columns.Add("От", typeof(DateTime));
            drugsInfo.Columns.Add("До", typeof(DateTime));
        }

        IQueryable<WeekIntake> GetFullDrList()
        {
            PillsReminderEntities pl=new PillsReminderEntities();
            var d = pl.WeekIntakes.Where(p => p.User.Id == App.curPnID);
            return d;
        }

        void TableToDGBinding(IQueryable<WeekIntake> dr)
        {
            drugsInfo.Rows.Clear();
            using(PillsReminderEntities plsr=new PillsReminderEntities())
	        {
             foreach (var item in dr)
                {
                    DataRow row = drugsInfo.NewRow();
                    row[0] = item.Drug.DrugName;
                    row[1] = item.Time;
                    var tm=plsr.IntakeDurations.Where(p=>p.Id_person==App.curPnID&&p.Id_drug==item.Id_drug);
                    foreach (var it in tm)
                    {
                      row[2] = it.DateFrom;
                      row[3] = it.DateTo;  
                    }
                    drugsInfo.Rows.Add(row);
                }

	        }
                
        }
    }
}
