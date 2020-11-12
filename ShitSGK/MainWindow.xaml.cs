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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShitSGK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerivceController srvcontroller = new SerivceController();
        public MainWindow()
        {
            InitializeComponent();
            lbContent.ItemsSource = srvcontroller.ServiceWs;
            AddOrChangeForm addOrChangeForm = new AddOrChangeForm();
            addOrChangeForm.Show();
        }

        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var s = b.DataContext as ServiceW;
            AddOrChangeForm addOrChangeForm = new EditForm(s);
            if (addOrChangeForm.ShowDialog() == true)
            {
                srvcontroller = new SerivceController();
                lbContent.ItemsSource = srvcontroller.ServiceWs;
            }
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

                MessageBox.Show("Запись удалена");
            }
        }

        private void Btn_Write_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void UpName_Click(object sender, RoutedEventArgs e)
        {
            srvcontroller.ServiceWs = srvcontroller.ServiceWs.OrderBy(x => x.Name).ToList();
            lbContent.ItemsSource = srvcontroller.ServiceWs;
        }
    }
}
