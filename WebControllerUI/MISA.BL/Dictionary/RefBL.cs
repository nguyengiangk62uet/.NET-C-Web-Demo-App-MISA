using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.DL;
using MISA.Entities;

namespace MISA.BL
{
    public class RefBL
    {
        private RefDL _refDL = new RefDL();
        
        /// <summary>
        /// Hàm thực hiện phân trang
        /// </summary>
        /// <param name="_pageIndex"></param>
        /// <param name="_pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Ref> GetPageData(int _pageIndex, int _pageSize)
        {
            var _ref = _refDL.GetData();
            _ref = _ref.OrderBy(p => p.RefID)
                .Skip((_pageIndex - 1) * _pageSize)
                .Take(_pageSize);
            return _ref;
        }
    }
}
