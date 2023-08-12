using BLL.Entity;
using BLL.Interfaces.Repository;
using BLL.Interfaces.Services;
using System.Xml.Linq;

namespace BLL.Services
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository _categoryRepository;
        IKeyParamsRepository _keyParamsRepository;
        public CategoryServices(ICategoryRepository userRepository, IKeyParamsRepository productRepository)
        {
            _categoryRepository = userRepository;
            _keyParamsRepository = productRepository;
        }
        public async Task<bool> CreateCategory(Category entity)
        {
            return await _categoryRepository.Create(entity);
        }

        public async Task<bool> DeleteCategory(Category entity)
        {
            return await _categoryRepository.Delete(entity);
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }
        public async Task<Category> GetCategoryByName(string category)
        {
            var rer = await _categoryRepository.Select();

            return rer.Where(x => x.Name == category);
        }

        public async Task<IEnumerable<Category>> AllCategories()
        {
            return await _categoryRepository.Select();
        }

        public async Task<Category> UpdateCategory(Category entity)
        {
            return await _categoryRepository.Update(entity);
        }

        public async Task<CategoryInfo> GetCategoryInfoByName(string category)
        {
            var categoryEntity = (await _categoryRepository.SelectIncludeProducts()).FirstOrDefault(c => c.Name == category);
            var keyWords = (await _keyParamsRepository.SelectIncludeWords())
                .Where(k => categoryEntity.Products.Any(p => p.Id == k.Product.Id))
                .Select(k => k.KeyWords.KeyWord)
                .Distinct();

            return new CategoryInfo
            {
                CategoryName = category,
                Selections = new Dictionary<string, string[]>
                {
                    { category, keyWords.ToArray() }
                },

                MinPrice = categoryEntity.Products.Min(x => x.Price),
                MaxPrice = categoryEntity.Products.Max(x => x.Price)
            };
        }
    }
}
