using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonAppWeb.Models;
using System.Text;

namespace PersonAppWeb.Controllers
{
    public class PersonController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7047/api");
        private readonly HttpClient _client;


        public PersonController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        
        {
            List<Person> person = new List<Person>();
            List<PersonType> personTypes = new List<PersonType>(); 
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Person/GetPersons").Result;
            HttpResponseMessage response2 = _client.GetAsync(_client.BaseAddress + "/PersonType/GetPersonTypes").Result;


            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<List<Person>>(data);
            }

            if (response2.IsSuccessStatusCode)
            {
                string data2 = response2.Content.ReadAsStringAsync().Result;
                personTypes = JsonConvert.DeserializeObject<List<PersonType>>(data2);
            }


            List<PersonViewModel> addviewmodelval = new List<PersonViewModel>();
            foreach (var p in person) 
            {
                addviewmodelval.Add(new PersonViewModel {
                    ID = p.ID,
                   Name = p.Name,
                   Age = p.Age,
                   TypeID = p.TypeID,
                   Description = personTypes.Where(pt => pt.Type == p.TypeID).Select(pt => pt.Description).SingleOrDefault() ?? string.Empty

            });
            }
            TempData["successMessage"] = "";

            return View(addviewmodelval);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
   
            string data = JsonConvert.SerializeObject(person);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Person/CreatePerson/", content).Result;


            if (response.IsSuccessStatusCode)
             {
                TempData["successMessage"] = "Successfully Added!";
                return RedirectToAction("Index");
             }
            else
                TempData["errorMessage"] = "Error adding this record. Please check your inputs (Make sure to create unique ID)";


            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Person person = new Person();
            person = GetPersonByID(id);

            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)

        {
            string data = JsonConvert.SerializeObject(person);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Person/UpdatePerson/", content).Result;
            person = GetPersonByID(person.ID);


            if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Successfully Updated!";
                return RedirectToAction("Index");
            }
            else
                TempData["errorMessage"] = "Error updating this record. Please check your inputs";

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Person person = new Person();
            person = GetPersonByID(id);
            return View(person);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)

        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Person/RemovePerson/" + id).Result;
            if (response.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
                return View();
        }

        public Person GetPersonByID(int id) 
        {
            Person person = new Person();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Person/GetPerson/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<Person>(data);
            }

            return person;
        }
        public PersonType GetPersonTypeByID(int id)
        {
            PersonType persontype = new PersonType();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/PersonType/GetPersonType/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                persontype = JsonConvert.DeserializeObject<PersonType>(data);
            }

            return persontype;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            Person person = new Person();
            PersonType personType = new PersonType();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Person/GetPerson/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<Person>(data);
            }

            personType = GetPersonTypeByID(person.TypeID);

            PersonViewModel personViewModel = new PersonViewModel();


                personViewModel.ID = person.ID;
                personViewModel.Name = person.Name;
                personViewModel.Age = person.Age;
                personViewModel.TypeID = person.TypeID;
                personViewModel.Description = personType.Description?? string.Empty;
   



            return View(personViewModel);
        }





    }
}
