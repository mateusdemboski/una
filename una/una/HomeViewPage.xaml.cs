using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace una
{
    public partial class HomeViewPage : ContentPage
    {
        public HomeViewPage()
        {
            InitializeComponent();
        }

        void OnCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroViewPage());
        }

        void OnListagem(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PessoasListViewPage());
        }
    }
}
