using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XuLyKhoaLuan.Migrations
{
    public partial class AddIdentityAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DETAI",
                columns: table => new
                {
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenDT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TomTat = table.Column<string>(type: "ntext", nullable: true),
                    SLMin = table.Column<int>(type: "int", nullable: true),
                    SLMax = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETAI", x => x.MaDT);
                });

            migrationBuilder.CreateTable(
                name: "DOTDK",
                columns: table => new
                {
                    NamHoc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOTDK", x => new { x.NamHoc, x.Dot });
                });

            migrationBuilder.CreateTable(
                name: "KHOA",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phong = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHOA", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "NHOM",
                columns: table => new
                {
                    MaNhom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenNhom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHOM", x => x.MaNhom);
                });

            migrationBuilder.CreateTable(
                name: "VAITRO",
                columns: table => new
                {
                    MaVT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenVaiTro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAITRO", x => x.MaVT);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BOMON",
                columns: table => new
                {
                    MaBM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenBM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MaKhoa = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMON", x => x.MaBM);
                    table.ForeignKey(
                        name: "FK_BOMON_KHOA",
                        column: x => x.MaKhoa,
                        principalTable: "KHOA",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "CHUYENNGANH",
                columns: table => new
                {
                    MaCN = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenCN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhoa = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHUYENNGANH", x => x.MaCN);
                    table.ForeignKey(
                        name: "FK_CHUYENNGANH_KHOA",
                        column: x => x.MaKhoa,
                        principalTable: "KHOA",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "GIAOVU",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenGV = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    NgayNhanViec = table.Column<DateTime>(type: "date", nullable: true),
                    NgayNghi = table.Column<DateTime>(type: "date", nullable: true),
                    MaKhoa = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIAOVU", x => x.MaGV);
                    table.ForeignKey(
                        name: "FK_GIAOVU_KHOA",
                        column: x => x.MaKhoa,
                        principalTable: "KHOA",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "THONGBAO",
                columns: table => new
                {
                    MaTB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTB = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NoiDung = table.Column<string>(type: "ntext", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileTB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayTB = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaKhoa = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THONGBAO", x => x.MaTB);
                    table.ForeignKey(
                        name: "FK_THONGBAO_KHOA",
                        column: x => x.MaKhoa,
                        principalTable: "KHOA",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "DANGKY",
                columns: table => new
                {
                    MaNhom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NgayDK = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayGiao = table.Column<DateTime>(type: "date", nullable: true),
                    NgayBD = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKT = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANGKY", x => new { x.MaNhom, x.MaDT });
                    table.ForeignKey(
                        name: "FK_DANGKY_DETAI",
                        column: x => x.MaDT,
                        principalTable: "DETAI",
                        principalColumn: "MaDT");
                    table.ForeignKey(
                        name: "FK_DANGKY_NHOM",
                        column: x => x.MaNhom,
                        principalTable: "NHOM",
                        principalColumn: "MaNhom");
                });

            migrationBuilder.CreateTable(
                name: "GIANGVIEN",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenGV = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    HocHam = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HocVi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NgayNhanViec = table.Column<DateTime>(type: "date", nullable: true),
                    NgayNghi = table.Column<DateTime>(type: "date", nullable: true),
                    MaBM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIANGVIEN", x => x.MaGV);
                    table.ForeignKey(
                        name: "FK_GIANGVIEN_BOMON",
                        column: x => x.MaBM,
                        principalTable: "BOMON",
                        principalColumn: "MaBM");
                });

            migrationBuilder.CreateTable(
                name: "HOIDONG",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenHD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayLap = table.Column<DateTime>(type: "date", nullable: true),
                    NgayBaoVe = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiaDiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaBM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOIDONG", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HOIDONG_BOMON",
                        column: x => x.MaBM,
                        principalTable: "BOMON",
                        principalColumn: "MaBM");
                });

            migrationBuilder.CreateTable(
                name: "KEHOACH",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKH = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SoLuongDT = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBD = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThoiGianKT = table.Column<DateTime>(type: "datetime", nullable: true),
                    HinhAnh = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FileKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaKhoa = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaBM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KEHOACH", x => x.MaKH);
                    table.ForeignKey(
                        name: "FK_KEHOACH_BOMON",
                        column: x => x.MaBM,
                        principalTable: "BOMON",
                        principalColumn: "MaBM");
                    table.ForeignKey(
                        name: "FK_KEHOACH_KHOA",
                        column: x => x.MaKhoa,
                        principalTable: "KHOA",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "DETAI_CHUYENNGANH",
                columns: table => new
                {
                    MaCN = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Note = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETAI_CHUYENNGANH", x => new { x.MaCN, x.MaDT });
                    table.ForeignKey(
                        name: "FK_DT_CN_CHUYENNGANH",
                        column: x => x.MaCN,
                        principalTable: "CHUYENNGANH",
                        principalColumn: "MaCN");
                    table.ForeignKey(
                        name: "FK_DT_CN_DETAI",
                        column: x => x.MaDT,
                        principalTable: "DETAI",
                        principalColumn: "MaDT");
                });

            migrationBuilder.CreateTable(
                name: "SINHVIEN",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenSV = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Lop = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MaCN = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SINHVIEN", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SINHVIEN_CHUYENNGANH",
                        column: x => x.MaCN,
                        principalTable: "CHUYENNGANH",
                        principalColumn: "MaCN");
                });

            migrationBuilder.CreateTable(
                name: "DUYETDT",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    LanDuyet = table.Column<int>(type: "int", nullable: false),
                    NgayDuyet = table.Column<DateTime>(type: "datetime", nullable: false),
                    NhanXet = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUYETDT", x => new { x.MaGV, x.MaDT, x.LanDuyet });
                    table.ForeignKey(
                        name: "FK_DUYETDT_DETAI",
                        column: x => x.MaDT,
                        principalTable: "DETAI",
                        principalColumn: "MaDT");
                    table.ForeignKey(
                        name: "FK_DUYETDT_GIANGVIEN",
                        column: x => x.MaGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGV");
                });

            migrationBuilder.CreateTable(
                name: "HUONGDAN",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    DuaRaHD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HUONGDAN", x => new { x.MaGV, x.MaDT });
                    table.ForeignKey(
                        name: "FK_HUONGDAN_DETAI",
                        column: x => x.MaDT,
                        principalTable: "DETAI",
                        principalColumn: "MaDT");
                    table.ForeignKey(
                        name: "FK_HUONGDAN_GIANGVIEN",
                        column: x => x.MaGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGV");
                });

            migrationBuilder.CreateTable(
                name: "NHIEMVU",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNV = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SoLuongDT = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBD = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThoiGianKT = table.Column<DateTime>(type: "datetime", nullable: true),
                    HinhAnh = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FileNV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaBM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHIEMVU", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NHIEMVU_BOMON",
                        column: x => x.MaBM,
                        principalTable: "BOMON",
                        principalColumn: "MaBM");
                    table.ForeignKey(
                        name: "FK_NHIEMVU_GIANGVIEN",
                        column: x => x.MaGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGV");
                });

            migrationBuilder.CreateTable(
                name: "PHANBIEN",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    DuaRaHD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANBIEN", x => new { x.MaGV, x.MaDT });
                    table.ForeignKey(
                        name: "FK_PHANBIEN_DETAI",
                        column: x => x.MaDT,
                        principalTable: "DETAI",
                        principalColumn: "MaDT");
                    table.ForeignKey(
                        name: "FK_PHANBIEN_GIANGVIEN",
                        column: x => x.MaGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGV");
                });

            migrationBuilder.CreateTable(
                name: "RADE",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Note = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RADE", x => new { x.MaGV, x.MaDT });
                    table.ForeignKey(
                        name: "FK_RADE_DETAI",
                        column: x => x.MaDT,
                        principalTable: "DETAI",
                        principalColumn: "MaDT");
                    table.ForeignKey(
                        name: "FK_RADE_GIANGVIEN",
                        column: x => x.MaGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGV");
                });

            migrationBuilder.CreateTable(
                name: "TRUONGBM",
                columns: table => new
                {
                    MaTBM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NgayNhanChuc = table.Column<DateTime>(type: "date", nullable: true),
                    NgayNghi = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRUONGBM", x => x.MaTBM);
                    table.ForeignKey(
                        name: "FK_TRUONGBM_BOMON",
                        column: x => x.MaBM,
                        principalTable: "BOMON",
                        principalColumn: "MaBM");
                    table.ForeignKey(
                        name: "FK_TRUONGBM_GIANGVIEN",
                        column: x => x.MaGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGV");
                });

            migrationBuilder.CreateTable(
                name: "TRUONGKHOA",
                columns: table => new
                {
                    MaTK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhoa = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NgayNhanChuc = table.Column<DateTime>(type: "date", nullable: false),
                    NgayNghi = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRUONGKHOA", x => x.MaTK);
                    table.ForeignKey(
                        name: "FK_TRUONGKHOA_GIANGVIEN",
                        column: x => x.MaGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGV");
                    table.ForeignKey(
                        name: "FK_TRUONGKHOA_KHOA",
                        column: x => x.MaKhoa,
                        principalTable: "KHOA",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "XACNHAN",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    DuaRaHD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XACNHAN", x => new { x.MaGV, x.MaDT });
                    table.ForeignKey(
                        name: "FK_XACNHAN_DETAI",
                        column: x => x.MaDT,
                        principalTable: "DETAI",
                        principalColumn: "MaDT");
                    table.ForeignKey(
                        name: "FK_XACNHAN_GIANGVIEN",
                        column: x => x.MaGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGV");
                });

            migrationBuilder.CreateTable(
                name: "THAMGIAHD",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaVT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THAMGIAHD", x => new { x.MaHD, x.MaGV });
                    table.ForeignKey(
                        name: "FK_THAMGIAHD_GIANGVIEN",
                        column: x => x.MaGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGV");
                    table.ForeignKey(
                        name: "FK_THAMGIAHD_HOIDONG",
                        column: x => x.MaHD,
                        principalTable: "HOIDONG",
                        principalColumn: "MaHD");
                    table.ForeignKey(
                        name: "FK_THAMGIAHD_VAITRO",
                        column: x => x.MaVT,
                        principalTable: "VAITRO",
                        principalColumn: "MaVT");
                });

            migrationBuilder.CreateTable(
                name: "THAMGIA",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NamHoc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dot = table.Column<int>(type: "int", nullable: false),
                    MaNhom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DiemTB = table.Column<double>(type: "float", nullable: true),
                    TruongNhom = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THAMGIA", x => new { x.MaSV, x.NamHoc, x.Dot });
                    table.ForeignKey(
                        name: "FK_THAMGIA_DOTDK",
                        columns: x => new { x.NamHoc, x.Dot },
                        principalTable: "DOTDK",
                        principalColumns: new[] { "NamHoc", "Dot" });
                    table.ForeignKey(
                        name: "FK_THAMGIA_SINHVIEN",
                        column: x => x.MaSV,
                        principalTable: "SINHVIEN",
                        principalColumn: "MaSV");
                });

            migrationBuilder.CreateTable(
                name: "CONGVIEC",
                columns: table => new
                {
                    MaCV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TenCV = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    YeuCau = table.Column<string>(type: "ntext", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    HanChot = table.Column<DateTime>(type: "datetime", nullable: true),
                    MucDoHoanThanh = table.Column<double>(type: "float", nullable: true),
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaNhom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONGVIEC", x => x.MaCV);
                    table.ForeignKey(
                        name: "FK_CONGVIEC_HUONGDAN",
                        columns: x => new { x.MaGV, x.MaDT },
                        principalTable: "HUONGDAN",
                        principalColumns: new[] { "MaGV", "MaDT" });
                    table.ForeignKey(
                        name: "FK_CONGVIEC_NHOM",
                        column: x => x.MaNhom,
                        principalTable: "NHOM",
                        principalColumn: "MaNhom");
                });

            migrationBuilder.CreateTable(
                name: "PBNHANXET",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGian = table.Column<DateTime>(type: "datetime", nullable: true),
                    NoiDung = table.Column<string>(type: "ntext", nullable: true),
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBNHANXET", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PBNHANXET_PHANBIEN",
                        columns: x => new { x.MaGV, x.MaDT },
                        principalTable: "PHANBIEN",
                        principalColumns: new[] { "MaGV", "MaDT" });
                });

            migrationBuilder.CreateTable(
                name: "HDPHANBIEN",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaHD = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Diem = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHAMDIEM", x => new { x.MaGV, x.MaHD, x.MaDT });
                    table.ForeignKey(
                        name: "FK_HDPHANBIEN_DETAI",
                        column: x => x.MaDT,
                        principalTable: "DETAI",
                        principalColumn: "MaDT");
                    table.ForeignKey(
                        name: "FK_HDPHANBIEN_THAMGIAHD",
                        columns: x => new { x.MaHD, x.MaGV },
                        principalTable: "THAMGIAHD",
                        principalColumns: new[] { "MaHD", "MaGV" });
                });

            migrationBuilder.CreateTable(
                name: "HDCHAM",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaSV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NamHoc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dot = table.Column<int>(type: "int", nullable: false),
                    Diem = table.Column<double>(type: "float", nullable: true),
                    HeSo = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDCHAM", x => new { x.MaGV, x.MaDT });
                    table.ForeignKey(
                        name: "FK_HDCHAM_HUONGDAN",
                        columns: x => new { x.MaGV, x.MaDT },
                        principalTable: "HUONGDAN",
                        principalColumns: new[] { "MaGV", "MaDT" });
                    table.ForeignKey(
                        name: "FK_HDCHAM_THAMGIA",
                        columns: x => new { x.MaSV, x.NamHoc, x.Dot },
                        principalTable: "THAMGIA",
                        principalColumns: new[] { "MaSV", "NamHoc", "Dot" });
                });

            migrationBuilder.CreateTable(
                name: "LOIMOI",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NamHoc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dot = table.Column<int>(type: "int", nullable: false),
                    MaNhom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LoiNhan = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOIMOI", x => new { x.MaSV, x.NamHoc, x.Dot, x.MaNhom });
                    table.ForeignKey(
                        name: "FK_LOIMOI_NHOM",
                        column: x => x.MaNhom,
                        principalTable: "NHOM",
                        principalColumn: "MaNhom");
                    table.ForeignKey(
                        name: "FK_LOIMOI_THAMGIA",
                        columns: x => new { x.MaSV, x.NamHoc, x.Dot },
                        principalTable: "THAMGIA",
                        principalColumns: new[] { "MaSV", "NamHoc", "Dot" });
                });

            migrationBuilder.CreateTable(
                name: "PBCHAM",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaSV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NamHoc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dot = table.Column<int>(type: "int", nullable: false),
                    Diem = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBCHAM", x => new { x.MaGV, x.MaDT });
                    table.ForeignKey(
                        name: "FK_PBCHAM_PHANBIEN",
                        columns: x => new { x.MaGV, x.MaDT },
                        principalTable: "PHANBIEN",
                        principalColumns: new[] { "MaGV", "MaDT" });
                    table.ForeignKey(
                        name: "FK_PBCHAM_THAMGIA",
                        columns: x => new { x.MaSV, x.NamHoc, x.Dot },
                        principalTable: "THAMGIA",
                        principalColumns: new[] { "MaSV", "NamHoc", "Dot" });
                });

            migrationBuilder.CreateTable(
                name: "BAOCAO",
                columns: table => new
                {
                    MaCV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaSV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NamHoc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dot = table.Column<int>(type: "int", nullable: false),
                    LanNop = table.Column<int>(type: "int", nullable: false),
                    ThoiGianNop = table.Column<DateTime>(type: "datetime", nullable: true),
                    File_BC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAOCAO", x => new { x.MaCV, x.MaSV, x.NamHoc, x.Dot, x.LanNop });
                    table.ForeignKey(
                        name: "FK_BAOCAO_CONGVIEC",
                        column: x => x.MaCV,
                        principalTable: "CONGVIEC",
                        principalColumn: "MaCV");
                    table.ForeignKey(
                        name: "FK_BAOCAO_THAMGIA",
                        columns: x => new { x.MaSV, x.NamHoc, x.Dot },
                        principalTable: "THAMGIA",
                        principalColumns: new[] { "MaSV", "NamHoc", "Dot" });
                });

            migrationBuilder.CreateTable(
                name: "BINHLUAN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGian = table.Column<DateTime>(type: "datetime", nullable: true),
                    NoiDung = table.Column<string>(type: "ntext", nullable: true),
                    MaCV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaSV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    NamHoc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Dot = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BINHLUAN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BINHLUAN_CONGVIEC",
                        column: x => x.MaCV,
                        principalTable: "CONGVIEC",
                        principalColumn: "MaCV");
                    table.ForeignKey(
                        name: "FK_BINHLUAN_THAMGIA",
                        columns: x => new { x.MaSV, x.NamHoc, x.Dot },
                        principalTable: "THAMGIA",
                        principalColumns: new[] { "MaSV", "NamHoc", "Dot" });
                });

            migrationBuilder.CreateTable(
                name: "HDGOPY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGian = table.Column<DateTime>(type: "datetime", nullable: true),
                    NoiDung = table.Column<string>(type: "ntext", nullable: true),
                    MaCV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDGOPY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HDGOPY_CONGVIEC",
                        column: x => x.MaCV,
                        principalTable: "CONGVIEC",
                        principalColumn: "MaCV");
                    table.ForeignKey(
                        name: "FK_HDGOPY_HUONGDAN",
                        columns: x => new { x.MaGV, x.MaDT },
                        principalTable: "HUONGDAN",
                        principalColumns: new[] { "MaGV", "MaDT" });
                });

            migrationBuilder.CreateTable(
                name: "HDPBCHAM",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaHD = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaSV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NamHoc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Dot = table.Column<int>(type: "int", nullable: false),
                    Diem = table.Column<double>(type: "float", nullable: true),
                    HeSo = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDPBCHAM", x => new { x.MaGV, x.MaHD, x.MaDT, x.MaSV, x.NamHoc, x.Dot });
                    table.ForeignKey(
                        name: "FK_HDPBCHAM_HDPHANBIEN",
                        columns: x => new { x.MaGV, x.MaHD, x.MaDT },
                        principalTable: "HDPHANBIEN",
                        principalColumns: new[] { "MaGV", "MaHD", "MaDT" });
                    table.ForeignKey(
                        name: "FK_HDPBCHAM_THAMGIA",
                        columns: x => new { x.MaSV, x.NamHoc, x.Dot },
                        principalTable: "THAMGIA",
                        principalColumns: new[] { "MaSV", "NamHoc", "Dot" });
                });

            migrationBuilder.CreateTable(
                name: "HDPBNHANXET",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGian = table.Column<DateTime>(type: "datetime", nullable: true),
                    NoiDung = table.Column<string>(type: "ntext", nullable: true),
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaHD = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDPBNHANXET", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HDPBNHANXET_HDPHANBIEN",
                        columns: x => new { x.MaGV, x.MaHD, x.MaDT },
                        principalTable: "HDPHANBIEN",
                        principalColumns: new[] { "MaGV", "MaHD", "MaDT" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BAOCAO_MaSV_NamHoc_Dot",
                table: "BAOCAO",
                columns: new[] { "MaSV", "NamHoc", "Dot" });

            migrationBuilder.CreateIndex(
                name: "IX_BINHLUAN_MaCV",
                table: "BINHLUAN",
                column: "MaCV");

            migrationBuilder.CreateIndex(
                name: "IX_BINHLUAN_MaSV_NamHoc_Dot",
                table: "BINHLUAN",
                columns: new[] { "MaSV", "NamHoc", "Dot" });

            migrationBuilder.CreateIndex(
                name: "IX_BOMON_MaKhoa",
                table: "BOMON",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_CHUYENNGANH_MaKhoa",
                table: "CHUYENNGANH",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_CONGVIEC_MaGV_MaDT",
                table: "CONGVIEC",
                columns: new[] { "MaGV", "MaDT" });

            migrationBuilder.CreateIndex(
                name: "IX_CONGVIEC_MaNhom",
                table: "CONGVIEC",
                column: "MaNhom");

            migrationBuilder.CreateIndex(
                name: "IX_DANGKY_MaDT",
                table: "DANGKY",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_DETAI_CHUYENNGANH_MaDT",
                table: "DETAI_CHUYENNGANH",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_DUYETDT_MaDT",
                table: "DUYETDT",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_GIANGVIEN_MaBM",
                table: "GIANGVIEN",
                column: "MaBM");

            migrationBuilder.CreateIndex(
                name: "IX_GIAOVU_MaKhoa",
                table: "GIAOVU",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_HDCHAM_MaSV_NamHoc_Dot",
                table: "HDCHAM",
                columns: new[] { "MaSV", "NamHoc", "Dot" });

            migrationBuilder.CreateIndex(
                name: "IX_HDGOPY_MaCV",
                table: "HDGOPY",
                column: "MaCV");

            migrationBuilder.CreateIndex(
                name: "IX_HDGOPY_MaGV_MaDT",
                table: "HDGOPY",
                columns: new[] { "MaGV", "MaDT" });

            migrationBuilder.CreateIndex(
                name: "IX_HDPBCHAM_MaSV_NamHoc_Dot",
                table: "HDPBCHAM",
                columns: new[] { "MaSV", "NamHoc", "Dot" });

            migrationBuilder.CreateIndex(
                name: "IX_HDPBNHANXET_MaGV_MaHD_MaDT",
                table: "HDPBNHANXET",
                columns: new[] { "MaGV", "MaHD", "MaDT" });

            migrationBuilder.CreateIndex(
                name: "IX_HDPHANBIEN_MaDT",
                table: "HDPHANBIEN",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_HDPHANBIEN_MaHD_MaGV",
                table: "HDPHANBIEN",
                columns: new[] { "MaHD", "MaGV" });

            migrationBuilder.CreateIndex(
                name: "IX_HOIDONG_MaBM",
                table: "HOIDONG",
                column: "MaBM");

            migrationBuilder.CreateIndex(
                name: "IX_HUONGDAN_MaDT",
                table: "HUONGDAN",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_KEHOACH_MaBM",
                table: "KEHOACH",
                column: "MaBM");

            migrationBuilder.CreateIndex(
                name: "IX_KEHOACH_MaKhoa",
                table: "KEHOACH",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_LOIMOI_MaNhom",
                table: "LOIMOI",
                column: "MaNhom");

            migrationBuilder.CreateIndex(
                name: "IX_NHIEMVU_MaBM",
                table: "NHIEMVU",
                column: "MaBM");

            migrationBuilder.CreateIndex(
                name: "IX_NHIEMVU_MaGV",
                table: "NHIEMVU",
                column: "MaGV");

            migrationBuilder.CreateIndex(
                name: "IX_PBCHAM_MaSV_NamHoc_Dot",
                table: "PBCHAM",
                columns: new[] { "MaSV", "NamHoc", "Dot" });

            migrationBuilder.CreateIndex(
                name: "IX_PBNHANXET_MaGV_MaDT",
                table: "PBNHANXET",
                columns: new[] { "MaGV", "MaDT" });

            migrationBuilder.CreateIndex(
                name: "IX_PHANBIEN_MaDT",
                table: "PHANBIEN",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_RADE_MaDT",
                table: "RADE",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_SINHVIEN_MaCN",
                table: "SINHVIEN",
                column: "MaCN");

            migrationBuilder.CreateIndex(
                name: "IX_THAMGIA_NamHoc_Dot",
                table: "THAMGIA",
                columns: new[] { "NamHoc", "Dot" });

            migrationBuilder.CreateIndex(
                name: "IX_THAMGIAHD_MaGV",
                table: "THAMGIAHD",
                column: "MaGV");

            migrationBuilder.CreateIndex(
                name: "IX_THAMGIAHD_MaVT",
                table: "THAMGIAHD",
                column: "MaVT");

            migrationBuilder.CreateIndex(
                name: "IX_THONGBAO_MaKhoa",
                table: "THONGBAO",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_TRUONGBM_MaBM",
                table: "TRUONGBM",
                column: "MaBM");

            migrationBuilder.CreateIndex(
                name: "IX_TRUONGBM_MaGV",
                table: "TRUONGBM",
                column: "MaGV");

            migrationBuilder.CreateIndex(
                name: "IX_TRUONGKHOA_MaGV",
                table: "TRUONGKHOA",
                column: "MaGV");

            migrationBuilder.CreateIndex(
                name: "IX_TRUONGKHOA_MaKhoa",
                table: "TRUONGKHOA",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_XACNHAN_MaDT",
                table: "XACNHAN",
                column: "MaDT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BAOCAO");

            migrationBuilder.DropTable(
                name: "BINHLUAN");

            migrationBuilder.DropTable(
                name: "DANGKY");

            migrationBuilder.DropTable(
                name: "DETAI_CHUYENNGANH");

            migrationBuilder.DropTable(
                name: "DUYETDT");

            migrationBuilder.DropTable(
                name: "GIAOVU");

            migrationBuilder.DropTable(
                name: "HDCHAM");

            migrationBuilder.DropTable(
                name: "HDGOPY");

            migrationBuilder.DropTable(
                name: "HDPBCHAM");

            migrationBuilder.DropTable(
                name: "HDPBNHANXET");

            migrationBuilder.DropTable(
                name: "KEHOACH");

            migrationBuilder.DropTable(
                name: "LOIMOI");

            migrationBuilder.DropTable(
                name: "NHIEMVU");

            migrationBuilder.DropTable(
                name: "PBCHAM");

            migrationBuilder.DropTable(
                name: "PBNHANXET");

            migrationBuilder.DropTable(
                name: "RADE");

            migrationBuilder.DropTable(
                name: "THONGBAO");

            migrationBuilder.DropTable(
                name: "TRUONGBM");

            migrationBuilder.DropTable(
                name: "TRUONGKHOA");

            migrationBuilder.DropTable(
                name: "XACNHAN");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CONGVIEC");

            migrationBuilder.DropTable(
                name: "HDPHANBIEN");

            migrationBuilder.DropTable(
                name: "THAMGIA");

            migrationBuilder.DropTable(
                name: "PHANBIEN");

            migrationBuilder.DropTable(
                name: "HUONGDAN");

            migrationBuilder.DropTable(
                name: "NHOM");

            migrationBuilder.DropTable(
                name: "THAMGIAHD");

            migrationBuilder.DropTable(
                name: "DOTDK");

            migrationBuilder.DropTable(
                name: "SINHVIEN");

            migrationBuilder.DropTable(
                name: "DETAI");

            migrationBuilder.DropTable(
                name: "GIANGVIEN");

            migrationBuilder.DropTable(
                name: "HOIDONG");

            migrationBuilder.DropTable(
                name: "VAITRO");

            migrationBuilder.DropTable(
                name: "CHUYENNGANH");

            migrationBuilder.DropTable(
                name: "BOMON");

            migrationBuilder.DropTable(
                name: "KHOA");
        }
    }
}
