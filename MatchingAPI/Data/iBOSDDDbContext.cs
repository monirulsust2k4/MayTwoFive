using System;
using System.Collections.Generic;
using MatchingAPI.Data.Entity.iBOSDDD;
using Microsoft.EntityFrameworkCore;

namespace MatchingAPI.Data;

public partial class iBOSDDDbContext : DbContext
{
    public iBOSDDDbContext()
    {
    }

    public iBOSDDDbContext(DbContextOptions<iBOSDDDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEmailSend> TblEmailSends { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblVessel> TblVessels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.209.99.244;Initial Catalog=iBOSDDD;User ID=isukisespts3vapp8dt;Password=wsa0str1vpo@8d5ws;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEmailSend>(entity =>
        {
            entity.HasKey(e => e.IntEmailId);

            entity.ToTable("tblEmailSend", "dco");

            entity.HasIndex(e => new { e.IntEmailId, e.IntMailTypeId, e.DteSendTime, e.YsnHtml }, "nciEmailSend").IsUnique();

            entity.Property(e => e.IntEmailId).HasColumnName("intEmailID");
            entity.Property(e => e.DteInsertTime)
                .HasColumnType("datetime")
                .HasColumnName("dteInsertTime");
            entity.Property(e => e.DteSendTime)
                .HasColumnType("datetime")
                .HasColumnName("dteSendTime");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntMailTypeId).HasColumnName("intMailTypeID");
            entity.Property(e => e.IntPartnerId).HasColumnName("intPartnerId");
            entity.Property(e => e.IntPartnerTypeId).HasColumnName("intPartnerTypeId");
            entity.Property(e => e.IntUnitId).HasColumnName("intUnitId");
            entity.Property(e => e.StrBcemailAdd)
                .IsUnicode(false)
                .HasColumnName("strBCEmailAdd");
            entity.Property(e => e.StrBody)
                .IsUnicode(false)
                .HasColumnName("strBody");
            entity.Property(e => e.StrCcemailAdd)
                .IsUnicode(false)
                .HasColumnName("strCCEmailAdd");
            entity.Property(e => e.StrEmailAdd)
                .IsUnicode(false)
                .HasColumnName("strEmailAdd");
            entity.Property(e => e.StrEmailProfile)
                .HasMaxLength(50)
                .HasColumnName("strEmailProfile");
            entity.Property(e => e.StrFilePath)
                .IsUnicode(false)
                .HasColumnName("strFilePath");
            entity.Property(e => e.StrPartnerName)
                .HasMaxLength(150)
                .HasColumnName("strPartnerName");
            entity.Property(e => e.StrSubject)
                .IsUnicode(false)
                .HasColumnName("strSubject");
            entity.Property(e => e.YsnHtml).HasColumnName("ysnHTML");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.IntUserId);

            entity.ToTable("tblUser", "dco");

            entity.Property(e => e.IntUserId).HasColumnName("intUserId");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DtePasswordExpDate).HasColumnName("dtePasswordExpDate");
            entity.Property(e => e.DteServerDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IntCountryId).HasColumnName("intCountryId");
            entity.Property(e => e.IntDefaultBusinessUnit).HasColumnName("intDefaultBusinessUnit");
            entity.Property(e => e.IntUpdatedBy).HasColumnName("intUpdatedBy");
            entity.Property(e => e.IntUserReferenceId).HasColumnName("intUserReferenceId");
            entity.Property(e => e.IntUserType).HasColumnName("intUserType");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsApproveIhb)
                .HasDefaultValue(false)
                .HasColumnName("isApproveIHB");
            entity.Property(e => e.IsDefaultPassword)
                .HasDefaultValue(true)
                .HasColumnName("isDefaultPassword");
            entity.Property(e => e.IsFeatureUser)
                .HasDefaultValue(false)
                .HasColumnName("isFeatureUser");
            entity.Property(e => e.IsForceLogout)
                .HasDefaultValue(false)
                .HasColumnName("isForceLogout");
            entity.Property(e => e.IsMgt).HasColumnName("isMGT");
            entity.Property(e => e.IsOtp).HasColumnName("isOTP");
            entity.Property(e => e.IsSuperUser)
                .HasDefaultValue(false)
                .HasColumnName("isSuperUser");
            entity.Property(e => e.StrContact)
                .HasMaxLength(50)
                .HasColumnName("strContact");
            entity.Property(e => e.StrCountryName)
                .HasMaxLength(50)
                .HasColumnName("strCountryName");
            entity.Property(e => e.StrEmailAddress)
                .HasMaxLength(100)
                .HasColumnName("strEmailAddress");
            entity.Property(e => e.StrLoginId)
                .HasMaxLength(50)
                .HasColumnName("strLoginId");
            entity.Property(e => e.StrPassword)
                .HasMaxLength(50)
                .HasColumnName("strPassword");
            entity.Property(e => e.StrUserImageFile).HasColumnName("strUserImageFile");
            entity.Property(e => e.StrUserName)
                .HasMaxLength(100)
                .HasColumnName("strUserName");
            entity.Property(e => e.StrUserNidno)
                .HasMaxLength(50)
                .HasColumnName("strUserNIDNo");
            entity.Property(e => e.StrUserReferenceNo)
                .HasMaxLength(50)
                .HasColumnName("strUserReferenceNo");
        });

        modelBuilder.Entity<TblVessel>(entity =>
        {
            entity.HasKey(e => e.IntVesselId);

            entity.ToTable("tblVessel", "ihcm");

            entity.Property(e => e.IntVesselId).HasColumnName("intVesselId");
            entity.Property(e => e.DteLastActionTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionTime");
            entity.Property(e => e.DteServerDatetime)
                .HasColumnType("datetime")
                .HasColumnName("dteServerDatetime");
            entity.Property(e => e.DteYearOfBuilt)
                .HasMaxLength(100)
                .HasColumnName("dteYearOfBuilt");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");
            entity.Property(e => e.IntCostCenterId)
                .HasDefaultValue(0L)
                .HasColumnName("intCostCenterId");
            entity.Property(e => e.IntFlagId).HasColumnName("intFlagId");
            entity.Property(e => e.IntInsertby).HasColumnName("intInsertby");
            entity.Property(e => e.IntOwnerId).HasColumnName("intOwnerId");
            entity.Property(e => e.IntProfitCenterId).HasColumnName("intProfitCenterId");
            entity.Property(e => e.IntRevenueCenterId).HasColumnName("intRevenueCenterId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsOtherInfo).HasColumnName("isOtherInfo");
            entity.Property(e => e.IsOwnVessel).HasColumnName("isOwnVessel");
            entity.Property(e => e.NumBallastSpeed)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("numBallastSpeed");
            entity.Property(e => e.NumBeam)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numBeam");
            entity.Property(e => e.NumDeadWeight)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numDeadWeight");
            entity.Property(e => e.NumDepth)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numDepth");
            entity.Property(e => e.NumGrt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numGRT");
            entity.Property(e => e.NumHoldCubicBale)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numHoldCubicBale");
            entity.Property(e => e.NumHoldCubicGrain)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numHoldCubicGrain");
            entity.Property(e => e.NumHoldsLengthBreadth)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numHoldsLengthBreadth");
            entity.Property(e => e.NumIfoatportIdle)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("numIFOatportIdle");
            entity.Property(e => e.NumIfoatportWorking)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("numIFOatportWorking");
            entity.Property(e => e.NumIfoatsea)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("numIFOatsea");
            entity.Property(e => e.NumImono)
                .HasMaxLength(100)
                .HasColumnName("numIMONo");
            entity.Property(e => e.NumLadenSpeed)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("numLadenSpeed");
            entity.Property(e => e.NumLbp)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numLBP");
            entity.Property(e => e.NumLoa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numLOA");
            entity.Property(e => e.NumMgoatSea)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("numMGOatSea");
            entity.Property(e => e.NumMgoatportIdle)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("numMGOatport_Idle");
            entity.Property(e => e.NumMgoatportWorking)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("numMGOatportWorking");
            entity.Property(e => e.NumNrt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numNRT");
            entity.Property(e => e.NumUpperDeckStrength)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("numUpperDeckStrength");
            entity.Property(e => e.StrActual)
                .HasMaxLength(100)
                .HasColumnName("strActual");
            entity.Property(e => e.StrCallSign)
                .HasMaxLength(100)
                .HasColumnName("strCallSIgn");
            entity.Property(e => e.StrClassName)
                .HasMaxLength(100)
                .HasColumnName("strClassName");
            entity.Property(e => e.StrCostCenterName)
                .HasMaxLength(150)
                .HasColumnName("strCostCenterName");
            entity.Property(e => e.StrCranes)
                .HasMaxLength(100)
                .HasColumnName("strCranes");
            entity.Property(e => e.StrEcoAndConsumptionAtSea)
                .HasMaxLength(100)
                .HasColumnName("strEcoAndConsumptionAtSea");
            entity.Property(e => e.StrFlag)
                .HasMaxLength(100)
                .HasColumnName("strFlag");
            entity.Property(e => e.StrGrabs)
                .HasMaxLength(100)
                .HasColumnName("strGrabs");
            entity.Property(e => e.StrHatchCover)
                .HasMaxLength(100)
                .HasColumnName("strHatchCover");
            entity.Property(e => e.StrHatchCoverLengthBreadth)
                .HasMaxLength(100)
                .HasColumnName("strHatchCoverLengthBreadth");
            entity.Property(e => e.StrHatchCoverStrength)
                .HasMaxLength(100)
                .HasColumnName("strHatchCoverStrength");
            entity.Property(e => e.StrInPortWorking)
                .HasMaxLength(100)
                .HasColumnName("strInPortWorking");
            entity.Property(e => e.StrOwnerName)
                .HasMaxLength(300)
                .HasColumnName("strOwnerName");
            entity.Property(e => e.StrPiclub)
                .HasMaxLength(100)
                .HasColumnName("strPIClub");
            entity.Property(e => e.StrProfitCenterName)
                .HasMaxLength(150)
                .HasColumnName("strProfitCenterName");
            entity.Property(e => e.StrRemarks)
                .HasMaxLength(100)
                .HasColumnName("strRemarks");
            entity.Property(e => e.StrRevenueCenterName)
                .HasMaxLength(150)
                .HasColumnName("strRevenueCenterName");
            entity.Property(e => e.StrShipYard)
                .HasMaxLength(100)
                .HasColumnName("strShipYard");
            entity.Property(e => e.StrSpeedAndConsumptionAtSea)
                .HasMaxLength(100)
                .HasColumnName("strSpeedAndConsumptionAtSea");
            entity.Property(e => e.StrTpconSummerFreeBoard)
                .HasMaxLength(100)
                .HasColumnName("strTPCOnSummerFreeBoard");
            entity.Property(e => e.StrVesselName)
                .HasMaxLength(300)
                .HasColumnName("strVesselName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
