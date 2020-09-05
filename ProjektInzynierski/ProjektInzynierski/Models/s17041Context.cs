using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjektInzynierski.Models
{
    public partial class s17041Context : DbContext
    {
        public s17041Context()
        {
        }

        public s17041Context(DbContextOptions<s17041Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventRelation> EventRelation { get; set; }
        public virtual DbSet<ForumEvent> ForumEvent { get; set; }
        public virtual DbSet<Gift> Gift { get; set; }
        public virtual DbSet<GiftRelationEvent> GiftRelationEvent { get; set; }
        public virtual DbSet<Hobby> Hobby { get; set; }
        public virtual DbSet<Relation> Relation { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserHobby> UserHobby { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server='db-mssql';Database=s17041;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent)
                    .HasName("Event_pk");

                entity.Property(e => e.IdEvent).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.EventPlace)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Okazja_Uzytkownik");
            });

            modelBuilder.Entity<EventRelation>(entity =>
            {
                entity.HasKey(e => e.IdEventRelation)
                    .HasName("EventRelation_pk");

                entity.Property(e => e.IdEventRelation).ValueGeneratedNever();

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.EventRelation)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_5_Okazja");

                entity.HasOne(d => d.IdRelationNavigation)
                    .WithMany(p => p.EventRelation)
                    .HasForeignKey(d => d.IdRelation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OkazjaZnajomi_Znajomosc");
            });

            modelBuilder.Entity<ForumEvent>(entity =>
            {
                entity.HasKey(e => new { e.IdEventRelation, e.IdEvent, e.Date })
                    .HasName("Forum_Event_pk");

                entity.ToTable("Forum_Event");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.ForumEvent)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Wpis_Okazja");

                entity.HasOne(d => d.IdEventRelationNavigation)
                    .WithMany(p => p.ForumEvent)
                    .HasForeignKey(d => d.IdEventRelation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Wpis_OkazjaZnajomi");
            });

            modelBuilder.Entity<Gift>(entity =>
            {
                entity.HasKey(e => e.IdGift)
                    .HasName("Gift_pk");

                entity.Property(e => e.IdGift).ValueGeneratedNever();

                entity.Property(e => e.Brand).HasMaxLength(30);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Gift1)
                    .IsRequired()
                    .HasColumnName("Gift")
                    .HasMaxLength(64);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Size)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Gift)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prezent_Uzytkownik");
            });

            modelBuilder.Entity<GiftRelationEvent>(entity =>
            {
                entity.HasKey(e => new { e.IdGift, e.IdRelation, e.IdEvent })
                    .HasName("Gift_Relation_Event_pk");

                entity.ToTable("Gift_Relation_Event");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.GiftRelationEvent)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_9_Okazja");

                entity.HasOne(d => d.IdGiftNavigation)
                    .WithMany(p => p.GiftRelationEvent)
                    .HasForeignKey(d => d.IdGift)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_9_Prezent");

                entity.HasOne(d => d.IdRelationNavigation)
                    .WithMany(p => p.GiftRelationEvent)
                    .HasForeignKey(d => d.IdRelation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_9_Znajomosc");
            });

            modelBuilder.Entity<Hobby>(entity =>
            {
                entity.HasKey(e => e.IdHobby)
                    .HasName("Hobby_pk");

                entity.Property(e => e.IdHobby).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.HobbyName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Relation>(entity =>
            {
                entity.HasKey(e => e.IdRelation)
                    .HasName("Relation_pk");

                entity.Property(e => e.IdRelation).ValueGeneratedNever();

                entity.Property(e => e.IdUser2).HasColumnName("IdUser_2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.RelationIdUserNavigation)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Znajomosc_Uzytkownik");

                entity.HasOne(d => d.IdUser2Navigation)
                    .WithMany(p => p.RelationIdUser2Navigation)
                    .HasForeignKey(d => d.IdUser2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Znajomosc_Uzytkownik_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("User_pk");

                entity.Property(e => e.Avatar).HasColumnType("image");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<UserHobby>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdHobby })
                    .HasName("User_Hobby_pk");

                entity.ToTable("User_Hobby");
            });
        }
    }
}
