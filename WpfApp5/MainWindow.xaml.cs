using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users;
        public MainWindow()
        {
            InitializeComponent();
            users = new ObservableCollection<User>(){
                new User() { id =1, Name = "Сашко", Age = 12,  Phone_number = "249524952" },
                new User() {id =1, Name = "Міша", Age = 39, Phone_number = "512452184" },
                new User() { id =1,Name = "Роман", Age = 71, Phone_number = "258484632" },
                new User() {id =1, Name = "Діма", Age = 31, Phone_number = "9595693243245" },
                new User() {id =1, Name = "Андрій", Age = 21, Phone_number = "4895959523555" },
                new User() {id =1,  Name ="Коля", Age = 51, Phone_number = "595959534535" }
            };
            lvUsers.ItemsSource = users;
        }
        public class User
        {
            private int ID;
            static int id_count = 0;
            public string Name { get; set; }

            public int Age { get; set; }

            public int id { get { return ID; } set { ID = id_count++; } }

            public string Phone_number { get; set; }

            public string PersonName
            {
                get { return Name; }
                set
                {
                    Name = value;
                    OnPropertyChanged("PersonName");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName] string prop = "")
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = Name_text.Text, Age = Convert.ToInt32( Age_text.Text), Phone_number = Phone_text.Text });
            Name_text.Text = string.Empty;
            Age_text.Text = string.Empty;
            Phone_text.Text = string.Empty;
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (deleteIDtext.Text != string.Empty)
            {
                var deleteusers = (from s in users
                                   where s.id == Convert.ToInt32(deleteIDtext.Text)
                                   select s).FirstOrDefault();
                users.Remove(deleteusers);
                deleteIDtext.Text = string.Empty;
            }
        }
    }
}
