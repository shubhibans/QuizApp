﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class AppAdmin
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }  // navigation property
        public string Location { get; set; }
        public string Locale { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }

    }
}