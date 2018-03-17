## Handling EF6 Migrations manually through the VS Package Manager Console (aka Power Shell)
### Setup (One time only)
<code>PM> Enable-Migrations</code>

### Per Migration (Every migration)
1. Modify your schema (via changes to the entity models/maps)
<br/><code>PM> Add-Migration &lt;migration note&gt;</code>
<br/><sup><i>Note: A new file will be created within the Migrations/ directory containing the generated migration file</i></sup>

2. Update <code>.Migrations.Configuration.Seed(...)</code> to include altered seed data to run during migration

3. Repeat steps 1 &amp; 2 (as often as needed until migration changes are complete)

4. Apply your migrations
<br/><code>PM> Update-Database <i>[-Verbose]</i></code>

