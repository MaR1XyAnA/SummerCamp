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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SummerCamp.ViewFolder.PageFolder
{
    public partial class CompetitionPage : Page
    {
        public CompetitionPage()
        {
            InitializeComponent();
            CompetitionListListBox.ItemsSource = AppConnectDataBase.DataBase.CompetitionTables.ToList();
            StatusCompetitionComboBox.ItemsSource = AppConnectDataBase.DataBase.StatusTables.ToList();
        }

        private void NewCompetitionButton_Click(object sender, RoutedEventArgs e)
        {
            NewCompetitionBorder.Visibility = Visibility.Visible;
            NewCompetitionButton.Visibility = Visibility.Collapsed;
            CompetitionListListBox.Visibility = Visibility.Collapsed;
        }

        private void AddCompetitionButton_Click(object sender, RoutedEventArgs e)
        {
            string NameCompetitionString, StatusCompetitionString;
            NameCompetitionString = Convert.ToString(NameCompetitionTextBox.Text);
            StatusCompetitionString = Convert.ToString(StatusCompetitionComboBox.Text);
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 60;
            doubleAnimation.To = 0;
            doubleAnimation.EasingFunction = new QuadraticEase();
            doubleAnimation.Duration = TimeSpan.FromSeconds(5);
            if (AppConnectDataBase.DataBase.CompetitionTables.Count
                (data => data.NameCompetition == NameCompetitionString) > 0)
            {
                InfoBorder.BeginAnimation(HeightProperty, doubleAnimation);
                InfoBorder.Visibility = Visibility.Visible;
                InfoTextBlock.Text = "ДАННОЕ СОРЕВНОВАНИЕ УЖЕ СУЩЕСТВУЕТ";
                return;
            }
            else
            {
                try
                {
                    CompetitionTables competitionTables = new CompetitionTables()
                    {
                        NameCompetition = NameCompetitionString,
                        StatusCompetition = StatusCompetitionString
                    };
                    AppConnectDataBase.DataBase.CompetitionTables.Add(competitionTables);
                    AppConnectDataBase.DataBase.SaveChanges();
                    InfoBorder.BeginAnimation(HeightProperty, doubleAnimation);
                    InfoBorder.Visibility = Visibility.Visible;
                    InfoTextBlock.Text = "ДАННЫЕ УСПЕШНО ДОБАВЛЕННЫ";
                    NewCompetitionBorder.Visibility = Visibility.Collapsed;
                    NewCompetitionButton.Visibility = Visibility.Visible;
                    CompetitionListListBox.Visibility = Visibility.Visible;
                    NameCompetitionTextBox.Text = null;
                    StatusCompetitionComboBox.Text = null;
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
