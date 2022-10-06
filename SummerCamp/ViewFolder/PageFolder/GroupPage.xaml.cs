using SummerCamp.Content;
using SummerCamp.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 60;
            doubleAnimation.To = 0;
            doubleAnimation.EasingFunction = new QuadraticEase();
            doubleAnimation.Duration = TimeSpan.FromSeconds(5);
            NameGroupString = Convert.ToString(NameGroupTextBox.Text);
            SpecializationGroupString = Convert.ToString(SpecializationGroupComboBox.Text);
            if (AppConnectDataBase.DataBase.GroupTables.Count
                (data => data.NameGroup == NameGroupString) > 0)
            {
                InfoBorder.BeginAnimation(HeightProperty, doubleAnimation);
                InfoBorder.Visibility = Visibility.Visible;
                InfoTextBlock.Text = "ДАННАЯ ГРУППА УЖЕ СУЩЕСТВУЕТ";
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
                    InfoBorder.BeginAnimation(HeightProperty, doubleAnimation);
                    InfoBorder.Visibility = Visibility.Visible;
                    InfoTextBlock.Text = "ДАННЫЕ УСПЕШНО ДОБАВЛЕННЫ";
                    NewGroupBorder.Visibility = Visibility.Collapsed;
                    NewGRroupButton.Visibility = Visibility.Visible;
                    GroupListListBox.Visibility = Visibility.Visible;
                    NameGroupTextBox.Text = null;
                    SpecializationGroupComboBox.Text = null;
                }
                catch
                {
                    InfoBorder.BeginAnimation(HeightProperty, doubleAnimation);
                    InfoBorder.Visibility = Visibility.Visible;
                    InfoTextBlock.Text = "ЗАПОЛНЕТЕ ПОЛЯ";
                }
            }
        }
    }
}
