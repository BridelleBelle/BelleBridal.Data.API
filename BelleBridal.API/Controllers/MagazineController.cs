using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BelleBridal.API.Data;
using BelleBridal.API.Models;
using BelleBridal.API.Service;

namespace BelleBridal.API.Controllers
{
	public class MagazineController : ApiController
	{
		private MagazineService MagazineService;

		[HttpGet]
		public async Task<MagazineDto> GetMagazine(long id)
		{
			if (Request.IsLocal())
			{
				MagazineService = new MagazineService();
				var mag = await MagazineService.GetMagazine(id.ToString());
				var convertType = new MagazineConverter();
				return convertType.ConvertMagazine(mag);
			}

			return null;
		}

		[HttpGet]
		public async Task<IEnumerable<Advertiser>> GetAds(long id)
		{
			if (Request.IsLocal())
			{
				MagazineService = new MagazineService();
				var mag = await MagazineService.GetMagazine(id.ToString());
				return await MagazineService.GetMagazineAdvertisers(mag.Id);
			}

			return null;
		}

		[HttpGet]
		public async Task GetLatestMagazines()
		{
			if (Request.IsLocal())
			{
				MagazineService = new MagazineService();
				await MagazineService.GetLatestMagazines();
			}
		}
	}
}
