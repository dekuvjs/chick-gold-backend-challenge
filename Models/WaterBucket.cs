
namespace WaterJugChallenge.Models
{

    public class WaterBucket
    {
        private int _capacity;
        private int _waterAmount;


        public WaterBucket(int capacity)
        {
            _capacity = capacity;

        }

        /// <summary>Fill the bucket of water</summary>
        public void Fill()
        {
            _waterAmount = _capacity;
        }

        /// <summary>Add a specific amount of water to the bucket</summary>
        /// <param name="amount">Amount of water to add</param>
        public void AddSpecificAmount(int amount)
        {
            _waterAmount += amount;
        }


        /// <summary>Transfer the water from this bucket to the other bucket</summary>
        /// <param name="otherBucket">Other bucket object</param>
        public void Transfer(WaterBucket otherBucket)
        {
            // Check the amount of water the  other bucket currently supports.
            int supportedWater = otherBucket.GetCapacity() - otherBucket.getWaterAmount();


            if (supportedWater >= _waterAmount)
            {
                // Add the amount of water from this bucket to the other one. 
                otherBucket.AddSpecificAmount(_waterAmount);

                // Empty all the water from the current bucket. 
                ThrowWater();
            }
            else
            {
                // If the supported water is less than the amount of water 
                // fill the other bucket. 
                otherBucket.Fill();

                // Remove the supported water from this bucket.
                PourWater(supportedWater);
            }


        }

        /// <summary>Pour water from one bucket</summary>
        /// <param name="amountToPour">amount of water to pour</param>
        public void PourWater(int amountToPour)
        {
            _waterAmount -= amountToPour;
        }


        /// <summary>Get the amount of water from the bucket</summary>
        /// <returns>The amount of water in the bucket</returns>
        public int getWaterAmount()
        {
            return _waterAmount;
        }



        /// <summary>Throws all the water from the bucket</summary>
        public void ThrowWater()
        {
            _waterAmount = 0;
        }


        /// <summary>Check if the bucket is full</summary>
        /// <returns>True if the bucket is full, false otherwise</returns>
        public bool IsFull()
        {
            return _waterAmount == _capacity;
        }

        /// <summary>Check if the bucket is empty</summary>
        /// <returns>True if the bucket is empty, false otherwise</returns>
        public bool IsEmpty()
        {
            return _waterAmount == 0;
        }


        /// <summary>Get the capacity of the bucket</summary>
        /// <returns>The capacity of the bucket</returns>
        public int GetCapacity()
        {
            return _capacity;
        }
    }

}