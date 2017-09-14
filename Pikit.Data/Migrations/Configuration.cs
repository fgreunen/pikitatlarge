namespace Pikit.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Contexts.PikitContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(Contexts.PikitContext context)
		{
			LoadMigrationScripts(context);
		}

		private void LoadMigrationScripts(Contexts.PikitContext context)
		{
			const string SQLNewCommandSplit = "GO";

			var dirs = new string[] {
				Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Pikit.Data\\Migrations\\MigrationScripts") };

			foreach (string dir in dirs)
			{
				if (!Directory.Exists(dir))
					throw new Exception(string.Format("Pikit.Data.Migrations.Configuration.LoadStoredProcedures() - [{0}] folder not found!", dir));

				foreach (var filePath in Directory.EnumerateFiles(dir, "*.sql"))
				{
					Debug.WriteLine(string.Format("Executing SQL file: {0}", filePath));
					var individualCommands = File.ReadAllText(filePath).Split(new string[] { SQLNewCommandSplit }, StringSplitOptions.RemoveEmptyEntries);

					foreach (string splitCommand in individualCommands.Where(x => !string.IsNullOrEmpty(x.Trim())))
						context.Database.ExecuteSqlCommand(splitCommand);
				}
			}
		}
	}
}