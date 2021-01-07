using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coursApiRest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coursApiRest.Controllers
{
    [Route("api/v1/personnes")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        [HttpGet]
        public List<Personne> Get()
        {
            List<Personne> personnes = new List<Personne>()
            {
                new Personne() {Nom = "abadi", Prenom = "ihab"},
                new Personne() {Nom = "toto", Prenom = "tata"},
            };
            return personnes;
        }

        [HttpGet("{id}")]
        public Personne Get(int id)
        {
            return new Personne() { Id = id, Nom = "tata", Prenom = "toto" };
        }

        [HttpGet("filter/{search}")]
        public List<Personne> Get(string search)
        {
            List<Personne> personnes = new List<Personne>()
            {
                new Personne() {Nom = "abadi", Prenom = "ihab"},
                new Personne() {Nom = "toto", Prenom = "tata"},
            };
            return personnes.Where(p=>p.Nom.Contains(search)).ToList();
        }

        [HttpPost]
        public Personne Post([FromForm]Personne personne, [FromForm] IFormFile image)
        {
            //Ajout de ressources
            personne.Id = 1;
            return personne;
        }

        [HttpPut("{id}")] 
        public Personne Put(int id, [FromBody]Personne personne)
        {
            personne.Id = id;
            personne.Nom = "new firstName";
            personne.Prenom = "new LastName";

            return personne;
        }

        [HttpDelete("{id}")] 
        public bool Delete(int id)
        {
            return true;
        }
    }
}