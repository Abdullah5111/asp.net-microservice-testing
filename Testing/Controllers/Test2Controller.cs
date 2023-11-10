using Microsoft.AspNetCore.Mvc;
using Testing.Models;
using Testing.Repository;

[ApiController]
[Route("api/[controller]")]
public class Test2Controller : ControllerBase
{
    private readonly ITest2Repository _test2Repository;

    public Test2Controller(ITest2Repository test2Repository)
    {
        _test2Repository = test2Repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Test>>> Get()
    {
        var tests2 = await this._test2Repository.GetAllTests2();
        return Ok(tests2);
    }

    [HttpPost]
    public async Task<ActionResult<Test>> Post([FromBody] Test2 test2)
    {
        var createdTest2 = await this._test2Repository.AddTest2(test2);
        return CreatedAtAction(nameof(Get), new { id = createdTest2.Id }, createdTest2);
    }

    //[HttpPost]
    //public IActionResult PostTest2([FromBody] Test2 test2)
    //{
    //    // Implement logic to create a new Test2 record
    //}

    //[HttpPut("{id}")]
    //public IActionResult PutTest2(int id, [FromBody] Test2 test2)
    //{
    //    // Implement logic to update an existing Test2 record
    //}

    //[HttpDelete("{id}")]
    //public IActionResult DeleteTest2(int id)
    //{
    //    // Implement logic to delete a Test2 record
    //}

}
