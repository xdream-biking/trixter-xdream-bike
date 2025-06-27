namespace Trixter.XDream.API.Crank
{
    public interface ICrankSpecification
    {
        int MinCrankPosition { get; }
        int MaxCrankPosition { get; }

        /// <summary>
        /// The number of crank positions, which is the range of valid crank positions.
        /// </summary>
        int Positions { get; }

        double RadiansPerPosition { get; }

        double RevolutionsPerPosition { get; }


        int MinRawDataReading { get; }
    
        int MaxRawDataReading { get; }

    }

}
