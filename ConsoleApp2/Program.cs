using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ConsoleApp2
{
    class Program
    {
        struct Usuario
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Nome { get; set; }
            public string Senha { get; set; }
            public string CPF { get; set; }
            public DateTime Aniversario { get; set; }
        }

        async static void myGET(string RestUrl)
        {
            HttpClient client;
            client = new HttpClient();

            var uri = new Uri(string.Format(RestUrl, string.Empty));

            var response = await client.GetAsync(uri);

            List<Usuario> usuarios;

            Console.WriteLine("Ok, vamos lá");

            if (response.IsSuccessStatusCode)
            {
                string str = await response.Content.ReadAsStringAsync();
                usuarios = JsonConvert.DeserializeObject<List<Usuario>>(str);
                Console.WriteLine(usuarios[0].Nome);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }
        }

        static void Main(string[] args)
        {
            myGET("http://localhost:51542/api/UsuarioAPI");

            while (true)
            {

            }
        }

    }

}
