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

        public static class Picture
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
            public const int QuantityScale = 6;

            public const int ValuePrecision = 18;
            public const int ValueScale = 6;

        }

        public static class Offer
        {
            public const int MessageMinLength = 1;
            public const int MessageMaxLength = 1000;

            public const int ValuePrecision = 18;
            public const int ValueScale = 6;

            public const int QuantityPrecision = 18;
            public const int QuantityScale = 6;
        }
        
        public static class Account
        {
            public const int ValuePrecision = 18;
            public const int ValueScale = 6;
        }

        
    }
}
