using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("inputs.txt");

            var depths = input.Select(d => Int32.Parse(d));

            var answer_part_1 = depths.Aggregate(new
            {
                prev = -1,
                increases = 0
            }, (state, current) =>
            {
                Boolean prev_measurement = state.prev != -1;

                if (prev_measurement && state.prev < current)
                {
                    return new
                    {
                        prev = current,
                        increases = state.increases + 1,
                    };
                }

                return new
                {
                    prev = current,
                    increases = state.increases,
                };
            });

            var answer_part_2 = depths.Aggregate(new
            {
                prev1 = -1,
                prev2 = -1,
                prev3 = -1,
                increases = 0
            }, (state, current) =>
            {
                Boolean prev_measurement = !(state.prev1 == -1 || state.prev2 == -1 || state.prev3 == -1);

                if (prev_measurement && state.prev1 + state.prev2 + state.prev3 < current + state.prev1 + state.prev2)
                {
                    return new
                    {
                        prev1 = current,
                        prev2 = state.prev1,
                        prev3 = state.prev2,
                        increases = state.increases + 1,
                    };
                }

                return new
                {
                    prev1 = current,
                    prev2 = state.prev1,
                    prev3 = state.prev2,
                    increases = state.increases,
                };
            });

            Console.WriteLine("Answer to part 1: " + answer_part_1.increases);
            Console.WriteLine("Answer to part 2: " + answer_part_2.increases);
        }
    }
}
