using Pikit.Data.Migrations;
using Pikit.Domain.Entities;
using Repository.Pattern.Ef6;
using System.Data.Entity;

namespace Pikit.Data.Contexts
{
	public class PikitContext
		: DataContext, IPikitContext
	{
		const string CONNECTION_STRING_NAME = "PikitContext";
		const int COMMAND_TIMEOUT = 600;

		public PikitContext() : base(CONNECTION_STRING_NAME)
		{
			/* http://www.entityframeworktutorial.net/code-first/automated-migration-in-code-first.aspx
			 * Commands:
			 * enable-migrations –EnableAutomaticMigration:$true -Force
			 * update-database
			 * update-database -Force
			 * Update-Database -Script // This builds a .sql script (but doesn't run it) to update the current database.
			 * */

			Database.SetInitializer(new MigrateDatabaseToLatestVersion<PikitContext, Configuration>(CONNECTION_STRING_NAME));
			Database.CommandTimeout = COMMAND_TIMEOUT;
		}

		public virtual IDbSet<User> User { get; set; }

		public void ConnectTest()
		{
			Database.Connection.Open();
			Database.Connection.Close();
		}
	}
}