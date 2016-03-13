using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace pills_reminder.SN
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(PassBoxP.Password!=PassBoxPAg.Password)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            
            MD5 md = new MD5CryptoServiceProvider();
            byte[] bt = Encoding.UTF8.GetBytes(PassBoxP.Password);

            using (PillsReminderEntities rem = new PillsReminderEntities())
            {
                
                if (rem.Users.Select(t => t.Login == TextBoxName.Text).FirstOrDefault())
                {
                    MessageBox.Show("Такое имя уже занято");
                    return;
                }

                User p = new User()
                {
                    Login = TextBoxName.Text,
                    Password = bt
                };
                rem.Users.Add(p);
                rem.SaveChanges();
            }

            this.Close();
        }
    }
}
