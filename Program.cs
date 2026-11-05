
using GNET90_EFCORE04;
using GNET90_EFCORE04.Data;
using Microsoft.EntityFrameworkCore;

using var _context = new AppDbContext();

_context.Database.Migrate();
DataSeed.Seed(_context);
