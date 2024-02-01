using Konyvtar.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class KonyvPage : Page, INotifyPropertyChanged
    {
        KonyvtarContext context = new KonyvtarContext();

        private Konyv kivKonyv;

        public Konyv KivKonyv
        {
            get { return kivKonyv; }
            set { kivKonyv = value; OnPropertyChanged("KivKonyv"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string tulajdonsagNev)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNev));
        }

        public KonyvPage()
        {
            InitializeComponent();
            this.DataContext = this;
            context.Szerzo.Load();
            context.Konyv.Load();
            context.Tipus.Load();
            szerzok_CBX.ItemsSource = context.Szerzo.Local.ToObservableCollection();
            tipus_CBX.ItemsSource = context.Tipus.Local.ToObservableCollection();
        }

        private void szerzok_CBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lista = context.Konyv.Local.ToObservableCollection().Where(x => x.Szerzo.TeljesNev == ((Szerzo)szerzok_CBX.SelectedItem).TeljesNev);
            konyvek_LB.ItemsSource = lista;
        }

        private void uj_BTN_Click(object sender, RoutedEventArgs e)
        {
            konyv_SP.IsEnabled = true;
            konyv_SP.DataContext = new Konyv()
            {
                Szerzo = (Szerzo)szerzok_CBX.SelectedItem
            };
        }

        private void modosit_BTN_Click(object sender, RoutedEventArgs e)
        {
            konyv_SP.DataContext = (Konyv)konyvek_LB.SelectedItem;
            konyv_SP.IsEnabled = true;
        }

        private void mentes_BTN_Click(object sender, RoutedEventArgs e)
        {
            Konyv k = (Konyv)konyv_SP.DataContext;
            if (k.KonyvID == 0)
            {
                if (!String.IsNullOrWhiteSpace(nev_TXB.Text) && tipus_CBX.SelectedItem != null)
                {
                    context.Konyv.Add(k);
                }
                else
                {
                    MessageBox.Show("A könyv címét és típúsát kötelező megadni!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                context.Entry(k).State = EntityState.Modified;
            }
            context.SaveChanges();
            konyv_SP.IsEnabled = false;
            konyvek_LB.Items.Refresh();
        }

        private void megse_BTN_Click(object sender, RoutedEventArgs e)
        {
            Konyv k = (Konyv)konyvLista_SP.DataContext;
            if (k.KonyvID != 0)
            {
                context.Entry(k).State = EntityState.Unchanged;
                konyvek_LB.Items.Refresh();
            }
            konyv_SP.IsEnabled = false;
            konyvek_LB.SelectedItem = null;
            konyvLista_SP.DataContext = null;
        }
    }
}
