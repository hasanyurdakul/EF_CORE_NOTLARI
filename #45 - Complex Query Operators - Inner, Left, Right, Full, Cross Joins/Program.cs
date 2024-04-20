using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace _45___Complex_Query_Operators___Inner__Left__Right__Full__Cross_Joins
{
    public class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new();

            #region Complext Query Operators

            #region Join

            #region Query Syntax
            //var query = from photo in context.Photos
            //            join person in context.Persons
            //                on photo.PersonId equals person.PersonId
            //            select new
            //            {
            //                person.Name,
            //                photo.Url
            //            };
            //var datas = await query.ToListAsync();
            #endregion
            #region Method Syntax
            //var query = context.Photos
            //    .Join(context.Persons,
            //    photo => photo.PersonId,
            //    person => person.PersonId,
            //    (photo, person) => new
            //    {
            //        person.Name,
            //        photo.Url
            //    });

            //var datas = await query.ToListAsync();
            #endregion

            #region Multiple Columns Join

            #region Query Syntax
            //var query = from photo in context.Photos
            //            join person in context.Persons
            //                on new { photo.PersonId, photo.Url } equals new { person.PersonId, Url = person.Name }
            //            select new
            //            {
            //                person.Name,
            //                photo.Url
            //            };
            //var datas = await query.ToListAsync();
            #endregion
            #region Method Syntax
            //var query = context.Photos
            //    .Join(context.Persons,
            //    photo => new
            //    {
            //        photo.PersonId,
            //        photo.Url
            //    },
            //    person => new
            //    {
            //        person.PersonId,
            //        Url = person.Name
            //    },
            //    (photo, person) => new
            //    {
            //        person.Name,
            //        photo.Url
            //    });

            //var datas = await query.ToListAsync();
            #endregion
            #endregion

            #region 2'den Fazla Tabloyla Join

            #region Query Syntax
            //var query = from photo in context.Photos
            //            join person in context.Persons
            //                on photo.PersonId equals person.PersonId
            //            join order in context.Orders
            //                on person.PersonId equals order.PersonId
            //            select new
            //            {
            //                person.Name,
            //                photo.Url,
            //                order.Description
            //            };

            //var datas = await query.ToListAsync();
            #endregion
            #region Method Syntax
            //var query = context.Photos
            //    .Join(context.Persons,
            //    photo => photo.PersonId,
            //    person => person.PersonId,
            //    (photo, person) => new
            //    {
            //        person.PersonId,
            //        person.Name,
            //        photo.Url
            //    })
            //    .Join(context.Orders,
            //    personPhotos => personPhotos.PersonId,
            //    order => order.PersonId,
            //    (personPhotos, order) => new
            //    {
            //        personPhotos.Name,
            //        personPhotos.Url,
            //        order.Description
            //    });

            //var datas = await query.ToListAsync();
            #endregion
            #endregion

            #region Group Join - GroupBy Değil!
            //var query = from person in context.Persons
            //            join order in context.Orders
            //                on person.PersonId equals order.PersonId into personOrders
            //            //from order in personOrders
            //            select new
            //            {
            //                person.Name,
            //                Count = personOrders.Count(),
            //                personOrders
            //            };
            //var datas = await query.ToListAsync();
            #endregion
            #endregion

            //DefaultIfEmpty : Sorgulama sürecinde ilişkisel olarak karşılığı olmayan verilere default değerini yazdıran yani LEFT JOIN sorgusunu oluşturtan bir fonksiyondur.

            #region Left Join
            //var query = from person in context.Persons
            //                person,
            //                order
            //            };

            //var datas = await query.ToListAsync();
            #endregion

            #region Outer Apply
            //Left Join
            //var query = from person in context.Persons
            //            from order in context.Orders.Select(o => person.Name).DefaultIfEmpty()
            //            select new
            //            {
            //                person,
            //                order
            //            };

            //var datas = await query.ToListAsync();
            #endregion
            #endregion
            Console.WriteLine();
        }


        public class Photo
        {
            public int PersonId { get; set; }
            public string Url { get; set; }

            public Person Person { get; set; }
        }
        public enum Gender { Man, Woman }
        public class Person
        {
            public int PersonId { get; set; }
            public string Name { get; set; }
            public Gender Gender { get; set; }

            public Photo Photo { get; set; }
            public ICollection<Order> Orders { get; set; }
        }
        public class Order
        {
            public int OrderId { get; set; }
            public int PersonId { get; set; }
            public string Description { get; set; }

            public Person Person { get; set; }
        }

        class ApplicationDbContext : DbContext
        {
            public DbSet<Photo> Photos { get; set; }
            public DbSet<Person> Persons { get; set; }
            public DbSet<Order> Orders { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

                modelBuilder.Entity<Photo>()
                    .HasKey(p => p.PersonId);

                modelBuilder.Entity<Person>()
                    .HasOne(p => p.Photo)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Photo>(p => p.PersonId);

                modelBuilder.Entity<Person>()
                    .HasMany(p => p.Orders)
                    .WithOne(o => o.Person)
                    .HasForeignKey(o => o.PersonId);
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=ApplicationDB;User ID=SA;Password=1q2w3e4r+!;TrustServerCertificate=True");
            }
        }

    }
}
