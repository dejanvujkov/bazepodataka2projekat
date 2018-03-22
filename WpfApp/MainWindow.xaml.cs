using DatabaseAccess;
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
            switch (CBTabela.SelectedItem)
            {
                case "Autobuska stanica":
                    var stanica = (autobuska_stanica)DataGrid.SelectedItem;
                    if (get.GetAutobuska_StanicaById(stanica.idstanice) == null)
                    {
                        try
                        {
                            add.AddStanica(stanica.idstanice, stanica.ime, stanica.grad, stanica.ulica);
                            MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Niste uneli dobre podatke", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Takav id vec postoji, izaberite drugi", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Autobus":
                    var autobus = (autobu)DataGrid.SelectedItem;
                    if (get.GetAutobusById(autobus.brtablica) == null)
                    {
                        try
                        {
                            add.AddAutobus(autobus.brtablica, autobus.brojmesta, autobus.ispravan, autobus.marka);
                            MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Niste uneli dobre podatke!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Autobus sa takvim idom vec postoji, izaberite drugi", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Vozac":

                    var vozac = (vozac)DataGrid.SelectedItem;
                    try
                    {
                        add.AddVozac(vozac.jmbg, vozac.brojvoznihlinija);
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Niste uneli dobro polja", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Radnik":
                    var radnik = (radnik)DataGrid.SelectedItem;
                    if (get.GetRadnikByJmbg(radnik.jmbg) == null)
                    {
                        try
                        {
                            add.AddRadnik(radnik.autobuska_stanica_idstanice, radnik.ime, radnik.prezime, radnik.jmbg);
                            MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Niste uneli dobre podatke", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Niste uneli dobro polja", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Prodavac":
                    var prodavac = (prodavac)DataGrid.SelectedItem;
                    if (get.GetProdavacByJmbg(prodavac.jmbg) == null)
                    {
                        try
                        {
                            add.AddProdavac(prodavac.jmbg, prodavac.brojsaltera);
                            MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Niste uneli dobre podatke", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Niste uneli dobro polja", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Remove
        private void BRemove_Click(object sender, RoutedEventArgs e)
        {
            switch (CBTabela.SelectedItem)
            {
                case "Autobuska stanica":
                    var stanica = (autobuska_stanica)DataGrid.SelectedItem;
                    delete.DeleteAutobuskaStanica(stanica);
                    break;
                case "Autobus":
                    try
                    {
                        var autobus = (autobu)DataGrid.SelectedItem;
                        delete.DeleteAutobus(autobus);
                        MessageBox.Show("Obrisano!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greska prilikom brisanja autobusa", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Vozac":
                    try
                    {
                        var vozac = (vozac)DataGrid.SelectedItem;
                        delete.DeleteVozac(get.GetRadnikByJmbg(vozac.jmbg));
                        MessageBox.Show("Obrisano!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greska prilikom brisanja vozaca", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Radnik":
                    try
                    {
                        var radnik = (radnik)DataGrid.SelectedItem;
                        delete.DeleteRadnik(radnik);
                        MessageBox.Show("Obrisano!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Doslo je do greske prilikom brisanja radnika", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Prodavac":
                    try
                    {
                        var prodavac = (prodavac)DataGrid.SelectedItem;
                        delete.DeleteProdavac(get.GetRadnikByJmbg(prodavac.jmbg));
                        MessageBox.Show("Obrisano!", "Oops", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Doslo je do greske prilikom brisanja prodavca", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Update
        private void BUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (CBTabela.SelectedItem)
            {
                case "Autobuska stanica":
                    var stanica = (autobuska_stanica)DataGrid.SelectedItem;
                    update.UpdateAutobuskaStanica(stanica.idstanice, stanica.ime, stanica.grad, stanica.ulica);
                    MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case "Autobus":
                    try
                    {
                        var autobus = (autobu)DataGrid.SelectedItem;
                        update.UpdateAutobus(autobus.brtablica, autobus.brojmesta, autobus.ispravan, autobus.marka);
                        MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greska prilikom menjanja autobusa", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;

                case "Vozac":
                    try
                    {
                        var vozac = (vozac)DataGrid.SelectedItem;
                        update.UpdateVozac(vozac.jmbg, vozac.brojvoznihlinija);
                        MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greska prilikom menjanja vozaca", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Radnik":
                    try
                    {
                        var radnik = (radnik)DataGrid.SelectedItem;
                        update.UpdateRadnik(radnik.jmbg, radnik.autobuska_stanica_idstanice, radnik.ime, radnik.prezime);
                        MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Doslo je do greske prilikom izmene radnika", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    break;
                case "Prodavac":
                    try
                    {
                        var prodavac = (prodavac)DataGrid.SelectedItem;
                        update.UpdateProdavac(prodavac.jmbg, prodavac.brojsaltera);
                        MessageBox.Show("Promenjeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Doslo je do greske prilikom izmene prodavca", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                default:
                    break;
            }
        } 
        #endregion
    }
}
