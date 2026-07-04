using System;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
namespace IntelligencePipeline.Models.Reports
{
    class SoldierReport : Report
    {
        
        private string _soldiername;
        private string _soldierid; //Why not int?
        private string _unit;
        private int _confidencelevel;

        
        
        
        
        
        
        
        public string SoldierName { get => _soldierid; protected set => _soldierid = value; }
        public string SoldierID { get => _soldierid; protected set => _soldierid = value; }
        public string Unit { get => _soldierid; protected set => _soldierid = value; }
        public int ConfidenceLevel { get => _confidencelevel; protected set => _confidencelevel = value; }


        public SoldierReport(int reportId, DateTime timestamp, double latitude,double longitude, string description,string soldierName, string soldierID, string unit,int confidenceLevel)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            SoldierName = soldierName;
            SoldierID = soldierID;
            Unit = unit;
            ConfidenceLevel = confidenceLevel;
            Console.WriteLine("this soldeir class");
        }
        public override string GetSourceType() => "Soldier";
        public override int CalculateReliabilityScore()
        {
            int Base = 4;
            Base += ConfidenceLevel;
            if (Regex.IsMatch(Description, @"\bweapon\b") || Regex.IsMatch(Description, @"\bvehicle\b") || Regex.IsMatch(Description, @"\bmovement\b") || Regex.IsMatch(Description, @"\bexplosion\b"))
                Base += 1;
            return Base;
        }

    }
}
