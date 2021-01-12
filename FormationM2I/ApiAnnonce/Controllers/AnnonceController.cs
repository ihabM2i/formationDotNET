using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnnonce.Models;
using ApiAnnonce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnnonce.Controllers
{
    [Route("api/v1/annonces")]
    [EnableCors("all")]
    [ApiController]
    public class AnnonceController : ControllerBase
    {

        private IUpload _upload;

        public AnnonceController(IUpload upload)
        {
            _upload = upload;
        }
        [HttpGet("filter/{search}")]
        [Authorize("connect")]
        public List<Annonce> Get(string search)
        {
            return Annonce.Search(search);
        }

        [HttpGet]
        [Authorize("connect")]
        public List<Annonce> Get()
        {
            return Annonce.Search(null);
        }

        [HttpGet("{id}")]
        [Authorize("connect")]
        public Annonce Get(int id)
        {
            return Annonce.GetAnnonce(id);
        }

        [HttpPost]
        [Authorize("admin")]
        public Annonce Post([FromForm]Annonce annonce, [FromForm] IFormFile image)
        {
            annonce.Images.Add(new Image() { Url = _upload.Upload(image) });
            annonce.Save();
            return annonce;
        }

        [HttpPut("{id}/images")]
        [Authorize("admin")]
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