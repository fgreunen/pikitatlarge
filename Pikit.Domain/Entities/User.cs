using Repository.Pattern.Ef6;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pikit.Domain.Entities
{
	[Table(nameof(User))]
	public class User
	: Entity
	{
		public User()
		{
			if (UniqueIdentifier == Guid.Empty)
				UniqueIdentifier = Guid.NewGuid();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		public Guid UniqueIdentifier { get; set; }
	}
}