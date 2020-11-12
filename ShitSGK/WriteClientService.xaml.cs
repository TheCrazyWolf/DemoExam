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

namespace ShitSGK
{
    /// <summary>
    /// Логика взаимодействия для WriteClientService.xaml
    /// </summary>
    public partial class WriteClientService : Window
    {
        public WriteClientService()
        {
            InitializeComponent();
            Database.masterEntities entities = new Database.masterEntities();

            cbClients.ItemsSource = entities.Client.ToList();
            cbService.ItemsSource = entities.Client.ToList();

        }
    }
}
