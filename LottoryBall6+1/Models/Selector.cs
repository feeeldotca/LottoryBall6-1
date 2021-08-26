using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoryBall6_1
{
    /// <summary>
    /// selector class, pick 6 numbers from the RedNumbers pool, 1 number from 
    /// the BlueNumbers pool
    /// </summary>
    public class Selector
    {
        //Red Ball numbers pool and Blue ball numbers pool
        public List<string> RedNumbers { get; set; }
        public List<string> BlueNumbers { get; set; }

        public List<DualColorBalls> SelectedNumbers { get; set; } = new List<DualColorBalls>();

        //produce random numbers, only used inside the class
        private Random random = new Random();

        /// <summary>
        /// constructor: initialize red and blue ball pools filled with numbers
        /// </summary>
        public Selector()
        {
            RedNumbers = new List<string>
            {
                "01","02","03","04","05","06","07","08","09",
                "10","11","12","13","14","15","16","17","18","19",
                "20","21","22","23","24","25","26","27","28","29",
                "30","31","32","33"
            };
            BlueNumbers = new List<string>
            {
                "01","02","03","04","05","06","07","08","09",
                "10","11","12","13","14","15","16"
            };
        }


        /// <summary>
        /// create n random numbers from exist pools
        /// </summary>
        /// <param name="n">the number of random number produces</param>
        /// <param name="pools">RedNumbers or BlueNumbers</param>
        /// <returns></returns>
        public List<string> createRandomNumbers(int n, List<string> pools)
        {
            List<string> numList = new List<string>();
            while (true) {
                if (numList.Count > n) break; //if produced enough numbers then exit
                string num = pools[random.Next(pools.Count)];
                if (numList.Contains(num)) continue;
                numList.Add(num); 
            }
            
            return numList;
        }

        


    }
}
