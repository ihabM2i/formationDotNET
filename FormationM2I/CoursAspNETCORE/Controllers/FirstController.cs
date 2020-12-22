﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNETCORE.Models;
using CoursAspNETCORE.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNETCORE.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult() { Content= "<h1>Bonjour tout le monde</h1>", ContentType="text/html" };
        }

        public IActionResult Contact()
        {
            return new JsonResult(new { Nom="abadi", Prenom="Ihab"});
        }

        public IActionResult FirstView()
        {
            return View();
        }

        public IActionResult SecondView()
        {
            return View("FirstView");
        }

        public IActionResult ThirdView()
        {
            return View("~/Views/Home/Privacy.cshtml");
        }

        public IActionResult ActionWithViewData()
        {
            Personne p = new Personne() { Nom = "abadi", Prenom = "ihab" };
            ViewData["personne"] = p;
            ViewData["listePersonnes"] = new List<Personne>()
            {
                new Personne() {Nom = "tata", Prenom = "toto"},
                new Personne() {Nom = "titi", Prenom = "minet"},
            };
            return View("ViewData");
        }

        public IActionResult ActionWithViewBag()
        {
            Personne p = new Personne() { Nom = "abadi", Prenom = "ihab" };
            ViewBag.Personne = p;
            ViewBag.ListePersonnes = new List<Personne>()
            {
                new Personne() {Nom = "tata", Prenom = "toto"},
                new Personne() {Nom = "titi", Prenom = "minet"},
            };
            return View("ViewBag");
        }


        public IActionResult ActionWithViewModel()
        {
            Personne p = new Personne() { Nom = "abadi", Prenom = "ihab" };
            List<Personne> liste = new List<Personne>()
            {
                new Personne() {Nom = "tata", Prenom = "toto"},
                new Personne() {Nom = "titi", Prenom = "minet"},
            };
            ViewModelActionWithViewModel v = new ViewModelActionWithViewModel();
            v.Personne = p;
            v.ListePersonnes = liste;
            return View("Model", v);
        }

        public IActionResult ActionGetDataFromGet(string nom, string prenom)
        {
            ViewBag.Prenom = prenom;
            ViewBag.Nom = nom;
            return View("DataFromGet");
        }

        public IActionResult ActionForm(string? message)
        {
            if(message != null)
            {
                ViewBag.Message = message;
            }
            return View("Form");
        }

        //public IActionResult SubmitForm(string nom, string prenom)
        public IActionResult SubmitForm(Personne p)
        {
            //Récupérer les paramètres envoyés par le formulaire
            //Action avec les paramètres 
            //Personne p = new Personne() { Nom = nom, Prenom = prenom };
            //Renvoyer une view
            //return View("Form");
            //Ou faire une redirection
            return RedirectToAction("ActionForm", "First", new { message = "personne ajouté" });
        }
    }
}