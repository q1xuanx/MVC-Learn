using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.DataAccess.Repository.IRepository
{
    internal interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}
