using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnnonce.Models;
using ApiAnnonce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnnonce.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnnonceController : ControllerBase
    {

        private IUpload _upload;

        public AnnonceController(IUpload upload)
        {
            _upload = upload;
        }
        [HttpGet("{search}")]
        public List<Annonce> Get(string search)
        {
            return Annonce.Search(search);
        }

        [HttpGet("{id}")]
        public Annonce Get(int id)
        {
            return Annonce.GetAnnonce(id);
        }

        [HttpPost]
        public Annonce Post([FromForm]Annonce annonce, [FromForm] IFormFile image)
        {
            annonce.Images.Add(new Image() { Url = _upload.Upload(image) });
            annonce.Save();
            return annonce;
        }

        [HttpPut("{id}/images")]

        public Annonce Put(int id, [FromForm] IFormFile image)
        {
            Annonce annonce = Annonce.GetAnnonce(id);
            if(annonce != null)
            {
                annonce.Images.Add(new Image() { Url = _upload.Upload(image) });
                annonce.Update();
            }
            return annonce;
        }

    }
}