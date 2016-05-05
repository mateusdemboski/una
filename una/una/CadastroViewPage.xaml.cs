using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using una.Entidades;
using una.DataService;
using Xamarin.Forms;

namespace una
{
    public partial class CadastroViewPage : ContentPage
    {
        private Pessoa pessoa;
        private PessoaDataService dataService = new PessoaDataService();

        public CadastroViewPage()
        {
            InitializeComponent();
            SetVisibility(true);
        }

        public CadastroViewPage(Pessoa pessoa)
        {
            InitializeComponent();

            this.pessoa = pessoa;

            SetVisibility(false);

            LoadData(pessoa);
        }

        private void SetVisibility(bool isNew)
        {
            btnSalvar.IsVisible = isNew;
            btnAtualizar.IsVisible = !isNew;
            btnExcluir.IsVisible = !isNew;
        }

        private void LoadData(Pessoa pessoa)
        {
            entName.Text = pessoa.Nome;
            entEmail.Text = pessoa.Email;
            entAddress.Text = pessoa.Endereco;
            entPhone.Text = pessoa.Telefone;
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(entName.Text))
            {
                DisplayAlert("Error", "Campo nome deve ser preenchido.", "Ok");
                return false;
            }

            if (string.IsNullOrEmpty(entEmail.Text))
            {
                DisplayAlert("Error", "Campo email deve ser preenchido.", "Ok");
                return false;
            }

            if (string.IsNullOrEmpty(entAddress.Text))
            {
                DisplayAlert("Error", "Campo endereço deve ser preenchido.", "Ok");
                return false;
            }

            return true;
        }

        void OnSalvar(object sender, EventArgs args)
        {
            if (IsValid())
            {
                pessoa = new Pessoa()
                {
                    Nome = entName.Text,
                    Email = entEmail.Text,
                    Endereco = entAddress.Text,
                    Telefone = entPhone.Text
                };

                try
                {
                    dataService.Salvar(pessoa);
                    DisplayAlert("Sucesso", "Pessoa cadastrada com sucesso!", "Ok");
                    Navigation.PushAsync(new PessoasListViewPage());
                }
                catch (Exception)
                {
                    DisplayAlert("Error", "Erro ao salvar o registro!", "Ok");
                }
            }
        }

        async void OnExcluir(object sender, EventArgs args)
        {
            try
            {
                var action = await DisplayActionSheet("Deseja realmente excluir esta pessoa?", "Cancel", null, "Sim", "Não");

                switch (action)
                {
                    case "Sim":
                        dataService.Excluir(pessoa);
                        await DisplayAlert("Sucesso", "Pessoa excluida com sucesso!", "Ok");
                        await Navigation.PushAsync(new PessoasListViewPage());
                        break;
                        
                    case "Não":
                    default:
                        break;
                }
            }
            catch (Exception)
            {

                await DisplayAlert("Error", "Erro ao excluir o registro!", "Ok");
            }
        }

        void OnAtualizar(object sender, EventArgs args)
        {
            if (IsValid())
            {
                try
                {
                    pessoa.Nome = entName.Text;
                    pessoa.Email = entEmail.Text;
                    pessoa.Endereco = entAddress.Text;
                    pessoa.Telefone = entPhone.Text;

                    dataService.Atualizar(pessoa);
                    DisplayAlert("Sucesso", "Pessoa atualizada com sucesso!", "Ok");
                    Navigation.PushAsync(new PessoasListViewPage());
                }
                catch (Exception)
                {

                    DisplayAlert("Error", "Erro ao atualizar o registro!", "Ok");
                }
            }
        }
    }
}
