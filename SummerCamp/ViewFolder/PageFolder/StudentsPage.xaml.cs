using SummerCamp.Content;
using SummerCamp.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                MessageBox.Show("ДАННЫЙ СТУДЕНТ УЖЕ СУЩЕСТВУЕТ В БАЗЕ ДАНЫХ");
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
                    MessageBox.Show("УСПЕШНО СОХРАНЕНО");
                    NewStudentsBorder.Visibility = Visibility.Collapsed;
                    NewStudentsButton.Visibility = Visibility.Visible;
                    StudentsListListBox.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "");
                }
            }
        }
    }
}
