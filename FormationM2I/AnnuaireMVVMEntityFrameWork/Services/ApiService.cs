using AnnuaireMVVMEntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace AnnuaireMVVMEntityFrameWork.Services
{
    public class ApiService
    {
        private HttpClient client = new HttpClient();

        public ApiService()
        {
            client.BaseAddress = new Uri("http://localhost:53751/");
            client.DefaultRequestHeaders.Add("Autorization", "Bearer jwt");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Contact>> GetContacts()
        {
            HttpResponseMessage response = await client.GetAsync("api/v1/contacts");
            string result = await response.Content.ReadAsStringAsync();
            List<ContactApi> contactsDynamic = JsonConvert.DeserializeObject<List<ContactApi>>(result);
            List<Contact> contacts = new List<Contact>();
            contactsDynamic.ForEach(e =>
            {
                contacts.Add(new Contact() { FirstName = e.Nom, LastName = e.Prenom, Id = e.Id, Phone = e.Telephone, Mails = e.Mails });
            });
            return contacts;
        }

        public async void PostContact(Contact contact)
        {
            ContactApi contactApi = new ContactApi()
            {
                Nom = contact.FirstName,
                Prenom = contact.LastName,
                Telephone = contact.Phone,
                Mails = contact.Mails
            };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/v1/contacts", contactApi);
        }
    }
}
