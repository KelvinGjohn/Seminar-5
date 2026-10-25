# Seminar 5 – Invoice system (Visual Programming Languages)

Windows Forms app with Entity Framework Core (SQLite) and Bogus fake data.

## How to run
1. Open `Seminar_5.sln` in Visual Studio.
2. Press **Start**. The database `app.db` is created automatically and filled with
   30 clients, 200 invoices and 400 payments the first time.

## Where is each task step?
| Task step | File |
|---|---|
| 2) NuGet packages | `Seminar_5/Seminar_5.csproj` |
| 3) Database classes | `Seminar_5/Models/Client.cs`, `Invoice.cs`, `Payment.cs`, `PaymentMethod.cs` |
| 4) Create the database | `AppDbContext.cs` + `db.Database.EnsureCreated()` in `Form1_Load` |
| 5) DataSeeder with Bogus | `Seminar_5/Seeders/DataSeeder.cs` |
| 6) Form design | `Form1.Designer.cs` |
| 7) Invoices / Clients / Payments buttons + dynamic search | `Form1.cs` (top part) |
| 8) Five LINQ query buttons | `Form1.cs` (bottom part) |

## Study notes
- **Join** = connect two lists by a matching key (invoice.ClientId == client.Id). One row per match.
- **GroupJoin** = for each item on the left, get a *group* of matching items on the right
  (one invoice → all its payments `ps`). Then you can do `ps.Sum(p => p.Amount)`.
- **Where** filters, **OrderByDescending** sorts biggest first, **Take(3)** keeps the first 3.
- `new { ... }` creates an anonymous object — its properties become the DataGridView columns.
- We call `.ToList()` on the tables first, so LINQ runs in memory. SQLite cannot sum or sort
  `decimal` values, and EF Core cannot translate `GroupJoin`, so this avoids runtime errors.
- Balance = TotalAmount − sum of payments. Balance > 0 means the invoice is not fully paid.

## Using migrations instead (like in class)
If you prefer migrations: remove `db.Database.EnsureCreated();` from `Form1_Load`, then in
Package Manager Console run `Add-Migration InitialCreate` and `Update-Database`.
