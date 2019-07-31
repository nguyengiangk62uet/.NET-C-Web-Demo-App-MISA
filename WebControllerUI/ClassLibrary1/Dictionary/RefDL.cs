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

        //Hàm thực hiện chức năng lấy phiếu thu chi tiết tương ứng phiếu thu
        //Người tạo NTGiang 31/07/2019
        public IEnumerable<RefDetail> GetRefDetailsByRefID(Guid _refID)
        {
            var _refResult = db.RefDetails.Where(p => p.RefID == _refID).ToList();
            return _refResult;
        }

        //Hàm thực hiện thêm mới phiếu thu
        //Người tạo NTGiang 30/07/2019
        public void AddRef(Ref _ref)
        {
            _ref.RefID = Guid.NewGuid();
            db.Refs.Add(_ref);
            db.SaveChanges();
        }

        //Hàm thực hiện chức năng xóa phiếu thu
        //Người tạo NTGiang 30/07/2019
        public void DeleteMutiple(List<Guid> _refids)
        {
            foreach (var refid in _refids)
            {
                var refitem = db.Refs.Where(p => p.RefID == refid).FirstOrDefault();
                db.Refs.Remove(refitem);
            }
            db.SaveChanges();
        }

        //Hàm thực hiện chức năng sửa phiếu thu
        //Người tạo NTGiang 30/07/2019
        public void Edit(Guid _refid)
        {
            foreach (Ref itemNeedUpdate in db.Refs)
            {
                if (itemNeedUpdate.RefID == _refid)
                {

                }
            }
        }
    }
}
