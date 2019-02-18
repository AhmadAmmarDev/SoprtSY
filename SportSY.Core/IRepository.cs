using SportSY.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportSY.Core
{
	public interface IRepository<TModel> where TModel : Model, new()
	{
		IEnumerable<TModel> GetItems();
		void AddItem(TModel newItem);
		void EditItem(TModel existItem);
		void DeleteItem(TModel existItem);
		TModel GetItemById(TModel item);
	}
}