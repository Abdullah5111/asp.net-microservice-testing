using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testing.Models;
using Microsoft.EntityFrameworkCore;
using Testing.DBContexts;
using Testing.Repository;

namespace Testing.Repository
{
    public class Test2Repository : ITest2Repository
    {
        private readonly TestContext _context;

        public Test2Repository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Test2>> GetAllTests2()
        {
            return await _context.Tests2.ToListAsync();
        }

        public async Task<Test2> GetTest2ById(int id)
        {
            return await _context.Tests2.FindAsync(id);
        }

        public async Task<Test2> AddTest2(Test2 test2)
        {
            _context.Tests2.Add(test2);
            await _context.SaveChangesAsync();
            return test2;
        }

        public async Task<Test2> UpdateTest2(Test2 test2)
        {
            _context.Entry(test2).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return test2;
        }

        public async Task DeleteTest2(int id)
        {
            var test2 = await _context.Tests2.FindAsync(id);
            if (test2 != null)
            {
                _context.Tests2.Remove(test2);
                await _context.SaveChangesAsync();
            }
        }
    }
}
