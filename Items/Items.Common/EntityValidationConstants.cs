namespace Items.Common
{
    public static class EntityValidationConstants
    {
        public static class Location
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 200;

            public const int CountryMinLength = 2;
            public const int CountryMaxLength = 90;

            public const int AddressMinLength = 2;
            public const int AddressMaxLength = 500;

            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 500;
        }

        public static class Place
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 200;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }

        public static class Currency
        {
            public const int IsoCodeMinLength = 3;
            public const int IsoCodeMaxLength = 3;

            public const int NameMinLength = 3;
            public const int NameMaxLength = 40;

            public const int SymbolMinLength = 1;
            public const int SymbolMaxLength = 4;
        }

        public static class Document
        {
            public const int UriMinLength = 1;
            public const int UriMaxLength = 2048;
        }

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 200;
        }

        public static class Item
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 200;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const int DocumentUriMinLength = 1;
            public const int DocumentUriMaxLength = 2048;

            public const int QuantityPrecision = 18;
            public const int QuantityScale = 3;

            public const double QuantityMinValue = 0.001;
            public const double QuantityMaxValue = 999999999999999.999;
            
            public const double QuantityFrontMinValue = 0.001;
            public const double QuantityFrontMaxValue = 999999999999999.999;

			public const int PromisedQuantityPrecision = 18;
			public const int PromisedQuantityScale = 3;

			public const double PromisedQuantityMinValue = 0.001;
			public const double PromisedQuantityMaxValue = 999999999999999.999;



			public const int ValuePrecision = 18;
            public const int ValueScale = 2;
			public const double ValueMinValue = 0.01;
			public const double ValueMaxValue = 9999999999999999.99;
            
            public const double ValueFrontMinValue = 0.01;
			public const double ValueFrontMaxValue = 9999999999999999.99;

			public const int UriMinLength = 1;
			public const int UriMaxLength = 2048;

            public const long ImageSizeMaxLength = 5000000;

		}

        public static class Offer
        {
            public const int MessageMinLength = 1;
            public const int MessageMaxLength = 1000;

            public const int ValuePrecision = 18;
            public const int ValueScale = 2;
			public const double ValueMinValue = 0;
			public const double ValueMaxValue = 9999999999999999.99;
			public const double ValueMinStep = 0.01;

			public const int QuantityPrecision = 18;
            public const int QuantityScale = 3;
			public const double QuantityMinValue = 0.001;
			public const double QuantityMaxValue = 999999999999999.999;

			public const double QuantityFrontMinValue = 0.001;
			public const double QuantityFrontMaxValue = 999999999999.999;
		}
        
        public static class Contract
        {
            public const int CommentMinLength = 2;
            public const int CommentMaxLength = 1000;

            public const int ValuePrecision = 18;
            public const int ValueScale = 6;
			public const double ValueMinValue = 0;
			public const double ValueMaxValue = 9999999999999999.99;

			public const int QuantityPrecision = 18;
            public const int QuantityScale = 6;

			public const double QuantityMinValue = 0.001;
			public const double QuantityMaxValue = 999999999999999.999;

			public const int DeliveryAddressMinLength = 5;
			public const int DeliveryAddressMaxLength = 1000;

			public const int ItemNameMinLength = 2;
			public const int ItemNameMaxLength = 200;

			public const int UriMinLength = 1;
			public const int UriMaxLength = 2048;

			public const int ItemDescriptionMinLength = 10;
			public const int ItemDescriptionMaxLength = 1000;

		}
        
        public static class QueryFilter
        {
            public const int SearchTermMin = 1;
            public const int SearchTermMax = 1500;

            public const int HitsPerPageMin = 1;
            public const int HitsPerPageMax = 100;


        }

        public static class User
        {

			public const int UserNameMinLength = 2;
			public const int UserNameMaxLength = 256;

			public const int UserEmailMinLength = 2;
			public const int UserEmailMaxLength = 256;

			public const int UserPhoneMinLength = 2;
			public const int UserPhoneMaxLength = 200;

			public const int UserRoleMinLength = 2;
			public const int UserRoleMaxLength = 256;

            public const int ProfilePictureMax = 2 - 000 - 000;
		}


		public static class Ticket
		{
			public const int TitleMin = 1;
			public const int TitleMax = 50;

			public const int DescriptionMin = 10;
			public const int DescriptionMax = 1000;

            public const int SnapshotMax = 2 - 000 - 000;
		}


        public static class TicketType
        {
            public const int NameMin = 2;
            public const int NameMax = 50;
        }
        

        public static class TicketStatus
		{
            public const int NameMin = 2;
            public const int NameMax = 50;
        }

        public static class Unit
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 200;

            public const int SymbolMinLength = 1;
            public const int SymbolMaxLength = 90;

        }
    }
}
