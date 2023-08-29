using Code.API.Data;
using Code.API.Models.Domain;
using Code.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Code.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category); // Vai Criar a coleção de categoria 
            await _dbContext.SaveChangesAsync(); // Vai salvar no BD

            return category;
        }
    }
}
