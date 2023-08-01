namespace Items.Data.Configurations
{
	using Items.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class PictureEntityConfiguration : IEntityTypeConfiguration<Picture>
	{
		public void Configure(EntityTypeBuilder<Picture> builder)
		{
			builder
				.HasData(GeneratePictures());
		}

		private Picture[] GeneratePictures()
		{
			List<Picture> pictures = new List<Picture>();

			Picture picture = new Picture
			{
				Id = Guid.Parse("E63087E2-E37A-4E94-8BA8-E4751568D345"),
				ItemId = Guid.Parse("70AB6375-3DA7-41CB-B80C-DCEE2BA4FBBB"),
				Uri = "https://i5.walmartimages.com/asr/19fe13d7-ea2e-47f7-8547-202ce8c88717_1.bc800cefd11bb60ebc07ebdd7fac8ff6.jpeg",
				IsPrivate = false,
				IsMain = true
			};
			pictures.Add(picture);
			
			picture = new Picture
			{
				Id = Guid.Parse("FFB2C420-ACCA-4346-9E99-0E52D44F9F50"),
				ItemId = Guid.Parse("E4D2697E-8EDF-49F5-BAC0-BC76DFBB43EE"),
				Uri = "https://image.pushauction.com/0/0/77191e32-26bc-45d1-b916-1425f6513281/4533eb18-a6eb-4783-b444-aad16f842869.jpg",
				IsPrivate = false,
				IsMain = true
			};
			pictures.Add(picture);
			
			picture = new Picture
			{
				Id = Guid.Parse("FE43B7C3-8583-4F87-B6B4-8FA522072A17"),
				ItemId = Guid.Parse("EA486471-25CA-40C5-BDCE-C7C4157EB1B0"),
				Uri = "https://static2.redcart.pl/templates/images/thumb/10281/800/9999/pl/0/templates/images/products/10281/067a782229f0ab90838b869e943673ca.jpg",
				IsPrivate = false,
				IsMain = true
			};
			pictures.Add(picture);
			
			picture = new Picture
			{
				Id = Guid.Parse("78F32A40-2D8B-47ED-A424-0F757C4BD0FB"),
				ItemId = Guid.Parse("2AA8B934-59F3-473B-842E-3DF2A3590B92"),
				Uri = "https://i5.walmartimages.com/asr/0b26c2b4-5459-424c-ae09-364824104c90_1.642441b6196644f95b66202bb6185285.jpeg?odnWidth=1000&odnHeight=1000&odnBg=ffffff",
				IsPrivate = false,
				IsMain = true
			};
			pictures.Add(picture);
			
			picture = new Picture
			{
				Id = Guid.Parse("F2F7BD16-E413-4735-A550-0CA57628996D"),
				ItemId = Guid.Parse("7EC3D946-D2EF-4D54-A98E-00EA2B2E8B45"),
				Uri = "https://i5.walmartimages.com/asr/ea368e4c-f0e3-401b-8cff-2344a05955ed_2.de437c99da79acc1cc2bec706fea7ce4.jpeg",
				IsPrivate = false,
				IsMain = true
			};
			pictures.Add(picture);
			
			picture = new Picture
			{
				Id = Guid.Parse("0E1DB751-83FD-42E8-8C5D-E9D4A96A9A6C"),
				ItemId = Guid.Parse("EA9141C8-8C5B-4126-9A30-7A82796E922C"),
				Uri = "https://i5.walmartimages.com/asr/cb1717c7-d4b2-483b-91a9-770f3db40076_1.1f5d5f997641b1adb8323d08d95e6bd6.jpeg",
				IsPrivate = false,
				IsMain = true
			};
			pictures.Add(picture);
			
			picture = new Picture
			{
				Id = Guid.Parse("A109510E-B303-479C-B1FE-A9B92967A057"),
				ItemId = Guid.Parse("CC1A92FF-E773-4D37-8D66-DDB31AB612B2"),
				Uri = "http://www.babylonhobbies.com/ebay/pictures/EDU_14862.jpg",
				IsPrivate = false,
				IsMain = true
			};
			pictures.Add(picture);
			
			picture = new Picture
			{
				Id = Guid.Parse("7C7DAF02-3D4E-4D0D-B42A-52F20F5F6206"),
				ItemId = Guid.Parse("A0F0C44B-1BA4-484D-9C36-498579B61D37"),
				Uri = "https://www.kids-room.com/WebRoot/KidsroomDE/Shops/Kidsroom/55B8/CACC/36F4/5060/F31B/4DEB/AE1C/138D/BILD3_E6319/IC_IMAGE/en-hape-knob-puzzle-vehicles.jpg",
				IsPrivate = false,
				IsMain = true
			};
			pictures.Add(picture);
			
			picture = new Picture
			{
				Id = Guid.Parse("85A7CD2B-46D8-4C1F-B931-5B2047891D5B"),
				ItemId = Guid.Parse("A676AF29-2FD2-4E17-918D-73EC948CDC73"),
				Uri = "https://jigsawpuzzles.online/king-include/uploads1/auto-cadillac-oldtimer-classic-vehicle-chrome-607938272.jpg",
				IsPrivate = false,
				IsMain = true
			};
			pictures.Add(picture);


			return pictures.ToArray();
		}
	}
}
