﻿using System.Data.Entity;

namespace MvcMusicStore.Models
{
	public class MusicStoreDb : DbContext
	{
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MvcMusicStore.Models.MusicStoreDB>());

		public DbSet<Album> Albums { get; set; }

		public DbSet<Artist> Artists { get; set; }

		public DbSet<Genre> Genres { get; set; }

		public DbSet<Cart> Carts { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
