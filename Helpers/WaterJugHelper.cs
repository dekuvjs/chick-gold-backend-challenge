
using WaterJugChallenge.Models;

namespace WaterJugChallenge.Helpers
{
    public static class WaterJugHelper
    {


        /// <summary>
        /// Solve the water jug riddle
        /// </summary>
        /// <param name="firstBucketCapacity">The amount of water the first bucket supports</param>
        /// <param name="secondBucketCapacity">The amount of water the second bucket supports</param>
        /// <param name="amountWanted">The target water</param>
        /// <param name="firstBucketName">First bucket name</param>
        /// <param name="secondBucketName">Second bucket name</param>
        /// <param name="isYTheFirstBucket">Indicates if the Y bucket is the first bucket</param>
        /// <returns>List of steps to reach the target amount</returns>
        public static List<Step> SolveRiddle(int firstBucketCapacity, int secondBucketCapacity, int amountWanted, string firstBucketName, string secondBucketName, bool isYTheFirstBucket = false)
        {
            int stepCount = 0;
            List<Step> steps = [];
            WaterBucket firstBucket = new(firstBucketCapacity);
            WaterBucket secondBucket = new(secondBucketCapacity);

            // Start process until one of the buckets has the wanted amount. 
            while (amountWanted != firstBucket.getWaterAmount() && amountWanted != secondBucket.getWaterAmount())
            {


                if (firstBucket.IsEmpty())
                {
                    stepCount++;

                    // If the first bucket is empty, fill it.
                    firstBucket.Fill();

                    // Log the step
                    steps.Add(new Step
                    {
                        StepNumber = stepCount,
                        BucketX = isYTheFirstBucket ? secondBucket.getWaterAmount() : firstBucket.getWaterAmount(),
                        BucketY = isYTheFirstBucket ? firstBucket.getWaterAmount() : secondBucket.getWaterAmount(),
                        Action = $"Fill bucket {firstBucketName}",
                        Status = GetStatus(firstBucket.getWaterAmount(), secondBucket.getWaterAmount(), amountWanted)
                    });

                }
                else if (secondBucket.IsFull())
                {
                    stepCount++;

                    // If the second bucket is full, empty it.
                    secondBucket.ThrowWater();

                    // Log the step.
                    steps.Add(new Step
                    {
                        StepNumber = stepCount,
                        BucketX = isYTheFirstBucket ? secondBucket.getWaterAmount() : firstBucket.getWaterAmount(),
                        BucketY = isYTheFirstBucket ? firstBucket.getWaterAmount() : secondBucket.getWaterAmount(),
                        Action = $"Throw water from bucket {secondBucketName}",
                        Status = GetStatus(firstBucket.getWaterAmount(), secondBucket.getWaterAmount(), amountWanted)
                    });
                }
                else
                {
                    // In this case, the first bucket has some water and the second one is not full.
                    stepCount++;

                    // Transfer water from the first bucket to the second one.
                    firstBucket.Transfer(secondBucket);

                    // Log the step.
                    steps.Add(new Step
                    {
                        StepNumber = stepCount,
                        BucketX = isYTheFirstBucket ? secondBucket.getWaterAmount() : firstBucket.getWaterAmount(),
                        BucketY = isYTheFirstBucket ? firstBucket.getWaterAmount() : secondBucket.getWaterAmount(),
                        Action = $"Transfer water from bucket {firstBucketName} to bucket {secondBucketName}",
                        Status = GetStatus(firstBucket.getWaterAmount(), secondBucket.getWaterAmount(), amountWanted)
                    });
                }

            }

            return steps;

        }





        /// <summary>
        /// Check if the water jug riddle is solvable with the given parameters
        /// </summary>
        /// <param name="xBucketCapacity">The amount of water the X bucket supports</param>
        /// <param name="yBucketCapacity">The amount of water the Y bucket supports</param>
        /// <param name="amountWanted">The target water</param>
        /// <returns>True if the riddle is solvable, false otherwise</returns>
        public static bool CheckIfPossible(int xBucketCapacity, int yBucketCapacity, int amountWanted)
        {
            // Validate that all values are positive.
            if (xBucketCapacity <= 0 || yBucketCapacity <= 0 || amountWanted <= 0)
                return false;

            // Check if the wanted amount is not greater than the largest bucket.
            int maxCapacity = Math.Max(xBucketCapacity, yBucketCapacity);
            if (amountWanted > maxCapacity)
                return false;

            // Check if the wanted amount is a multiple of the GCD of both buckets
            int gcd = GreatestCommonDivisor(xBucketCapacity, yBucketCapacity);
            return amountWanted % gcd == 0;
        }


        /// <summary>
        /// Calculate the Greatest Common Divisor (GCD) of two numbers
        /// </summary>
        /// <param name="xBucketCapacity">First number</param>
        /// <param name="yBucketCapacity">Second number</param>
        /// <returns>The GCD of the two numbers</returns>
        static int GreatestCommonDivisor(int xBucketCapacity, int yBucketCapacity)
        {
            int a = xBucketCapacity;
            int b = yBucketCapacity;



            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            // At the end the value of a will be the Greatest Common Divisor.
            return a;

        }

        /// <summary>
        /// Get the status of the current step
        /// </summary>
        /// <param name="firstBucketAmount">Amount of water in the first bucket</param>
        /// <param name="secondBucketAmount">Amount of water in the second bucket</param>
        /// <param name="amountWanted">The target water</param>
        /// <returns>"Solved" if the target amount is reached, null otherwise</returns>
        static string? GetStatus(int firstBucketAmount, int secondBucketAmount, int amountWanted)
        {
            if (firstBucketAmount == amountWanted || secondBucketAmount == amountWanted)
            {
                return "Solved";
            }
            return null;
        }




    }
}