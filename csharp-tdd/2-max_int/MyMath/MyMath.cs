using System.Collections.Generic;

namespace MyMath
{
    /// <summary>This is the Operations class within MyMath namespace.</summary>
    public class Operations
    {
        /// <summary>Returns the max integer in a list of integers.</summary>
        public static int Max(List<int> nums)
        {
            if (noms == null)
            {
                return 0;
            }
            if (nums.Count == 0)
            {
                return 0;
            }

            int returnValue = nums[0];
            
            foreach (int i in nums)
            {
                if (i > returnValue)
                {
                    returnValue = i;
                }
            }
            return returnValue;
        }
    }
}
