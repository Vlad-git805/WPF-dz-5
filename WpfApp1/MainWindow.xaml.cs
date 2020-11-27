using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Phone> group = new ObservableCollection<Phone>();
        public MainWindow()
        {
            InitializeComponent();
            list.Items.Clear();
            list.ItemsSource = group; 
            list.DisplayMemberPath = nameof(Phone.FullInfo);
        }

        private bool check_number()
        {
            for (int i = 0; i < textboxPhone.Text.Length; i++)
            {
                if (textboxPhone.Text[i] < 48 || textboxPhone.Text[i] > 57)
                {
                    if (textboxPhone.Text[i] != '+')
                        return false;
                }
            }
            return true;
        }

        private bool check_age()
        {
            for (int i = 0; i < textboxAge.Text.Length; i++)
            {
                if (textboxAge.Text[i] < 48 || textboxAge.Text[i] > 57)
                {
                    return false;
                }
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text != "" && textboxSurName.Text != "" && textboxAge.Text != "" && textboxPhone.Text != "")
            {
                if (check_age() == false)
                    return;
                if (check_number() == false)
                    return;
                group.Add(new Phone() { Name = textboxName.Text.ToString(), SurName = textboxSurName.Text.ToString(), Age = int.Parse(textboxAge.Text), Phon = textboxPhone.Text.ToString()});
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(list.SelectedIndex != -1)
                group.RemoveAt(list.SelectedIndex);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text != "" && textboxSurName.Text != "" && textboxAge.Text != "" && textboxPhone.Text != "" && check_age() == true && check_number())
            {
                group[list.SelectedIndex].Name = textboxName.Text;
                group[list.SelectedIndex].SurName = textboxSurName.Text;
                group[list.SelectedIndex].Age = int.Parse(textboxAge.Text);
                group[list.SelectedIndex].Phon = textboxPhone.Text;
            }
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedIndex != -1)
            {
                Phone ph = (list.SelectedItem as Phone);
                textboxName.Text = ph.Name;
                textboxSurName.Text = ph.SurName;
                textboxAge.Text = ph.Age.ToString();
                textboxPhone.Text = ph.Phon;
            }
        }
    }
}
