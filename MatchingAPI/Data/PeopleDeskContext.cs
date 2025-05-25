using System;
using System.Collections.Generic;
using MatchingAPI.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace MatchingAPI.Data;

public partial class PeopleDeskContext : DbContext
{
    public PeopleDeskContext()
    {
    }

    public PeopleDeskContext(DbContextOptions<PeopleDeskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccountCategory> TblAccountCategories { get; set; }

    public virtual DbSet<TblAccountClass> TblAccountClasses { get; set; }

    public virtual DbSet<TblAccountGroup> TblAccountGroups { get; set; }

    public virtual DbSet<TblBusinessTransaction> TblBusinessTransactions { get; set; }

    public virtual DbSet<TblBusinessUnitGeneralLedger> TblBusinessUnitGeneralLedgers { get; set; }

    public virtual DbSet<TblCustomerType> TblCustomerTypes { get; set; }

    public virtual DbSet<TblDdlcommunity> TblDdlcommunities { get; set; }

    public virtual DbSet<TblDdlcountryList> TblDdlcountryLists { get; set; }

    public virtual DbSet<TblDdldietPreference> TblDdldietPreferences { get; set; }

    public virtual DbSet<TblDdlhighestQualification> TblDdlhighestQualifications { get; set; }

    public virtual DbSet<TblDdlhobbiesInterest> TblDdlhobbiesInterests { get; set; }

    public virtual DbSet<TblDdlmaritalStatus> TblDdlmaritalStatuses { get; set; }

    public virtual DbSet<TblDdlparentOccupation> TblDdlparentOccupations { get; set; }

    public virtual DbSet<TblDdlresidencyStatus> TblDdlresidencyStatuses { get; set; }

    public virtual DbSet<TblDdlsubCommunity> TblDdlsubCommunities { get; set; }

    public virtual DbSet<TblDdlworkDesignation> TblDdlworkDesignations { get; set; }

    public virtual DbSet<TblDdlworkIndustry> TblDdlworkIndustries { get; set; }

    public virtual DbSet<TblDistrict> TblDistricts { get; set; }

    public virtual DbSet<TblDivision> TblDivisions { get; set; }

    public virtual DbSet<TblGeneralLedger> TblGeneralLedgers { get; set; }

    public virtual DbSet<TblGeneralLedgerSubType> TblGeneralLedgerSubTypes { get; set; }

    public virtual DbSet<TblGeneralLedgerType> TblGeneralLedgerTypes { get; set; }

    public virtual DbSet<TblMasterDataForCode> TblMasterDataForCodes { get; set; }

    public virtual DbSet<TblPriceStructureGl> TblPriceStructureGls { get; set; }

    public virtual DbSet<TblReligion> TblReligions { get; set; }

    public virtual DbSet<TblSubscriptionPlan> TblSubscriptionPlans { get; set; }

    public virtual DbSet<TblSubscriptionPlanHeader> TblSubscriptionPlanHeaders { get; set; }

    public virtual DbSet<TblSubscriptionPlanRow> TblSubscriptionPlanRows { get; set; }

    public virtual DbSet<TblThana> TblThanas { get; set; }

    public virtual DbSet<TblUserEducationInformation> TblUserEducationInformations { get; set; }

    public virtual DbSet<TblUserHobbiesInterest> TblUserHobbiesInterests { get; set; }

    public virtual DbSet<TblUserPreferenceSummery> TblUserPreferenceSummeries { get; set; }

    public virtual DbSet<TblUserPreferredCommunity> TblUserPreferredCommunities { get; set; }

    public virtual DbSet<TblUserPreferredCountry> TblUserPreferredCountries { get; set; }

    public virtual DbSet<TblUserPreferredDiet> TblUserPreferredDiets { get; set; }

    public virtual DbSet<TblUserPreferredHobby> TblUserPreferredHobbies { get; set; }

    public virtual DbSet<TblUserPreferredMaritalStatus> TblUserPreferredMaritalStatuses { get; set; }

    public virtual DbSet<TblUserPreferredParentOccupation> TblUserPreferredParentOccupations { get; set; }

    public virtual DbSet<TblUserPreferredQualification> TblUserPreferredQualifications { get; set; }

    public virtual DbSet<TblUserPreferredResidencyStatus> TblUserPreferredResidencyStatuses { get; set; }

    public virtual DbSet<TblUserPreferredSubCommunity> TblUserPreferredSubCommunities { get; set; }

    public virtual DbSet<TblUserPreferredWorkDesignation> TblUserPreferredWorkDesignations { get; set; }

    public virtual DbSet<TblUserPreferredWorkIndustry> TblUserPreferredWorkIndustries { get; set; }

    public virtual DbSet<TblUserProfessionalDetail> TblUserProfessionalDetails { get; set; }

    public virtual DbSet<TblUserProfileSummery> TblUserProfileSummeries { get; set; }

    public virtual DbSet<TblUserWorkInformation> TblUserWorkInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=103.125.255.10,9433;Initial Catalog=marriage;User ID=mar;Password=matrimony@Mar1;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("mar");

        modelBuilder.Entity<TblAccountCategory>(entity =>
        {
            entity.HasKey(e => e.IntAccountCategoryId);

            entity.ToTable("tblAccountCategory");

            entity.Property(e => e.IntAccountCategoryId).HasColumnName("intAccountCategoryId");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DteServerDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.IntAccountClassId).HasColumnName("intAccountClassId");
            entity.Property(e => e.IntAccountGroupId).HasColumnName("intAccountGroupId");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.StrAccountCategoryCode)
                .HasMaxLength(50)
                .HasColumnName("strAccountCategoryCode");
            entity.Property(e => e.StrAccountCategoryName)
                .HasMaxLength(100)
                .HasColumnName("strAccountCategoryName");
            entity.Property(e => e.StrAccountClassCode)
                .HasMaxLength(50)
                .HasColumnName("strAccountClassCode");
            entity.Property(e => e.StrAccountGroupCode)
                .HasMaxLength(50)
                .HasColumnName("strAccountGroupCode");
        });

        modelBuilder.Entity<TblAccountClass>(entity =>
        {
            entity.HasKey(e => e.IntAccountClassId);

            entity.ToTable("tblAccountClass");

            entity.Property(e => e.IntAccountClassId).HasColumnName("intAccountClassId");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DteServerDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.IntAccountGroupId).HasColumnName("intAccountGroupId");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.StrAccountClassCode)
                .HasMaxLength(50)
                .HasColumnName("strAccountClassCode");
            entity.Property(e => e.StrAccountClassName)
                .HasMaxLength(100)
                .HasColumnName("strAccountClassName");
            entity.Property(e => e.StrAccountGroupCode)
                .HasMaxLength(50)
                .HasColumnName("strAccountGroupCode");
        });

        modelBuilder.Entity<TblAccountGroup>(entity =>
        {
            entity.HasKey(e => e.IntAccountGroupId);

            entity.ToTable("tblAccountGroup");

            entity.Property(e => e.IntAccountGroupId).HasColumnName("intAccountGroupId");
            entity.Property(e => e.IntAccountType).HasColumnName("intAccountType");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsIncomeStatementAccount).HasColumnName("isIncomeStatementAccount");
            entity.Property(e => e.StrAccountGroupCode)
                .HasMaxLength(50)
                .HasColumnName("strAccountGroupCode");
            entity.Property(e => e.StrAccountGroupName)
                .HasMaxLength(100)
                .HasColumnName("strAccountGroupName");
        });

        modelBuilder.Entity<TblBusinessTransaction>(entity =>
        {
            entity.HasKey(e => e.IntBusinessTransactionId);

            entity.ToTable("tblBusinessTransaction");

            entity.Property(e => e.IntBusinessTransactionId).HasColumnName("intBusinessTransactionId");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DteServerDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");
            entity.Property(e => e.IntGeneralLedgerId).HasColumnName("intGeneralLedgerId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsDefault)
                .HasDefaultValue(false)
                .HasColumnName("isDefault");
            entity.Property(e => e.IsInternalExpense).HasColumnName("isInternalExpense");
            entity.Property(e => e.StrBusinessTransactionCode)
                .HasMaxLength(50)
                .HasColumnName("strBusinessTransactionCode");
            entity.Property(e => e.StrBusinessTransactionName)
                .HasMaxLength(100)
                .HasColumnName("strBusinessTransactionName");
            entity.Property(e => e.StrGeneralLedgerCode)
                .HasMaxLength(50)
                .HasColumnName("strGeneralLedgerCode");
            entity.Property(e => e.StrGeneralLedgerName)
                .HasMaxLength(100)
                .HasColumnName("strGeneralLedgerName");
        });

        modelBuilder.Entity<TblBusinessUnitGeneralLedger>(entity =>
        {
            entity.HasKey(e => e.IntAutoId);

            entity.ToTable("tblBusinessUnitGeneralLedger");

            entity.Property(e => e.IntAutoId).HasColumnName("intAutoId");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DteServerDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");
            entity.Property(e => e.IntGeneralLedgerId).HasColumnName("intGeneralLedgerId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.NumCurrentBalance)
                .HasColumnType("numeric(18, 6)")
                .HasColumnName("numCurrentBalance");
            entity.Property(e => e.StrGeneralLedgerCode)
                .HasMaxLength(50)
                .HasColumnName("strGeneralLedgerCode");
            entity.Property(e => e.StrGeneralLedgerName)
                .HasMaxLength(100)
                .HasColumnName("strGeneralLedgerName");
        });

        modelBuilder.Entity<TblCustomerType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblCustomerType");

            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DteServerDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IntBusinessPartnerTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("intBusinessPartnerTypeID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrBusinessPartnerTypeName)
                .HasMaxLength(100)
                .HasColumnName("strBusinessPartnerTypeName");
        });

        modelBuilder.Entity<TblDdlcommunity>(entity =>
        {
            entity.HasKey(e => e.IntCommunityId).HasName("PK__tblCommu__E21CD3BAA001F247");

            entity.ToTable("tblDDLCommunity");

            entity.Property(e => e.IntCommunityId).HasColumnName("intCommunityId");
            entity.Property(e => e.DteLastActionDate)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDate");
            entity.Property(e => e.IntPreferencyTypeId).HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrCommunityName)
                .HasMaxLength(100)
                .HasColumnName("strCommunityName");
            entity.Property(e => e.StrCountry)
                .HasMaxLength(50)
                .HasColumnName("strCountry");
        });

        modelBuilder.Entity<TblDdlcountryList>(entity =>
        {
            entity.HasKey(e => e.IntCountryId).HasName("PK__tblCount__10D160BFCFCF0BC0");

            entity.ToTable("tblDDLCountryList");

            entity.Property(e => e.IntCountryId).HasColumnName("intCountryID");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(2L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrCountryName)
                .HasMaxLength(100)
                .HasColumnName("strCountryName");
            entity.Property(e => e.StrMotherLanguage)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("strMotherLanguage");
        });

        modelBuilder.Entity<TblDdldietPreference>(entity =>
        {
            entity.HasKey(e => e.IntDietId).HasName("PK__tblDDLDi__B7E1FBD5D73CD869");

            entity.ToTable("tblDDLDietPreferences");

            entity.Property(e => e.IntDietId).HasColumnName("intDietId");
            entity.Property(e => e.DteLastActionDate)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDate");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(3L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrDietType)
                .HasMaxLength(100)
                .HasColumnName("strDietType");
        });

        modelBuilder.Entity<TblDdlhighestQualification>(entity =>
        {
            entity.HasKey(e => e.IntQualificationId).HasName("PK__TblHighe__E8E9F936B01CCDE8");

            entity.ToTable("TblDDLHighestQualification");

            entity.Property(e => e.IntQualificationId).HasColumnName("intQualificationID");
            entity.Property(e => e.DteCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteCreatedDate");
            entity.Property(e => e.DteUpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteUpdatedDate");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(4L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StrFaculty)
                .HasMaxLength(255)
                .HasColumnName("strFaculty");
            entity.Property(e => e.StrQualificationName)
                .HasMaxLength(255)
                .HasColumnName("strQualificationName");
            entity.Property(e => e.StrQualificationType)
                .HasMaxLength(100)
                .HasColumnName("strQualificationType");
            entity.Property(e => e.StrSortOrder).HasColumnName("strSortOrder");
        });

        modelBuilder.Entity<TblDdlhobbiesInterest>(entity =>
        {
            entity.HasKey(e => e.IntHobbyId).HasName("PK__tblDDLHo__AFE87774542C41E9");

            entity.ToTable("tblDDLHobbiesInterests");

            entity.Property(e => e.IntHobbyId).HasColumnName("intHobbyId");
            entity.Property(e => e.DteLastActionTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionTime");
            entity.Property(e => e.DteServerDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(5L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrCategory)
                .HasMaxLength(50)
                .HasColumnName("strCategory");
            entity.Property(e => e.StrHobbyName)
                .HasMaxLength(100)
                .HasColumnName("strHobbyName");
        });

        modelBuilder.Entity<TblDdlmaritalStatus>(entity =>
        {
            entity.HasKey(e => e.IntMaritalStatusId).HasName("PK__tblDDLMa__8B4FA219C2104B4A");

            entity.ToTable("tblDDLMaritalStatus");

            entity.Property(e => e.IntMaritalStatusId).HasColumnName("intMaritalStatusId");
            entity.Property(e => e.DteLastActionDate)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDate");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(6L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrStatusName)
                .HasMaxLength(50)
                .HasColumnName("strStatusName");
        });

        modelBuilder.Entity<TblDdlparentOccupation>(entity =>
        {
            entity.HasKey(e => e.IntOccupationId).HasName("PK__tblParen__EE5252E09774CF22");

            entity.ToTable("tblDDLParentOccupation");

            entity.Property(e => e.IntOccupationId).HasColumnName("intOccupationId");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(7L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrOccupationName)
                .HasMaxLength(100)
                .HasColumnName("strOccupationName");
            entity.Property(e => e.StrParentType)
                .HasMaxLength(10)
                .HasColumnName("strParentType");
        });

        modelBuilder.Entity<TblDdlresidencyStatus>(entity =>
        {
            entity.HasKey(e => e.IntResidencyId).HasName("PK__tblDDLRe__ECACC3F80210F5B2");

            entity.ToTable("tblDDLResidencyStatus");

            entity.Property(e => e.IntResidencyId).HasColumnName("intResidencyId");
            entity.Property(e => e.DteLastActionDate)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDate");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(8L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrResidencyType)
                .HasMaxLength(100)
                .HasColumnName("strResidencyType");
        });

        modelBuilder.Entity<TblDdlsubCommunity>(entity =>
        {
            entity.HasKey(e => e.IntCommunityId).HasName("PK__tblCommu__E21CD3BABD8C5F60");

            entity.ToTable("tblDDLSubCommunity");

            entity.HasIndex(e => e.StrSubCommunityName, "UQ__tblCommu__E970EC87CF6A2BC3").IsUnique();

            entity.Property(e => e.IntCommunityId).HasColumnName("intCommunityId");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(9L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IntReligionId).HasColumnName("intReligionId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StrSubCommunityName)
                .HasMaxLength(100)
                .HasColumnName("strSubCommunityName");
        });

        modelBuilder.Entity<TblDdlworkDesignation>(entity =>
        {
            entity.HasKey(e => e.IntDesignationId).HasName("PK__tblDDLWo__0431712FB1BD38D2");

            entity.ToTable("tblDDLWorkDesignation");

            entity.Property(e => e.IntDesignationId).HasColumnName("intDesignationId");
            entity.Property(e => e.DteLastActionTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionTime");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(10L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrDesignationName)
                .HasMaxLength(100)
                .HasColumnName("strDesignationName");
        });

        modelBuilder.Entity<TblDdlworkIndustry>(entity =>
        {
            entity.HasKey(e => e.IntWorkId).HasName("PK__tblDDLWo__5BAF54CC3A411CE1");

            entity.ToTable("tblDDLWorkIndustry");

            entity.Property(e => e.IntWorkId).HasColumnName("intWorkId");
            entity.Property(e => e.DteLastActionDate)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDate");
            entity.Property(e => e.IntPreferencyTypeId)
                .HasDefaultValue(11L)
                .HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrWorkType)
                .HasMaxLength(100)
                .HasColumnName("strWorkType");
        });

        modelBuilder.Entity<TblDistrict>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblDistrict");

            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DteServerDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IntCountryId).HasColumnName("intCountryId");
            entity.Property(e => e.IntDistrictId)
                .ValueGeneratedOnAdd()
                .HasColumnName("intDistrictId");
            entity.Property(e => e.IntDivisionId).HasColumnName("intDivisionId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrDistrictGeocode)
                .HasMaxLength(50)
                .HasColumnName("strDistrictGEOCode");
            entity.Property(e => e.StrDistrictName)
                .HasMaxLength(100)
                .HasColumnName("strDistrictName");
        });

        modelBuilder.Entity<TblDivision>(entity =>
        {
            entity.HasKey(e => e.IntDivisionId);

            entity.ToTable("tblDivision");

            entity.Property(e => e.IntDivisionId).HasColumnName("intDivisionID");
            entity.Property(e => e.IntCountryId).HasColumnName("intCountryId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrCountryName)
                .HasMaxLength(100)
                .HasColumnName("strCountryName");
            entity.Property(e => e.StrDivision)
                .HasMaxLength(50)
                .HasColumnName("strDivision");
            entity.Property(e => e.StrDivisionGeocode)
                .HasMaxLength(100)
                .HasColumnName("strDivisionGEOCode");
            entity.Property(e => e.StrDivitionBanglaName)
                .HasMaxLength(100)
                .HasColumnName("strDivitionBanglaName");
        });

        modelBuilder.Entity<TblGeneralLedger>(entity =>
        {
            entity.HasKey(e => e.IntGeneralLedgerId);

            entity.ToTable("tblGeneralLedger");

            entity.Property(e => e.IntGeneralLedgerId).HasColumnName("intGeneralLedgerId");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DteServerDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.IntAccountCategoryId).HasColumnName("intAccountCategoryId");
            entity.Property(e => e.IntAccountClassId).HasColumnName("intAccountClassId");
            entity.Property(e => e.IntAccountGroupId).HasColumnName("intAccountGroupId");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IntGeneralLedgerTypeId).HasColumnName("intGeneralLedgerTypeId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsScheduleView).HasColumnName("isScheduleView");
            entity.Property(e => e.IsSubGlallowed).HasColumnName("isSubGLAllowed");
            entity.Property(e => e.StrGeneralLedgerCode)
                .HasMaxLength(50)
                .HasColumnName("strGeneralLedgerCode");
            entity.Property(e => e.StrGeneralLedgerName)
                .HasMaxLength(100)
                .HasColumnName("strGeneralLedgerName");
        });

        modelBuilder.Entity<TblGeneralLedgerSubType>(entity =>
        {
            entity.HasKey(e => e.IntGeneralLedgerSubTypeId);

            entity.ToTable("tblGeneralLedgerSubType");

            entity.Property(e => e.IntGeneralLedgerSubTypeId).HasColumnName("intGeneralLedgerSubTypeID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrGeneralLedgerSubTypeName)
                .HasMaxLength(100)
                .HasColumnName("strGeneralLedgerSubTypeName");
        });

        modelBuilder.Entity<TblGeneralLedgerType>(entity =>
        {
            entity.HasKey(e => e.IntGeneralLedgerTypeId);

            entity.ToTable("tblGeneralLedgerType");

            entity.Property(e => e.IntGeneralLedgerTypeId).HasColumnName("intGeneralLedgerTypeId");
            entity.Property(e => e.IntGeneralLedgerTypeName)
                .HasMaxLength(100)
                .HasColumnName("intGeneralLedgerTypeName");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<TblMasterDataForCode>(entity =>
        {
            entity.HasKey(e => e.IntId);

            entity.ToTable("tblMasterDataForCode");

            entity.Property(e => e.IntId).HasColumnName("intId");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntCounter).HasColumnName("intCounter");
            entity.Property(e => e.IntMasterDataTypeId).HasColumnName("intMasterDataTypeId");
            entity.Property(e => e.IntSubTypeId).HasColumnName("intSubTypeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrMasterDataTypeName)
                .HasMaxLength(100)
                .HasColumnName("strMasterDataTypeName");
            entity.Property(e => e.StrSubTypeName)
                .HasMaxLength(100)
                .HasColumnName("strSubTypeName");
            entity.Property(e => e.StrTypePrefix)
                .HasMaxLength(20)
                .HasColumnName("strTypePrefix");
        });

        modelBuilder.Entity<TblPriceStructureGl>(entity =>
        {
            entity.HasKey(e => e.IntId);

            entity.ToTable("tblPriceStructureGL");

            entity.Property(e => e.IntId).HasColumnName("intId");
            entity.Property(e => e.DteActionTime)
                .HasColumnType("datetime")
                .HasColumnName("dteActionTime");
            entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IntGeneralLedgerId).HasColumnName("intGeneralLedgerId");
            entity.Property(e => e.IntPriceComponentId).HasColumnName("intPriceComponentId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsFactor).HasColumnName("isFactor");
            entity.Property(e => e.StrPriceComponentName)
                .HasMaxLength(50)
                .HasColumnName("strPriceComponentName");
        });

        modelBuilder.Entity<TblReligion>(entity =>
        {
            entity.HasKey(e => e.IntReligionId).HasName("PK__tblRelig__1262ED9987095C37");

            entity.ToTable("tblReligion");

            entity.HasIndex(e => e.StrReligionName, "UQ__tblRelig__C476AA4034460736").IsUnique();

            entity.Property(e => e.IntReligionId).HasColumnName("intReligionId");
            entity.Property(e => e.IntPreferencyTypeId).HasColumnName("intPreferencyTypeId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StrReligionName)
                .HasMaxLength(200)
                .HasColumnName("strReligionName");
        });

        modelBuilder.Entity<TblSubscriptionPlan>(entity =>
        {
            entity.HasKey(e => e.IntPlanId).HasName("PK__tblSubsc__DA670023605B7240");

            entity.ToTable("tblSubscriptionPlans");

            entity.Property(e => e.IntPlanId).HasColumnName("intPlanId");
            entity.Property(e => e.DecDiscountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("decDiscountPercentage");
            entity.Property(e => e.DecPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("decPrice");
            entity.Property(e => e.DteEndDate)
                .HasColumnType("datetime")
                .HasColumnName("dteEndDate");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DteServerDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.DteStartDate)
                .HasColumnType("datetime")
                .HasColumnName("dteStartDate");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IntMessageLimit).HasColumnName("intMessageLimit");
            entity.Property(e => e.IntNumberOfMatches).HasColumnName("intNumberOfMatches");
            entity.Property(e => e.IsAccessToAdvancedFilters).HasColumnName("isAccessToAdvancedFilters");
            entity.Property(e => e.IsAccessToPremiumProfiles).HasColumnName("isAccessToPremiumProfiles");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsIncreasedMatchScore).HasColumnName("isIncreasedMatchScore");
            entity.Property(e => e.IsPrioritySupport).HasColumnName("isPrioritySupport");
            entity.Property(e => e.StrAdditionalBenefits)
                .HasMaxLength(200)
                .HasColumnName("strAdditionalBenefits");
            entity.Property(e => e.StrDuration)
                .HasMaxLength(50)
                .HasColumnName("strDuration");
            entity.Property(e => e.StrPlanName)
                .HasMaxLength(50)
                .HasColumnName("strPlanName");
            entity.Property(e => e.StrProfileVisibility)
                .HasMaxLength(50)
                .HasColumnName("strProfileVisibility");
        });

        modelBuilder.Entity<TblSubscriptionPlanHeader>(entity =>
        {
            entity.HasKey(e => e.IntMembershipId).HasName("PK__tblSubsc__980A607E3236F11A");

            entity.ToTable("tblSubscriptionPlanHeader");

            entity.Property(e => e.IntMembershipId).HasColumnName("intMembershipId");
            entity.Property(e => e.DteEndDate)
                .HasColumnType("datetime")
                .HasColumnName("dteEndDate");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.DteServerDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteServerDateTime");
            entity.Property(e => e.DteStartDate)
                .HasColumnType("datetime")
                .HasColumnName("dteStartDate");
            entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");
            entity.Property(e => e.IntCustomerId).HasColumnName("intCustomerId");
            entity.Property(e => e.IntPlanId).HasColumnName("intPlanId");
            entity.Property(e => e.IntUnitId).HasColumnName("intUnitId");
            entity.Property(e => e.IntUserId).HasColumnName("intUserId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<TblSubscriptionPlanRow>(entity =>
        {
            entity.HasKey(e => e.IntChangeRequestId).HasName("PK__tblSubsc__3D9B42742972F2CC");

            entity.ToTable("tblSubscriptionPlanRow");

            entity.Property(e => e.IntChangeRequestId).HasColumnName("intChangeRequestId");
            entity.Property(e => e.DteChangeProcessedDate)
                .HasColumnType("datetime")
                .HasColumnName("dteChangeProcessedDate");
            entity.Property(e => e.DteChangeRequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteChangeRequestDate");
            entity.Property(e => e.DteCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteCreatedAt");
            entity.Property(e => e.DteUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteUpdatedAt");
            entity.Property(e => e.IntCurrentPlan).HasColumnName("intCurrentPlan");
            entity.Property(e => e.IntMembershipId).HasColumnName("intMembershipId");
            entity.Property(e => e.IntRequestedPlan).HasColumnName("intRequestedPlan");
            entity.Property(e => e.IntUserId).HasColumnName("intUserId");
            entity.Property(e => e.StrAdminNotes)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("strAdminNotes");
            entity.Property(e => e.StrChangeStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending")
                .HasColumnName("strChangeStatus");
            entity.Property(e => e.StrCurrentPlan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strCurrentPlan");
            entity.Property(e => e.StrPaymentStatus)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("strPaymentStatus");
            entity.Property(e => e.StrReasonForChange)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("strReasonForChange");
            entity.Property(e => e.StrRequestedPlan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strRequestedPlan");
        });

        modelBuilder.Entity<TblThana>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblThana");

            entity.Property(e => e.IntCountryId).HasColumnName("intCountryId");
            entity.Property(e => e.IntDistrictId).HasColumnName("intDistrictId");
            entity.Property(e => e.IntDivisionId).HasColumnName("intDivisionId");
            entity.Property(e => e.IntThanaId)
                .ValueGeneratedOnAdd()
                .HasColumnName("intThanaId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrPostCode)
                .HasMaxLength(50)
                .HasColumnName("strPostCode");
            entity.Property(e => e.StrSubOffice)
                .HasMaxLength(100)
                .HasColumnName("strSubOffice");
            entity.Property(e => e.StrThanaBanglaName)
                .HasMaxLength(100)
                .HasColumnName("strThanaBanglaName");
            entity.Property(e => e.StrThanaName)
                .HasMaxLength(100)
                .HasColumnName("strThanaName");
        });

        modelBuilder.Entity<TblUserEducationInformation>(entity =>
        {
            entity.HasKey(e => e.IntUserProfessionDetId);

            entity.ToTable("tblUserEducationInformation");

            entity.Property(e => e.IntUserProfessionDetId).HasColumnName("intUserProfessionDetId");
            entity.Property(e => e.DteInsertDate)
                .HasColumnType("datetime")
                .HasColumnName("dteInsertDate");
            entity.Property(e => e.IntUserId).HasColumnName("intUserId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrInstitute)
                .HasMaxLength(200)
                .HasColumnName("strInstitute");
            entity.Property(e => e.StrQualification)
                .HasMaxLength(200)
                .HasColumnName("strQualification");
        });

        modelBuilder.Entity<TblUserHobbiesInterest>(entity =>
        {
            entity.HasKey(e => e.IntAutoId);

            entity.ToTable("tblUserHobbiesInterests");

            entity.Property(e => e.IntAutoId).HasColumnName("intAutoId");
            entity.Property(e => e.DteLastActionDate)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDate");
            entity.Property(e => e.IntUserId).HasColumnName("intUserId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrHobbyName)
                .HasMaxLength(100)
                .HasColumnName("strHobbyName");
            entity.Property(e => e.StrSection)
                .HasMaxLength(50)
                .HasColumnName("strSection");
        });

        modelBuilder.Entity<TblUserPreferenceSummery>(entity =>
        {
            entity.HasKey(e => e.IntUsererenceId).HasName("PK__tblUserP__8D0B6A54842DE9B5");

            entity.ToTable("tblUserPreferenceSummery");

            entity.Property(e => e.IntUsererenceId).HasColumnName("intUsererenceID");
            entity.Property(e => e.DecAnnualIncomeMax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("decAnnualIncomeMax");
            entity.Property(e => e.DecAnnualIncomeMin)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("decAnnualIncomeMin");
            entity.Property(e => e.DecHeightMax)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("decHeightMax");
            entity.Property(e => e.DecHeightMin)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("decHeightMin");
            entity.Property(e => e.DteCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteCreatedDate");
            entity.Property(e => e.DteUpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteUpdatedDate");
            entity.Property(e => e.IntAgeMax).HasColumnName("intAgeMax");
            entity.Property(e => e.IntAgeMin).HasColumnName("intAgeMin");
            entity.Property(e => e.IntCommunityId).HasColumnName("intCommunityID");
            entity.Property(e => e.IntCountryId).HasColumnName("intCountryID");
            entity.Property(e => e.IntDistrictId).HasColumnName("intDistrictID");
            entity.Property(e => e.IntFatherOccupationId).HasColumnName("intFatherOccupationID");
            entity.Property(e => e.IntHighestQualificationId).HasColumnName("intHighestQualificationID");
            entity.Property(e => e.IntMaritalStatusId).HasColumnName("intMaritalStatusID");
            entity.Property(e => e.IntMotherOccupationId).HasColumnName("intMotherOccupationID");
            entity.Property(e => e.IntNoOfBrothers).HasColumnName("intNoOfBrothers");
            entity.Property(e => e.IntNoOfSisters).HasColumnName("intNoOfSisters");
            entity.Property(e => e.IntReligionId).HasColumnName("intReligionID");
            entity.Property(e => e.IntResidencyStatusId).HasColumnName("intResidencyStatusID");
            entity.Property(e => e.IntSubCommunityId).HasColumnName("intSubCommunityID");
            entity.Property(e => e.IntThanaId).HasColumnName("intThanaID");
            entity.Property(e => e.IntUnitId).HasColumnName("intUnitID");
            entity.Property(e => e.IntUserId).HasColumnName("intUserID");
            entity.Property(e => e.IntWorkDesignationId).HasColumnName("intWorkDesignationID");
            entity.Property(e => e.IntWorkIndustryId).HasColumnName("intWorkIndustryID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsCommunitPreperence).HasColumnName("isCommunitPreperence");
            entity.Property(e => e.StrDiet)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strDiet");
            entity.Property(e => e.StrGender)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("strGender");
            entity.Property(e => e.StrHobbiesAndInterests)
                .IsUnicode(false)
                .HasColumnName("strHobbiesAndInterests");
        });

        modelBuilder.Entity<TblUserPreferredCommunity>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B67932E9D81032");

            entity.ToTable("tblUserPreferredCommunities");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntCommunityId).HasColumnName("intCommunityID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntCommunity).WithMany(p => p.TblUserPreferredCommunities)
                .HasForeignKey(d => d.IntCommunityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intCo__03BB8E22");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredCommunities)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__02C769E9");
        });

        modelBuilder.Entity<TblUserPreferredCountry>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B67932FD9AE6B1");

            entity.ToTable("tblUserPreferredCountries");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntCountryId).HasColumnName("intCountryID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntCountry).WithMany(p => p.TblUserPreferredCountries)
                .HasForeignKey(d => d.IntCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intCo__078C1F06");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredCountries)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__0697FACD");
        });

        modelBuilder.Entity<TblUserPreferredDiet>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B679324F6EF748");

            entity.ToTable("tblUserPreferredDiets");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntDietId).HasColumnName("intDietID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntDiet).WithMany(p => p.TblUserPreferredDiets)
                .HasForeignKey(d => d.IntDietId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intDi__0B5CAFEA");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredDiets)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__0A688BB1");
        });

        modelBuilder.Entity<TblUserPreferredHobby>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B679328B1C136D");

            entity.ToTable("tblUserPreferredHobbies");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntHobbyId).HasColumnName("intHobbyID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntHobby).WithMany(p => p.TblUserPreferredHobbies)
                .HasForeignKey(d => d.IntHobbyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intHo__12FDD1B2");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredHobbies)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__1209AD79");
        });

        modelBuilder.Entity<TblUserPreferredMaritalStatus>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B6793278FC8A95");

            entity.ToTable("tblUserPreferredMaritalStatus");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntMaritalStatusId).HasColumnName("intMaritalStatusID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntMaritalStatus).WithMany(p => p.TblUserPreferredMaritalStatuses)
                .HasForeignKey(d => d.IntMaritalStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intMa__7D0E9093");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredMaritalStatuses)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__7C1A6C5A");
        });

        modelBuilder.Entity<TblUserPreferredParentOccupation>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B67932C6E7D899");

            entity.ToTable("tblUserPreferredParentOccupations");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntFamilyMembersTypeId).HasColumnName("intFamilyMembersTypeId");
            entity.Property(e => e.IntOccupationId).HasColumnName("intOccupationID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntOccupation).WithMany(p => p.TblUserPreferredParentOccupations)
                .HasForeignKey(d => d.IntOccupationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intOc__16CE6296");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredParentOccupations)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__15DA3E5D");
        });

        modelBuilder.Entity<TblUserPreferredQualification>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B679321EDAE60F");

            entity.ToTable("tblUserPreferredQualifications");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntQualificationId).HasColumnName("intQualificationID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntQualification).WithMany(p => p.TblUserPreferredQualifications)
                .HasForeignKey(d => d.IntQualificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intQu__0F2D40CE");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredQualifications)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__0E391C95");
        });

        modelBuilder.Entity<TblUserPreferredResidencyStatus>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B67932C32BA73C");

            entity.ToTable("tblUserPreferredResidencyStatus");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntResidencyId).HasColumnName("intResidencyID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntResidency).WithMany(p => p.TblUserPreferredResidencyStatuses)
                .HasForeignKey(d => d.IntResidencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intRe__1A9EF37A");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredResidencyStatuses)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__19AACF41");
        });

        modelBuilder.Entity<TblUserPreferredSubCommunity>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B67932A492E46B");

            entity.ToTable("tblUserPreferredSubCommunity");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntSubCommunityId).HasColumnName("intSubCommunityID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntSubCommunity).WithMany(p => p.TblUserPreferredSubCommunities)
                .HasForeignKey(d => d.IntSubCommunityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intSu__1E6F845E");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredSubCommunities)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__1D7B6025");
        });

        modelBuilder.Entity<TblUserPreferredWorkDesignation>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B679324F3E8811");

            entity.ToTable("tblUserPreferredWorkDesignation");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntDesignationId).HasColumnName("intDesignationID");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntDesignation).WithMany(p => p.TblUserPreferredWorkDesignations)
                .HasForeignKey(d => d.IntDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intDe__27F8EE98");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredWorkDesignations)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__2704CA5F");
        });

        modelBuilder.Entity<TblUserPreferredWorkIndustry>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__tblUserP__11B6793251D5D367");

            entity.ToTable("tblUserPreferredWorkIndustry");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLastActionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDateTime");
            entity.Property(e => e.IntUserPreferenceId).HasColumnName("intUserPreferenceID");
            entity.Property(e => e.IntWorkIndustryId).HasColumnName("intWorkIndustryID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.IntUserPreference).WithMany(p => p.TblUserPreferredWorkIndustries)
                .HasForeignKey(d => d.IntUserPreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intUs__2AD55B43");

            entity.HasOne(d => d.IntWorkIndustry).WithMany(p => p.TblUserPreferredWorkIndustries)
                .HasForeignKey(d => d.IntWorkIndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblUserPr__intWo__2BC97F7C");
        });

        modelBuilder.Entity<TblUserProfessionalDetail>(entity =>
        {
            entity.HasKey(e => e.IntUserProfessionDetId);

            entity.ToTable("tblUserProfessionalDetails");

            entity.Property(e => e.IntUserProfessionDetId).HasColumnName("intUserProfessionDetId");
            entity.Property(e => e.DteInsertDate)
                .HasColumnType("datetime")
                .HasColumnName("dteInsertDate");
            entity.Property(e => e.IntUserId).HasColumnName("intUserId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StrInstitute)
                .HasMaxLength(200)
                .HasColumnName("strInstitute");
            entity.Property(e => e.StrQualification)
                .HasMaxLength(200)
                .HasColumnName("strQualification");
        });

        modelBuilder.Entity<TblUserProfileSummery>(entity =>
        {
            entity.HasKey(e => e.IntUserId)
                .HasName("PK__tblUserP__AE995E2F079B60D3")
                .IsClustered(false);

            entity.ToTable("tblUserProfileSummery");

            entity.Property(e => e.IntUserId).HasColumnName("intUserID");
            entity.Property(e => e.DecAnnualIncome)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("decAnnualIncome");
            entity.Property(e => e.DecHeight).HasColumnName("decHeight");
            entity.Property(e => e.DteApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("dteApproveDate");
            entity.Property(e => e.DteDateOfBirth).HasColumnName("dteDateOfBirth");
            entity.Property(e => e.DteLastActionDate)
                .HasColumnType("datetime")
                .HasColumnName("dteLastActionDate");
            entity.Property(e => e.IntApproveBy).HasColumnName("intApproveBy");
            entity.Property(e => e.IntCommunityId).HasColumnName("intCommunityID");
            entity.Property(e => e.IntCountryId).HasColumnName("intCountryID");
            entity.Property(e => e.IntDistrictId).HasColumnName("intDistrictID");
            entity.Property(e => e.IntFatherDetailsId).HasColumnName("intFatherDetailsID");
            entity.Property(e => e.IntHighestQualificationId).HasColumnName("intHighestQualificationID");
            entity.Property(e => e.IntMaritalStatusId).HasColumnName("intMaritalStatusID");
            entity.Property(e => e.IntMotherOccupationId).HasColumnName("intMotherOccupationID");
            entity.Property(e => e.IntNoOfBrothers).HasColumnName("intNoOfBrothers");
            entity.Property(e => e.IntNoOfSisters).HasColumnName("intNoOfSisters");
            entity.Property(e => e.IntReligionId).HasColumnName("intReligionID");
            entity.Property(e => e.IntResidencyStatusId).HasColumnName("intResidencyStatusID");
            entity.Property(e => e.IntSubCommunityId).HasColumnName("intSubCommunityID");
            entity.Property(e => e.IntThanaId).HasColumnName("intThanaID");
            entity.Property(e => e.IntUnitId).HasColumnName("intUnitId");
            entity.Property(e => e.IntWorkDesignationId).HasColumnName("intWorkDesignationID");
            entity.Property(e => e.IntWorkIndustryId).HasColumnName("intWorkIndustryID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsApprove).HasColumnName("isApprove");
            entity.Property(e => e.IsPartnerCommunityPreference).HasColumnName("isPartnerCommunityPreference");
            entity.Property(e => e.StrCode)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("strCode");
            entity.Property(e => e.StrCollege)
                .HasMaxLength(255)
                .HasColumnName("strCollege");
            entity.Property(e => e.StrCountryName)
                .HasMaxLength(100)
                .HasColumnName("strCountryName");
            entity.Property(e => e.StrDiet)
                .HasMaxLength(50)
                .HasColumnName("strDiet");
            entity.Property(e => e.StrEmail)
                .HasMaxLength(255)
                .HasColumnName("strEmail");
            entity.Property(e => e.StrGender)
                .HasMaxLength(10)
                .HasColumnName("strGender");
            entity.Property(e => e.StrHobbiesAndInterests).HasColumnName("strHobbiesAndInterests");
            entity.Property(e => e.StrMobileNumber)
                .HasMaxLength(20)
                .HasColumnName("strMobileNumber");
            entity.Property(e => e.StrName)
                .HasMaxLength(500)
                .HasColumnName("strName");
            entity.Property(e => e.StrPermanentAddress)
                .HasMaxLength(100)
                .HasColumnName("strPermanentAddress");
            entity.Property(e => e.StrPresentAddress)
                .HasMaxLength(100)
                .HasColumnName("strPresentAddress");
            entity.Property(e => e.StrProfileFor)
                .HasMaxLength(100)
                .HasColumnName("strProfileFor");
        });

        modelBuilder.Entity<TblUserWorkInformation>(entity =>
        {
            entity.HasKey(e => e.IntWorkId).HasName("PK__tblUserW__5BAF54CCFA5FA1AB");

            entity.ToTable("tblUserWorkInformation");

            entity.Property(e => e.IntWorkId).HasColumnName("intWorkId");
            entity.Property(e => e.DecIncome)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("decIncome");
            entity.Property(e => e.DteCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteCreatedAt");
            entity.Property(e => e.DteFromDate)
                .HasColumnType("datetime")
                .HasColumnName("dteFromDate");
            entity.Property(e => e.DteToDate)
                .HasColumnType("datetime")
                .HasColumnName("dteToDate");
            entity.Property(e => e.DteUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteUpdatedAt");
            entity.Property(e => e.IntDesignationId).HasColumnName("intDesignationId");
            entity.Property(e => e.IntIndustryId).HasColumnName("intIndustryId");
            entity.Property(e => e.IntUserId).HasColumnName("intUserId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsWorkFromHome)
                .HasDefaultValue(false)
                .HasColumnName("isWorkFromHome");
            entity.Property(e => e.StrCompanyName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("strCompanyName");
            entity.Property(e => e.StrCurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("strCurrencyCode");
            entity.Property(e => e.StrDesignation)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("strDesignation");
            entity.Property(e => e.StrIndustry)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("strIndustry");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
