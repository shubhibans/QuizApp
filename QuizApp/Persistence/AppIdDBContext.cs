﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Persistence
{
    public class AppIdDBContext : IdentityDbContext<AppUser>
    {
        public AppIdDBContext(DbContextOptions<AppIdDBContext> options)
        : base(options)
        {

        }

        public DbSet<AppAdmin> AppAdmins {get; set;}
        public DbSet<Interviewee> Interviewees { get; set; }

    }
}
