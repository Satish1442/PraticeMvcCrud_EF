﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PraticeMvcCrud_EF.Models
{
    public class MyDbContext :DbContext
    {
        public MyDbContext() :base("Constr"){ }
        public DbSet<Student> Students { get; set; }
    }
}