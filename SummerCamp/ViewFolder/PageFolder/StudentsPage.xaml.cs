﻿using SummerCamp.Content;
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
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
            AppConnectDataBase.DataBase = new ModelFolder.SummerCampDataBaseEntities();
            StudentsListListBox.ItemsSource = AppConnectDataBase.DataBase.StudentsTables.ToList();
            GroupComboBox.ItemsSource = AppConnectDataBase.DataBase.GroupTables.ToList();
            CompetitionComboBox.ItemsSource = AppConnectDataBase.DataBase.CompetitionTables.ToList();
        }

        private void NewStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            NewStudentsBorder.Visibility = Visibility.Visible;
            NewStudentsButton.Visibility = Visibility.Collapsed;
            StudentsListListBox.Visibility = Visibility.Collapsed;
        }
    }
}
