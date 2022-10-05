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
            MainListButton.FontWeight = FontWeights.Bold;
            MainListButton.Foreground = new SolidColorBrush(Color.FromRgb(215, 35, 35));

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
            MainListButton.FontWeight = FontWeights.Bold;
            MainListButton.Foreground = new SolidColorBrush(Color.FromRgb(215, 35, 35));
            StudentsListButton.FontWeight = FontWeights.Normal;
            StudentsListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            GroupListButton.FontWeight = FontWeights.Normal;
            GroupListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            CompetitionListBitton.FontWeight = FontWeights.Normal;
            CompetitionListBitton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            TapeListButton.FontWeight = FontWeights.Normal;
            TapeListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
        }

        private void StudentsListButton_Click(object sender, RoutedEventArgs e)
        {
            MainListButton.FontWeight = FontWeights.Normal;
            MainListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            StudentsListButton.FontWeight = FontWeights.Bold;
            StudentsListButton.Foreground = new SolidColorBrush(Color.FromRgb(215, 35, 35));
            GroupListButton.FontWeight = FontWeights.Normal;
            GroupListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            CompetitionListBitton.FontWeight = FontWeights.Normal;
            CompetitionListBitton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            TapeListButton.FontWeight = FontWeights.Normal;
            TapeListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
        }

        private void GroupListButton_Click(object sender, RoutedEventArgs e)
        {
            MainListButton.FontWeight = FontWeights.Normal;
            MainListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            StudentsListButton.FontWeight = FontWeights.Normal;
            StudentsListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            GroupListButton.FontWeight = FontWeights.Bold;
            GroupListButton.Foreground = new SolidColorBrush(Color.FromRgb(215, 35, 35));
            CompetitionListBitton.FontWeight = FontWeights.Normal;
            CompetitionListBitton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            TapeListButton.FontWeight = FontWeights.Normal;
            TapeListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
        }

        private void CompetitionListBitton_Click(object sender, RoutedEventArgs e)
        {
            MainListButton.FontWeight = FontWeights.Normal;
            MainListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            StudentsListButton.FontWeight = FontWeights.Normal;
            StudentsListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            GroupListButton.FontWeight = FontWeights.Normal;
            GroupListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            CompetitionListBitton.FontWeight = FontWeights.Bold;
            CompetitionListBitton.Foreground = new SolidColorBrush(Color.FromRgb(215, 35, 35));
            TapeListButton.FontWeight = FontWeights.Normal;
            TapeListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
        }

        private void TapeListButton_Click(object sender, RoutedEventArgs e)
        {
            MainListButton.FontWeight = FontWeights.Normal;
            MainListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            StudentsListButton.FontWeight = FontWeights.Normal;
            StudentsListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            GroupListButton.FontWeight = FontWeights.Normal;
            GroupListButton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            CompetitionListBitton.FontWeight = FontWeights.Normal;
            CompetitionListBitton.Foreground = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            TapeListButton.FontWeight = FontWeights.Bold;
            TapeListButton.Foreground = new SolidColorBrush(Color.FromRgb(215, 35, 35));
        }
    }
}
