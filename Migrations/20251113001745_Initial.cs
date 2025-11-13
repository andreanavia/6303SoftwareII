using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationId",
                table: "ReservationSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_Seats_SeatId",
                table: "ReservationSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Shows_ShowId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_ShowId_Row_Number",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationSeats",
                table: "ReservationSeats");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameTable(
                name: "ReservationSeats",
                newName: "ReservationSeat");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeats_SeatId",
                table: "ReservationSeat",
                newName: "IX_ReservationSeat_SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeats_ReservationId",
                table: "ReservationSeat",
                newName: "IX_ReservationSeat_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationSeat",
                table: "ReservationSeat",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ShowId",
                table: "Seat",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeat_Reservations_ReservationId",
                table: "ReservationSeat",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeat_Seat_SeatId",
                table: "ReservationSeat",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Shows_ShowId",
                table: "Seat",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeat_Reservations_ReservationId",
                table: "ReservationSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeat_Seat_SeatId",
                table: "ReservationSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Shows_ShowId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_ShowId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationSeat",
                table: "ReservationSeat");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameTable(
                name: "ReservationSeat",
                newName: "ReservationSeats");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeat_SeatId",
                table: "ReservationSeats",
                newName: "IX_ReservationSeats_SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeat_ReservationId",
                table: "ReservationSeats",
                newName: "IX_ReservationSeats_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationSeats",
                table: "ReservationSeats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ShowId_Row_Number",
                table: "Seats",
                columns: new[] { "ShowId", "Row", "Number" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationId",
                table: "ReservationSeats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_Seats_SeatId",
                table: "ReservationSeats",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Shows_ShowId",
                table: "Seats",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
