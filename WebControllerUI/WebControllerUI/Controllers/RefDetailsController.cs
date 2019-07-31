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

namespace WebControllerUI.Controllers
{
    public class RefDetailsController : ApiController
    {
        private RefDL _refDL = new RefDL();

        //Hàm thực hiện chức năng lấy phiếu thu chi tiết tương ứng phiếu thu
        //Người tạo NTGiang 31/07/2019
        public AjaxResult GetRefDetailByRefID(Guid refid)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refDL.GetRefDetailsByRefID(refid);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }
            return _ajaxResult;
        }
    }
}