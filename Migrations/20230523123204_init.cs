using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("109bc11b-00fd-4827-8937-e9c3e2d484f8"), "mpdqmmuvjdklxmzwiiht" },
                    { new Guid("17ee3b77-5833-42e2-b8e3-7efc1d5164f5"), "hhtixvuuepihhyvluwnn" },
                    { new Guid("25068f13-df49-40e7-8b86-cc758d2cb947"), "biwpuckhntwengstszij" },
                    { new Guid("2b84c6bf-c871-4878-9f28-ae77c721f146"), "hlrfdrnaliukgxyritvz" },
                    { new Guid("3a1501b7-1b3b-45e2-b9b4-709a0ebb8533"), "vxhodfssdwrggtijeawu" },
                    { new Guid("3f08abbb-a7bf-4410-8d52-2bd797ffeed9"), "mlqgdzmjslgeghgahtdu" },
                    { new Guid("47c4583d-2e5e-41dc-8016-c2b3d099616d"), "skbwlslzziplbwcgeaim" },
                    { new Guid("60a8e100-1709-431d-8e4d-c4940e85fe6c"), "kmxewrbivhddneclshzq" },
                    { new Guid("6c315a57-8c52-4772-a1a8-a70a9734124b"), "lmlgafempckrdkyiteif" },
                    { new Guid("70c150b6-e020-4632-8bd6-23078c1f3078"), "mmbuzwhfwkhxnafjybcp" },
                    { new Guid("7497a69e-8597-4c12-be10-f4187d764875"), "dkvcilhhcweqzpnwpmky" },
                    { new Guid("8572e9a9-9208-43b0-97f2-2d9ede0a3231"), "xmglmzsbjewcefxbhzxq" },
                    { new Guid("859e2059-869f-444f-bc38-28decb831e49"), "wsceoudxazqxnovsziqc" },
                    { new Guid("91eaa6ae-8e65-4a78-93f8-ec83f4c73db1"), "czjvvznlfikbxiwqiqbw" },
                    { new Guid("9ab9f8bc-9a86-4050-9891-faced2a0585d"), "vcdjhhhzdrkvmuuuvfqj" },
                    { new Guid("a099d1b6-4c9e-4328-ba4c-5f14f5c00817"), "bidfptnhcgwyprhkkeme" },
                    { new Guid("ce500b3a-0a11-4de7-bb7c-9b2ad9ab7eae"), "nrigcofkjaufikegifdu" },
                    { new Guid("d388deea-56f3-4e9f-9f6d-ea324447599a"), "fzjufquflndwxurnhywv" },
                    { new Guid("d8fc0830-efcd-4a70-af0c-da6f7b2a937a"), "ijxdfoawhdhbpenpcizs" },
                    { new Guid("e65986b5-9024-4abb-8263-b83a5f5233be"), "zlepzuabhsebkzxtblvz" },
                    { new Guid("ed55a8b1-7756-413f-8ea0-d67f6f4eb861"), "vzfuwfrhcldvfkrcqlrk" },
                    { new Guid("eeccb781-3d41-4e78-ae4a-495c99fd3a5b"), "oabphzptjbdihhapnmlg" },
                    { new Guid("ef3a7363-630c-4b7c-b126-7816b41ef275"), "rtnyrygujhwgiugdevhq" },
                    { new Guid("f15501f3-c969-4adb-9f11-9e5308eeda8a"), "dvehuiarbtqikfjioivs" },
                    { new Guid("fb609679-66e2-4718-a25e-fcef955c602c"), "bmnzarqgenitjefbxszm" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
