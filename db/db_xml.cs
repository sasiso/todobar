using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todobar.db
{
    class DB_Xml : Db
    {
        IList<Data> Db.readAll()
        {
            throw new NotImplementedException();
        }

        bool Db.save(Data input)
        {
            throw new NotImplementedException();
        }

        bool Db.saveAll(IList<Data> input)
        {
            throw new NotImplementedException();
        }
    }
}
