﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    { //burası bir kalıp gibi düşün 

        public Context(DbContextOptions<Context> options) : base(options)
        {
            optionsBuilder.UseSqlServer("Server=SELIMMELIH;database=TraversalDB;integrated security=true;TrustServerCertificate=True");
        }
        // s takısı almamıs hali Entity ismi
        // s takısı almıs hali DB tablo hali
        // karısmaması icin böyle yapılır
        // code first oldugu icin bu asagıdaki kodlar ile buradaki tabloları propları DB Ye yazdırmaya yarar.
        public DbSet<Account> Accounts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<About2> Abouts2 { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Feature2> Feature2s { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
         
    }
}
