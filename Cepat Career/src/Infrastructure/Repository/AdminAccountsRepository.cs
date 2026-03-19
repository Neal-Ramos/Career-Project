using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.commons.IRepository;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public class AdminAccountsRepository: IAdminAccountsRepository
    {
        private readonly AppDbContext _context;
        public AdminAccountsRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
    }
}