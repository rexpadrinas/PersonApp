using Microsoft.AspNetCore.Mvc;
using PersonApp.Interfaces;
using PersonApp.Model;

namespace PersonApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonTypeController : Controller
    {

        private readonly IPersonTypeInterface _personTypeInterface;
        public PersonTypeController(IPersonTypeInterface personTypeInterface)
        {
            _personTypeInterface = personTypeInterface;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PersonType>))]
        public async Task<ActionResult<IEnumerable<PersonType>>> GetPersonTypes()
        {

            var persontypes = _personTypeInterface.GetPersonTypes();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (persontypes == null)
                return NotFound();

            return Ok(persontypes);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PersonType))]
        public async Task<ActionResult<PersonType>> GetPersonType(int id)
        {
            var person = _personTypeInterface.GetPersonType(id);
            if (person == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(person);


        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PersonType>> CreatePerson([FromBody] PersonType persontype)
        {
            var checkpersontype = _personTypeInterface.GetPersonType(persontype.Type);
            if (checkpersontype != null)
                return BadRequest("Existing ID. Try using another ID");

            var create = _personTypeInterface.CreatePersonType(persontype);
            return Ok(create);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PersonType>> UpdatePerson(int id, [FromBody] PersonType persontype)
        {
            var checkpersontype = _personTypeInterface.GetPersonType(id);
            if (checkpersontype == null)
                return NotFound("ID not found");

            var update = _personTypeInterface.UpdatePersonType(id, checkpersontype, persontype);

            return Ok(update);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PersonType>> RemovePerson(int id)
        {
            var delete = _personTypeInterface.DeletePersonType(id);
            if (!delete)
                return BadRequest("Data not found or was not sucessfully delete.");


            return Ok($"Person with ID:{id} has successfully deleted");
        }
    }
}
