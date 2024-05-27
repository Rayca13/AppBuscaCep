using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppBuscaCep.Models;
using AppBuscaCep.Services;

namespace AppBuscaCep.Views;

public partial class BairrosPorCidade : ContentPage
{
    ObservableCollection<Cidade> lista_cidades = new ObservableCollection<Cidade>();

    ObservableCollection<Bairro> lista_bairro = new ObservableCollection<Bairro>();

    public BairrosPorCidade()
    {
        InitializeComponent();

        pck_cidade.ItemsSource = lista_cidades;

        pck_bairros.ItemsSource = lista_bairro;
    }

    private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            Picker disparador = sender as Picker;

            string? estado_selecionado = disparador.SelectedItem as string;

            List<Cidade> arr_cidades = await DataService.GetEnderecoByEstado(
                estado_selecionado);

            lista_cidades.Clear();

            arr_cidades.ForEach(i => lista_cidades.Add(i));
        }
        catch (Exception ex) 
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            Picker disparador = sender as Picker;

            Cidade cidade_selecionada = disparador.SelectedItem as Cidade;

            List<Bairro> arr_bairros = await DataService.GetBairrosByIdCidade(
                cidade_selecionada.id_cidade);

            lista_bairro.Clear();

            arr_bairros.ForEach(i => lista_bairro.Add(i));

        }
         catch(Exception ex) 
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}