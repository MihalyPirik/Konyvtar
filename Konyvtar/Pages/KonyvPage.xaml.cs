using Konyvtar.Model;
using Microsoft.EntityFrameworkCore;
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

namespace Konyvtar.Pages
{
    /// <summary>
    /// Interaction logic for Konyv.xaml
    /// </summary>
    public partial class KonyvPage : Page
    {
        KonyvtarContext context = new KonyvtarContext();
        public KonyvPage()
        {
            InitializeComponent();
            context.Szerzo.Load();
            context.Konyv.Load();
            szerzok_CBX.ItemsSource = context.Szerzo.Local.ToObservableCollection();


        }

        private void szerzok_CBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lista = context.Konyv.Local.ToObservableCollection().Where(x => x.Szerzo.TeljesNev == ((Szerzo)szerzok_CBX.SelectedItem).TeljesNev).ToList();
        }
    }
}
