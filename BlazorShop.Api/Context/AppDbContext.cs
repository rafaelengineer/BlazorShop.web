using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Your database connection string or other configurations here
                optionsBuilder.UseNpgsql("Host=172.19.0.72;Port=5432;Database=rls_tmp;Username=postgres;Password=postgres")
                              .EnableSensitiveDataLogging(); // Enable sensitive data logging
            }
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<ShopCar>? tb_ShopCars { get; set; }
        public DbSet<shopItems>? tb_ShopItems { get; set; }
        public DbSet<Product>? tb_Product { get; set; }
        public DbSet<Category>? tb_Category { get; set; }
        public DbSet<User>? tb_User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                categoryId = 1,
                Name = "Beauty",
                IconCSS = "fas fa-spa"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                categoryId = 2,
                Name = "Beverages",
                IconCSS = "Bev fa-spa"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                categoryId = 3,
                Name = "AutoParts",
                IconCSS = "Auto fa-spa"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                categoryId = 4,
                Name = "Shoes",
                IconCSS = "fas fa-shoe-prints"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                categoryId = 5,
                Name = "Forniture",
                IconCSS = "fas fa-couch"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                categoryId = 6,
                Name = "Electronics",
                IconCSS = "fas fa-headphones"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 1,
                Name = "Glossier - Beauty Kit",
                Description = "Um kit fornecido pela Natura, contendo produtos para cuidados com a pele",
                ImagemUrl = "/Imagens/Beauty/Beleza1.png",
                Price = 100,
                qtdInStock = 100,
                Manufacturer = null,
                CategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 2,
                Name = "Curology - Kit para Pele",
                Description = "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele",
                ImagemUrl = "/Imagens/Beauty/Beleza2.png",
                Price = 50,
                qtdInStock = 45,
                Manufacturer = null,
                CategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 3,
                Name = "Óleo de Coco Orgânico",
                Description = "Um kit fornecido pela Glossier, contendo produtos para cuidados com a pele",
                ImagemUrl = "/Imagens/Beauty/Beleza3.png",
                Price = 20,
                qtdInStock = 30,
                Manufacturer = null,
                CategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 4,
                Name = "Schwarzkopf - Kit de cuidados com a pele e cabelo",
                Description = "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele",
                ImagemUrl = "/Imagens/Beauty/Beleza4.png",
                Price = 50,
                qtdInStock = 60,
                Manufacturer = null,
                CategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 5,
                Name = "Kit de cuidados com a pele",
                Description = "Kit de cuidados com a pele, contendo produtos para cuidados com a pele e cabelos",
                ImagemUrl = "/Imagens/Beauty/Beleza5.png",
                Price = 30,
                qtdInStock = 85,
                Manufacturer = null,
                CategoryId = 1

            });
            //eletronico Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 6,
                Name = "Fones de ouvidos",
                Description = "Air Pods - fones de ouvido sem fio intra-auriculares",
                ImagemUrl = "/Imagens/Electronics/eletronico1.png",
                Price = 100,
                qtdInStock = 120,
                Manufacturer = null,
                CategoryId = 6

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 7,
                Name = "Fones de ouvido dourados",
                Description = "Fones de ouvido dourados na orelha - esses fones de ouvido não são sem fio",
                ImagemUrl = "/Imagens/Electronics/eletronico2.png",
                Price = 40,
                qtdInStock = 200,
                Manufacturer = null,
                CategoryId = 6

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 8,
                Name = "Fones de ouvido pretos",
                Description = "Fones de ouvido pretos na orelha - esses fones de ouvido não são sem fio",
                ImagemUrl = "/Imagens/Electronics/eletronico3.png",
                Price = 40,
                qtdInStock = 300,
                Manufacturer = null,
                CategoryId = 6

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 9,
                Name = "Câmera digital Sennheiser com tripé",
                Description = "Câmera Digital Sennheiser - Câmera digital de alta qualidade fornecida pela Sennheiser - inclui tripé",
                ImagemUrl = "/Imagens/Electronics/eletronico4.png",
                Price = 600,
                qtdInStock = 20,
                Manufacturer = null,
                CategoryId = 6

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 10,
                Name = "Câmera Digital Canon",
                Description = "Canon Digital Camera - Câmera digital de alta qualidade fornecida pela Canon",
                ImagemUrl = "/Imagens/Electronics/eletronico5.png",
                Price = 500,
                qtdInStock = 15,
                Manufacturer = null,
                CategoryId = 6

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 11,
                Name = "Nintendo Gameboy",
                Description = "Gameboy - Fornecido por Nintendo",
                ImagemUrl = "/Imagens/Electronics/tecnologia6.png",
                Price = 100,
                qtdInStock = 60,
                Manufacturer = null,
                CategoryId = 6
            });
            //Forniture Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 12,
                Name = "Cadeira de escritório de couro preto",
                Description = "Cadeira de escritório em couro preto muito confortável",
                ImagemUrl = "/Imagens/Forniture/moveis1.png",
                Price = 50,
                qtdInStock = 212,
                Manufacturer = null,
                CategoryId = 5
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 13,
                Name = "Cadeira de escritório de couro rosa",
                Description = "Cadeira de escritório em couro rosa muito confortável",
                ImagemUrl = "/Imagens/Forniture/moveis2.png",
                Price = 50,
                qtdInStock = 112,
                Manufacturer = null,
                CategoryId = 5
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 14,
                Name = "Espreguiçadeira",
                Description = "Poltrona muito confortável",
                ImagemUrl = "/Imagens/Forniture/moveis3.png",
                Price = 70,
                qtdInStock = 90,
                Manufacturer = null,
                CategoryId = 5
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 15,
                Name = "Silver Lounge Chair",
                Description = "Poltrona prateada muito confortável",
                ImagemUrl = "/Imagens/Forniture/moveis4.png",
                Price = 120,
                qtdInStock = 95,
                Manufacturer = null,
                CategoryId = 5
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 16,
                Name = "Luminária de mesa de porcelana",
                Description = "Abajur de mesa de porcelana branco e azul",
                ImagemUrl = "/Imagens/Forniture/moveis6.png",
                Price = 15,
                qtdInStock = 100,
                Manufacturer = null,
                CategoryId = 5
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 17,
                Name = "Office Table Lamp",
                Description = "Abajur de mesa de escritório",
                ImagemUrl = "/Imagens/Forniture/moveis7.png",
                Price = 20,
                qtdInStock = 73,
                Manufacturer = null,
                CategoryId = 5
            });
            //Shoes Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 18,
                Name = "Tênis Puma",
                Description = "Tênis Puma confortáveis na maioria dos tamanhos",
                ImagemUrl = "/Imagens/Shoes/calcado1.png",
                Price = 100,
                qtdInStock = 50,
                Manufacturer = null,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 19,
                Name = "Tênis Colodiros",
                Description = "Tênis coloridos - disponíveis na maioria dos tamanhos",
                ImagemUrl = "/Imagens/Shoes/calcado2.png",
                Price = 150,
                qtdInStock = 60,
                Manufacturer = null,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 20,
                Name = "Tênis Nike Azul",
                Description = "Tênis Nike azul - disponível na maioria dos tamanhos",
                ImagemUrl = "/Imagens/Shoes/calcado3.png",
                Price = 200,
                qtdInStock = 70,
                Manufacturer = null,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 21,
                Name = "Tênis Hummel Coloridos",
                Description = "Treinadores Hummel coloridos - disponíveis na maioria dos tamanhos",
                ImagemUrl = "/Imagens/Shoes/calcado4.png",
                Price = 120,
                qtdInStock = 120,
                Manufacturer = null,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 22,
                Name = "Tênis Nike Vermelho",
                Description = "Tênis Nike vermelho - disponível na maioria dos tamanhos",
                ImagemUrl = "/Imagens/Shoes/calcado5.png",
                Price = 200,
                qtdInStock = 100,
                Manufacturer = null,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 23,
                Name = "Sandálidas Birkenstock",
                Description = "Sandálias Birkenstock - disponíveis na maioria dos tamanhos",
                ImagemUrl = "/Imagens/Shoes/calcado6.png",
                Price = 50,
                qtdInStock = 150,
                Manufacturer = null,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 30,
                Name = "Tire_165'60'13R",
                ImagemUrl = "/Imagens/AutoParts/AutoParts30.png",
                Description = "Small tires.",
                Price = 323m,
                qtdInStock = 10,
                CategoryId = 1,
                //CategoryId = null, // Replace with an instance of the 'Category' class
                Manufacturer = "Pirelle",
                //ManufactureDate = new DateTime(2023, 1, 1)
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 31,
                Name = "Tire_220'90'19R",
                Description = "Sprt tire.",
                ImagemUrl = "/Imagens/AutoParts/AutoParts31.png",
                Price = 550m,
                CategoryId = 1,
                //Category = null, // Replace with an instance of the 'Category' class
                Manufacturer = "Toyo",
                qtdInStock = 11,
                //ManufactureDate = new DateTime(2023, 1, 1)
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 32,
                Name = "windscreen_wiper_blade",
                Description = "windscreen wiper blade for Ford focus.",
                ImagemUrl = "/Imagens/AutoParts/AutoParts32.png",
                Price = 13.32m,
                CategoryId = 1,
                //Category = null, // Replace with an instance of the 'Category' class
                Manufacturer = "ChinaCo",
                qtdInStock = 12,
                //ManufactureDate = new DateTime(2023, 1, 1)
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 41,
                Name = "Lipstick",
                Description = "A long-lasting lipstick in a vibrant red color.",
                ImagemUrl = "/Imagens/Beauty/Beleza41.png",
                Price = 15.99m,
                CategoryId = 1,
                //Category = null, // Replace with an instance of the 'Category' class
                Manufacturer = "BeautyCo",
                qtdInStock = 13,
                //ManufactureDate = new DateTime(2023, 1, 1)
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 42,
                Name = "Mascara",
                Description = "A waterproof mascara that adds volume and length to your lashes.",
                ImagemUrl = "/Imagens/Beauty/Beleza42.png",
                Price = 12.99m,
                CategoryId = 1,
                //Category = null, // Replace with an instance of the 'Category' class
                Manufacturer = "BeautyCo",
                qtdInStock = 14,
                //ManufactureDate = new DateTime(2023, 2, 2)
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 43,
                Name = "Foundation",
                Description = "A lightweight foundation that provides medium coverage for a natural look.",
                ImagemUrl = "/Imagens/Beauty/Beleza43.png",
                Price = 20.99m,
                CategoryId = 1,
                //Category = null, // Replace with an instance of the 'Category' class
                Manufacturer = "BeautyCo",
                qtdInStock = 15,
                //ManufactureDate = new DateTime(2023, 3, 3)
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 44,
                Name = "CocaCola_600ml",
                Description = "Disgusting syrup.",
                ImagemUrl = "/Imagens/Beverages/Beverage20.png",
                Price = 1.99m,
                CategoryId = 2,
                //Category = null, // Replace with an instance of the 'Category' class
                Manufacturer = "CocaCo",
                qtdInStock = 16,
                //ManufactureDate = new DateTime(1899, 3, 3)
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 45,
                Name = "Heiniken_0%",
                Description = "Just like beer, but only a sour-smelling drink. .",
                ImagemUrl = "/Imagens/Beverages/Beverage21.png",
                Price = 1.79m,
                CategoryId = 2,
                //Category = null, // Replace with an instance of the 'Category' class
                Manufacturer = "HeinikenCo",
                qtdInStock = 17,
                //ManufactureDate = new DateTime(2023, 3, 3)
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                productId = 46,
                Name = "Bäcker_trigo_600ml",
                Description = "Sweet and dense beer.",
                ImagemUrl = "/Imagens/Beverages/Beverage23.png",
                Price = 2.59m,
                CategoryId = 2,
                //Category = null, // Replace with an instance of the 'Category' class
                Manufacturer = "TresLobosCo",
                qtdInStock = 18,
                // ManufactureDate = new DateTime(2023, 3, 3)
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                userId = 1,
                Name = "John Doe",
                Email = "johndoe@example.com"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                userId = 2,
                Name = "Jane Doe",
                Email = "janedoe@example.com"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                userId = 3,
                Name = "Bob Smith",
                Email = "bobsmith@example.com"
            });
        }

    }
}
