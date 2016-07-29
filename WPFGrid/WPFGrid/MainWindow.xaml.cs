using System;
using System.Collections.Generic;
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

namespace WPFGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<Person> People { get; set; }

        private bool _rowSelected;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool RowSelected
        {
            get
            {
                return _rowSelected;
            }

            set
            {
                _rowSelected = value;
                OnPropertyChanged("RowSelected");
            }
        }

        public MainWindow()
        {
            //Add Sample data
            People = new List<Person>();
            People.Add(new Person() { FirstName = "Santi", LastName = "Murtagh", Id = Guid.NewGuid() });

            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EditPerson editModal = new EditPerson(new Person() { Id = Guid.NewGuid() });
            if (editModal.ShowDialog().Value)
            {
                People.Add(editModal.Person);
                MainGrid.Items.Refresh();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Person personToDelete = (Person)MainGrid.SelectedItem;
            People.Remove(People.Where(p => p.Id == personToDelete.Id).First());
            MainGrid.Items.Refresh();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Person personToEdit = (Person)MainGrid.SelectedItem;
            EditPerson editModal = new EditPerson(personToEdit);
            editModal.ShowDialog();
            MainGrid.SelectedIndex = -1;

        }

        private void MainGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            RowSelected = MainGrid.SelectedItem != null;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
