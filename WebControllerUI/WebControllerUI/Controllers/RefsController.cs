using MISA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebControllerUI.Controllers
{
    public class RefsController : ApiController
    {
        /// Thực hiện lấy dữ liệu xuống
        /// Người tạo: Nguyễn Giang
        //[Route("refs")]
        //[HttpGet]
        //public IEnumerable<Ref> Get()
        //{
        //    return Ref.Refs;
        //}

        //// Tra ve doi tuong tim kiem theo ma
        //[Route("refs/{refno}")]
        //[HttpGet]
        //public IEnumerable<Ref> Get(string refno)
        //{
        //    List<Ref> refitems = new List<Ref>();
        //    //var refitem = Ref.Refs.Where(p => p.refNo.Contains(refno)).FirstOrDefault();
        //    foreach (Ref i in Ref.Refs)
        //    {
        //        if (i.refNo.Contains(refno))
        //        refitems.Add(i);
        //    }
        //    return refitems;
        //}

        //// Them moi doi tuong
        //[Route("refs")]
        //[HttpPost]
        //public void Post([FromBody] Ref refitem)
        //{
        //    Ref.Refs.Add(refitem);
        //}

        //// Chinh sua doi tuong
        //[Route("refs/{refno}")]
        //[HttpPut]
        //public void Put(string refno, [FromBody] Ref refitem)
        //{
        //    foreach (Ref updateItem in Ref.Refs)
        //    {
        //        if (updateItem.refNo == refno)
        //        {
        //            updateItem.total = refitem.total;
        //            updateItem.refDate = refitem.refDate;
        //            updateItem.refNo = refitem.refNo;
        //            updateItem.refType = refitem.refType;
        //            updateItem.reason = refitem.reason;
        //            updateItem.contactName = refitem.contactName;
        //        }
        //    }

        //}

        //// Xoa doi tuong
        ////[Route("refs/{refno}")]
        ////[HttpDelete]
        ////public void Delete(string refno)
        ////{
        ////    var refitem = Ref.Refs.Where(p => p.refNo == refno).FirstOrDefault();
        ////    Ref.Refs.Remove(refitem);
        ////}

        ///// xoa nhieu doi tuong
        ///// 
        //[Route("refs")]
        //[HttpDelete]
        //public void DeleteMutiple([FromBody]List<String> refnos)
        //{
        //    foreach(var refno in refnos)
        //    {
        //        var refitem = Ref.Refs.Where(p => p.refNo == refno).FirstOrDefault();
        //        Ref.Refs.Remove(refitem);
        //    }
        //}
    }
}
