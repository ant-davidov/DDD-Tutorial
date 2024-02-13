
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberSinner.Infrastructure.Persistence.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }

        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(x => x.MenuReviewId, di =>
            {
                di.ToTable("MenuReviewIds");
                di.WithOwner().HasForeignKey("MenuId");
                di.HasKey("Id");
                di.Property(d => d.Value)
                    .HasColumnName("ReviewId")
                    .ValueGeneratedNever();

            });
            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewId)).SetPropertyAccessMode(PropertyAccessMode.Field);

        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(x => x.DinnerIds, di =>
            {
                di.ToTable("MenuDinnerIds");
                di.WithOwner().HasForeignKey("MenuId");
                di.HasKey("Id");
                di.Property(d => d.Value)
                    .HasColumnName("DinnerId")
                    .ValueGeneratedNever();

            });
            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds)).SetPropertyAccessMode(PropertyAccessMode.Field);

        }

        private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(x => x.Sections, sb =>
            {
                sb.ToTable("MenuSections");
                sb.WithOwner().HasForeignKey("MenuId");
                sb.HasKey("Id", "MenuId");
                sb.Property(x => x.Id)
                    .HasColumnName("MenuSectionId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuSectionId.Create(value));
                sb.Property(x => x.Name).HasMaxLength(100);
                sb.Property(x=>x.Description).HasMaxLength(100);
                sb.OwnsMany(x => x.Items, sb =>
                {
                   
                    sb.ToTable("MenuItems");
                    sb.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
                    sb.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");
                    sb.Property(x=>x.Id)
                        .HasColumnName("MenuItemId")
                        .ValueGeneratedNever()
                        .HasConversion(
                    id => id.Value,
                    value => MenuItemId.Create(value));
                });
                builder.Property(x => x.Name).HasMaxLength(100);
                builder.Property(x => x.Description).HasMaxLength(100);
                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });
            builder.Metadata.FindNavigation(nameof(Menu.Sections)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(
                id => id.Value,
                value => MenuId.Create(value));
            builder.Property(x=>x.Name).HasMaxLength(100);
            builder.Property(x=>x.Description).HasMaxLength(100);
            builder.OwnsOne(x => x.AverageRating);
            builder.Property(x=>x.HostId).HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        }
    }
}
