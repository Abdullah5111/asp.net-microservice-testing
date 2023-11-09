using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testing.Models;
using Microsoft.EntityFrameworkCore;
using Testing.DBContexts;
using Testing.Repository;

namespace Testing.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly TestContext _context;

        public TestRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Test>> GetAllTests()
        {
            return await _context.Tests.ToListAsync();
        }

        public async Task<Test> GetTestById(int id)
        {
            return await _context.Tests.FindAsync(id);
        }

        public async Task<Test> AddTest(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<Test> UpdateTest(Test test)
        {
            _context.Entry(test).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task DeleteTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test != null)
            {
                _context.Tests.Remove(test);
                await _context.SaveChangesAsync();
            }
        }
    }
}
