using System;

namespace Trixter.XDream.API.Crank
{
    public static class CrankSpecificationExtensions
    {

        /// <summary>
        /// Determines if the specified value is a valid crank raw data reading.
        /// </summary>
        /// <param name="crankTimeReading"></param>
        /// <returns></returns>
        public static bool IsValidRawDataReading(this ICrankSpecification crank, int value)
            => value >= crank.MinRawDataReading && value <= crank.MaxRawDataReading;

        /// <summary>
        /// Determines if the specified value is a valid crank position.
        /// </summary>
        /// <param name="crankPosition"></param>
        /// <returns></returns>
        public static bool IsValidCrankPosition(this ICrankSpecification crank, int crankPosition)
            => crankPosition >= crank.MinCrankPosition && crankPosition <= crank.MaxCrankPosition;
        

        /// <summary>
        /// Determine a crank direction from an integer position change or directional measurement.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static CrankDirection GetDirection(this ICrankSpecification crank, int x)
        {
            if (x == 0) return CrankDirection.None;
            if (x > 0) return CrankDirection.Forward;
            return CrankDirection.Backward;
        }

        /// <summary>
        /// Determine the number of positions between the 2 specified positions.
        /// </summary>
        /// <param name="position0"></param>
        /// <param name="position1"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int CrankDelta(this ICrankSpecification crank, int position0, int position1)
        {
            if (!IsValidCrankPosition(crank, position0))
                throw new ArgumentOutOfRangeException(nameof(position0));
            if (!IsValidCrankPosition(crank,position1))
                throw new ArgumentOutOfRangeException(nameof(position1));

            int result = position1 - position0;
            if (result < 0) result += crank.MaxCrankPosition;
            return result;
        }

        /// <summary>
        /// Calculates the number of positions between the first and second, and the direction
        /// using whichever difference has the smallest magnitude. If the direction is backward, the result is negative.
        /// Direction can be forced with the <see cref="forceDirection"/> parameter.
        /// </summary>
        /// <param name="position0">The first position.</param>
        /// <param name="position1">The second position.</param>
        /// <param name="forceDirection">Optional parameter to force a particular direction.
        /// Should not be <see cref="CrankDirection.None"/>.</param>
        /// <returns></returns>
        public static int DirectionalCrankDelta(this ICrankSpecification crank, int position0, int position1, CrankDirection? forceDirection=null)
        {
            if (position0 == position1)
            {
                return 0;
            }
            else if(forceDirection!=null)
            {
                CrankDirection direction = forceDirection.Value;

                if (direction == CrankDirection.None)
                    throw new ArgumentException(nameof(forceDirection));
                if (direction == CrankDirection.Forward)
                    return CrankDelta(crank, position0, position1);
                return -CrankDelta(crank, position1, position0);
            }
            else
            {
                int forwardDiff = CrankDelta(crank, position0, position1);
                int backwardDiff = -CrankDelta(crank, position1, position0);

                return (Math.Abs(forwardDiff) < Math.Abs(backwardDiff)) ? forwardDiff : backwardDiff;
            }
        }

        /// <summary>
        /// Add the specified delta to the specified crank position and map to a valid crank position if the result is not.
        /// </summary>
        /// <param name="position">The initial position.</param>
        /// <param name="delta">The change. Can be negative for backward motion.</param>
        /// <returns></returns>
        public static int Advance(this ICrankSpecification crank, int position, int delta)
        {
            if (!IsValidCrankPosition(crank, position))
                throw new ArgumentOutOfRangeException(nameof(position));

            if(delta==0)
                return position;
            
            int result = position-crank.MinCrankPosition + delta;

            if(Math.Abs(result)>=crank.Positions)
                result %= crank.Positions;

            if (result < 0)
                result += crank.Positions;
            result += crank.MinCrankPosition;

            return result;

        }

        /// <summary>
        /// Calculate the revolutions per minute from the number of crank positions and the time taken.
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static int CalculateRPM(this ICrankSpecification crank, double positions, double milliseconds)
        {
            double crankPositionsPerMillisecond = Math.Abs((double)positions / milliseconds);
            double crankPositionsPerMinute = Constants.MillisecondsPerMinute * crankPositionsPerMillisecond;
            var result= (int)(0.5 + crank.RevolutionsPerPosition * crankPositionsPerMinute);
            return result;
        }

        /// <summary>
        /// Calculate the angular velocity from the number of crank positions and the time taken.
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static double CalculateRadiansPerSecond(this ICrankSpecification crank, double positions, double milliseconds)
        {
            double crankPositionsPerMillisecond = Math.Abs((double)positions / milliseconds);
            double crankPositionsPerSecond = Constants.MillisecondsPerSecond * crankPositionsPerMillisecond;
            return crankPositionsPerSecond * crank.RadiansPerPosition;
        }
    }
}