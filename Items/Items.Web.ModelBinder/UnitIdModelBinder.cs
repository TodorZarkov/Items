namespace Items.Web.ModelBinder
{
	using Items.Data;
	using Items.Data.Models;
	

	using static Items.Common.EntityValidationErrorMessages.Unit;

	using Microsoft.AspNetCore.Mvc.ModelBinding;

	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;

	public class UnitIdModelBinder : IModelBinder
	{
		private readonly ItemsDbContext dbContext;

		public UnitIdModelBinder(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task BindModelAsync(ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider
				.GetValue(bindingContext.ModelName);


			int? actualUnitId = null;
			bool success = false;

			if (
				bindingContext.ModelName.ToLower().StartsWith("unitid") &&
				valueResult != ValueProviderResult.None &&
				!string.IsNullOrEmpty(valueResult.FirstValue)
				)
			{
				try
				{
					string intValue = valueResult.FirstValue;
					if (intValue.Count(c => c.Equals(',')) > 1)
					{
						intValue = intValue.Replace(",", string.Empty);
					}
					else if (intValue.Count(c => c.Equals('.')) > 1)
					{
						intValue = intValue.Replace(".", string.Empty);
					}

					actualUnitId = int.Parse(intValue);

					Unit? actualUnit = await dbContext.Units.FindAsync(actualUnitId);
					if (actualUnit != null)
					{
						success = true;
					}
					else
					{
						int maxUnitId = await dbContext.Units.MaxAsync(u => u.Id);
						success = false;
						bindingContext.ModelState
							.AddModelError(
											bindingContext.ModelName,
											string.Format(InvalidUnitId, 0, maxUnitId));
					}
				}
				catch (Exception e)//overflow exception to
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName, e, bindingContext.ModelMetadata);
				}
			}
			else
			{
				if (bindingContext.ModelName.ToLower().StartsWith("unitid") && bindingContext.ModelMetadata.ModelType == typeof(int?))
				{
					success = true;
				}
			}


			if (success)
			{
				bindingContext.Result = ModelBindingResult.Success(actualUnitId);
			}

		}
	}
}
