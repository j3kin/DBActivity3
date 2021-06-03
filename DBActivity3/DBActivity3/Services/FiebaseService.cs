using DBActivity3.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActivity3.Service
{
   public  class FiebaseService
    {
        private readonly string Childname = "Bmiss";
         readonly FirebaseClient firebase = new FirebaseClient("https://fir-connect-ce353-default-rtdb.firebaseio.com/");
        public async Task<List<BmiModel>> GetAllBmi()
        {
            return (await firebase.Child(Childname).OnceAsync<BmiModel>()).Select(item =>
            new BmiModel
            {
                IdNum = item.Object.IdNum,
                Name = item.Object.Name,
                Height = item.Object.Height,
                Weight = item.Object.Weight,
                BmiId = item.Object.BmiId,
                BmiCategory = item.Object.BmiCategory,
                Bmi = item.Object.Bmi
            }).ToList();
        }
        public async Task AddBMI(int idnum, string name, double height, double weight, double bmi, string bmicategory)
        {
            await firebase.Child(Childname).PostAsync(new BmiModel()
            {
                BmiId = Guid.NewGuid(),
                IdNum = idnum,
                Name = name,
                Weight = weight,
                Height = height,
                Bmi = bmi,
                BmiCategory = bmicategory
            });
        }

        /* public async Task<BmiModel> GetPerson(int personId)
         {
             var allPersons = await GetAllPersons();
             await firebase
                 .Child(ChildName)
                 .OnceAsync<Person>();
             return allPersons.FirstOrDefault(a => a.PersonId == IdNum);
         }
 */
        /*public async Task UpdatePerson(int personId, double height, double weight)
        {
            var toUpdatePerson = (await firebase
                .Child(ChildName)
                .OnceAsync<Person>()).FirstOrDefault(a => a.Object.PersonId == personId);

            await firebase
                .Child(ChildName)
                .Child(toUpdatePerson.Key)
                .PutAsync(new Person() { PersonId = personId, Name = name, Phone = phone });
        }*/

    }
}
