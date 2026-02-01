using System;

namespace Trixter.XDream.API.Crank
{
    public class XDreamCrankSpecification : ICrankSpecification
    {
        public static readonly XDreamCrankSpecification Default = new XDreamCrankSpecification();
        
        public int MinCrankPosition => 1;
        public int MaxCrankPosition => 60;
        public int Positions => MaxCrankPosition - MinCrankPosition + 1;
        public double RadiansPerPosition => 2 * Math.PI / Positions;
        public double RevolutionsPerPosition => 1d / Positions;

        public int MinRawDataReading => 0;
        public int MaxRawDataReading => 65535;


    }
}