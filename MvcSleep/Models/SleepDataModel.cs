using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MvcSleep.Models
{
    public class MyRecords
    {
        public int Id { get; set; }
        public double Value { get; set; }
    }
    public class SleepDataModel
    {
        public int Id { get; set; }
        public string SleepDataName { get; set; }
        public string SleepDataAnnotation { get; set; }
        public List<double> SleepDataRecords { get; set; }
    }


}