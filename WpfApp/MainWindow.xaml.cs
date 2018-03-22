using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
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


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GetAccess get;
        private AddAccess add;
        private UpdateAccess update;
        private DeleteAccess delete;
        public MainWindow()
        {
            get = new GetAccess();
            add = new AddAccess();
            update = new UpdateAccess();
            delete = new DeleteAccess();

            InitializeComponent();
            PopuniComboBoxTabele();
        }

        #region PopuniComboBoxTabele
        private void PopuniComboBoxTabele()
        {
            CBTabela.Items.Add("Autobuska stanica");
            CBTabela.Items.Add("Autobus");
            CBTabela.Items.Add("Vozac");
            CBTabela.Items.Add("Radnik");
            CBTabela.Items.Add("Prodavac");
        }
        #endregion

        #region CBTabela_SelectionChanged
        private void CBTabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CBTabela.SelectedItem)
            {
                case "Autobuska stanica":
                    DataGrid.ItemsSource = get.GetAllAutobuskaStanica();
                    break;
                case "Autobus":
                    DataGrid.ItemsSource = get.GetAllAutobus();
                    break;
                case "Vozac":
                    DataGrid.ItemsSource = get.GetAllVozac();
                    break;
                case "Radnik":
                    DataGrid.ItemsSource = get.GetAllRadnik();
                    break;
                case "Prodavac":
                    DataGrid.ItemsSource = get.GetAllProdavac();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Add
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (CBTabela.SelectedItem)
                {
                    case "Autobuska stanica":
                        var stanica = (autobuska_stanica)DataGrid.SelectedItem;
                        add.AddStanica(stanica.idstanice, stanica.ime, stanica.grad, stanica.ulica);
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllAutobuskaStanica();
                        break;

                    case "Autobus":
                        var autobus = (autobu)DataGrid.SelectedItem;
                        add.AddAutobus(autobus.brtablica, autobus.brojmesta, autobus.ispravan, autobus.marka, autobus.kilometri?? default(int));
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllAutobus();
                        break;

                    case "Vozac":
                        var vozac = (vozac)DataGrid.SelectedItem;
                        add.AddVozac(vozac.jmbg, vozac.brojvoznihlinija);
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllVozac();
                        break;

                    case "Radnik":
                        var radnik = (radnik)DataGrid.SelectedItem;
                        add.AddRadnik(radnik.autobuska_stanica_idstanice, radnik.ime, radnik.prezime, radnik.jmbg);
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllRadnik();
                        break;

                    case "Prodavac":
                        var prodavac = (prodavac)DataGrid.SelectedItem;
                        add.AddProdavac(prodavac.jmbg, prodavac.brojsaltera);
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllProdavac();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Niste uneli dobre podatke", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Remove
        private void BRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (CBTabela.SelectedItem)
                {
                    case "Autobuska stanica":
                        var stanica = (autobuska_stanica)DataGrid.SelectedItem;
                        delete.DeleteAutobuskaStanica(stanica);
                        MessageBox.Show("Obrisano!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllAutobuskaStanica();
                        break;

                    case "Autobus":
                        var autobus = (autobu)DataGrid.SelectedItem;
                        delete.DeleteAutobus(autobus);
                        MessageBox.Show("Obrisano!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllAutobus();
                        break;

                    case "Vozac":
                        var vozac = (vozac)DataGrid.SelectedItem;
                        delete.DeleteVozac(get.GetRadnikByJmbg(vozac.jmbg));
                        MessageBox.Show("Obrisano!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllVozac();
                        break;

                    case "Radnik":
                        var radnik = (radnik)DataGrid.SelectedItem;
                        delete.DeleteRadnik(radnik);
                        MessageBox.Show("Obrisano!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllRadnik();
                        break;

                    case "Prodavac":
                        var prodavac = (prodavac)DataGrid.SelectedItem;
                        delete.DeleteProdavac(get.GetRadnikByJmbg(prodavac.jmbg));
                        MessageBox.Show("Obrisano!", "Oops", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllProdavac();
                        break;

                    default:
                        break;
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Podatak ne moze da se obrise, zato sto postoji drugi podatak u tabeli koji zavisi njega", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom brisanja polja", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        #endregion

        #region Update
        private void BUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (CBTabela.SelectedItem)
                {
                    case "Autobuska stanica":
                        var stanica = (autobuska_stanica)DataGrid.SelectedItem;
                        update.UpdateAutobuskaStanica(stanica.idstanice, stanica.ime, stanica.grad, stanica.ulica);
                        MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllAutobuskaStanica();
                        break;

                    case "Autobus":
                        var autobus = (autobu)DataGrid.SelectedItem;
                        update.UpdateAutobus(autobus.brtablica, autobus.brojmesta, autobus.ispravan, autobus.marka, autobus.kilometri ?? default(int));
                        MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllAutobus();
                        break;

                    case "Vozac":
                        var vozac = (vozac)DataGrid.SelectedItem;
                        update.UpdateVozac(vozac.jmbg, vozac.brojvoznihlinija);
                        MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllVozac();
                        break;

                    case "Radnik":
                        var radnik = (radnik)DataGrid.SelectedItem;
                        update.UpdateRadnik(radnik.jmbg, radnik.autobuska_stanica_idstanice, radnik.ime, radnik.prezime);
                        MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllRadnik();
                        break;

                    case "Prodavac":
                        var prodavac = (prodavac)DataGrid.SelectedItem;
                        update.UpdateProdavac(prodavac.jmbg, prodavac.brojsaltera);
                        MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid.ItemsSource = get.GetAllProdavac();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Doslo je do greske prilikom izmene polja", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        private void BIzracunajBrojRadnika_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbBroj.Text))
            {
                MessageBox.Show("Niste uneli id stanice za koju hocete da izracunate ukupan broj radnika", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
                TbBroj.Focus();
                return;
            }

            using(var db = new AutobuskaStanicaEntities())
            {
                //var broj = db.get_radnik_count[int.Parse(TbBroj.Text)];
            }
            //var rezultati = new RezultatiFunkcije(int.Parse(TbBroj.Text), broj);
            //DataGrid.ItemSource = rezultati;
        }
    }
}
