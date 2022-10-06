using SummerCamp.Content;
using SummerCamp.ModelFolder;
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

namespace SummerCamp.ViewFolder.PageFolder
{
    public partial class GroupPage : Page
    {
        public GroupPage()
        {
            InitializeComponent();
            AppConnectDataBase.DataBase = new ModelFolder.SummerCampDataBaseEntities();
            GroupListListBox.ItemsSource = AppConnectDataBase.DataBase.GroupTables.ToList();
            SpecializationGroupComboBox.ItemsSource = AppConnectDataBase.DataBase.GroupTables.ToList();
        }

        private void NewGRroupButton_Click(object sender, RoutedEventArgs e)
        {
            NewGroupBorder.Visibility = Visibility.Visible;
            NewGRroupButton.Visibility = Visibility.Collapsed;
            GroupListListBox.Visibility = Visibility.Collapsed;
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            string NameGroupString, SpecializationGroupString;
            NameGroupString = Convert.ToString(NameGroupTextBox.Text);
            SpecializationGroupString = Convert.ToString(SpecializationGroupComboBox.Text);
            if (AppConnectDataBase.DataBase.GroupTables.Count
                (data => data.NameGroup == NameGroupString) > 0)
            {
                MessageBox.Show("ДАННАЯ ГРУППА УЖЕ СУЩЕСТВУЕТ");
            }
            else
            {
                try
                {
                    GroupTables groupTables = new GroupTables()
                    {
                        NameGroup = NameGroupString,
                        NameSpecialization = SpecializationGroupString
                    };
                    AppConnectDataBase.DataBase.GroupTables.Add(groupTables);
                    AppConnectDataBase.DataBase.SaveChanges();
                    MessageBox.Show("ДАННЫЕ УСПЕШНО ДОБАВЛЕННЫ");
                    NewGroupBorder.Visibility = Visibility.Collapsed;
                    NewGRroupButton.Visibility = Visibility.Visible;
                    GroupListListBox.Visibility = Visibility.Visible;
                    NameGroupTextBox.Text = null;
                    SpecializationGroupComboBox.Text = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }
    }
}
