# TaxRating-Api
Angular + DotNet 6

Api build on DotNetFrameWork 6;

Using, TDD , DDD, Fluent Assertion, Fluent Validation, EF 6, AutoMapper.

Run Migration, the project are using SQLServer localdb.

- In DotNet project open Package Manager Console, and with Infrastructure project selected execute Migration

I used 2 differents players to get rating information, https://openexchangerates.org and http://api.exchangeratesapi.io , in my tests the openexchange was better, because was must more faster and use https by default and had header option eTag.

For the correct functioning, a previous registration in the players will be necessary: https://openexchangerates.org ou http://api.exchangeratesapi.io, to get a valid apikey,
and add in appsettings;
