using Microsoft.AspNetCore.Mvc;
using PersonApp.Interfaces;
using PersonApp.Model;

namespace PersonApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController: Controller
    {
        private readonly IPersonInterface _personInterface;

        public PersonController(IPersonInterface personInterface)
        {

            _personInterface = personInterface;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Person>))]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {

            var persons = _personInterface.GetPersons();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (persons == null)
                return NotFound();

            return Ok(persons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Person))]
        public IActionResult GetPerson(int id)
        {
            var person = _personInterface.GetPerson(id);
            if (person == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(person);


        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Person>> CreatePerson([FromBody] Person person)
        {
            var checkperson = _personInterface.GetPerson(person.ID);
            if (checkperson != null)
                return BadRequest("Existing ID. Try using another ID");

            var create = _personInterface.CreatePerson(person);
            return Ok(create);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Person>> UpdatePerson([FromBody] Person person)
        {
            var checkperson = _personInterface.GetPerson(person.ID);
            if (checkperson == null)
                return NotFound("ID not found");

                var update = _personInterface.UpdatePerson(person.ID, checkperson, person);

            return Ok(update);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Person>> RemovePerson(int id)
        {
            var delete =  _personInterface.DeletePerson(id);
            if (!delete) 
                return BadRequest("Data not found or was not sucessfully delete.");
  

            return Ok($"Person with ID:{id} has successfully deleted");
        }


    }
}
