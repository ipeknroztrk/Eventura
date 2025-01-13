using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 'TicketId' kolonunun adını 'EventId' olarak değiştiriyoruz
            migrationBuilder.RenameColumn(
                name: "TicketId",  // Eski kolon adı
                table: "UserFavorites",  // Tablo adı
                newName: "EventId");  // Yeni kolon adı

            // Kolon adı değiştikten sonra, ilişkiyi tekrar tanımlıyoruz
            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Events_EventId",  // Yeni ilişki adı
                table: "UserFavorites",
                column: "EventId",
                principalTable: "Events",  // Events tablosuna referans
                principalColumn: "EventId",  // EventId'yi ilişkilendiriyoruz
                onDelete: ReferentialAction.Cascade);  // Etkinlik silindiğinde favori kayıtları da silinsin
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
