﻿using System.Collections.Generic;

namespace Software_Engineering_Assignment.Support_Classes
{
   
    public class Patient
    {
        // get/set patient details 

        public string FirstName { get; set; } = "Nobody";
        public string Surname { get; set; } = "Nobody";

        public string Gender { get; set; } = "Unknown";

        public string Address { get; set; } = "Holy Grove";

        public string DOB { get; set; } = "00/00/0000";

        public string ContactNumber1 { get; set; } = "07700000000";
        public string ContactNumber2 { get; set; } = "07700000000";

        public string IntakeReason { get; set; } = "Well damn";

        public int bedNumber = 0;

        public int bayNumber = 0;

        // creating module-objects for storing moduledata 
        public Module Module1 => new Module();
        public Module Module2 => new Module();
        public Module Module3 => new Module();
        public Module Module4 => new Module();

        //Only show first two active modules for space management reasons (to be used on the bay-page)
        public string ModulesActive => $"{Module1},{Module2}...";

        public Patient()
        {

        }

        public Patient(List<string> rawPatientDat)
        {
            FirstName = rawPatientDat[1];
            Surname = rawPatientDat[2];
            DOB = rawPatientDat[3].Split(' ')[0];
            Gender = rawPatientDat[4];
            IntakeReason = rawPatientDat[5];
            Address = rawPatientDat[6];
            ContactNumber1 = rawPatientDat[7];
            ContactNumber2 = rawPatientDat[8];
            bedNumber = int.Parse(rawPatientDat[9]);
            bayNumber = int.Parse(rawPatientDat[10]);
        }
    }
}
