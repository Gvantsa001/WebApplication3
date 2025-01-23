# WebApplication3
1. პროექტის შექმნა
Visual Studio-ის გამოყენებით:
გახსენით Visual Studio.
აირჩიეთ Create a new project.
მოძებნეთ ASP.NET Core Web API შაბლონი და დააჭირეთ Next.
დაასახელეთ პროექტი (მაგალითად: MobileContactsAPI) და აირჩიეთ მისთვის განკუთვნილი მდებარეობა.
დააჭირეთ Create.
პროექტის ვარიანტებში აირჩიეთ:
.NET 7.0 (Long-term support) (ან უახლესი ვერსია).
Use controllers.
დატოვეთ სხვა ვარიანტები სტანდარტულად და დააჭირეთ Create.
2. დამოკიდებულებების დამატება
პროექტში საჭიროა SQLite-ისა და EF Core-ის დამოკიდებულებები. გააკეთეთ შემდეგი:

გახსენით Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
დააინსტალირეთ შემდეგი პაკეტები:
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore (Swagger-ისთვის).

3. კოდის ჩაწერა
3.1 Პროგრამის ფაილები
კოდი ჩაწერეთ შემდეგი ლოგიკით:

Program.cs ფაილი: გამოიყენეთ ის, რაც პროექტს ავტომატურად მოყვება, ან ჩაანაცვლეთ მოცემული კოდით.

ContactsDbContext და Contact მოდელები: შექმენით ახალი ფაილები პროექტში:

პროექტში შექმენით ახალი დირექტორია Models.
შექმენით ფაილი Contact.cs და ჩაწერეთ მოდელის კოდი.
შექმენით ფაილი ContactsDbContext.cs და ჩაწერეთ კონტექსტი.
ContactsController.cs ფაილი: შექმენით ახალი ფაილი დირექტორიაში Controllers და ჩაწერეთ Controller-ის ლოგიკა.
