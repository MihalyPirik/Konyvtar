using Konyvtar.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for KonyvekLista.xaml
    /// </summary>
    public partial class KonyvekLista : Page
    {
        KonyvtarContext context = new KonyvtarContext();
        public ObservableCollection<Konyv> konyvek { get; set; }
        public KonyvekLista()
        {
            InitializeComponent();
            this.DataContext = context;
            context.Konyv.Load();
            context.Tipus.Load();
            context.Szerzo.Load();
            SetTipusok();
            SetSzerzok();
            konyvek = context.Konyv.Local.ToObservableCollection();
            konyvLista_DG.ItemsSource = konyvek;
        }

        private void SetTipusok()
        {
            ObservableCollection<Tipus> tipusok = context.Tipus.Local.ToObservableCollection();
            tipusok.Insert(0, new Tipus
            {
                TipusID = 0,
                Nev = ""
            });
            kategoria_CBX.ItemsSource = tipusok;
        }

        private void SetSzerzok()
        {
            ObservableCollection<Szerzo> szerzok = context.Szerzo.Local.ToObservableCollection();
            szerzok.Insert(0, new Szerzo
            {
                szerzoID = 0,
                Keresztnev = "",
                Vezeteknev = ""
            });
            szerzok_CBX.ItemsSource = szerzok;
        }

        private void keres_BTN_Click(object sender, RoutedEventArgs e)
        {
            var lista = konyvek.Where(x => x.Cim.Substring(0, cim_TXB.Text.Length).ToLower() == cim_TXB.Text.ToLower() && x.Szerzo.TeljesNev.Contains(((Szerzo)szerzok_CBX.SelectedItem).TeljesNev) && x.Tipus.Nev.Contains(((Tipus)kategoria_CBX.SelectedItem).Nev)).ToList();
            konyvLista_DG.ItemsSource = lista;
        }
    }
}
