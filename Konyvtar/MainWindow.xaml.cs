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
using Konyvtar.Pages;

namespace Konyvtar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void konyvLista_M_Click(object sender, RoutedEventArgs e)
        {
            nyito_FRM.Content = new KonyvekLista();
        }

        private void konyv_M_Click(object sender, RoutedEventArgs e)
        {
            nyito_FRM.Content = new KonyvPage();
        }

        private void kolcsonzes_M_Click(object sender, RoutedEventArgs e)
        {
            nyito_FRM.Content = new KolcsonzesPage();
        }
    }
}
