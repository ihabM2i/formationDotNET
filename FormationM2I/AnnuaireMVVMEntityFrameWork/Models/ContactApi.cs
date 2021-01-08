using System;
using System.Collections.Generic;
using System.Text;

namespace AnnuaireMVVMEntityFrameWork.Models
{
    class ContactApi
    {
        public int Id {get;set;}
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }

        public List<Email> Mails { get; set; }
    }
}
