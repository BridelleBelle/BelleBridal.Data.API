using System.Collections.Generic;
using System.Threading.Tasks;
using BelleBridal.API.Data;
using BelleBridal.Persistence;

namespace BelleBridal.API.Service
{
	public class MagazineService
	{
		private MagazinePersistence MagazinePersistence;
		private AdvertiserPersistence AdvertiserPersistence;
		public MagazineService()
		{
			MagazinePersistence = new MagazinePersistence();
			AdvertiserPersistence = new AdvertiserPersistence();
		}

		public async Task<Magazine> GetMagazine(string id)
		{
			return await MagazinePersistence.GetMagazine(id);
		}

		public async Task<IEnumerable<Advertiser>> GetMagazineAdvertisers(string magazineId)
		{
			var mag = await MagazinePersistence.GetMagazine(magazineId);

			var advertisers = new List<Advertiser>();

			foreach (var ad in mag.Advertisers)
			{
				advertisers.Add(await AdvertiserPersistence.GetAdvertiser(ad.Advertiser.ID));
			}

			return advertisers;
		}

		public async Task GetLatestMagazines()
		{
			await MagazinePersistence.GetLatestMagazines();
		}
	}
}
