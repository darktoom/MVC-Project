using Company.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interfaces
{
    public interface IDepartmentService
    {

        Department GetById(int? id);
        IEnumerable<Department> GetAll();

        void add(Department entity);

        void update(Department entity);


        void delete(Department entity);


    }
}
