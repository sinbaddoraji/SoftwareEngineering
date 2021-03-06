﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Engineering_Assignment.Support_Classes
{
    public class StaffListViewItem : ListViewItem
    {
        public Staff staff;

        /// <summary>
        /// Method to hold a staff's Full Name & Staff ID
        /// </summary>
        /// <param name="staff"></param>
        public StaffListViewItem(Staff staff)
        {
            this.staff = staff;
            Text = $"{staff.FirstName} {staff.LastName} (Staff ID: {staff.StaffId})";
        }
    }
}
