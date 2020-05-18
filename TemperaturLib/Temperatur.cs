using System;

namespace TemperaturLib
{
    public class Temperatur
    {
        public decimal Degress { get; set; }
        public DateTime TimeNow { get; set; }

        public Temperatur(decimal degress, DateTime timeNow)
        {
            TimeNow = timeNow;
            Degress = degress;
        }
        public override string ToString()
        {
            //return MeasureTime + "\r\n" + Location + " " + SensorType + "\r\n" + Compound + ": " + MeasurementValue+ "\r\n" + "\r\n";
            return Degress + " " + TimeNow;
        }

    }

}
