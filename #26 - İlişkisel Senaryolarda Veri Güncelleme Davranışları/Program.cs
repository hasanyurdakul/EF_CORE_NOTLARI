using Microsoft.EntityFrameworkCore;

namespace _26___İlişkisel_Senaryolarda_Veri_Güncelleme_Davranışları
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private ApplicationDbContext context = new();

        #region One to One İlişkisel Senaryolarda Veri Güncelleme

        #region Saving

        //Person person = new()
        //{
        //    Name = "Gençay",
        //    Address = new()
        //    {
        //        PersonAddress = "Yenimahalle/ANKARA"
        //    }
        //};

        //Person person2 = new()
        //{
        //    Name = "Hilmi"
        //};

        //await context.AddAsync(person);
        //await context.AddAsync(person2);
        //await context.SaveChangesAsync();

        #endregion Saving

        #region 1. Durum | Esas tablodaki veriye bağımlı veriyi değiştirme

        //Person? person = await context.Persons
        //    .Include(p => p.Address)
        //    .FirstOrDefaultAsync(p => p.Id == 1);

        //context.Addresses.Remove(person.Address);
        //person.Address = new()
        //{
        //    PersonAddress = "Yeni adres"
        //};

        //await context.SaveChangesAsync();

        #endregion 1. Durum | Esas tablodaki veriye bağımlı veriyi değiştirme

        #region 2. Durum | Bağımlı verinin ilişkisel olduğu ana veriyi güncelleme

        //Address? address = await context.Addresses.FindAsync(1);
        //address.Id = 2;
        //await context.SaveChangesAsync();

        //Address? address = await context.Addresses.FindAsync(2);
        //context.Addresses.Remove(address);
        //await context.SaveChangesAsync();

        ////Person? person = await context.Persons.FindAsync(2);
        ////address.Person = person;

        //address.Person = new()
        //{
        //    Name = "Rıfkı"
        //};
        //await context.Addresses.AddAsync(address);

        //await context.SaveChangesAsync();

        #endregion 2. Durum | Bağımlı verinin ilişkisel olduğu ana veriyi güncelleme

        #endregion One to One İlişkisel Senaryolarda Veri Güncelleme

        #region One to Many İlişkisel Senaryolarda Veri Güncelleme

        #region Saving

        //Blog blog = new()
        //{
        //    Name = "Gencayyildiz.com Blog",
        //    Posts = new List<Post>
        //    {
        //        new(){ Title = "1. Post" },
        //        new(){ Title = "2. Post" },
        //        new(){ Title = "3. Post" },
        //    }
        //};

        //await context.Blogs.AddAsync(blog);
        //await context.SaveChangesAsync();
        //Blog? blog = await context.Blogs.FindAsync(2);
        //post.Blog = blog;
        //await context.SaveChangesAsync();

        #endregion Saving

        #endregion One to Many İlişkisel Senaryolarda Veri Güncelleme

        #region Many to Many İlişkisel Senaryolarda Veri Güncelleme

        #region Saving

        //Book book1 = new() { BookName = "1. Kitap" };
        //Book book2 = new() { BookName = "2. Kitap" };
        //Book book3 = new() { BookName = "3. Kitap" };

        //Author author1 = new() { AuthorName = "1. Yazar" };
        //Author author2 = new() { AuthorName = "2. Yazar" };
        //Author author3 = new() { AuthorName = "3. Yazar" };

        //book1.Authors.Add(author1);
        //book1.Authors.Add(author2);

        //book2.Authors.Add(author1);
        //book2.Authors.Add(author2);
        //book2.Authors.Add(author3);

        //book3.Authors.Add(author3);

        //await context.AddAsync(book1);
        //await context.AddAsync(book2);
        //await context.AddAsync(book3);
        //await context.SaveChangesAsync();

        #endregion Saving

        #region 1. Örnek

        //Book? book = await context.Books.FindAsync(1);
        //Author? author = await context.Authors.FindAsync(3);
        //book.Authors.Add(author);

        //await context.SaveChangesAsync();

        #endregion 1. Örnek

        #region 2. Örnek

        //Author? author = await context.Authors
        //    .Include(a => a.Books)
        //    .FirstOrDefaultAsync(a => a.Id == 3);

        //foreach (var book in author.Books)
        //{
        //    if (book.Id != 1)
        //        author.Books.Remove(book);
        //}

        //await context.SaveChangesAsync();

        #endregion 2. Örnek

        #region 3. Örnek

        //Book? book = await context.Books
        //    .Include(b => b.Authors)
        //    .FirstOrDefaultAsync(b => b.Id == 2);

        //Author silinecekYazar = book.Authors.FirstOrDefault(a => a.Id == 1);
        //book.Authors.Remove(silinecekYazar);

        //Author author = await context.Authors.FindAsync(3);
        //book.Authors.Add(author);
        //book.Authors.Add(new() { AuthorName = "4. Yazar" });

        //await context.SaveChangesAsync();

        #endregion 3. Örnek

        #endregion Many to Many İlişkisel Senaryolarda Veri Güncelleme

        private class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Address Address { get; set; }
        }

        private class Address
        {
            public int Id { get; set; }
            public string PersonAddress { get; set; }

            public Person Person { get; set; }
        }

        private class Blog
        {
            public Blog()
            {
                Posts = new HashSet<Post>();
            }

            public int Id { get; set; }
            public string Name { get; set; }

            public ICollection<Post> Posts { get; set; }
        }

        private class Post
        {
            public int Id { get; set; }
            public int BlogId { get; set; }
            public string Title { get; set; }

            public Blog Blog { get; set; }
        }

        private class Book
        {
            public Book()
            {
                Authors = new HashSet<Author>();
            }

            public int Id { get; set; }
            public string BookName { get; set; }

            public ICollection<Author> Authors { get; set; }
        }

        private class Author
        {
            public Author()
            {
                Books = new HashSet<Book>();
            }

            public int Id { get; set; }
            public string AuthorName { get; set; }

            public ICollection<Book> Books { get; set; }
        }

        private class ApplicationDbContext : DbContext
        {
            public DbSet<Person> Persons { get; set; }
            public DbSet<Address> Addresses { get; set; }
            public DbSet<Post> Posts { get; set; }
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=ApplicationDb;User ID=SA;Password=1q2w3e4r+!");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Address>()
                    .HasOne(a => a.Person)
                    .WithOne(p => p.Address)
                    .HasForeignKey<Address>(a => a.Id);
            }
        }
    }
}