using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using una.DataService;
using una.Entidades;
using Xamarin.Forms;

namespace una
{
    public partial class PessoasListViewPage : ContentPage
    {

        private PessoaDataService dataservice = new PessoaDataService();

        public PessoasListViewPage()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            IList<Pessoa> pessoas = dataservice.Select();
            ItemListView.ItemsSource = pessoas;
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CadastroViewPage((Pessoa) e.Item));
        }

        void OnBack(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomeViewPage());
        }
    }
}
