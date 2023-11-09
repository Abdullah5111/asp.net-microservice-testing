using Microsoft.AspNetCore.Mvc;
using Testing.Repository;
using Testing.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> Get()
        {
            var tests = await this._testRepository.GetAllTests();
            return Ok(tests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> Get(int id)
        {
            var test = await this._testRepository.GetTestById(id);
            if (test == null)
                return NotFound();
            return Ok(test);
        }

        [HttpPost]
        public async Task<ActionResult<Test>> Post([FromBody] Test test)
        {
            var createdTest = await this._testRepository.AddTest(test);
            return CreatedAtAction(nameof(Get), new { id = createdTest.Id }, createdTest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Test test)
        {
            if (id != test.Id)
                return BadRequest();

            var updatedTest = await this._testRepository.UpdateTest(test);
            if (updatedTest == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var test = await this._testRepository.GetTestById(id);
            if (test == null)
                return NotFound();

            await this._testRepository.DeleteTest(id);

            return NoContent();
        }
    }
}
