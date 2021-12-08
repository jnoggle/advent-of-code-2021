using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("inputs.txt");

            int[] bit_counts = mostCommonBits(input);

            int gamma_rate = 0b0;
            int epsilon_rate = 0b0;

            foreach (int count in bit_counts)
            {
                gamma_rate <<= 1;
                epsilon_rate <<= 1;

                if (count == 1)
                {
                    gamma_rate++;
                }
                else
                {
                    epsilon_rate++;
                }
            }

            Console.WriteLine("Answer to part 1: " + (gamma_rate * epsilon_rate));
        }

        static int[] mostCommonBits(string[] input)
        {
            int[] bit_counts = new int[12];
            int number_of_bits = input[0].Length;

            foreach (string line in input)
            {
                for (int i = 0; i < number_of_bits; i++)
                {
                    if (line[i] == '1')
                    {
                        bit_counts[i]++;
                    }
                    else
                    {
                        bit_counts[i]--;
                    }
                }
            }

            int[] common_bits = new int[number_of_bits];

            for (int i = 0; i < number_of_bits; i++)
            {
                if (bit_counts[i] > 0)
                {
                    common_bits[i] = 1;
                }
            }

            return common_bits;
        }
    }
}
