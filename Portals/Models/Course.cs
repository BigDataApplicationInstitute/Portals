﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Portals.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class CourseDBContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }
}