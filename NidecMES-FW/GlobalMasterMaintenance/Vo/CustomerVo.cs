using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
   public class CustomerVo:ValueObject
    {
        /// <summary>
        /// get and set CustomerId
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// get and set Customercode
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// get and set Customername
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// get and set Address1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// get and set Address2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// get and set EmailId
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// get and set Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// get and set PhoneNo
        /// </summary>
        public string PhoneNo { get; set; }
       
        /// <summary>
        /// get and set registrationusercode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set registrationdatetime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set  factorycode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// store affectedcount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// store mode
        /// </summary>
        public string Mode = string.Empty;
       

    /// <summary>
    /// list of customervo
    /// </summary>
    public List<CustomerVo> CustomerListVo = new List<CustomerVo>();
    }
}
