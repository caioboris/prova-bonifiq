using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
	public class ProductService : IProductService
	{
		private readonly TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

		public ProductList ListProducts(int page)
		{
			int pageSize = 10;
			var products = _ctx.Products.Skip((page - 1) * pageSize	).Take(pageSize).ToList();

			return new ProductList()
			{
				HasNext = _ctx.Products.Skip(page * pageSize).Any(),
				TotalCount = _ctx.Products.Count(),
				Products = products
			};
		}

	}
}
