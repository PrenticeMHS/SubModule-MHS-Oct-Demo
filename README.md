1. updated the "conn" connection string in the app.config to match your sqlexpress database's connection string.
2. Update the following Paths in the app.config to your own local directory.
 - SchemaPath
 - migrationPath
 - seedingPath

 # October DUBUP DEMO Script

## STEP 1
SUB Module Example
1. try and run the solution.
- it will fail do the database not exisiting.
2. create a branch.
- show off the ability to make branches for just 1 of the submodules.
3. Update the code with with this:
DbupDemo.Program.updater();
4. run the code
- the code will fail again.
- Accept the PR I made in advacned that will add the following code:
https://github.com/PrenticeMHS/Dbup-MHS-Oct-Demo/pull/2

#if DEBUG
EnsureDatabase.For.SqlDatabase(connectionString);
#endif

5. run it again and it should work an display the list of products.
## Step 2
DB UP DbupDemo
1. GIVE OVER VIEW OF CODE AND COMPARE THE CONSOLE
- Line 16 is going to check if the database exists and it does not it will create it. *THIS CODE IS REQUIRED TO RUN THE UPGRADER*
- Line 18Explain the Upgrader
- Line 21-23 have them change the file location to match their local and give a brief explanation of WithScriptsFromFileSystem
- Line 26 Brief over view of logging with custom logging
- over view of the OutputResults Method
2. GO OVER THE DATABASE
- See the tables that were added
- See look at and talk about the journaling tables.
3. POPULATE THE STORES PAGE
1.	Give and add following script: SeedStores.sql
2.	Update File using naming scheme YYYYMMDDHHMM[FileName].
3.	[INSERT DATE HERE]SeedStores.sql

## Step 3
4. USE CO-PILOT TO CREATE MIGRATION AND POPULATE LOOK UP TABLE
- Have copilot modify the stock table.
- make sure to refernece the 'Stock' schema script
- PROMPT: Create a new Migration script that will add quantity to the stock table with a default of 0 as well as create a new seeding script that will populate it based on the store and product table with random quanties.
- run the 2 new scripts to add the quantity field and the seeding script.
- go back to the database
- End off with this query:
Select strs.outlet, strs.location, p.Name, stck.quantity
From [dbo].[stores] strs
inner join [dbo].[stock] stck
on strs.id = stck.store_id
inner join [dbo].[Product] p
on stck.product_id = p.id
