using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AppBuscaCep.Models;
using Java.Net;

namespace AppBuscaCep.Services
{
    public class DataService
    {
        /**
        * https://stackoverflow.com/questions/43115536/php-built-in-webserver-not-reacheable-with-ipport-via-network-cable
        */


        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            string url = "https://cep.metoda.com.br/endereco/by-cep?cep=" + cep;

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                end = JsonConverter.DeserializeObject<Endereco>(json);
            }
            else
                throw new Exception(response.RequestMessage.Content.ToString());
        }

        return end;
    }

    /**
     * 
     */

    public static async Task<List<Bairro>> GetBairrosByCidade(int id_cidade)
    {
        List<Bairro> arr_bairros = new List<Bairro>();

        using (HttpClient client = new HttpClient())
        {
            string url = "https://cep.metoda.com.br/bairro/by-cidade?id_cidade=" + id_cidade;

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                arr_bairros = JsonConverter.Deserial<List<Bairro>>(json);
            }
            else
                throw new Exception(response.RequestMessage.Content.ToString());
        }

    }

    }
}

