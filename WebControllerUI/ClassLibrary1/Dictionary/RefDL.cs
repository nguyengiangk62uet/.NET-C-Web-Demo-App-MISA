using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Entities;

namespace MISA.DL
{
    public class RefDL
    {
        private WebControllerUIContext db = new WebControllerUIContext();

        //Hàm thực hiện lấy danh sách phiếu thu
        //Người tạo NTGiang 30/07/2019
        public IEnumerable<Ref> GetData()
        {
            return db.Refs;
        }

        //Hàm thực hiện thêm mới phiếu thu
        //Người tạo NTGiang 30/07/2019
        public void AddRef(Ref _ref)
        {
            _ref.refID = Guid.NewGuid();
            db.Refs.Add(_ref);
            db.SaveChanges();
        }

        //Hàm thực hiện chức năng xóa phiếu thu
        //Người tạo NTGiang 30/07/2019
        public void DeleteMutiple(List<Guid> _refids)
        {
            foreach (var refid in _refids)
            {
                var refitem = db.Refs.Where(p => p.refID == refid).FirstOrDefault();
                db.Refs.Remove(refitem);
            }
            db.SaveChanges();
        }
    }
}
