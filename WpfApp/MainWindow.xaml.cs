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
            CBTabela.Items.Add("Poseduje");
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
                case "Poseduje":
                    DataGrid.ItemsSource = get.GetAllPoseduje();
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
                        add.AddStanica(stanica.idstanice, stanica.ime, stanica.grad, stanica.ulica);
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
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
                        add.AddAutobus(autobus.brtablica, autobus.brojmesta, autobus.ispravan, autobus.marka);
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Autobus sa takvim idom vec postoji, izaberite drugi", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Poseduje":

                    var poseduje = (poseduje)DataGrid.SelectedItem;
                    try
                    {
                        add.AddPoseduje(poseduje.autobus_brtablica, poseduje.autobuska_stanica_idstanice);
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
                        add.AddRadnik(radnik.autobuska_stanica_idstanice, radnik.ime, radnik.prezime, radnik.jmbg);
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
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
                        add.AddProdavac(prodavac.jmbg, prodavac.brojsaltera);
                        MessageBox.Show("Dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
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
    }
}
