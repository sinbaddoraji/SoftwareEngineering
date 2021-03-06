﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_Assignment.Support_Classes
{
    static class Constants
    {

        private static Random random;

        public static int Next()
        {
            if (random == null)
                random = new Random();

            return random.Next();
        }

        public static int NextRandomValue(int min, int max)
        {
            if (random == null)
                random = new Random();

            return random.Next(min, max);
        }

        //These are sql queries that will be used regurally
        public static string LogEvent(string description, string type, int id)
      => $@"INSERT INTO LogActivity ({type}_id, activity_description, timestamp)
                    VALUES ({id}, '{description}', '{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}');";

        public static string GetAllEventLogs()
        => $@"SELECT * FROM LogActivity;";

        public static string GetPatientsFromBay(int bayNo)
        => $@"SELECT *
                FROM Patient 
                Where bay_id = {bayNo};";

        public static string GetPatient(int bedside_no, int bay_id)
        => $@"SELECT *
                FROM Patient 
                Where bedside_no = {bedside_no} AND bay_id = {bay_id};";

        public static string GetStaff(int id)
        => $@"SELECT staff_id, first_name, last_name, staff_type, date_of_birth, gender, contact_no_1, contact_no_2, email, address
                FROM Staff 
                Where staff_id = {id};";

        public static string GetStaffSchedule(string date)
       => $@"SELECT staff_id
                FROM StaffSchedule
                WHERE oncall_date = '{date}' AND deregistered = 0";

        public static string GetStaffOnCall(string date)
        => $@"SELECT staff_id
                FROM StaffSchedule
                WHERE oncall_date = '{date}' AND deregistered = 0";
                

        public static string GetStaffUnregistered(string date)
        => $@"SELECT staff_id
                FROM StaffSchedule
                WHERE oncall_date = '{date}' AND deregistered = 1";


        public static string RegisterStaff(int staffId)
        => $@"INSERT INTO StaffSchedule VALUES ({staffId},@date,0)";

        public static string DeregisterStaff(int staffId)
        => $@"INSERT INTO StaffSchedule VALUES ({staffId},@date,1)";

        public static string UpdateStaffRegister(int staffId)
        => $@"UPDATE StaffSchedule
                SET oncall_date = @date, deregistered = @deregistered
                WHERE staff_Id = {staffId}";



        //Get staff ID using sql query
        public static string GetStaffId => $"SELECT staff_id FROM Staff;";

        public static string GetStaffPassword(int id) => $"SELECT password FROM Staff Where staff_id = {id};";

        public static string GetModules(int moduleID) => $@"SELECT module_id, monitor_function, module_unit, module_max, module_min, module_current
                                                            FROM Module
                                                            WHERE module_id = {moduleID}";

        public static string GetBedside(int bedsideNo, int bayNo) => $@"SELECT bedside_id, bedside_no, bay_no, module_id_1, module_id_2, module_id_3, module_id_4 
                                                            FROM Bedside
                                                            WHERE bedside_no = {bedsideNo} AND bay_no = {bayNo}";

        public static string RegisterModule(int moduleID)
        {
            return $"INSERT INTO Module (module_id, monitor_function, module_unit, module_max, module_min, module_current) VALUES ({moduleID}, @m1, @m2, @m3, @m4, @m5);";
        }

        public static string UpdateModule(int moduleID)
        => $@"UPDATE Module
                SET monitor_function = @m1, module_unit = @m2, module_max = @m3, module_min = @m4, module_current = @m5
                WHERE module_Id = {moduleID}";

        //SELECT column1, column2, ...
        //FROM table_name;


    }
}
