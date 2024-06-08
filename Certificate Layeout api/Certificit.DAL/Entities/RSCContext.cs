using System;
using System.Collections.Generic;
using Certificit.DAL.test;
using Microsoft.EntityFrameworkCore;

namespace Certificit.DAL.Entities;

public partial class RSCContext : DbContext
{
    public RSCContext()
    {
    }

    public RSCContext(DbContextOptions<RSCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressesUpdated> AddressesUpdateds { get; set; }

    public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }

    public virtual DbSet<Assignement> Assignements { get; set; }

    public virtual DbSet<CertificateCoverView> CertificateCoverViews { get; set; }

    public virtual DbSet<CertificateCoverViewEdit> CertificateCoverViewEdits { get; set; }

    public virtual DbSet<CertificateViewLayout> CertificateViewLayouts { get; set; }
    public virtual DbSet<CertificateViewLayout33> CertificateViewLayout33s { get; set; }

    public virtual DbSet<CertificateViewLayoutEdit> CertificateViewLayoutEdits { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<FieldDataV2> FieldDataV2s { get; set; }

    public virtual DbSet<Governorate> Governorates { get; set; }

    public virtual DbSet<LkupStatus> LkupStatuses { get; set; }

    public virtual DbSet<LkupUnittype> LkupUnittypes { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Orderstatus> Orderstatuses { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestsExtrainfo> RequestsExtrainfos { get; set; }

    public virtual DbSet<RequestsOverlap> RequestsOverlaps { get; set; }

    public virtual DbSet<Shippingorder> Shippingorders { get; set; }

    public virtual DbSet<ShippingordersStatus> ShippingordersStatuses { get; set; }

    public virtual DbSet<Ssec> Ssecs { get; set; }

    public virtual DbSet<SsecGeom> SsecGeoms { get; set; }

    public virtual DbSet<Subunittype> Subunittypes { get; set; }

    public virtual DbSet<Surveygi> Surveygis { get; set; }

    public virtual DbSet<UnittypeValue> UnittypeValues { get; set; }

    public virtual DbSet<UsageStatus> UsageStatuses { get; set; }

    public virtual DbSet<Useraddress> Useraddresses { get; set; }

    public virtual DbSet<Userprofile> Userprofiles { get; set; }

    public virtual DbSet<_1PrintCertificateCover> _1PrintCertificateCovers { get; set; }

    public virtual DbSet<_2CertificateView> _2CertificateViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=10.100.102.58;Port=5432;Database=msd_db_v1;Username=bass;Password=bass;", x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("address_standardizer")
            .HasPostgresExtension("fuzzystrmatch")
            .HasPostgresExtension("h3")
            .HasPostgresExtension("ogr_fdw")
            .HasPostgresExtension("pgrouting")
            .HasPostgresExtension("pointcloud")
            .HasPostgresExtension("pointcloud_postgis")
            .HasPostgresExtension("postgis")
            .HasPostgresExtension("postgis_raster")
            .HasPostgresExtension("postgis_sfcgal")
            .HasPostgresExtension("postgres_fdw")
            .HasPostgresExtension("tiger", "postgis_tiger_geocoder")
            .HasPostgresExtension("topology", "postgis_topology");
        modelBuilder.Entity<CertificateViewLayout33>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("certificate_view_layout33");

            entity.Property(e => e.Addeddate).HasColumnName("addeddate");
            entity.Property(e => e.ApartNum)
                .HasColumnType("character varying")
                .HasColumnName("apart_num");
            entity.Property(e => e.AreaAp1).HasColumnName("area_ap1");
            entity.Property(e => e.AreaAp2).HasColumnName("area_ap2");
            entity.Property(e => e.AreaAp3).HasColumnName("area_ap3");
            entity.Property(e => e.AreaAp4).HasColumnName("area_ap4");
            entity.Property(e => e.AreaAp5).HasColumnName("area_ap5");
            entity.Property(e => e.AreaAp6).HasColumnName("area_ap6");
            entity.Property(e => e.AreaBuild).HasColumnName("area_build");
            entity.Property(e => e.AreaG).HasColumnName("area_g");
            entity.Property(e => e.AreaLand).HasColumnName("area_land");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Descrip).HasColumnName("descrip");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.EastB)
                .HasColumnType("character varying")
                .HasColumnName("east_b");
            entity.Property(e => e.EastL).HasColumnName("east_l");
            entity.Property(e => e.EastL1).HasColumnName("east_l1");
            entity.Property(e => e.EastL2).HasColumnName("east_l2");
            entity.Property(e => e.EastL3).HasColumnName("east_l3");
            entity.Property(e => e.EastL4).HasColumnName("east_l4");
            entity.Property(e => e.EastL5).HasColumnName("east_l5");
            entity.Property(e => e.EastL6).HasColumnName("east_l6");
            entity.Property(e => e.EastLg).HasColumnName("east_lg");
            entity.Property(e => e.FloorNT)
                .HasColumnType("character varying")
                .HasColumnName("floor_n_t");
            entity.Property(e => e.FloorNumb)
                .HasMaxLength(20)
                .HasColumnName("floor_numb");
            entity.Property(e => e.Garden).HasColumnName("garden");
            entity.Property(e => e.Geom).HasColumnName("geom");
            entity.Property(e => e.Gov)
                .HasMaxLength(200)
                .HasColumnName("gov");
            entity.Property(e => e.GovNo)
                .HasMaxLength(200)
                .HasColumnName("gov_no");
            entity.Property(e => e.Hod)
                .HasColumnType("character varying")
                .HasColumnName("hod");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ket3a)
                .HasColumnType("character varying")
                .HasColumnName("ket3a");
            entity.Property(e => e.Letter)
                .HasMaxLength(1)
                .HasColumnName("letter");
            entity.Property(e => e.Manwr).HasColumnName("manwr");
            entity.Property(e => e.MilOverlap).HasColumnName("mil_overlap");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Ncpslu).HasColumnName("ncpslu");
            entity.Property(e => e.NorthB)
                .HasColumnType("character varying")
                .HasColumnName("north_b");
            entity.Property(e => e.NorthL).HasColumnName("north_l");
            entity.Property(e => e.NorthL1).HasColumnName("north_l1");
            entity.Property(e => e.NorthL2).HasColumnName("north_l2");
            entity.Property(e => e.NorthL3).HasColumnName("north_l3");
            entity.Property(e => e.NorthL4).HasColumnName("north_l4");
            entity.Property(e => e.NorthL5).HasColumnName("north_l5");
            entity.Property(e => e.NorthL6).HasColumnName("north_l6");
            entity.Property(e => e.NorthLg).HasColumnName("north_lg");
            entity.Property(e => e.Overlap).HasColumnName("overlap");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Print).HasColumnName("print");
            entity.Property(e => e.Printdate).HasColumnName("printdate");
            entity.Property(e => e.PropertyN)
                .HasColumnType("character varying")
                .HasColumnName("property_n");
            entity.Property(e => e.Receiptimagepath).HasColumnName("receiptimagepath");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.Sealm).HasColumnName("sealm");
            entity.Property(e => e.Sealmm).HasColumnName("sealmm");
            entity.Property(e => e.Sec)
                .HasMaxLength(200)
                .HasColumnName("sec");
            entity.Property(e => e.SecNow)
                .HasMaxLength(200)
                .HasColumnName("sec_now");
            entity.Property(e => e.Serag)
                .HasColumnType("character varying")
                .HasColumnName("serag");
            entity.Property(e => e.SeragShaqaa).HasColumnName("serag_shaqaa");
            entity.Property(e => e.Seragid).HasColumnName("seragid");
            entity.Property(e => e.SeragidCount).HasColumnName("seragid_count");
            entity.Property(e => e.ShaqaaSeragCount).HasColumnName("shaqaa_serag_count");
            entity.Property(e => e.SouthB)
                .HasColumnType("character varying")
                .HasColumnName("south_b");
            entity.Property(e => e.SouthL).HasColumnName("south_l");
            entity.Property(e => e.SouthL1).HasColumnName("south_l1");
            entity.Property(e => e.SouthL2).HasColumnName("south_l2");
            entity.Property(e => e.SouthL3).HasColumnName("south_l3");
            entity.Property(e => e.SouthL4).HasColumnName("south_l4");
            entity.Property(e => e.SouthL5).HasColumnName("south_l5");
            entity.Property(e => e.SouthL6).HasColumnName("south_l6");
            entity.Property(e => e.SouthLg).HasColumnName("south_lg");
            entity.Property(e => e.Ssec)
                .HasMaxLength(200)
                .HasColumnName("ssec");
            entity.Property(e => e.SsecNow)
                .HasColumnType("character varying")
                .HasColumnName("ssec_now");
            entity.Property(e => e.Streetname)
                .HasMaxLength(200)
                .HasColumnName("streetname");
            entity.Property(e => e.SurveyReview).HasColumnName("survey_review");
            entity.Property(e => e.SurveyTeamId).HasColumnName("survey_team_id");
            entity.Property(e => e.Surveynum)
                .HasMaxLength(10)
                .HasColumnName("surveynum");
            entity.Property(e => e.Tawheed).HasColumnName("tawheed");
            entity.Property(e => e.Totalaparts).HasColumnName("totalaparts");
            entity.Property(e => e.Totalarea).HasColumnName("totalarea");
            entity.Property(e => e.Unittype)
                .HasMaxLength(50)
                .HasColumnName("unittype");
            entity.Property(e => e.Usage)
                .HasColumnType("character varying")
                .HasColumnName("usage");
            entity.Property(e => e.WestB)
                .HasColumnType("character varying")
                .HasColumnName("west_b");
            entity.Property(e => e.WestL).HasColumnName("west_l");
            entity.Property(e => e.WestL1).HasColumnName("west_l1");
            entity.Property(e => e.WestL2).HasColumnName("west_l2");
            entity.Property(e => e.WestL3).HasColumnName("west_l3");
            entity.Property(e => e.WestL4).HasColumnName("west_l4");
            entity.Property(e => e.WestL5).HasColumnName("west_l5");
            entity.Property(e => e.WestL6).HasColumnName("west_l6");
            entity.Property(e => e.WestLg).HasColumnName("west_lg");
            entity.Property(e => e.X)
                .HasColumnType("character varying")
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasColumnType("character varying")
                .HasColumnName("y");
        });

        modelBuilder.Entity<AddressesUpdated>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Addresses_updated");

            entity.ToTable("addresses_updated");

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.HasIndex(e => e.Requestid, "requestid").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Addeddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("addeddate");
            entity.Property(e => e.ApartmentNumber)
                .HasColumnType("character varying")
                .HasColumnName("apartment_number");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Districtid).HasColumnName("districtid");
            entity.Property(e => e.Easternborder)
                .HasColumnType("character varying")
                .HasColumnName("easternborder");
            entity.Property(e => e.Easternborderlength)
                .HasColumnType("character varying")
                .HasColumnName("easternborderlength");
            entity.Property(e => e.FloorNumber)
                .HasMaxLength(20)
                .HasColumnName("floor_number");
            entity.Property(e => e.Floornumbertext)
                .HasColumnType("character varying")
                .HasColumnName("floornumbertext");
            entity.Property(e => e.Maritimeborder)
                .HasColumnType("character varying")
                .HasColumnName("maritimeborder");
            entity.Property(e => e.Maritimeborderlength)
                .HasColumnType("character varying")
                .HasColumnName("maritimeborderlength");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Partnumber)
                .HasColumnType("character varying")
                .HasColumnName("partnumber");
            entity.Property(e => e.PropertyNumber)
                .HasColumnType("character varying")
                .HasColumnName("property_number");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.Requestid).HasColumnName("requestid");
            entity.Property(e => e.Sinknumber)
                .HasColumnType("character varying")
                .HasColumnName("sinknumber");
            entity.Property(e => e.Streetname)
                .HasMaxLength(200)
                .HasColumnName("streetname");
            entity.Property(e => e.Tribalborder)
                .HasColumnType("character varying")
                .HasColumnName("tribalborder");
            entity.Property(e => e.Tribalborderlength)
                .HasColumnType("character varying")
                .HasColumnName("tribalborderlength");
            entity.Property(e => e.UniqueMark)
                .HasMaxLength(200)
                .HasColumnName("unique_mark");
            entity.Property(e => e.Westernborder)
                .HasColumnType("character varying")
                .HasColumnName("westernborder");
            entity.Property(e => e.Westernborderlength)
                .HasColumnType("character varying")
                .HasColumnName("westernborderlength");
        });

        modelBuilder.Entity<Aspnetuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetUsers");

            entity.ToTable("aspnetusers");

            entity.HasIndex(e => e.Addressid, "IX_AspNetUsers_AddressId");

            entity.HasIndex(e => e.Id, "aspnetusers_index").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Addeddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("addeddate");
            entity.Property(e => e.Addressid).HasColumnName("addressid");
            entity.Property(e => e.Arabicfullname)
                .HasMaxLength(200)
                .HasColumnName("arabicfullname");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(15)
                .HasColumnName("phonenumber");
        });

        modelBuilder.Entity<Assignement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("assignements_pkey");

            entity.ToTable("assignements");

            entity.HasIndex(e => e.Requestnumber, "ass_requestnumber").IsUnique();

            entity.HasIndex(e => e.Id, "assignements_id_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AcceptedDate).HasColumnName("accepted_date");
            entity.Property(e => e.Assigned).HasColumnName("assigned");
            entity.Property(e => e.AssignmentDateTime).HasColumnName("assignment_date_time");
            entity.Property(e => e.CallcenterConfirmTime).HasColumnName("callcenter_confirm_time");
            entity.Property(e => e.Cert).HasColumnName("cert");
            entity.Property(e => e.Collected)
                .HasDefaultValueSql("0")
                .HasColumnName("collected");
            entity.Property(e => e.Com)
                .HasColumnType("character varying")
                .HasColumnName("com");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Confirmed)
                .HasDefaultValueSql("1")
                .HasColumnName("confirmed");
            entity.Property(e => e.CretRecievedMsd).HasColumnName("cret_recieved_msd");
            entity.Property(e => e.DifferenceAreaStatus).HasColumnName("difference_area_status");
            entity.Property(e => e.Done).HasColumnName("done");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.Featuretype).HasColumnName("featuretype");
            entity.Property(e => e.FinDate).HasColumnName("fin_date");
            entity.Property(e => e.Finabstract).HasColumnName("finabstract");
            entity.Property(e => e.IdShippingorder).HasColumnName("id_shippingorder");
            entity.Property(e => e.LogProc).HasColumnName("log_proc");
            entity.Property(e => e.LogTime).HasColumnName("log_time");
            entity.Property(e => e.LogUser).HasColumnName("log_user");
            entity.Property(e => e.Oldsubunit).HasColumnName("oldsubunit");
            entity.Property(e => e.Oldunittype).HasColumnName("oldunittype");
            entity.Property(e => e.PrintDate).HasColumnName("print_date");
            entity.Property(e => e.PrintStatus)
                .HasDefaultValueSql("0")
                .HasColumnName("print_status");
            entity.Property(e => e.Processtype).HasColumnName("processtype");
            entity.Property(e => e.RefuseReason).HasColumnName("refuse_reason");
            entity.Property(e => e.Repeatrefuse)
                .HasDefaultValueSql("0")
                .HasColumnName("repeatrefuse");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.Requestnumber)
                .HasMaxLength(21)
                .HasColumnName("requestnumber");
            entity.Property(e => e.ReviewAfterExtraction).HasColumnName("review_after_extraction");
            entity.Property(e => e.Serag)
                .HasColumnType("character varying")
                .HasColumnName("serag");
            entity.Property(e => e.SeragLetters)
                .HasMaxLength(1)
                .HasColumnName("serag_letters");
            entity.Property(e => e.Session)
                .HasColumnType("character varying")
                .HasColumnName("session");
            entity.Property(e => e.SurveyReview).HasColumnName("survey_review");
            entity.Property(e => e.SurveyReviewMsd).HasColumnName("survey_review_msd");
            entity.Property(e => e.SurveyTeamId).HasColumnName("survey_team_id");
            entity.Property(e => e.Tawheed)
                .HasDefaultValueSql("0")
                .HasColumnName("tawheed");
            entity.Property(e => e.Tofedex).HasColumnName("tofedex");
        });

        modelBuilder.Entity<CertificateCoverView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("certificate_cover_view");

            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Arabicfullname)
                .HasMaxLength(200)
                .HasColumnName("arabicfullname");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Gov)
                .HasMaxLength(200)
                .HasColumnName("gov");
            entity.Property(e => e.NewAreaApartment).HasColumnName("new_area_apartment");
            entity.Property(e => e.NewAreabuilding).HasColumnName("new_areabuilding");
            entity.Property(e => e.NewArealand).HasColumnName("new_arealand");
            entity.Property(e => e.NewUnittype).HasColumnName("new_unittype");
            entity.Property(e => e.NewUsage).HasColumnName("new_usage");
            entity.Property(e => e.OldArea).HasColumnName("old_area");
            entity.Property(e => e.OldAreatype).HasColumnName("old_areatype");
            entity.Property(e => e.OldBuildingarea)
                .HasColumnType("character varying")
                .HasColumnName("old_buildingarea");
            entity.Property(e => e.OldLandarea)
                .HasColumnType("character varying")
                .HasColumnName("old_landarea");
            entity.Property(e => e.OldPrice).HasColumnName("old_price");
            entity.Property(e => e.OldSubunittype).HasColumnName("old_subunittype");
            entity.Property(e => e.OldSubunittypearea).HasColumnName("old_subunittypearea");
            entity.Property(e => e.OldUnittype).HasColumnName("old_unittype");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.SecName)
                .HasMaxLength(200)
                .HasColumnName("sec_name");
            entity.Property(e => e.SsecName)
                .HasMaxLength(200)
                .HasColumnName("ssec_name");
            entity.Property(e => e.Telephonenumber)
                .HasColumnType("character varying")
                .HasColumnName("telephonenumber");
            entity.Property(e => e.Telephonenumber2)
                .HasColumnType("character varying")
                .HasColumnName("telephonenumber2");
        });

        modelBuilder.Entity<CertificateCoverViewEdit>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("certificate_cover_view_edit");

            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Arabicfullname)
                .HasMaxLength(200)
                .HasColumnName("arabicfullname");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Gov)
                .HasMaxLength(200)
                .HasColumnName("gov");
            entity.Property(e => e.IdShippingorder).HasColumnName("id_shippingorder");
            entity.Property(e => e.NewAreaApartment).HasColumnName("new_area_apartment");
            entity.Property(e => e.NewAreabuilding).HasColumnName("new_areabuilding");
            entity.Property(e => e.NewArealand).HasColumnName("new_arealand");
            entity.Property(e => e.NewUnittype).HasColumnName("new_unittype");
            entity.Property(e => e.NewUsage).HasColumnName("new_usage");
            entity.Property(e => e.OldArea).HasColumnName("old_area");
            entity.Property(e => e.OldAreatype).HasColumnName("old_areatype");
            entity.Property(e => e.OldBuildingarea)
                .HasColumnType("character varying")
                .HasColumnName("old_buildingarea");
            entity.Property(e => e.OldLandarea)
                .HasColumnType("character varying")
                .HasColumnName("old_landarea");
            entity.Property(e => e.OldPrice).HasColumnName("old_price");
            entity.Property(e => e.OldSubunittype).HasColumnName("old_subunittype");
            entity.Property(e => e.OldSubunittypearea).HasColumnName("old_subunittypearea");
            entity.Property(e => e.OldUnittype).HasColumnName("old_unittype");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.SecName)
                .HasMaxLength(200)
                .HasColumnName("sec_name");
            entity.Property(e => e.SsecName)
                .HasMaxLength(200)
                .HasColumnName("ssec_name");
            entity.Property(e => e.Telephonenumber)
                .HasColumnType("character varying")
                .HasColumnName("telephonenumber");
            entity.Property(e => e.Telephonenumber2)
                .HasColumnType("character varying")
                .HasColumnName("telephonenumber2");
        });

        modelBuilder.Entity<CertificateViewLayout>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("certificate_view_layout");

            entity.Property(e => e.Addeddate).HasColumnName("addeddate");
            entity.Property(e => e.ApartNum)
                .HasColumnType("character varying")
                .HasColumnName("apart_num");
            entity.Property(e => e.AreaAp1).HasColumnName("area_ap1");
            entity.Property(e => e.AreaAp2).HasColumnName("area_ap2");
            entity.Property(e => e.AreaAp3).HasColumnName("area_ap3");
            entity.Property(e => e.AreaAp4).HasColumnName("area_ap4");
            entity.Property(e => e.AreaAp5).HasColumnName("area_ap5");
            entity.Property(e => e.AreaAp6).HasColumnName("area_ap6");
            entity.Property(e => e.AreaBuild).HasColumnName("area_build");
            entity.Property(e => e.AreaG).HasColumnName("area_g");
            entity.Property(e => e.AreaLand).HasColumnName("area_land");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Descrip).HasColumnName("descrip");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.EastB)
                .HasColumnType("character varying")
                .HasColumnName("east_b");
            entity.Property(e => e.EastL).HasColumnName("east_l");
            entity.Property(e => e.EastL1).HasColumnName("east_l1");
            entity.Property(e => e.EastL2).HasColumnName("east_l2");
            entity.Property(e => e.EastL3).HasColumnName("east_l3");
            entity.Property(e => e.EastL4).HasColumnName("east_l4");
            entity.Property(e => e.EastL5).HasColumnName("east_l5");
            entity.Property(e => e.EastL6).HasColumnName("east_l6");
            entity.Property(e => e.EastLg).HasColumnName("east_lg");
            entity.Property(e => e.FloorNT)
                .HasColumnType("character varying")
                .HasColumnName("floor_n_t");
            entity.Property(e => e.FloorNumb)
                .HasMaxLength(20)
                .HasColumnName("floor_numb");
            entity.Property(e => e.Garden).HasColumnName("garden");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiPolygon,32636)")
                .HasColumnName("geom");
            entity.Property(e => e.Gov)
                .HasMaxLength(200)
                .HasColumnName("gov");
            entity.Property(e => e.GovNo)
                .HasMaxLength(200)
                .HasColumnName("gov_no");
            entity.Property(e => e.Hod)
                .HasColumnType("character varying")
                .HasColumnName("hod");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ket3a)
                .HasColumnType("character varying")
                .HasColumnName("ket3a");
            entity.Property(e => e.Letter)
                .HasMaxLength(1)
                .HasColumnName("letter");
            entity.Property(e => e.Manwr).HasColumnName("manwr");
            entity.Property(e => e.MilOverlap).HasColumnName("mil_overlap");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Ncpslu).HasColumnName("ncpslu");
            entity.Property(e => e.NorthB)
                .HasColumnType("character varying")
                .HasColumnName("north_b");
            entity.Property(e => e.NorthL).HasColumnName("north_l");
            entity.Property(e => e.NorthL1).HasColumnName("north_l1");
            entity.Property(e => e.NorthL2).HasColumnName("north_l2");
            entity.Property(e => e.NorthL3).HasColumnName("north_l3");
            entity.Property(e => e.NorthL4).HasColumnName("north_l4");
            entity.Property(e => e.NorthL5).HasColumnName("north_l5");
            entity.Property(e => e.NorthL6).HasColumnName("north_l6");
            entity.Property(e => e.NorthLg).HasColumnName("north_lg");
            entity.Property(e => e.Overlap).HasColumnName("overlap");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Print).HasColumnName("print");
            entity.Property(e => e.Printdate).HasColumnName("printdate");
            entity.Property(e => e.PropertyN)
                .HasColumnType("character varying")
                .HasColumnName("property_n");
            entity.Property(e => e.Receiptimagepath).HasColumnName("receiptimagepath");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.Sealm).HasColumnName("sealm");
            entity.Property(e => e.Sealmm).HasColumnName("sealmm");
            entity.Property(e => e.Sec)
                .HasMaxLength(200)
                .HasColumnName("sec");
            entity.Property(e => e.SecNow)
                .HasMaxLength(200)
                .HasColumnName("sec_now");
            entity.Property(e => e.Serag)
                .HasColumnType("character varying")
                .HasColumnName("serag");
            entity.Property(e => e.SeragShaqaa).HasColumnName("serag_shaqaa");
            entity.Property(e => e.Seragid).HasColumnName("seragid");
            entity.Property(e => e.SeragidCount).HasColumnName("seragid_count");
            entity.Property(e => e.ShaqaaSeragCount).HasColumnName("shaqaa_serag_count");
            entity.Property(e => e.SouthB)
                .HasColumnType("character varying")
                .HasColumnName("south_b");
            entity.Property(e => e.SouthL).HasColumnName("south_l");
            entity.Property(e => e.SouthL1).HasColumnName("south_l1");
            entity.Property(e => e.SouthL2).HasColumnName("south_l2");
            entity.Property(e => e.SouthL3).HasColumnName("south_l3");
            entity.Property(e => e.SouthL4).HasColumnName("south_l4");
            entity.Property(e => e.SouthL5).HasColumnName("south_l5");
            entity.Property(e => e.SouthL6).HasColumnName("south_l6");
            entity.Property(e => e.SouthLg).HasColumnName("south_lg");
            entity.Property(e => e.Ssec)
                .HasMaxLength(200)
                .HasColumnName("ssec");
            entity.Property(e => e.SsecNow)
                .HasColumnType("character varying")
                .HasColumnName("ssec_now");
            entity.Property(e => e.Streetname)
                .HasMaxLength(200)
                .HasColumnName("streetname");
            entity.Property(e => e.SurveyTeamId).HasColumnName("survey_team_id");
            entity.Property(e => e.SurveyReview).HasColumnName("survey_review");
            entity.Property(e => e.Surveynum)
                .HasMaxLength(10)
                .HasColumnName("surveynum");
            entity.Property(e => e.Tawheed).HasColumnName("tawheed");
            entity.Property(e => e.Totalaparts).HasColumnName("totalaparts");
            entity.Property(e => e.Totalarea).HasColumnName("totalarea");
            entity.Property(e => e.Unittype)
                .HasMaxLength(50)
                .HasColumnName("unittype");
            entity.Property(e => e.Usage)
                .HasColumnType("character varying")
                .HasColumnName("usage");
            entity.Property(e => e.WestB)
                .HasColumnType("character varying")
                .HasColumnName("west_b");
            entity.Property(e => e.WestL).HasColumnName("west_l");
            entity.Property(e => e.WestL1).HasColumnName("west_l1");
            entity.Property(e => e.WestL2).HasColumnName("west_l2");
            entity.Property(e => e.WestL3).HasColumnName("west_l3");
            entity.Property(e => e.WestL4).HasColumnName("west_l4");
            entity.Property(e => e.WestL5).HasColumnName("west_l5");
            entity.Property(e => e.WestL6).HasColumnName("west_l6");
            entity.Property(e => e.WestLg).HasColumnName("west_lg");
            entity.Property(e => e.X)
                .HasColumnType("character varying")
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasColumnType("character varying")
                .HasColumnName("y");
        });

        modelBuilder.Entity<CertificateViewLayoutEdit>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("certificate_view_layout_edit");

            entity.Property(e => e.Addeddate).HasColumnName("addeddate");
            entity.Property(e => e.ApartNum)
                .HasColumnType("character varying")
                .HasColumnName("apart_num");
            entity.Property(e => e.AreaAp1).HasColumnName("area_ap1");
            entity.Property(e => e.AreaAp2).HasColumnName("area_ap2");
            entity.Property(e => e.AreaAp3).HasColumnName("area_ap3");
            entity.Property(e => e.AreaAp4).HasColumnName("area_ap4");
            entity.Property(e => e.AreaAp5).HasColumnName("area_ap5");
            entity.Property(e => e.AreaAp6).HasColumnName("area_ap6");
            entity.Property(e => e.AreaBuild).HasColumnName("area_build");
            entity.Property(e => e.AreaG).HasColumnName("area_g");
            entity.Property(e => e.AreaLand).HasColumnName("area_land");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Descrip).HasColumnName("descrip");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.EastB)
                .HasColumnType("character varying")
                .HasColumnName("east_b");
            entity.Property(e => e.EastL).HasColumnName("east_l");
            entity.Property(e => e.EastL1).HasColumnName("east_l1");
            entity.Property(e => e.EastL2).HasColumnName("east_l2");
            entity.Property(e => e.EastL3).HasColumnName("east_l3");
            entity.Property(e => e.EastL4).HasColumnName("east_l4");
            entity.Property(e => e.EastL5).HasColumnName("east_l5");
            entity.Property(e => e.EastL6).HasColumnName("east_l6");
            entity.Property(e => e.EastLg).HasColumnName("east_lg");
            entity.Property(e => e.FloorNT)
                .HasColumnType("character varying")
                .HasColumnName("floor_n_t");
            entity.Property(e => e.FloorNumb)
                .HasMaxLength(20)
                .HasColumnName("floor_numb");
            entity.Property(e => e.Garden).HasColumnName("garden");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiPolygon,32636)")
                .HasColumnName("geom");
            entity.Property(e => e.Gov)
                .HasMaxLength(200)
                .HasColumnName("gov");
            entity.Property(e => e.GovNo)
                .HasMaxLength(200)
                .HasColumnName("gov_no");
            entity.Property(e => e.Hod)
                .HasColumnType("character varying")
                .HasColumnName("hod");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdShippingorder).HasColumnName("id_shippingorder");
            entity.Property(e => e.Ket3a)
                .HasColumnType("character varying")
                .HasColumnName("ket3a");
            entity.Property(e => e.Letter)
                .HasMaxLength(1)
                .HasColumnName("letter");
            entity.Property(e => e.Manwr).HasColumnName("manwr");
            entity.Property(e => e.MilOverlap).HasColumnName("mil_overlap");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Ncpslu).HasColumnName("ncpslu");
            entity.Property(e => e.NorthB)
                .HasColumnType("character varying")
                .HasColumnName("north_b");
            entity.Property(e => e.NorthL).HasColumnName("north_l");
            entity.Property(e => e.NorthL1).HasColumnName("north_l1");
            entity.Property(e => e.NorthL2).HasColumnName("north_l2");
            entity.Property(e => e.NorthL3).HasColumnName("north_l3");
            entity.Property(e => e.NorthL4).HasColumnName("north_l4");
            entity.Property(e => e.NorthL5).HasColumnName("north_l5");
            entity.Property(e => e.NorthL6).HasColumnName("north_l6");
            entity.Property(e => e.NorthLg).HasColumnName("north_lg");
            entity.Property(e => e.Numberofcopies).HasColumnName("numberofcopies");
            entity.Property(e => e.Overlap).HasColumnName("overlap");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Print).HasColumnName("print");
            entity.Property(e => e.Printdate).HasColumnName("printdate");
            entity.Property(e => e.PropertyN)
                .HasColumnType("character varying")
                .HasColumnName("property_n");
            entity.Property(e => e.Receiptimagepath).HasColumnName("receiptimagepath");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.Sealm).HasColumnName("sealm");
            entity.Property(e => e.Sealmm).HasColumnName("sealmm");
            entity.Property(e => e.Sec)
                .HasMaxLength(200)
                .HasColumnName("sec");
            entity.Property(e => e.SecNow)
                .HasMaxLength(200)
                .HasColumnName("sec_now");
            entity.Property(e => e.Serag)
                .HasColumnType("character varying")
                .HasColumnName("serag");
            entity.Property(e => e.SeragShaqaa).HasColumnName("serag_shaqaa");
            entity.Property(e => e.Seragid).HasColumnName("seragid");
            entity.Property(e => e.SeragidCount).HasColumnName("seragid_count");
            entity.Property(e => e.ShaqaaSeragCount).HasColumnName("shaqaa_serag_count");
            entity.Property(e => e.ShipPrintDate).HasColumnName("ship_print_date");
            entity.Property(e => e.ShipPrintStatus).HasColumnName("ship_print_status");
            entity.Property(e => e.ShipRecert).HasColumnName("ship_recert");
            entity.Property(e => e.ShipRequestnumber)
                .HasColumnType("character varying")
                .HasColumnName("ship_requestnumber");
            entity.Property(e => e.ShipStatus).HasColumnName("ship_status");
            entity.Property(e => e.ShipTofedex).HasColumnName("ship_tofedex");
            entity.Property(e => e.SouthB)
                .HasColumnType("character varying")
                .HasColumnName("south_b");
            entity.Property(e => e.SouthL).HasColumnName("south_l");
            entity.Property(e => e.SouthL1).HasColumnName("south_l1");
            entity.Property(e => e.SouthL2).HasColumnName("south_l2");
            entity.Property(e => e.SouthL3).HasColumnName("south_l3");
            entity.Property(e => e.SouthL4).HasColumnName("south_l4");
            entity.Property(e => e.SouthL5).HasColumnName("south_l5");
            entity.Property(e => e.SouthL6).HasColumnName("south_l6");
            entity.Property(e => e.SouthLg).HasColumnName("south_lg");
            entity.Property(e => e.Ssec)
                .HasMaxLength(200)
                .HasColumnName("ssec");
            entity.Property(e => e.SsecNow)
                .HasColumnType("character varying")
                .HasColumnName("ssec_now");
            entity.Property(e => e.Streetname)
                .HasMaxLength(200)
                .HasColumnName("streetname");
            entity.Property(e => e.SurveyTeamId).HasColumnName("survey_team_id");
            entity.Property(e => e.Surveynum)
                .HasMaxLength(10)
                .HasColumnName("surveynum");
            entity.Property(e => e.Tawheed).HasColumnName("tawheed");
            entity.Property(e => e.Totalaparts).HasColumnName("totalaparts");
            entity.Property(e => e.Totalarea).HasColumnName("totalarea");
            entity.Property(e => e.Unittype)
                .HasMaxLength(50)
                .HasColumnName("unittype");
            entity.Property(e => e.Usage)
                .HasColumnType("character varying")
                .HasColumnName("usage");
            entity.Property(e => e.WestB)
                .HasColumnType("character varying")
                .HasColumnName("west_b");
            entity.Property(e => e.WestL).HasColumnName("west_l");
            entity.Property(e => e.WestL1).HasColumnName("west_l1");
            entity.Property(e => e.WestL2).HasColumnName("west_l2");
            entity.Property(e => e.WestL3).HasColumnName("west_l3");
            entity.Property(e => e.WestL4).HasColumnName("west_l4");
            entity.Property(e => e.WestL5).HasColumnName("west_l5");
            entity.Property(e => e.WestL6).HasColumnName("west_l6");
            entity.Property(e => e.WestLg).HasColumnName("west_lg");
            entity.Property(e => e.X)
                .HasColumnType("character varying")
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasColumnType("character varying")
                .HasColumnName("y");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Districts");

            entity.ToTable("districts");

            entity.HasIndex(e => e.Id, "districtsid").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Addeddate)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("addeddate");
            entity.Property(e => e.Arabicname)
                .HasMaxLength(200)
                .HasColumnName("arabicname");
            entity.Property(e => e.Englishname)
                .HasMaxLength(200)
                .HasColumnName("englishname");
            entity.Property(e => e.Latitude)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("longitude");
            entity.Property(e => e.Modifieddate)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("modifieddate");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
        });

        modelBuilder.Entity<FieldDataV2>(entity =>
        {
            entity.HasKey(e => e.Requestnumber).HasName("field_data_v2_pkey");

            entity.ToTable("field_data_v2");

            entity.HasIndex(e => e.FieldDataId, "field_data_id").IsUnique();

            entity.HasIndex(e => e.Requestnumber, "field_data_v2_index").IsUnique();

            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.ApartmentNo)
                .HasMaxLength(10)
                .HasColumnName("apartment_no");
            entity.Property(e => e.AreaApartment).HasColumnName("area_apartment");
            entity.Property(e => e.AreaApartment2).HasColumnName("area_apartment2");
            entity.Property(e => e.AreaApartment3).HasColumnName("area_apartment3");
            entity.Property(e => e.AreaApartment4).HasColumnName("area_apartment4");
            entity.Property(e => e.AreaApartment5).HasColumnName("area_apartment5");
            entity.Property(e => e.AreaApartment6).HasColumnName("area_apartment6");
            entity.Property(e => e.AreaBerElselm).HasColumnName("area_ber_elselm");
            entity.Property(e => e.AreaBuildings).HasColumnName("area_buildings");
            entity.Property(e => e.AreaG).HasColumnName("area_g");
            entity.Property(e => e.AreaMnawer).HasColumnName("area_mnawer");
            entity.Property(e => e.Attach3aqd)
                .HasColumnType("character varying")
                .HasColumnName("attach_3aqd");
            entity.Property(e => e.AttachCadImg)
                .HasColumnType("character varying")
                .HasColumnName("attach_cad_img");
            entity.Property(e => e.AttachLandName)
                .HasColumnType("character varying")
                .HasColumnName("attach_land_name");
            entity.Property(e => e.AttachLayout)
                .HasColumnType("character varying")
                .HasColumnName("attach_layout");
            entity.Property(e => e.AttachMa7darName)
                .HasColumnType("character varying")
                .HasColumnName("attach_ma7dar_name");
            entity.Property(e => e.AttachName)
                .HasColumnType("character varying")
                .HasColumnName("attach_name");
            entity.Property(e => e.AttachSelimManwarName)
                .HasColumnType("character varying")
                .HasColumnName("attach_selim_manwar_name");
            entity.Property(e => e.CorridorArea).HasColumnName("corridor_area");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EastBorderLength).HasColumnName("east_border_length");
            entity.Property(e => e.EastBorderLengthApartment).HasColumnName("east_border_length_apartment");
            entity.Property(e => e.EastBorderLengthApartment2).HasColumnName("east_border_length_apartment2");
            entity.Property(e => e.EastBorderLengthApartment3).HasColumnName("east_border_length_apartment3");
            entity.Property(e => e.EastBorderLengthApartment4).HasColumnName("east_border_length_apartment4");
            entity.Property(e => e.EastBorderLengthApartment5).HasColumnName("east_border_length_apartment5");
            entity.Property(e => e.EastBorderLengthApartment6).HasColumnName("east_border_length_apartment6");
            entity.Property(e => e.EastBorderName)
                .HasColumnType("character varying")
                .HasColumnName("east_border_name");
            entity.Property(e => e.EastLg).HasColumnName("east_lg");
            entity.Property(e => e.ElevatorArea).HasColumnName("elevator_area");
            entity.Property(e => e.FieldDataId).HasColumnName("field_data_id");
            entity.Property(e => e.GeomBuild)
                .HasColumnType("geometry(Polygon,4326)")
                .HasColumnName("geom_build");
            entity.Property(e => e.ImageRefuse)
                .HasColumnType("character varying")
                .HasColumnName("image_refuse");
            entity.Property(e => e.NorthBorderLength).HasColumnName("north_border_length");
            entity.Property(e => e.NorthBorderLengthApartment).HasColumnName("north_border_length_apartment");
            entity.Property(e => e.NorthBorderLengthApartment2).HasColumnName("north_border_length_apartment2");
            entity.Property(e => e.NorthBorderLengthApartment3).HasColumnName("north_border_length_apartment3");
            entity.Property(e => e.NorthBorderLengthApartment4).HasColumnName("north_border_length_apartment4");
            entity.Property(e => e.NorthBorderLengthApartment5).HasColumnName("north_border_length_apartment5");
            entity.Property(e => e.NorthBorderLengthApartment6).HasColumnName("north_border_length_apartment6");
            entity.Property(e => e.NorthBorderName)
                .HasColumnType("character varying")
                .HasColumnName("north_border_name");
            entity.Property(e => e.NorthLg).HasColumnName("north_lg");
            entity.Property(e => e.SendReview)
                .HasDefaultValueSql("0")
                .HasColumnName("send_review");
            entity.Property(e => e.SouthBorderLength).HasColumnName("south_border_length");
            entity.Property(e => e.SouthBorderLengthApartment).HasColumnName("south_border_length_apartment");
            entity.Property(e => e.SouthBorderLengthApartment2).HasColumnName("south_border_length_apartment2");
            entity.Property(e => e.SouthBorderLengthApartment3).HasColumnName("south_border_length_apartment3");
            entity.Property(e => e.SouthBorderLengthApartment4).HasColumnName("south_border_length_apartment4");
            entity.Property(e => e.SouthBorderLengthApartment5).HasColumnName("south_border_length_apartment5");
            entity.Property(e => e.SouthBorderLengthApartment6).HasColumnName("south_border_length_apartment6");
            entity.Property(e => e.SouthBorderName)
                .HasColumnType("character varying")
                .HasColumnName("south_border_name");
            entity.Property(e => e.SouthLg).HasColumnName("south_lg");
            entity.Property(e => e.SurveyDate)
                .HasColumnType("character varying")
                .HasColumnName("survey_date");
            entity.Property(e => e.SurveyTime).HasColumnName("survey_time");
            entity.Property(e => e.SuvSubtype).HasColumnName("suv_subtype");
            entity.Property(e => e.TotalAreaBuilding).HasColumnName("total_area_building");
            entity.Property(e => e.Usage).HasColumnName("usage");
            entity.Property(e => e.Validdate)
                .HasMaxLength(100)
                .HasColumnName("validdate");
            entity.Property(e => e.Validuser)
                .HasMaxLength(100)
                .HasColumnName("validuser");
            entity.Property(e => e.VisitDate).HasColumnName("visit_date");
            entity.Property(e => e.WestBorderLength).HasColumnName("west_border_length");
            entity.Property(e => e.WestBorderLengthApartment).HasColumnName("west_border_length_apartment");
            entity.Property(e => e.WestBorderLengthApartment2).HasColumnName("west_border_length_apartment2");
            entity.Property(e => e.WestBorderLengthApartment3).HasColumnName("west_border_length_apartment3");
            entity.Property(e => e.WestBorderLengthApartment4).HasColumnName("west_border_length_apartment4");
            entity.Property(e => e.WestBorderLengthApartment5).HasColumnName("west_border_length_apartment5");
            entity.Property(e => e.WestBorderLengthApartment6).HasColumnName("west_border_length_apartment6");
            entity.Property(e => e.WestBorderName)
                .HasColumnType("character varying")
                .HasColumnName("west_border_name");
            entity.Property(e => e.WestLg).HasColumnName("west_lg");
        });

        modelBuilder.Entity<Governorate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Governorates");

            entity.ToTable("governorates");

            entity.HasIndex(e => e.Id, "governorates_index").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Addeddate)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("addeddate");
            entity.Property(e => e.Arabicname)
                .HasMaxLength(200)
                .HasColumnName("arabicname");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Crewtransfercost).HasColumnName("crewtransfercost");
            entity.Property(e => e.Englishname)
                .HasMaxLength(200)
                .HasColumnName("englishname");
            entity.Property(e => e.Latitude)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("longitude");
            entity.Property(e => e.Modifieddate)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("modifieddate");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
        });

        modelBuilder.Entity<LkupStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lkup_status_pkey");

            entity.ToTable("lkup_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Status)
                .HasMaxLength(254)
                .HasColumnName("status");
        });

        modelBuilder.Entity<LkupUnittype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lkup_unittype_pkey");

            entity.ToTable("lkup_unittype");

            entity.HasIndex(e => e.Id, "un_index").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("log_pkey");

            entity.ToTable("log");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Note)
                .HasColumnType("character varying")
                .HasColumnName("note");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("office_pkey");

            entity.ToTable("office");

            entity.HasIndex(e => e.Id, "office_index").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Addeddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("addeddate");
            entity.Property(e => e.Arabicaddress)
                .HasColumnType("character varying")
                .HasColumnName("arabicaddress");
            entity.Property(e => e.Englishaddress)
                .HasColumnType("character varying")
                .HasColumnName("englishaddress");
            entity.Property(e => e.Gpslocation)
                .HasColumnType("character varying")
                .HasColumnName("gpslocation");
            entity.Property(e => e.Latitude)
                .HasColumnType("character varying")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasColumnType("character varying")
                .HasColumnName("longitude");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
        });

        modelBuilder.Entity<Orderstatus>(entity =>
        {
            entity.HasKey(e => e.Orderstatusreference).HasName("orderstatus_pkey");

            entity.ToTable("orderstatus");

            entity.Property(e => e.Orderstatusreference)
                .ValueGeneratedNever()
                .HasColumnName("orderstatusreference");
            entity.Property(e => e.Orderstatusname)
                .HasColumnType("character varying")
                .HasColumnName("orderstatusname");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("regions");

            entity.HasIndex(e => e.Id, "reg").IsUnique();

            entity.Property(e => e.Addeddate)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("addeddate");
            entity.Property(e => e.Arabicname)
                .HasMaxLength(200)
                .HasColumnName("arabicname");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Crewtransfercost).HasColumnName("crewtransfercost");
            entity.Property(e => e.Englishname)
                .HasMaxLength(200)
                .HasColumnName("englishname");
            entity.Property(e => e.Governorateid).HasColumnName("governorateid");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Latitude)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("longitude");
            entity.Property(e => e.Modifieddate)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("modifieddate");
            entity.Property(e => e.Surveyteamid)
                .HasDefaultValueSql("0")
                .HasColumnName("surveyteamid");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Requestnumber }).HasName("requests_pkey");

            entity.ToTable("requests");

            entity.HasIndex(e => e.Requestnumber, "requests_index").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.Addeddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("addeddate");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Areatype).HasColumnName("areatype");
            entity.Property(e => e.Assigned)
                .HasDefaultValueSql("0")
                .HasColumnName("assigned");
            entity.Property(e => e.Buildingarea)
                .HasColumnType("character varying")
                .HasColumnName("buildingarea");
            entity.Property(e => e.Crewtransfercost).HasColumnName("crewtransfercost");
            entity.Property(e => e.Deliverydate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deliverydate");
            entity.Property(e => e.Hasinquiryrequest)
                .HasDefaultValueSql("(0)::bit(1)")
                .HasColumnType("bit(1)")
                .HasColumnName("hasinquiryrequest");
            entity.Property(e => e.Haspricedifference).HasColumnName("haspricedifference");
            entity.Property(e => e.Isarchived).HasColumnName("isarchived");
            entity.Property(e => e.Ispaid).HasColumnName("ispaid");
            entity.Property(e => e.Landarea)
                .HasColumnType("character varying")
                .HasColumnName("landarea");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Paymentdifferenceamount).HasColumnName("paymentdifferenceamount");
            entity.Property(e => e.Paymentstatus).HasColumnName("paymentstatus");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Requeststatus).HasColumnName("requeststatus");
            entity.Property(e => e.Statusdescription)
                .HasColumnType("character varying")
                .HasColumnName("statusdescription");
            entity.Property(e => e.Subunittype).HasColumnName("subunittype");
            entity.Property(e => e.Subunittypearea).HasColumnName("subunittypearea");
            entity.Property(e => e.Unittype).HasColumnName("unittype");
            entity.Property(e => e.Userid)
                .HasColumnType("character varying")
                .HasColumnName("userid");
        });

        modelBuilder.Entity<RequestsExtrainfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("requests_extrainfo_pkey");

            entity.ToTable("requests_extrainfo");

            entity.HasIndex(e => e.Requestnumber, "info").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateShahr).HasColumnName("date_shahr");
            entity.Property(e => e.DateTasgel).HasColumnName("date_tasgel");
            entity.Property(e => e.Fullname)
                .HasColumnType("character varying")
                .HasColumnName("fullname");
            entity.Property(e => e.Images).HasColumnName("images");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.RegistrationNo)
                .HasColumnType("character varying")
                .HasColumnName("registration_no");
            entity.Property(e => e.RequestNo)
                .HasColumnType("character varying")
                .HasColumnName("request_no");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.Validdate)
                .HasMaxLength(50)
                .HasColumnName("validdate");
            entity.Property(e => e.Validuser)
                .HasMaxLength(50)
                .HasColumnName("validuser");
        });

        modelBuilder.Entity<RequestsOverlap>(entity =>
        {
            entity.HasKey(e => e.Requestnumber).HasName("requests_overlap_pkey");

            entity.ToTable("requests_overlap");

            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.AttachOverlap)
                .HasColumnType("character varying")
                .HasColumnName("attach_overlap");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MilOverlap).HasColumnName("mil_overlap");
            entity.Property(e => e.NcpsluDate).HasColumnName("ncpslu_date");
            entity.Property(e => e.NcpsluOverlap).HasColumnName("ncpslu_overlap");
            entity.Property(e => e.NcpsluStatus)
                .HasColumnType("char")
                .HasColumnName("ncpslu_status");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Overlap).HasColumnName("overlap");
            entity.Property(e => e.OverlapDate).HasColumnName("overlap_date");
            entity.Property(e => e.OverlapResponsibility)
                .HasColumnType("char")
                .HasColumnName("overlap_responsibility");
            entity.Property(e => e.OverlapSendStatus)
                .HasColumnType("char")
                .HasColumnName("overlap_send_status");
            entity.Property(e => e.OverlapStatus)
                .HasColumnType("char")
                .HasColumnName("overlap_status");
            entity.Property(e => e.Registability)
                .HasColumnType("char")
                .HasColumnName("registability");
        });

        modelBuilder.Entity<Shippingorder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shippingorders_pkey");

            entity.ToTable("shippingorders");

            entity.HasIndex(e => e.Requestid, "requestidshipping");

            entity.HasIndex(e => e.Id, "shippingorders_index").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Addeddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("addeddate");
            entity.Property(e => e.Apartmentnumber).HasColumnName("apartmentnumber");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Districtid).HasColumnName("districtid");
            entity.Property(e => e.Editcertificateinformation)
                .HasColumnType("character varying")
                .HasColumnName("editcertificateinformation");
            entity.Property(e => e.Extracopiesprice).HasColumnName("extracopiesprice");
            entity.Property(e => e.Floornumber).HasColumnName("floornumber");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Numberofcopies).HasColumnName("numberofcopies");
            entity.Property(e => e.Officeid).HasColumnName("officeid");
            entity.Property(e => e.Orderstatus).HasColumnName("orderstatus");
            entity.Property(e => e.Propertynumber).HasColumnName("propertynumber");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.Requestid).HasColumnName("requestid");
            entity.Property(e => e.Shippingorderstatus).HasColumnName("shippingorderstatus");
            entity.Property(e => e.Shippingprice).HasColumnName("shippingprice");
            entity.Property(e => e.Shippingtype).HasColumnName("shippingtype");
            entity.Property(e => e.Streetname)
                .HasColumnType("character varying")
                .HasColumnName("streetname");
            entity.Property(e => e.Uniquemark)
                .HasColumnType("character varying")
                .HasColumnName("uniquemark");
        });

        modelBuilder.Entity<ShippingordersStatus>(entity =>
        {
            entity.HasKey(e => e.IdShippingorder).HasName("shippingorders_status_pkey");

            entity.ToTable("shippingorders_status");

            entity.HasIndex(e => e.IdShippingorder, "id_shipp").IsUnique();

            entity.HasIndex(e => e.Requestnumber, "requestshipping");

            entity.Property(e => e.IdShippingorder)
                .ValueGeneratedNever()
                .HasColumnName("id_shippingorder");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CommentCompany)
                .HasColumnType("character varying")
                .HasColumnName("comment_company");
            entity.Property(e => e.CommentRsc)
                .HasColumnType("character varying")
                .HasColumnName("comment_rsc");
            entity.Property(e => e.CommentSend)
                .HasColumnType("character varying")
                .HasColumnName("comment_send");
            entity.Property(e => e.CommentTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("comment_time");
            entity.Property(e => e.EditorComment).HasColumnName("editor_comment");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Numberofcopies).HasColumnName("numberofcopies");
            entity.Property(e => e.PrintDate).HasColumnName("print_date");
            entity.Property(e => e.PrintStatus).HasColumnName("print_status");
            entity.Property(e => e.ReceiveComment)
                .HasColumnType("character varying")
                .HasColumnName("receive_comment");
            entity.Property(e => e.Recert).HasColumnName("recert");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("0")
                .HasColumnName("status");
            entity.Property(e => e.StatusDate).HasColumnName("status_date");
            entity.Property(e => e.SubStatus).HasColumnName("sub_status");
            entity.Property(e => e.Tofedex).HasColumnName("tofedex");
        });

        modelBuilder.Entity<Ssec>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ssec");

            entity.Property(e => e.Districtid).HasColumnName("districtid");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.SecCode)
                .HasColumnType("character varying")
                .HasColumnName("sec_code");
            entity.Property(e => e.SsecCode)
                .HasColumnType("character varying")
                .HasColumnName("ssec_code");
            entity.Property(e => e.SsecNameAr)
                .HasColumnType("character varying")
                .HasColumnName("ssec_name_ar");
            entity.Property(e => e.SsecNameEn)
                .HasColumnType("character varying")
                .HasColumnName("ssec_name_en");
        });

        modelBuilder.Entity<SsecGeom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ssec_geom_pkey");

            entity.ToTable("ssec_geom");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Districtid).HasColumnName("districtid");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiPolygon,32636)")
                .HasColumnName("geom");
            entity.Property(e => e.SecCode)
                .HasMaxLength(255)
                .HasColumnName("sec_code");
            entity.Property(e => e.SsecCode)
                .HasMaxLength(255)
                .HasColumnName("ssec_code");
            entity.Property(e => e.SsecName)
                .HasMaxLength(255)
                .HasColumnName("ssec_name");
        });

        modelBuilder.Entity<Subunittype>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("subunittype");

            entity.Property(e => e.Subunittype1).HasColumnName("subunittype");
            entity.Property(e => e.SubunittypeArabicname)
                .HasMaxLength(50)
                .HasColumnName("subunittype_arabicname");
            entity.Property(e => e.SubunittypeName)
                .HasMaxLength(30)
                .HasColumnName("subunittype_name");
        });

        modelBuilder.Entity<Surveygi>(entity =>
        {
            entity.HasKey(e => e.Seragid).HasName("surveygis_seragid_pkey");

            entity.ToTable("surveygis");

            entity.Property(e => e.Seragid)
                .HasColumnType("character varying")
                .HasColumnName("seragid");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Districtid).HasColumnName("districtid");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiPolygon,32636)")
                .HasColumnName("geom");
            entity.Property(e => e.Ids)
                .ValueGeneratedOnAdd()
                .HasColumnName("ids");
            entity.Property(e => e.XValidation)
                .HasColumnType("character varying")
                .HasColumnName("x_validation");
            entity.Property(e => e.YValidation)
                .HasColumnType("character varying")
                .HasColumnName("y_validation");
        });

        modelBuilder.Entity<UnittypeValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unittype_lookup_pkey");

            entity.ToTable("unittype_value");

            entity.HasIndex(e => e.Id, "unittype").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Unitname)
                .HasColumnType("character varying")
                .HasColumnName("unitname");
        });

        modelBuilder.Entity<UsageStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lukp_sub_unit_type_pkey");

            entity.ToTable("usage_status");

            entity.HasIndex(e => e.Id, "idin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Useraddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("useraddresses_pkey");

            entity.ToTable("useraddresses");

            entity.HasIndex(e => e.Id, "useraddresses_index").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Addeddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("addeddate");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Districtid).HasColumnName("districtid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.Userprofileid).HasColumnName("userprofileid");
        });

        modelBuilder.Entity<Userprofile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userprofiles_pkey");

            entity.ToTable("userprofiles");

            entity.HasIndex(e => e.Id, "userprofiles_index").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Addeddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("addeddate");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Telephonenumber)
                .HasColumnType("character varying")
                .HasColumnName("telephonenumber");
            entity.Property(e => e.Telephonenumber2)
                .HasColumnType("character varying")
                .HasColumnName("telephonenumber2");
            entity.Property(e => e.Userid)
                .HasColumnType("character varying")
                .HasColumnName("userid");
        });

        modelBuilder.Entity<_1PrintCertificateCover>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("1_print_certificate_cover");

            entity.Property(e => e.Addr)
                .HasColumnType("character varying")
                .HasColumnName("addr");
            entity.Property(e => e.Areaafter).HasColumnName("areaafter");
            entity.Property(e => e.Areabefore).HasColumnName("areabefore");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Garden).HasColumnName("garden");
            entity.Property(e => e.Gov)
                .HasMaxLength(200)
                .HasColumnName("gov");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MaintypeCsv).HasColumnName("maintype_csv");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.Sec)
                .HasMaxLength(200)
                .HasColumnName("sec");
            entity.Property(e => e.Shippingtype).HasColumnName("shippingtype");
            entity.Property(e => e.Ssec)
                .HasColumnType("character varying")
                .HasColumnName("ssec");
            entity.Property(e => e.SubtypeCsv).HasColumnName("subtype_csv");
            entity.Property(e => e.Subunittypebefore).HasColumnName("subunittypebefore");
            entity.Property(e => e.Typeafter).HasColumnName("typeafter");
            entity.Property(e => e.Typebefore)
                .HasColumnType("character varying")
                .HasColumnName("typebefore");
        });

        modelBuilder.Entity<_2CertificateView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("2_certificate_view");

            entity.Property(e => e.Addeddate).HasColumnName("addeddate");
            entity.Property(e => e.ApartNum)
                .HasColumnType("character varying")
                .HasColumnName("apart_num");
            entity.Property(e => e.AreaAp1).HasColumnName("area_ap1");
            entity.Property(e => e.AreaAp2).HasColumnName("area_ap2");
            entity.Property(e => e.AreaAp3).HasColumnName("area_ap3");
            entity.Property(e => e.AreaAp4).HasColumnName("area_ap4");
            entity.Property(e => e.AreaAp5).HasColumnName("area_ap5");
            entity.Property(e => e.AreaAp6).HasColumnName("area_ap6");
            entity.Property(e => e.AreaBuild).HasColumnName("area_build");
            entity.Property(e => e.AreaG).HasColumnName("area_g");
            entity.Property(e => e.AreaLand).HasColumnName("area_land");
            entity.Property(e => e.Comcode).HasColumnName("comcode");
            entity.Property(e => e.Corridor).HasColumnName("corridor");
            entity.Property(e => e.Descrip).HasColumnName("descrip");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.EastB)
                .HasColumnType("character varying")
                .HasColumnName("east_b");
            entity.Property(e => e.EastL).HasColumnName("east_l");
            entity.Property(e => e.EastL1).HasColumnName("east_l1");
            entity.Property(e => e.EastL2).HasColumnName("east_l2");
            entity.Property(e => e.EastL3).HasColumnName("east_l3");
            entity.Property(e => e.EastL4).HasColumnName("east_l4");
            entity.Property(e => e.EastL5).HasColumnName("east_l5");
            entity.Property(e => e.EastL6).HasColumnName("east_l6");
            entity.Property(e => e.EastLg).HasColumnName("east_lg");
            entity.Property(e => e.Elevator).HasColumnName("elevator");
            entity.Property(e => e.FloorNT)
                .HasColumnType("character varying")
                .HasColumnName("floor_n_t");
            entity.Property(e => e.FloorNumb)
                .HasMaxLength(20)
                .HasColumnName("floor_numb");
            entity.Property(e => e.GeomBuild)
                .HasColumnType("geometry(Polygon,4326)")
                .HasColumnName("geom_build");
            entity.Property(e => e.Gov)
                .HasMaxLength(200)
                .HasColumnName("gov");
            entity.Property(e => e.Hod)
                .HasColumnType("character varying")
                .HasColumnName("hod");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ket3a)
                .HasColumnType("character varying")
                .HasColumnName("ket3a");
            entity.Property(e => e.Manwr).HasColumnName("manwr");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.NcpsluOverlap).HasColumnName("ncpslu_overlap");
            entity.Property(e => e.NorthB)
                .HasColumnType("character varying")
                .HasColumnName("north_b");
            entity.Property(e => e.NorthL).HasColumnName("north_l");
            entity.Property(e => e.NorthL1).HasColumnName("north_l1");
            entity.Property(e => e.NorthL2).HasColumnName("north_l2");
            entity.Property(e => e.NorthL3).HasColumnName("north_l3");
            entity.Property(e => e.NorthL4).HasColumnName("north_l4");
            entity.Property(e => e.NorthL5).HasColumnName("north_l5");
            entity.Property(e => e.NorthL6).HasColumnName("north_l6");
            entity.Property(e => e.NorthLg).HasColumnName("north_lg");
            entity.Property(e => e.Overlap).HasColumnName("overlap");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.PropertyN)
                .HasColumnType("character varying")
                .HasColumnName("property_n");
            entity.Property(e => e.Requestnumber)
                .HasColumnType("character varying")
                .HasColumnName("requestnumber");
            entity.Property(e => e.Sealm).HasColumnName("sealm");
            entity.Property(e => e.Sec)
                .HasMaxLength(200)
                .HasColumnName("sec");
            entity.Property(e => e.SouthB)
                .HasColumnType("character varying")
                .HasColumnName("south_b");
            entity.Property(e => e.SouthL).HasColumnName("south_l");
            entity.Property(e => e.SouthL1).HasColumnName("south_l1");
            entity.Property(e => e.SouthL2).HasColumnName("south_l2");
            entity.Property(e => e.SouthL3).HasColumnName("south_l3");
            entity.Property(e => e.SouthL4).HasColumnName("south_l4");
            entity.Property(e => e.SouthL5).HasColumnName("south_l5");
            entity.Property(e => e.SouthL6).HasColumnName("south_l6");
            entity.Property(e => e.SouthLg).HasColumnName("south_lg");
            entity.Property(e => e.Ssec)
                .HasMaxLength(200)
                .HasColumnName("ssec");
            entity.Property(e => e.Streetname)
                .HasMaxLength(200)
                .HasColumnName("streetname");
            entity.Property(e => e.SurveyReviewStatus).HasColumnName("survey_review_status");
            entity.Property(e => e.Surveynum)
                .HasMaxLength(10)
                .HasColumnName("surveynum");
            entity.Property(e => e.Totalaparts).HasColumnName("totalaparts");
            entity.Property(e => e.Totalarea).HasColumnName("totalarea");
            entity.Property(e => e.Unittype)
                .HasMaxLength(50)
                .HasColumnName("unittype");
            entity.Property(e => e.Usage)
                .HasColumnType("character varying")
                .HasColumnName("usage");
            entity.Property(e => e.WestB)
                .HasColumnType("character varying")
                .HasColumnName("west_b");
            entity.Property(e => e.WestL).HasColumnName("west_l");
            entity.Property(e => e.WestL1).HasColumnName("west_l1");
            entity.Property(e => e.WestL2).HasColumnName("west_l2");
            entity.Property(e => e.WestL3).HasColumnName("west_l3");
            entity.Property(e => e.WestL4).HasColumnName("west_l4");
            entity.Property(e => e.WestL5).HasColumnName("west_l5");
            entity.Property(e => e.WestL6).HasColumnName("west_l6");
            entity.Property(e => e.WestLg).HasColumnName("west_lg");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
