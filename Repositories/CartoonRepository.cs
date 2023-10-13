using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CartoonRepository : ICartoonRepository
    {
        public void Create(CartoonModel model) => CartoonDB.Instance.Create(model);
        

        public void Remove(int id) => CartoonDB.Instance.Remove(id);


        public CartoonModel GetCartoonModelByID(int id) => CartoonDB.Instance.GetCartoonModelByID(id);



        public IEnumerable<CartoonModel> GetCartoonModels() => CartoonDB.Instance.GetCartoonList;
      

        public void Update(CartoonModel model) => CartoonDB.Instance.Update(model);
        
    }
}
