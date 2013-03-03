using System;
using System.Collections.Generic;
using System.Text;

namespace RSys
{
    public class SecurityRights
    {


        private bool _canView;
        private bool _canAdd;
        private bool _canUpdate;
        private bool _canDelete;
        private bool _canExecute;
        private bool _canPrint;

        /// <summary>
        /// 
        /// </summary>
        /// <value>Boolean</value>
        /// <remarks></remarks>
        public bool CanExecute
        {
            get { return _canExecute; }
            set { _canExecute = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Boolean</value>
        /// <remarks></remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
            set { _canPrint = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <value>Boolean</value>
        /// <remarks></remarks>

        public bool CanAdd
        {
            get { return _canAdd; }
            set { _canAdd = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Boolean</value>
        /// <remarks></remarks>

        public bool CanUpdate
        {
            get { return _canUpdate; }
            set { _canUpdate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value>Boolean</value>
        /// <remarks></remarks>
        public bool CanView
        {
            get { return _canView; }
            set { _canView = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Boolean</value>
        /// <remarks></remarks>
        public bool CanDelete
        {
            get { return _canDelete; }
            set { _canDelete = value; }
        }
    }
}
