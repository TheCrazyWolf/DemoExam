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
using System.Data.Entity.Migrations;


namespace ShitSGK
{
    /// <summary>
    /// Логика взаимодействия для AddOrChangeForm.xaml
    /// </summary>
    public partial class AddOrChangeForm : Window
    {
        protected Database.Service newServis;
        public AddOrChangeForm()
        {
            InitializeComponent();
            Title = "Добавить сервис";

            newServis = new Database.Service();
            newServis.MainImagePath = 
                "no-image.png";
            mainGrid.DataContext = newServis as Database.Service;
            btSave.Content = "add";
        }

        protected virtual void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Database.masterEntities entities = new Database.masterEntities();
                newServis = mainGrid.DataContext as Database.Service;

                entities.Service.AddOrUpdate(newServis);
                entities.SaveChanges();
                MessageBox.Show("OK");
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message, "error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    
    public class EditForm : AddOrChangeForm
    {
        public  EditForm (ServiceW serviceW)
        {
            InitializeComponent();
            Database.masterEntities entities = new Database.masterEntities();
            newServis = entities.Service.Find(serviceW.ID);
            mainGrid.DataContext = newServis;
            base.Title = "Редактиравть";
            base.btSave.Content = "Edit";
        }


        protected override void Button_Click(object sender, RoutedEventArgs e)
        {
            base.Button_Click(sender,e);
        }
    }
}
