using Testing.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Testing.Repository
{
    public interface ITest2Repository
    {
        Task<IEnumerable<Test2>> GetAllTests2();
        Task<Test2> GetTest2ById(int id);
        Task<Test2> AddTest2(Test2 test2);
        Task<Test2> UpdateTest2(Test2 test2);
        Task DeleteTest2(int id);
    }
}

