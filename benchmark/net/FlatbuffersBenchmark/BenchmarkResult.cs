using System;
using System.Linq;

namespace FlatBuffersBenchmark
{
    public struct BenchmarkResult
    {
        public string Name { get; set; }
        public int Iterations { get; set; }
        public double[] Measurements { get; set; }

        public double Sum
        {
            get { return Iterations <= 0 ? Double.NaN : Measurements.Sum(); }
        }

        public double Mean
        {
            get { return Iterations <= 0 ? Double.NaN : Sum / Iterations; }
        }

        public double Variance
        {
            get
            {
                if (Iterations <= 0)
                {
                    return Double.NaN;
                }
                var mean = Mean;
                var variance = Measurements.Sum(i => Math.Pow(i - mean, 2));
                return variance / (Iterations - 1);
            }
        }

        public double StandardDeviation
        {
            get { return Math.Sqrt(Variance); }
        }
    }
}