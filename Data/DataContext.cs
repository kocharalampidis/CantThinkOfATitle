﻿using CantThinkOfATitle.Models;
using Microsoft.EntityFrameworkCore;

namespace CantThinkOfATitle.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<User> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }

    }   

}
