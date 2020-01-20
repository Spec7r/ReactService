using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReactService.Data;
using ReactService.Interfaces;
using ReactService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactService.Repository
{
	public class EFCoreRepository : IRepository
	{
		private readonly ApplicationContext _context;

		public EFCoreRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public async Task<TEntity> Delete<TEntity>(int id) where TEntity : class
		{
			var entity = await _context.Set<TEntity>().FindAsync(id);

			if (entity == null) return null;

			_context.Set<TEntity>().Remove(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public async Task<TEntity> Get<TEntity>(Guid id) where TEntity : class
		{
			var entity = await _context.Set<TEntity>().FindAsync(id);

			if (entity == null) return null;

			return entity;
		}

		public async Task<IList<TEntity>> GetAll<TEntity>() where TEntity : class
		{
			var entitys = await _context.Set<TEntity>().ToListAsync();

			if (entitys == null || entitys?.Count == 0) return null;

			return entitys;
		}

		public async Task<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
		{
			_context.Set<TEntity>().Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
