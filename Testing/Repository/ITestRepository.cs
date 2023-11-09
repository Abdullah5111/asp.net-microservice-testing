using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing.Repository
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetAllTests();
        Task<Test> GetTestById(int id);
        Task<Test> AddTest(Test test);
        Task<Test> UpdateTest(Test test);
        Task DeleteTest(int id);
    }
}
