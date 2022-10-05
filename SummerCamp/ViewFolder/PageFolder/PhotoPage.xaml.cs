using SummerCamp.Content;
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
    public partial class PhotoPage : Page
    {
        public PhotoPage()
        {
            InitializeComponent();
            AppConnectDataBase.DataBase = new ModelFolder.SummerCampDataBaseEntities();
            PhotoListListBox.ItemsSource = AppConnectDataBase.DataBase.PhotoPageTable.ToList();
        }
    }
}
