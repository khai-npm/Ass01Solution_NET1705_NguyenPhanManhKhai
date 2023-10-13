using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface ICartoonRepository
    {
        IEnumerable<CartoonModel> GetCartoonModels();
        CartoonModel GetCartoonModelByID(int id);
        void Create(CartoonModel model);
        void Remove(int id);
        void Update(CartoonModel model);
            




    }
}
