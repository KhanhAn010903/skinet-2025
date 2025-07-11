using Core.Entities;

namespace Core.Specification;

public class ProductSpecification : BaseSpecification<Product>
{
  public ProductSpecification(ProductSpecParams specParams) : base(x =>
     (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand)) &&
     (specParams.Types.Count == 0 || specParams.Types.Contains(x.Type))
  )
  {
    ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageIndex);
    switch (specParams.Sort)
    {
      case "priceAsc":
        AddOrderBy(x => (double)x.Price);
        break;
      case "priceDesc":
        AddOrderByDescending(x => (double)x.Price);
        break;
      default:
        AddOrderBy(x => x.Name);
        break;
    }
  }
}