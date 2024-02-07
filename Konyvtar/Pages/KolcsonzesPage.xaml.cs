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
    /// Interaction logic for Kolcsonzes.xaml
    /// </summary>
    public partial class KolcsonzesPage : Page
    {
        KonyvtarContext context = new KonyvtarContext();
        public KolcsonzesPage()
        {
            InitializeComponent();
            context.Konyv.Load();
            context.Kolcsonzes.Load();
            context.Tanulo.Load();
            context.Szerzo.Load();
            List<string> osztalyok = context.Tanulo.Local.Select(x => x.Osztaly).Distinct().ToList();
            osztalyok.Insert(0, "");
            osztalyok_CBX.ItemsSource = osztalyok;
            szerzok_CBX.ItemsSource = context.Szerzo.Local.ToObservableCollection();
        }

        private void osztalyok_CBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Keres(osztalyok_CBX.SelectedItem.ToString(), kereses_TXB.Text);
        }

        private void kereses_TXB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Keres(osztalyok_CBX.SelectedItem.ToString(), kereses_TXB.Text);
        }

        public void Keres(string osztaly, string szoveg)
        {
            List<Tanulo> tanulok = context.Tanulo.Where(x => x.Osztaly.Contains(osztaly) && (x.Keresztnev.ToLower() + " " + x.Vezeteknev.ToLower()).StartsWith(szoveg.ToLower())).ToList();
            tanulok_LB.ItemsSource = tanulok;
        }

        private void tanulok_LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tanulo t = (Tanulo)tanulok_LB.SelectedItem;
            if (t != null)
            {
                List<Kolcsonzes> kolcsonzesek = context.Kolcsonzes.Local.Where(x => x.TanuloID == t.TanuloID).ToList();
                kolcsonzottKonyvek_LB.ItemsSource = kolcsonzesek;
            }
        }

        private void visszahoz_BTN_Click(object sender, RoutedEventArgs e)
        {
            Kolcsonzes k = (Kolcsonzes)kolcsonzottKonyvek_LB.SelectedItem;
            if (k != null)
            {
                k.Visszahozta = true;
                context.SaveChanges();
                kolcsonzottKonyvek_LB.ItemsSource = context.Kolcsonzes.Local.ToObservableCollection();
            }
        }

        private void szerzok_CBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Konyv> konyvek = context.Konyv.Local.Where(x => x.Szerzo.TeljesNev == ((Szerzo)szerzok_CBX.SelectedItem).TeljesNev).ToList();
            konyvek_LB.ItemsSource = konyvek;
        }

        private void kolcsonzes_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (tanulok_LB.SelectedItem != null)
            {
                if (konyvek_LB.SelectedItem != null)
                {
                    if (kiadva_DP.SelectedDate != null && kiadva_DP.SelectedDate > DateTime.Now)
                    {
                        Kolcsonzes k = new Kolcsonzes()
                        {
                            Tanulo = (Tanulo)tanulok_LB.SelectedItem,
                            Konyv = (Konyv)konyvek_LB.SelectedItem,
                            Elvitel = DateTime.Now,
                            Visszahozas = (DateTime)kiadva_DP.SelectedDate
                        };
                        context.Kolcsonzes.Add(k);
                        context.SaveChanges();
                        kolcsonzottKonyvek_LB.ItemsSource = context.Kolcsonzes.Local.ToObservableCollection();
                    }
                    else
                    {
                        MessageBox.Show("A visszahozás dátumának nagyobbnak kell lennie az aktuális dátumnál!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Könyv kiválasztása kötelező!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Tanuló kiválasztása kötelező!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
