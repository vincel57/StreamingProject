using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using StreamingAPI.Models;
using Newtonsoft.Json;
using StreamingAPI.Models;

namespace WebApplication1.ControllersAPI
{
    public sealed class remplacement
    {
        private static readonly HttpClient client = new HttpClient();

        private remplacement()
        {
            client.BaseAddress = new Uri("http://localhost:44344");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private static readonly object padlock = new object();
        private static remplacement instance = null;
        
        public static remplacement Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new remplacement();
                    }
                    return instance;
                }
            }
        }


        public async Task<ICollection<Admin>> GetAdminsAsync()
        {
            ICollection<Admin> admins = new List<Admin>();
            HttpResponseMessage response = client.GetAsync("api/admins").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                admins = JsonConvert.DeserializeObject<List<Admin>>(resp);
            }
            return admins;
        }

        public async Task<Admin> GetAdminAsync(int? id)
        {
            Admin admin = null;
            HttpResponseMessage response = client.GetAsync("api/admins/" + id).Result;
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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/admins", admin);
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
                HttpResponseMessage response = await client.PutAsJsonAsync("api/admins/" + admin.Id, admin);
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
                HttpResponseMessage response = await client.DeleteAsync("api/admins/" + id);
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
