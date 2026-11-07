
using GNET90_EFCORE04;
using GNET90_EFCORE04.Data;
using GNET90_EFCORE04.Models;
using GNET90_EFCORE04.Services;
using GNET90_EFCORE04.UI.Menus;
using Microsoft.EntityFrameworkCore;

using var _context = new AppDbContext();

_context.Database.Migrate();
DataSeed.Seed(_context);

AccountServices account = new AccountServices(_context);
OpenAccountService open = new OpenAccountService(_context);
var MainMenu = new MainMenu(
    new CreateCustomer(account),
    new OpenAccount(open),
    new UpdateStatus(account)
);

MainMenu.run();