using Fox.Model.Dao.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Model.Dao
{
    public class dbDao : IdbDao
    {
        dbEntities entities = new dbEntities();
        public dbDao()
        {

        }

        public IEnumerable<Student> StudentSelect()
        {
            return null;
        }
    }
}
