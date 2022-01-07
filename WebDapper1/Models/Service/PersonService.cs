using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebDapper1.Models.DomainModel;
using WebDapper1.Models.Repository;

namespace WebDapper1.Models.Service
{
    public class PersonService
    {
        private PersonRepository repo = new PersonRepository();
        private PersonRepository _repo;

        public PersonService()
        {
            this._repo= repo;
        }

        public void Create(PersonModel Model)
        {
            _repo.Create(Model);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<PersonModel> GetAll()
        {
            return _repo.getAll();
        }

        public PersonModel Get(int id)
        {
            return _repo.GetId(id);
        }

        public void Update(int id,PersonModel model)
        {
            repo.Update(id,model);
        }

        public Login Login(Login model)
        {
            var data = repo.Login(model);
            return model;
        }




    }
}