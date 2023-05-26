using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FaithWebApp.Server.Models;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountLedger> AccountLedgers { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillDetail> BillDetails { get; set; }

    public virtual DbSet<BillHeader> BillHeaders { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public DbSet<CClient> Clients { get; set; }

    public virtual DbSet<ClientType> ClientTypes { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobPayorder> JobPayorders { get; set; }

    public virtual DbSet<Lolo> Lolos { get; set; }

    public virtual DbSet<PayorderHeader> PayorderHeaders { get; set; }

    public virtual DbSet<Pid> Pids { get; set; }

    public virtual DbSet<PidBill> PidBills { get; set; }

    public virtual DbSet<PidBillDetail> PidBillDetails { get; set; }

    public virtual DbSet<PidPayorder> PidPayorders { get; set; }

    public virtual DbSet<Psqcacertificate> Psqcacertificates { get; set; }

    public virtual DbSet<PsqcauthPerson> PsqcauthPeople { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SalesTaxInvoice> SalesTaxInvoices { get; set; }

    public virtual DbSet<ShippingLine> ShippingLines { get; set; }

    public virtual DbSet<Terminal> Terminals { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountLedger>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__AccountL__55433A4B771EB0BD");

            entity.ToTable("AccountLedger");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Drcr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("drcr");
            entity.Property(e => e.Particular).HasMaxLength(150);
            entity.Property(e => e.TransactionDate).HasColumnType("date");

            entity.HasOne(d => d.Client).WithMany(p => p.AccountLedgers)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Clients");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.BillDate).HasColumnType("date");
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.SalesTaxRate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Job).WithMany(p => p.Bills)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Bills_Jobs");
        });

        modelBuilder.Entity<BillDetail>(entity =>
        {
            entity.HasKey(e => e.BillDetailsId);

            entity.Property(e => e.BillDetailsId).HasColumnName("BillDetailsID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.Particulars).HasMaxLength(250);
            entity.Property(e => e.ReceiptNo).HasMaxLength(250);

            entity.HasOne(d => d.Bill).WithMany(p => p.BillDetails)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("FK_BillDetails_Bills");
        });

        modelBuilder.Entity<BillHeader>(entity =>
        {
            entity.HasKey(e => e.HeadId);

            entity.Property(e => e.HeadId).HasColumnName("HeadID");
            entity.Property(e => e.BillHead).HasMaxLength(250);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName).HasMaxLength(50);
        });

        modelBuilder.Entity<CClient>(entity =>
        {
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.AuthorizedPerson).HasMaxLength(150);
            entity.Property(e => e.ClientName).HasMaxLength(250);
            entity.Property(e => e.ClientType).HasMaxLength(50);
            entity.Property(e => e.Cnic)
                .HasMaxLength(20)
                .HasColumnName("CNIC");
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.Designation).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.Gst)
                .HasMaxLength(50)
                .HasColumnName("GST");
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Ntn)
                .HasMaxLength(50)
                .HasColumnName("NTN");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.StandAddress).HasMaxLength(500);

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.City)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_Cities");
        });

        modelBuilder.Entity<ClientType>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.AddCustomDuty).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Cess).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomDuty).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Hscode)
                .HasMaxLength(15)
                .HasColumnName("HSCode");
            entity.Property(e => e.IncomeTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ItemName).HasMaxLength(150);
            entity.Property(e => e.Rd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("RD");
            entity.Property(e => e.Rdtype).HasColumnName("RDType");
            entity.Property(e => e.SalesTax).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.AddCustomDutyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AddCustomDutyType).HasMaxLength(5);
            entity.Property(e => e.Bl)
                .HasMaxLength(50)
                .HasColumnName("BL");
            entity.Property(e => e.Bldate)
                .HasColumnType("date")
                .HasColumnName("BLDate");
            entity.Property(e => e.Cash).HasMaxLength(100);
            entity.Property(e => e.CashDate).HasColumnType("date");
            entity.Property(e => e.CessRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CessType).HasMaxLength(5);
            entity.Property(e => e.CustomDutyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomDutyType).HasMaxLength(5);
            entity.Property(e => e.ExchangeRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Gd)
                .HasMaxLength(100)
                .HasColumnName("GD");
            entity.Property(e => e.Gddate)
                .HasColumnType("date")
                .HasColumnName("GDDate");
            entity.Property(e => e.Igm).HasColumnName("IGM");
            entity.Property(e => e.Igmdate)
                .HasColumnType("date")
                .HasColumnName("IGMDate");
            entity.Property(e => e.ImportValuePkr).HasColumnName("ImportValuePKR");
            entity.Property(e => e.IncomeTaxRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IncomeTaxType).HasMaxLength(5);
            entity.Property(e => e.InvoiceValueUsd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("InvoiceValueUSD");
            entity.Property(e => e.ItemDetail).HasMaxLength(250);
            entity.Property(e => e.JobDate).HasColumnType("date");
            entity.Property(e => e.Lc)
                .HasMaxLength(50)
                .HasColumnName("LC");
            entity.Property(e => e.Lcdate)
                .HasColumnType("date")
                .HasColumnName("LCDate");
            entity.Property(e => e.Packages).HasMaxLength(150);
            entity.Property(e => e.Rd).HasColumnName("RD");
            entity.Property(e => e.Rdrate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("RDRate");
            entity.Property(e => e.Rdtype)
                .HasMaxLength(5)
                .HasColumnName("RDType");
            entity.Property(e => e.SalesTaxRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalesTaxType).HasMaxLength(5);
            entity.Property(e => e.ValueInPkr).HasColumnName("ValueInPKR");
            entity.Property(e => e.Vessel).HasMaxLength(50);

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jobs_Clients");

            entity.HasOne(d => d.ItemNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.Item)
                .HasConstraintName("FK_Jobs_Item");

            entity.HasOne(d => d.LoloNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.Lolo)
                .HasConstraintName("FK_Jobs_LOLOs");

            entity.HasOne(d => d.ShippingLineNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.ShippingLine)
                .HasConstraintName("FK_Jobs_ShippingLines");

            entity.HasOne(d => d.TerminalNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.Terminal)
                .HasConstraintName("FK_Jobs_Terminal");
        });

        modelBuilder.Entity<JobPayorder>(entity =>
        {
            entity.HasKey(e => e.PayorderId);

            entity.Property(e => e.PayorderId).HasColumnName("PayorderID");
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.Particular).HasMaxLength(250);

            entity.HasOne(d => d.Job).WithMany(p => p.JobPayorders)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_JobPayorders_Jobs");
        });

        modelBuilder.Entity<Lolo>(entity =>
        {
            entity.ToTable("LOLOs");

            entity.Property(e => e.LoloId).HasColumnName("LoloID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LoloName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.ShortName).HasMaxLength(50);
        });

        modelBuilder.Entity<PayorderHeader>(entity =>
        {
            entity.HasKey(e => e.HeaderId);

            entity.Property(e => e.HeaderId).HasColumnName("HeaderID");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.PayorderDetail).HasMaxLength(250);
        });

        modelBuilder.Entity<Pid>(entity =>
        {
            entity.Property(e => e.PidId).HasColumnName("PidID");
            entity.Property(e => e.AddCustomDutyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AddCustomDutyType).HasMaxLength(5);
            entity.Property(e => e.Bl)
                .HasMaxLength(50)
                .HasColumnName("BL");
            entity.Property(e => e.Bldate)
                .HasColumnType("date")
                .HasColumnName("BLDate");
            entity.Property(e => e.Cash).HasMaxLength(100);
            entity.Property(e => e.CashDate).HasColumnType("date");
            entity.Property(e => e.CessRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CessType).HasMaxLength(5);
            entity.Property(e => e.CustomDutyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomDutyType).HasMaxLength(5);
            entity.Property(e => e.ExchangeRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Gd)
                .HasMaxLength(100)
                .HasColumnName("GD");
            entity.Property(e => e.Gddate)
                .HasColumnType("date")
                .HasColumnName("GDDate");
            entity.Property(e => e.Igm).HasColumnName("IGM");
            entity.Property(e => e.Igmdate)
                .HasColumnType("date")
                .HasColumnName("IGMDate");
            entity.Property(e => e.ImportValuePkr).HasColumnName("ImportValuePKR");
            entity.Property(e => e.IncomeTaxRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IncomeTaxType).HasMaxLength(5);
            entity.Property(e => e.InvoiceValueUsd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("InvoiceValueUSD");
            entity.Property(e => e.ItemDetail).HasMaxLength(250);
            entity.Property(e => e.Lc)
                .HasMaxLength(50)
                .HasColumnName("LC");
            entity.Property(e => e.Lcdate)
                .HasColumnType("date")
                .HasColumnName("LCDate");
            entity.Property(e => e.Packages).HasMaxLength(150);
            entity.Property(e => e.PidDate).HasColumnType("date");
            entity.Property(e => e.Rd).HasColumnName("RD");
            entity.Property(e => e.Rdrate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("RDRate");
            entity.Property(e => e.Rdtype)
                .HasMaxLength(5)
                .HasColumnName("RDType");
            entity.Property(e => e.SalesTaxRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalesTaxType).HasMaxLength(5);
            entity.Property(e => e.ValueInPkr).HasColumnName("ValueInPKR");
            entity.Property(e => e.Vessel).HasMaxLength(50);

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Pids)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pids_Clients");

            entity.HasOne(d => d.ItemNavigation).WithMany(p => p.Pids)
                .HasForeignKey(d => d.Item)
                .HasConstraintName("FK_Pids_Item");

            entity.HasOne(d => d.LoloNavigation).WithMany(p => p.Pids)
                .HasForeignKey(d => d.Lolo)
                .HasConstraintName("FK_Pids_Lolo");

            entity.HasOne(d => d.ShippingLineNavigation).WithMany(p => p.Pids)
                .HasForeignKey(d => d.ShippingLine)
                .HasConstraintName("FK_Pids_ShippingLine");

            entity.HasOne(d => d.TerminalNavigation).WithMany(p => p.Pids)
                .HasForeignKey(d => d.Terminal)
                .HasConstraintName("FK_Pids_Terminal");
        });

        modelBuilder.Entity<PidBill>(entity =>
        {
            entity.HasKey(e => e.BillId);

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.BillDate).HasColumnType("date");
            entity.Property(e => e.PidId).HasColumnName("PidID");

            entity.HasOne(d => d.Pid).WithMany(p => p.PidBills)
                .HasForeignKey(d => d.PidId)
                .HasConstraintName("FK_PidBills_Pids");
        });

        modelBuilder.Entity<PidBillDetail>(entity =>
        {
            entity.HasKey(e => e.BillDetailsId);

            entity.Property(e => e.BillDetailsId).HasColumnName("BillDetailsID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.Particulars).HasMaxLength(250);
            entity.Property(e => e.ReceiptNo).HasMaxLength(250);

            entity.HasOne(d => d.Bill).WithMany(p => p.PidBillDetails)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("FK_PidBillDetails_PidBills");
        });

        modelBuilder.Entity<PidPayorder>(entity =>
        {
            entity.HasKey(e => e.PayorderId).HasName("PK_PIDPayorders");

            entity.Property(e => e.PayorderId).HasColumnName("PayorderID");
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.Particular).HasMaxLength(250);
            entity.Property(e => e.PidId).HasColumnName("PidID");

            entity.HasOne(d => d.Pid).WithMany(p => p.PidPayorders)
                .HasForeignKey(d => d.PidId)
                .HasConstraintName("FK_PIDPayorders_Pids");
        });

        modelBuilder.Entity<Psqcacertificate>(entity =>
        {
            entity.HasKey(e => e.Psqcid);

            entity.ToTable("PSQCACertificate");

            entity.Property(e => e.Psqcid).HasColumnName("PSQCID");
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.Invoice).HasMaxLength(50);
            entity.Property(e => e.InvoiceDate).HasColumnType("date");
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.Origin).HasMaxLength(50);

            entity.HasOne(d => d.AuthorizedPersonNavigation).WithMany(p => p.Psqcacertificates)
                .HasForeignKey(d => d.AuthorizedPerson)
                .HasConstraintName("FK_PSQCACertificate_PSQCAuthPerson");
        });

        modelBuilder.Entity<PsqcauthPerson>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.ToTable("PSQCAuthPerson");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Nic)
                .HasMaxLength(50)
                .HasColumnName("NIC");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A27DB4523");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(50);
        });

        modelBuilder.Entity<SalesTaxInvoice>(entity =>
        {
            entity.HasKey(e => e.Stid);

            entity.ToTable("SalesTaxInvoice");

            entity.Property(e => e.Stid).HasColumnName("STID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Stdate)
                .HasColumnType("date")
                .HasColumnName("STDate");

            entity.HasOne(d => d.Bill).WithMany(p => p.SalesTaxInvoices)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("FK_SalesTaxInvoice_Bills");
        });

        modelBuilder.Entity<ShippingLine>(entity =>
        {
            entity.Property(e => e.ShippingLineId).HasColumnName("ShippingLineID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.ShippingLineName).HasMaxLength(100);
            entity.Property(e => e.ShortName).HasMaxLength(50);
        });

        modelBuilder.Entity<Terminal>(entity =>
        {
            entity.Property(e => e.TerminalId).HasColumnName("TerminalID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.ShortName).HasMaxLength(50);
            entity.Property(e => e.TerminalName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC755FC424");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
