using System;
using System.Threading.Tasks;
using BelleBridal.API.Data;
using BridalBelle.Database;

namespace BelleBridal.Persistence
{
	public class MagazinePersistence
	{
		private DocumentDbClient<Magazine> Client;
		private string collection = "magazines";
		public MagazinePersistence()
		{
			Client = new DocumentDbClient<Magazine>(collection);
		}

		public async Task<Magazine> GetMagazine(string id)
		{
			await Client.Initialize();
			var result = await Client.Get(id);

			return new Magazine
			{
				Id = result.GetPropertyValue<string>("id"),
				Name = result.GetPropertyValue<string>("name")
			};
		}

		public async Task GetLatestMagazines()
		{
			await Client.Initialize();
			var sql = String.Format("SELECT * FROM {0}", collection);
			var x = Client.Query(sql);
		}
	}
}
