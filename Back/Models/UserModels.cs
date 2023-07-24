using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models
{
    public class UserModels
    {
        public int Id {get;set;}
        public string?  Name{get;set;}
        public string? Email{get;set;}
        public string? Password{get;set;}
        public string? Phone{get;set;}
        public string? Address{get;set;}
        public string? City{get;set;}
        public string? State{get;set;}
        public string? Country{get;set;}
        public string? PostalCode{get;set;}
    }
}
