using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using StreamingAPI.Models;
using Newtonsoft.Json;

namespace StreamingWeb.ControllerAPI
{
    public sealed class API
    {
        private static readonly HttpClient client = new HttpClient();

        private API()
        {
            client.BaseAddress = new Uri("http://localhost:7208");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private static readonly object padlock = new object();
        private static API instance = null;

        public static API Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new API();
                    }
                    return instance;
                }
            }
        }

        public async Task<Client> GetClient(int id)
        {
        
            Client clt = null;
            HttpResponseMessage response = client.GetAsync("api/Clients/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                clt = JsonConvert.DeserializeObject<Client>(resp);
            }
            return clt;
        }

        


        /*  public async Task<Client> GetClient(string login, string pwd)
          {
              Client clt = null;
              HttpResponseMessage response = client.GetAsync("api/clients/" + login + "/" + pwd).Result;
              if (response.IsSuccessStatusCode)
              {
                  var resp = await response.Content.ReadAsStringAsync();
                  clt = JsonConvert.DeserializeObject<Client>(resp);
              }
              return clt;
          }*/



        public async Task<Uri> AjoutClientAsync(Client clt)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Clients", clt);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> ModifClientAsync(Client clt)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Clients" + clt.Id, clt);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> SupprClientAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/Clients" + id);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        public async Task<ICollection<Client>> GetClientsAsync()
        {
            ICollection<Client> clients = new List<Client>();
            HttpResponseMessage response = client.GetAsync("api/Clients").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                clients = JsonConvert.DeserializeObject<List<Client>>(resp);
            }
            return clients;
        }


        ///////////////////////Animes/////////////////////////
        public async Task<ICollection<Anime>> GetAnimesAsync()
        {
            ICollection<Anime> animes = new List<Anime>();
            HttpResponseMessage response = client.GetAsync("api/Animes").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                animes = JsonConvert.DeserializeObject<List<Anime>>(resp);
            }
            return animes;
        }

        public async Task<Anime> GetAnimeAsync(int? id)
        {
            Anime anime = null;
            HttpResponseMessage response = client.GetAsync("api/Animes/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                anime = JsonConvert.DeserializeObject<Anime>(resp);
            }
            return anime;
        }

        public async Task<Uri> AjoutAnimeAsync(Anime anime)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Animes", anime);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> ModifAnimeAsync(Anime anime)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Animes/" + anime.Id, anime);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> SupprAnimeAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/Animes/" + id);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        ///////////////////Categorie///////////////////
        public async Task<ICollection<Categorie>> GetCategoriesAsync()
        {
            ICollection<Categorie> categories = new List<Categorie>();
            HttpResponseMessage response = client.GetAsync("api/Categories").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<Categorie>>(resp);
            }
            return categories;
        }

        public async Task<Categorie> GetCategorieAsync(int? id)
        {
            Categorie categorie = null;
            HttpResponseMessage response = client.GetAsync("api/Categories/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                categorie = JsonConvert.DeserializeObject<Categorie>(resp);
            }
            return categorie;
        }

        public async Task<Uri> AjoutCategorieAsync(Categorie categorie)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Categories", categorie);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> ModifCategorieAsync(Categorie categorie)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Categories/" + categorie.Id, categorie);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> SupprCategorieAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/Categories/" + id);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        /////////////////////////Admin//////////////////////

        public async Task<ICollection<Admin>> GetAdminsAsync()
        {
            ICollection<Admin> admins = new List<Admin>();
            HttpResponseMessage response = client.GetAsync("api/Admins").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                admins = JsonConvert.DeserializeObject<List<Admin>>(resp);
            }
            return admins;
        }

        public async Task<Admin> GetAdmin(int? id)
        {
            Admin admin = null;
            HttpResponseMessage response = client.GetAsync("api/Admins/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                admin = JsonConvert.DeserializeObject<Admin>(resp);
            }
            return admin;
        }

        public async Task<Uri> AjoutAdminAsync(Admin admin)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Admins", admin);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> ModifAdminAsync(Admin admin)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Admins/" + admin.Id, admin);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> SupprAdminAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/Admins/" + id);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
    


