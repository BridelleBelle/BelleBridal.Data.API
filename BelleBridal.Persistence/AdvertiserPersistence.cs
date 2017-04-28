using System.Threading.Tasks;
using BelleBridal.API.Data;
using BridalBelle.Database;

namespace BelleBridal.Persistence
{
	public class AdvertiserPersistence
	{
		private DocumentDbClient<Advertiser> Client;

		public AdvertiserPersistence()
		{
			Client = new DocumentDbClient<Advertiser>("advertisers");
		}

		public async Task<Advertiser> GetAdvertiser(string id)
		{
			await Client.Initialize();
			var result = await Client.Get(id);

			return new Advertiser
			{
				ID = result.GetPropertyValue<string>("id")
			};
		}
	}
}
