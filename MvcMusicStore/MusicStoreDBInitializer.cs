using System.Data.Entity;
using MvcMusicStore.Models;

namespace MvcMusicStore
{
	public class MusicStoreDbInitializer : DropCreateDatabaseAlways<MusicStoreDb>
	{
		protected override void Seed(MusicStoreDb context)
		{
			context.Artists.Add(new Artist() {Name = "Radu Poklitaru"});
			context.Genres.Add(new Genre() {Name = "Classic"});
			base.Seed(context);
		}
	}
}