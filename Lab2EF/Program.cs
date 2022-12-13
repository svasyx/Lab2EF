using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System;
using System.Linq;
using System.IO;


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

    public List<medicineList> medicineLists { get; set; } = new();

}


public class Program
{
    static void Main()
    {
        using ApplicationContext applicationContext = new();

        //applicationContext.Pharmacist.Add(new Pharmacist { Name = "Some1"});
        //applicationContext.Pharmacist.Update(new Pharmacist { ID = 1, Name = "New1"});
        //applicationContext.SaveChanges();
        //var get = applicationContext.Pharmacist.Where(e => e.ID == 1).First();
        //applicationContext.Pharmacist.Remove(get);
        //applicationContext.SaveChanges();

        

    }
}
public class ApplicationContext : DbContext
{
    public DbSet<Shopper> Shopper { get; set; } = null!;
    public DbSet<Pharmacist> Pharmacist { get; set; } = null!;

    public DbSet<Recipe> Recipe { get; set; } = null!;

    public DbSet<Bill> Bill { get; set; } = null!;

    public DbSet<medicineList> medicineList { get; set; } = null!;

    public DbSet<Medicine> Medicine { get; set; } = null!;

    public DbSet<Producer> Producer { get; set; } = null!;



    public ApplicationContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
                 .AddJsonFile($"appsettings.json", true, true).Build();
        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Zoo>().ToTable(t => t.HasCheckConstraint("Workers_Ammount", "[Workers_Ammount] > 0"));

        modelBuilder.Entity<Shopper>().ToTable(t => t.HasCheckConstraint("discountValue", "[discountValue] <= 1"));
        modelBuilder.Entity<Bill>().ToTable(t => t.HasCheckConstraint("finalPrice", "[finalPrice] > 0"));
        modelBuilder.Entity<medicineList>().ToTable(t => t.HasCheckConstraint("price", "[price] > 0"));
        modelBuilder.Entity<medicineList>().ToTable(t => t.HasCheckConstraint("count", "[count] > 0"));
        modelBuilder.Entity<Medicine>().ToTable(t => t.HasCheckConstraint("count", "[count] > 0"));

        //Shopper shopper = new Shopper { phoneNum = "0930991212" };
        //Pharmacist pharmacist = new Pharmacist { Name = "Belenko Nikola Petrovich" };
        //Producer producer = new Producer { Name = "Bayer", licenseNum = 123 };

        //modelBuilder.Entity<Shopper>().HasData(shopper);
        //modelBuilder.Entity<Pharmacist>().HasData(pharmacist);
        //modelBuilder.Entity<Producer>().HasData(producer);

        modelBuilder.Entity<Shopper>().HasMany(e => e.bills).WithOne(e => e.shopper);
        modelBuilder.Entity<Producer>().HasMany(e => e.medicines).WithOne(e => e.producer);
        modelBuilder.Entity<Bill>().HasOne(e => e.pharmacist).WithMany(b => b.bills);

        modelBuilder.Entity<medicineList>().HasMany(e => e.listifmedlists).WithMany(e => e.medicineLists);
       




    }


}
