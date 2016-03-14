using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace pills_reminder
{
    /// <summary>
    /// Interaction logic for DrugInfo.xaml
    /// </summary>
    public partial class DrugInfo : Window
    {
        
        public DrugInfo(Drug d)
        {
            InitializeComponent();
            
            
            cutTime.Text = DateTime.Now.ToShortTimeString();
            this.DataContext = d;
        }
    }
}
