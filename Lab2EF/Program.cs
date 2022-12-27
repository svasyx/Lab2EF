using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System;
using System.Linq;
using System.IO;
using Microsoft.Data.SqlClient;

public class Shopper
{
    [Key]
    public string phoneNum { get; set; } = "none";
    [MaxLength (12)]
    public float? discountValue { get; set; }
    public int? ID_discountcard { get; set; }

    public List<Bill> bills { get; set; } = new();  
}

public class Pharmacist
{
    public int ID { get; set; }

    public string? Name { get; set; } = "null";

    public List<Bill> bills { get; set;} = new();

}

public class Admin : Pharmacist
{
    public string password { get; set; } = "1234";
}

public class Recipe
{
    public int ID { get; set; }

    public int? billID { get; set; }
}


public class Bill
{
    public int ID { get; set; }

    public Pharmacist? pharmacist { get; set; }

    public Shopper shopper { get; set; }

    public int? DiscCardID { get; set; }

    public int finalPrice { get; set; }

    public string TypeOfPay { get; set; } = string.Empty;

    public DateTime dateofPay { get; set; } = DateTime.Today;

    public string? Place { get; set; } = "here";

    public Recipe? recipe { get; set; }

    public medicineList medicineList { get; set; }

    public float? discValue { get; set; } = 0;



}

public class medicineList
{
    public int ID { get; set; }

    public float price { get; set; } = 0;

    public int count { get; set; }

    public string? unitOfMeasurement { get; set; } = string.Empty;

    public int billID { get; set; } 

    public List<Medicine> listifmedlists { get; set; } = new();

}

public class Producer
{
    public int ID { get; set; }

    public string Name { get; set; } = "null";

    public float licenseNum { get; set; } = 0;

    public List<Medicine> medicines { get; set; } = new();

}

public class Medicine
{
    [Key]
    public float Article { get; set; }

    public string Name { get; set; } = "null";

    public DateTime expDate { get; set; } = DateTime.Today;

    public int count { get; set; }

    public bool receipeneed { get; set; }

    public float temperature { get; set; } = 0;

    public Producer producer { get; set; }

    public GoodsInStorage? goodsInStorage { get; set; }

    public List<medicineList> medicineLists { get; set; } = new();

}

public class GoodsInStorage
{
    [Key]
    public int place { get; set; }

    public float medicineArticle { get; set; }

    public bool IsAvailable { get; set; }   

    public int storageid { get; set; }  


}



public class Program
{
   

    static void Main()
    {
        
        using (ApplicationContext task = new ApplicationContext())
        {

            //select distinct * from producer

            //var get = task.Producer.ToList();
            //foreach (var item in get)
            //{
            //    Console.WriteLine($"Producer name = {item.Name}");
            //}

            //select top 2 * from producer

            //var get1 = task.Producer.Take(2).ToList();
            //foreach (var item in get1)
            //{
            //    Console.WriteLine($"Producer name = {item.Name}");
            //}

            //select * from medicine order by cnt_in_pack desc offset 2 rows fetch next 2 rows only;


            //var get2 = task.Medicine.OrderByDescending(med => med.count).Skip(2).Take(2).ToList();
            //foreach (var item in get2)
            //{
            //    Console.WriteLine($"medicine name = {item.Name}");
            //}

            //select * from medicine where name like("new")

            //var get4 = task.Medicine.Where(medicine => EF.Functions.Like(medicine.Name,"old%"));
            //foreach (var item in get4)
            //{
            //    Console.WriteLine($"Medicine name = {item.Name}");
            //}

            //select medicine.name from medicine where medicine.count BETWEEN 1 and 3 )

            //var get4 = task.Medicine.Where(medicine =>medicine.count >= 1 && medicine.count <= 3).ToList();
            //foreach (var item in get4)
            //{
            //    Console.WriteLine($"Medicine name = {item.Name}");
            //}

            //select medicine.MedArticle from medicine
            //except
            // select goods_in_storage.article from goods_in_storage



            //var get5 = task.Medicine.Select(medicine => medicine.Article)
            //    .Except(task.GoodsInStorage.Select(storage => storage.medicineArticle)).ToList();
            //foreach (var item in get5)
            //{
            //    Console.WriteLine($"Medicine Article = {item}");
            //}

            //select medicine.MedArticle from medicine
            //intersect
            // select goods_in_storage.article from goods_in_storage



            //var get6 = task.Medicine.Select(medicine => medicine.Article)
            //    .Intersect(task.GoodsInStorage.Select(storage => storage.medicineArticle)).ToList();
            //foreach (var item in get6)
            //{
            //    Console.WriteLine($"Medicine Article = {item}");
            //}


            //select medicine.MedArticle from medicine
            //union
            // select goods_in_storage.article from goods_in_storage

            //var get7 = task.Medicine.Select(medicine => medicine.Article)
            //    .Union(task.GoodsInStorage.Select(storage => storage.medicineArticle)).ToList();
            //foreach (var item in get7)
            //{
            //    Console.WriteLine($"Medicine Article = {item}");
            //}

            //select * from medicine cross join producer

            //var get8 = task.Medicine.SelectMany(medicine => task.Producer, (medicine, Producer) =>
            //new { medicine = medicine.Name, Producer = Producer.Name }).ToList();
            //foreach (var item in get8)
            //    Console.WriteLine($"Medicine Name = {item.medicine} Producer Name = {item.Producer}");

            //select name from medicine
            //group by count
            //having count >= 2

            //var get9 = task.Medicine.Where(m => m.count >= 2).GroupBy(m => m.count).ToList()
            //    .Select(group =>
            //    new
            //    {
            //        count = group.Key

            //    });

            //foreach (var item in get9)
            //{
            //    Console.WriteLine($"Medicine Name = {item.count}");
            //}

            //select Name from medicine where medicine.count < MIN(select licenseNum from producer)

            //var get10 = task.Medicine.Where(m => m.count < task.Producer.Min(l => l.licenseNum)).ToList();

            //foreach (var item in get10)
            //{
            //    Console.WriteLine($"Medicine Name = {item.Name}");
            //}

            //any

            //bool result = task.Producer.Any(l => l.licenseNum > 10);

            //Console.WriteLine(result);

            //count

            //int result1 = task.Producer.Where(l => l.licenseNum > 10).Count();

            //Console.WriteLine(result1);


            //AsNoTracking

            //var obj = task.Producer.AsNoTracking().Where(l => l.licenseNum == 10).ToList();

            //if (obj != null)
            //{
            //    foreach (var item in obj)
            //    {
            //        Console.WriteLine(item.Name);
            //    }



            //}

            //var obj1 = task.Producer.AsNoTracking().Where(l => l.licenseNum == 10).First();

            //if (obj != null)
            //{
            //    obj1.licenseNum = 999;
            //    task.Update(obj1);
            //    task.SaveChanges();

            //}

            //Eager

            //Producer producer = new Producer { Name = "NewProd1", licenseNum = 100 };
            //Producer producer1 = new Producer { Name = "NewProd2", licenseNum = 200 };

            //task.Producer.AddRange(producer,producer1);

            //Medicine medicine1 = new Medicine { Article = 100, Name = "Test1", 
            //                                    expDate = DateTime.Today, count = 100, receipeneed = false,temperature = 100, 
            //                                    producer = producer};

            //Medicine medicine2 = new Medicine
            //{
            //    Article = 200,
            //    Name = "Test2",
            //    expDate = DateTime.Today,
            //    count = 200,
            //    receipeneed = false,
            //    temperature = 200,
            //    producer = producer1
            //};

            //task.Medicine.AddRange(medicine1, medicine2);

            //task.SaveChanges();

            //var medicine = task.Medicine
            //    .Include(p => p.producer)
            //    .ToList();
            //foreach (var item in medicine)
            //{
            //    Console.WriteLine($"medicine name = {item.Name} - prodName = {item.producer.Name}");
            //}


            //Explicit

            //Producer producer = task.Producer.FirstOrDefault();
            //if(producer != null)
            //{
            //    task.Medicine.Where(m => m.producer.ID == producer.ID).Load();

            //    Console.WriteLine($"Producer: {producer.Name}");
            //    foreach (var item in producer.medicines)
            //    {
            //        Console.WriteLine($"MedicineName = {item.Name}");
            //    }


            //}

            //go
            //create proc GetProfit
            //@profit money out
            //    as
            //    set @profit = (select Sum(Bill.final_price) from bill)
            //    go
            //    declare @profit money
            //    exec GetProfit @profit out
            //    print(@profit)


            //SqlParameter sqlParameter = new()
            //{
            //    ParameterName = "@profit",
            //    SqlDbType = System.Data.SqlDbType.Money,
            //    Direction = System.Data.ParameterDirection.Output

            //};
            //task.Database.ExecuteSqlRaw("GetProfit @profit OUT", sqlParameter);
            //Console.WriteLine(sqlParameter.Value);

            //go
            //            create function MedicineCount()
            //returns int
            //as
            //begin
            //return (select medicine.count() from medicine)

            //end
            //go
            //select dbo.MedicineCount() as MedicineCount
            //go


           // var getfunc = task.Database.ExecuteSqlRaw("select dbo.MedicineCount()");

           //Console.WriteLine(getfunc);
           


        }
    }


}
public class ApplicationContext : DbContext
{
    public DbSet<Shopper> Shopper { get; set; } = null!;
    public DbSet<Pharmacist> Pharmacist { get; set; } = null!;

    public DbSet<Admin> Admin { get; set; } = null!;

    public DbSet<Recipe> Recipe { get; set; } = null!;

    public DbSet<Bill> Bill { get; set; } = null!;

    public DbSet<medicineList> medicineList { get; set; } = null!;

    public DbSet<Medicine> Medicine { get; set; } = null!;

    public DbSet<Producer> Producer { get; set; } = null!;

    public DbSet<GoodsInStorage> GoodsInStorage { get; set;} = null!;



    public ApplicationContext()
    {
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
                 .AddJsonFile($"appsettings.json", true, true).Build();
        optionsBuilder
            //.UseLazyLoadingProxies()
            .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Zoo>().ToTable(t => t.HasCheckConstraint("Workers_Ammount", "[Workers_Ammount] > 0"));

        modelBuilder.Entity<Shopper>()
            .ToTable(t => t.HasCheckConstraint("discountValue", "[discountValue] <= 1"));
        modelBuilder.Entity<Bill>()
            .ToTable(t => t.HasCheckConstraint("finalPrice", "[finalPrice] > 0"));
        modelBuilder.Entity<medicineList>()
            .ToTable(t => t.HasCheckConstraint("price", "[price] > 0"));
        modelBuilder.Entity<medicineList>()
            .ToTable(t => t.HasCheckConstraint("count", "[count] > 0"));
        modelBuilder.Entity<Medicine>()
            .ToTable(t => t.HasCheckConstraint("count", "[count] > 0"));


        //Shopper shopper = new Shopper { phoneNum = "0930991212" };
        //Pharmacist pharmacist = new Pharmacist { ID = 2, Name = "Belenko Nikola Petrovich" };
        //Producer producer = new Producer { ID = 2, Name = "Bayer", licenseNum = 123 };

        //modelBuilder.Entity<Shopper>().HasData(shopper);
        //modelBuilder.Entity<Pharmacist>().HasData(pharmacist);
        //modelBuilder.Entity<Producer>().HasData(producer);

        modelBuilder.Entity<Shopper>()
            .HasMany(e => e.bills)
            .WithOne(e => e.shopper)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Producer>()
            .HasMany(e => e.medicines)
            .WithOne(e => e.producer)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Bill>()
            .HasOne(e => e.pharmacist)
            .WithMany(b => b.bills)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<medicineList>()
            .HasMany(e => e.listifmedlists)
            .WithMany(e => e.medicineLists)
            .UsingEntity(j => j.ToTable("ListToList"));




    }


}



