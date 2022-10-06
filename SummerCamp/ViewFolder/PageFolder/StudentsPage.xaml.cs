using SummerCamp.Content;
using SummerCamp.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SummerCamp.ViewFolder.PageFolder
{
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
            AppConnectDataBase.DataBase = new ModelFolder.SummerCampDataBaseEntities();
            StudentsListListBox.ItemsSource = AppConnectDataBase.DataBase.StudentsTables.ToList();
            GroupStudentsComboBox.ItemsSource = AppConnectDataBase.DataBase.GroupTables.ToList();
            CompetitionStudentsComboBox.ItemsSource = AppConnectDataBase.DataBase.CompetitionTables.ToList();
        }

        private void NewStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            NewStudentsBorder.Visibility = Visibility.Visible;
            NewStudentsButton.Visibility = Visibility.Collapsed;
            StudentsListListBox.Visibility = Visibility.Collapsed;
        }

        private void AddStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 60;
            doubleAnimation.To = 0;
            doubleAnimation.EasingFunction = new QuadraticEase();
            doubleAnimation.Duration = TimeSpan.FromSeconds(5);
            string SurnameString, NameString, MiddleNameString , NameGroupString, NameCompetitionString;
            decimal ScoresString;
            SurnameString = Convert.ToString(SurnameStudentsTextBox.Text);
            NameString = Convert.ToString(NameStudentsTextBox.Text);
            MiddleNameString = Convert.ToString(MiddleNameStudentsTextBox.Text);
            NameGroupString = Convert.ToString(GroupStudentsComboBox.Text);
            NameCompetitionString = Convert.ToString(CompetitionStudentsComboBox.Text);
            ScoresString = Convert.ToDecimal(ScoresStudentsTextBox.Text);
            if (AppConnectDataBase.DataBase.StudentsTables.Count(
                data => data.SurnameStudents == SurnameString && data.NameStudents == NameString && data.MiddleName == MiddleNameString) > 0)
            {
                InfoBorder.BeginAnimation(HeightProperty, doubleAnimation);
                InfoBorder.Visibility = Visibility.Visible;
                InfoTextBlock.Text = "ДАННЫЙ СТУДЕНТ УЖЕ СУЩЕСТВУЕТ";
            }
            else
            {
                try
                {
                    StudentsTables studentsTables = new StudentsTables()
                    {
                        SurnameStudents = SurnameString,
                        NameStudents = NameString,
                        MiddleName = MiddleNameString,
                        NameGroup = NameGroupString,
                        NameCompetition = NameCompetitionString,
                        Scores = ScoresString
                    };
                    AppConnectDataBase.DataBase.StudentsTables.Add(studentsTables);
                    AppConnectDataBase.DataBase.SaveChanges();
                    SurnameStudentsTextBox.Text = null;
                    NameStudentsTextBox.Text = null;
                    MiddleNameStudentsTextBox.Text = null;
                    GroupStudentsComboBox.Text = null;
                    CompetitionStudentsComboBox.Text = null;
                    ScoresStudentsTextBox.Text = null;
                    InfoBorder.BeginAnimation(HeightProperty, doubleAnimation);
                    InfoBorder.Visibility = Visibility.Visible;
                    InfoTextBlock.Text = "ДАННЫЕ УСПЕШНО ДОБАВЛЕННЫ";
                    NewStudentsBorder.Visibility = Visibility.Collapsed;
                    NewStudentsButton.Visibility = Visibility.Visible;
                    StudentsListListBox.Visibility = Visibility.Visible;
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
