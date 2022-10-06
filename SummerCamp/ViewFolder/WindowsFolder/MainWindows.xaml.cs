using SummerCamp.ViewFolder.PageFolder;
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

namespace SummerCamp.ViewFolder.WindowsFolder
{
    public partial class MainWindows : Window
    {
        public MainWindows()
        {
            InitializeComponent();
            MainFrame.Navigate(new PhotoPage());
            MainListButton.IsChecked = true;


        }
        #region WindowsEddit
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        #endregion

        private void MainListButton_Click(object sender, RoutedEventArgs e)
        {
            StudentsListButton.IsChecked = false;
            GroupListButton.IsChecked = false;
            CompetitionListBitton.IsChecked = false;
            TapeListButton.IsChecked = false;
            MainFrame.Navigate(new PhotoPage());
        }

        private void StudentsListButton_Click(object sender, RoutedEventArgs e)
        {
            MainListButton.IsChecked = false;
            GroupListButton.IsChecked = false;
            CompetitionListBitton.IsChecked = false;
            TapeListButton.IsChecked = false;
            MainFrame.Navigate(new StudentsPage());
        }

        private void GroupListButton_Click(object sender, RoutedEventArgs e)
        {
            MainListButton.IsChecked = false;
            StudentsListButton.IsChecked = false;
            CompetitionListBitton.IsChecked = false;
            TapeListButton.IsChecked = false;
            MainFrame.Navigate(new GroupPage());
        }

        private void CompetitionListBitton_Click(object sender, RoutedEventArgs e)
        {
            MainListButton.IsChecked = false;
            StudentsListButton.IsChecked = false;
            GroupListButton.IsChecked = false;
            TapeListButton.IsChecked = false;
            MainFrame.Navigate(new CompetitionPage());
        }

        private void TapeListButton_Click(object sender, RoutedEventArgs e)
        {
            MainListButton.IsChecked = false;
            StudentsListButton.IsChecked = false;
            GroupListButton.IsChecked = false;
            CompetitionListBitton.IsChecked = false;
            //MainFrame.Navigate(new ());
        }
    }
}
