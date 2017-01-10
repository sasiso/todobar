using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todobar
{
    /// <summary>
    /// 
    /// </summary>
    interface Db
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<Data> readAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool saveAll(IList<Data> input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool save(Data input);

    }
}
