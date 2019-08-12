using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MISA.Entities;
using MISA.DL;
using WebControllerUI.Properties;
using MISA.BL;
using System.Threading.Tasks;

namespace WebControllerUI.Controllers
{
    public class RefsController : ApiController
    {
        private WebControllerUIContext db = new WebControllerUIContext();
        private RefDL _refDL = new RefDL();
        private RefBL _refBL = new RefBL();

        /// <summary>
        /// Gọi hàm lấy dữ liệu từ bảng
        /// Người tạo NTGiang 30/07/2019
        /// </summary>
        [Route("refs")]
        [HttpGet]
        public AjaxResult GetRefs()
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refDL.GetData();
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }
            return _ajaxResult;
        }

        /// <summary>
        /// Gọi hàm thêm mới đối tương
        /// Người tạo NTGiang 30/07/2019
        /// </summary>
        /// <param name="refitem"></param>
        [Route("refs")]
        [HttpPost]
        public AjaxResult Post([FromBody] Ref refitem)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _refDL.AddRef(refitem);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }
            return _ajaxResult;
        }


        ///Hàm xóa nhiều đối tượng
        ///Gọi từ MISA.DL
        [Route("refs")]
        [HttpDelete]
        public AjaxResult DeleteMultiple([FromBody]List<Guid> refIDs)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _refDL.DeleteMutiple(refIDs);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }
            return _ajaxResult;
        }

        ///Hàm phân trang
        ///
        [Route("refs")]
        [Route("refs/{pageIndex}/{pageSize}")]
        [HttpGet]
        public async Task<AjaxResult> GetRefs([FromUri]int pageIndex, int pageSize)
        {
            await Task.Delay(1000);
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refDL.GetData();
                _ajaxResult.Data = _refBL.GetPageData(pageIndex, pageSize);
            }
            catch (Exception ex) {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }
            return _ajaxResult;
        }


        ///// xoa nhieu doi tuong
        ///// 
        //[Route("refs")]
        //[HttpDelete]
        //public void DeleteMutiple([FromBody]List<Guid> refids)
        //{
        //    foreach (var refid in refids)
        //    {
        //        var refitem = db.Refs.Where(p => p.refID == refid).FirstOrDefault();
        //        db.Refs.Remove(refitem);
        //    }
        //    db.SaveChanges();
        //}

        //private bool RefExists(Guid id)
        //{
        //    return db.Refs.Count(e => e.refID == id) > 0;
        //}
    }
}