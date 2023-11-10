using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MarketplaceOnline.Models;

namespace UnifiedMarketplace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MarketplaceOnline.Models.Carrinho> Carrinho { get; set; } = default!;

        public DbSet<MarketplaceOnline.Models.Categoria> Categoria { get; set; } = default!;

        public DbSet<MarketplaceOnline.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<MarketplaceOnline.Models.Endereco> Endereco { get; set; } = default!;

        public DbSet<MarketplaceOnline.Models.Produto> Produto { get; set; } = default!;

        public DbSet<MarketplaceOnline.Models.Vendedor> Vendedor { get; set; } = default!;
    }
}
