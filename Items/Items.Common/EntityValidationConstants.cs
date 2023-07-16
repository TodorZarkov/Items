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
        }

        public static class Place
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 200;

        }

    }
}
