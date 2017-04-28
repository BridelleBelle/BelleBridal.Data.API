using BelleBridal.API.Data;
using BelleBridal.API.Models;

namespace BelleBridal.API
{
	public class MagazineConverter
	{
		public MagazineDto ConvertMagazine(Magazine mag)
		{
			return new MagazineDto
			{
				Id = mag.Id,
				Name = mag.Name
				
			};
		}
	}
}