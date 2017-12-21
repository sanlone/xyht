using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{
    /// <summary>
    /// SC_OrderDetailedArrange
    /// </summary>
    [Serializable]
    public class SC_OrderDetailedArrange
    {
        private int orderDetailedArrangeID;
        private int orderDetailedID;
        private int produceTaskID;
        private DateTime createDate;
        private string createUserID;
        private DateTime deleteDate;
        private string deleteReason;
        private string deleteUserID;


        /// <summary>
        /// OrderDetailedArrangeID
        /// </summary>
        public int OrderDetailedArrangeID
        {
            get { return orderDetailedArrangeID; }
            set { orderDetailedArrangeID = value; }
        }
        /// <summary>
        /// OrderDetailedID
        /// </summary>
        public int OrderDetailedID
        {
            get { return orderDetailedID; }
            set { orderDetailedID = value; }
        }
        /// <summary>
        /// ProduceTaskID
        /// </summary>
        public int ProduceTaskID
        {
            get { return produceTaskID; }
            set { produceTaskID = value; }
        }
        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        /// <summary>
        /// CreateUserID
        /// </summary>
        public string CreateUserID
        {
            get { return createUserID; }
            set { createUserID = value; }
        }
        /// <summary>
        /// DeleteDate
        /// </summary>
        public DateTime DeleteDate
        {
            get { return deleteDate; }
            set { deleteDate = value; }
        }
        /// <summary>
        /// DeleteReason
        /// </summary>
        public string DeleteReason
        {
            get { return deleteReason; }
            set { deleteReason = value; }
        }
        /// <summary>
        /// DeleteUserID
        /// </summary>
        public string DeleteUserID
        {
            get { return deleteUserID; }
            set { deleteUserID = value; }
        }
    }
}
