using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MISA.Entities
{
    public class Ref
    {

        public Guid RefID { get; set; }
        public DateTime RefDate { get; set; }
        public string RefNo { get; set; }
        public string RefType { get; set; }
        public decimal Total { get; set; }
        public string ContactName { get; set; }
        public string Reason { get; set; }

        //static List<Ref> _refs = new List<Ref>()
        //{
        //    new Ref(){
        //        refDate = new DateTime(2019, 06, 14),
        //        refNo = "PT00001",
        //        refType = "Phiếu thu nợ tiền mặt",
        //        total = 2500000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo"
        //    },
        //    new Ref(){
        //        refDate = new DateTime(2019, 07, 14),
        //        refNo = "PT00002",
        //        refType = "Phiếu thu nợ tiền mặt",
        //        total = 2500000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo"
        //    },
        //    new Ref(){
        //        refDate = new DateTime(2019, 08, 14),
        //        refNo = "PT00003",
        //        refType = "Phiếu thu nợ tiền mặt",
        //        total = 2500000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo"
        //    },
        //    new Ref(){
        //        refDate = new DateTime(2019, 09, 14),
        //        refNo = "PT00004",
        //        refType = "Phiếu thu nợ tiền mặt",
        //        total = 2500000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo"
        //    },
        //    new Ref(){
        //        refDate = new DateTime(2019, 10, 14),
        //        refNo = "PT00005",
        //        refType = "Phiếu thu nợ tiền mặt",
        //        total = 2500000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo"
        //    },
        //    new Ref(){
        //        refDate = new DateTime(2019, 10, 14),
        //        refNo = "PT00005",
        //        refType = "Phiếu thu nợ tiền mặt",
        //        total = 2500000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo"
        //    },
        //    new Ref(){
        //        refDate = new DateTime(2019, 10, 14),
        //        refNo = "PT00005",
        //        refType = "Phiếu thu nợ tiền mặt",
        //        total = 2500000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo"
        //    },
           
        //};

        //public static List<Ref> Refs
        //{
        //    get
        //    {
        //        return _refs;
        //    }
        //    set
        //    {
        //        _refs = value;
        //    }
        //}
    
}
}