﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RetrievingTooMuchData.DataAccess.Mapping
{
    // SalesPerson
    internal class SalesPersonConfiguration : EntityTypeConfiguration<SalesPerson>
    {
        public SalesPersonConfiguration(string schema = "Sales")
        {
            ToTable(schema + ".SalesPerson");
            HasKey(x => x.BusinessEntityId);

            Property(x => x.BusinessEntityId).HasColumnName("BusinessEntityID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TerritoryId).HasColumnName("TerritoryID").IsOptional();
            Property(x => x.SalesQuota).HasColumnName("SalesQuota").IsOptional().HasPrecision(19, 4);
            Property(x => x.Bonus).HasColumnName("Bonus").IsRequired().HasPrecision(19, 4);
            Property(x => x.CommissionPct).HasColumnName("CommissionPct").IsRequired().HasPrecision(10, 4);
            Property(x => x.SalesYtd).HasColumnName("SalesYTD").IsRequired().HasPrecision(19, 4);
            Property(x => x.SalesLastYear).HasColumnName("SalesLastYear").IsRequired().HasPrecision(19, 4);
            Property(x => x.Rowguid).HasColumnName("rowguid").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsRequired();
        }
    }

    // SalesOrderHeader
    internal class SalesOrderHeaderConfiguration : EntityTypeConfiguration<SalesOrderHeader>
    {
        public SalesOrderHeaderConfiguration(string schema = "Sales")
        {
            ToTable(schema + ".SalesOrderHeader");
            HasKey(x => x.SalesOrderId);

            Property(x => x.SalesOrderId).HasColumnName("SalesOrderID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RevisionNumber).HasColumnName("RevisionNumber").IsRequired();
            Property(x => x.OrderDate).HasColumnName("OrderDate").IsRequired();
            Property(x => x.DueDate).HasColumnName("DueDate").IsRequired();
            Property(x => x.ShipDate).HasColumnName("ShipDate").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsRequired();
            Property(x => x.OnlineOrderFlag).HasColumnName("OnlineOrderFlag").IsRequired();
            Property(x => x.SalesOrderNumber).HasColumnName("SalesOrderNumber").IsRequired().HasMaxLength(25).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.PurchaseOrderNumber).HasColumnName("PurchaseOrderNumber").IsOptional().HasMaxLength(25);
            Property(x => x.AccountNumber).HasColumnName("AccountNumber").IsOptional().HasMaxLength(15);
            Property(x => x.CustomerId).HasColumnName("CustomerID").IsRequired();
            Property(x => x.SalesPersonId).HasColumnName("SalesPersonID").IsOptional();
            Property(x => x.TerritoryId).HasColumnName("TerritoryID").IsOptional();
            Property(x => x.BillToAddressId).HasColumnName("BillToAddressID").IsRequired();
            Property(x => x.ShipToAddressId).HasColumnName("ShipToAddressID").IsRequired();
            Property(x => x.ShipMethodId).HasColumnName("ShipMethodID").IsRequired();
            Property(x => x.CreditCardId).HasColumnName("CreditCardID").IsOptional();
            Property(x => x.CreditCardApprovalCode).HasColumnName("CreditCardApprovalCode").IsOptional().IsUnicode(false).HasMaxLength(15);
            Property(x => x.CurrencyRateId).HasColumnName("CurrencyRateID").IsOptional();
            Property(x => x.SubTotal).HasColumnName("SubTotal").IsRequired().HasPrecision(19, 4);
            Property(x => x.TaxAmt).HasColumnName("TaxAmt").IsRequired().HasPrecision(19, 4);
            Property(x => x.Freight).HasColumnName("Freight").IsRequired().HasPrecision(19, 4);
            Property(x => x.TotalDue).HasColumnName("TotalDue").IsRequired().HasPrecision(19, 4).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Comment).HasColumnName("Comment").IsOptional().HasMaxLength(128);
            Property(x => x.Rowguid).HasColumnName("rowguid").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsRequired();

            HasOptional(a => a.SalesPerson).WithMany(b => b.SalesOrderHeaders).HasForeignKey(c => c.SalesPersonId); // FK_SalesOrderHeader_SalesPerson_SalesPersonID
        }
    }
}