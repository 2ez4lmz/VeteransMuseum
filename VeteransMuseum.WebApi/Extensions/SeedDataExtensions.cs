using System.Data;
using Bogus;
using Dapper;
using VeteransMuseum.Application.Abstractions.Data;

namespace VeteransMuseum.WebApi.Extensions;

internal static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            ISqlConnectionFactory sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
            using IDbConnection connection = sqlConnectionFactory.CreateConnection();

            var faker = new Faker();

            // List<object> apartments = new();
            // for (int i = 0; i < 100; i++)
            // {
            //
            // }
            //
            // const string sql = """
            // INSERT INTO public.apartments
            // (id, "name", description, address_country, address_state, address_zip_code, address_city, address_street, price_amount, price_currency, cleaning_fee_amount, cleaning_fee_currency, amenities, last_booked_on_utc)
            // VALUES(@Id, @Name, @Description, @Country, @State, @ZipCode, @City, @Street, @PriceAmount, @PriceCurrency, @CleaningFeeAmount, @CleaningFeeCurrency, @Amenities, @LastBookedOn);
            // """;
            //
            // connection.Execute(sql, apartments);
        }
    }