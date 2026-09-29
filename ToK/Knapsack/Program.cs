/*
using System;
using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args){

            string nextLine;

            // One iteration for each test case
            while ((nextLine = Console.ReadLine()) != null)
            {

                string[] input = nextLine.Split();

                int C = int.Parse(input[0]);
                int n = int.Parse(input[1]);
                int[,] items = new int[n,2];

                // items[value, weight]
                for(int i = 0; i < n; i++)
                {
                    input = Console.ReadLine().Split();
                    items[i,0] = int.Parse(input[0]);
                    items[i,1] = int.Parse(input[1]);
                }

                int[,] resultMatrix = new int[C+1,n+1];


                // iterate through each row of the matrix
                for(int i = 1; i <= n; i++)
                {
                    int currentItemValue = items[i-1,0];
                    int currentItemWeight = items[i-1,1];
                    for(int j = 1; j <= C; j++)
                    {
                        if (currentItemWeight > j)
                        {
                            resultMatrix[j,i] = resultMatrix[j,i-1];
                        }
                        else
                        {
                            if (resultMatrix[j,i-1] < (currentItemValue + resultMatrix[j-currentItemWeight,i-1]))
                            { 
                                resultMatrix[j,i] = currentItemValue + resultMatrix[j-currentItemWeight,i-1];
                            }
                            else
                            {
                                resultMatrix[j,i] = resultMatrix[j,i-1];
                                
                            }
                        }
                    }
                }
                
                //PrintMatrix(resultMatrix);
                PrintResult(resultMatrix,items);

            }
            
        }


        private static void PrintMatrix(int[,] resultMatrix)
        {
            for(int i = 0; i < resultMatrix.GetLength(1); i++)
                {
                for(int j = 0; j < resultMatrix.GetLength(0); j++)
                {
                    Console.Write(resultMatrix[j,i]+",");
                    
                }
                    Console.WriteLine(resultMatrix[resultMatrix.GetLength(0)-1,i]);
            }
        }

        private static void PrintResult(int[,] resultMatrix,int[,] items)
        {
            int noOfItems = 0;
            List<int> indices = new List<int>();

            int i = resultMatrix.GetLength(0)-1;
            int j = resultMatrix.GetLength(1)-1;
            int remainingValue = resultMatrix[i,j];

            while(i != 0 && j != 0 && remainingValue != 0)
            {
                if(resultMatrix[i,j] == resultMatrix[i, j - 1]){
                    j--;
                }
                else
                {
                    noOfItems++;
                    indices.Add(--j);
                    remainingValue -= items[j,0];
                    i -= items[j,1];
                }
            }

            Console.WriteLine(noOfItems);
            for(int p = noOfItems-1; p > 0; p--)
            {
                Console.Write(indices.ElementAt(p)+" ");
            }

            if(noOfItems > 0)
            {
                Console.WriteLine(indices.ElementAt(0));
            }

        }

    }

}
*/




using System;
using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args){

            string nextLine;

            // One iteration for each test case
            while ((nextLine = Console.ReadLine()) != null)
            {

                string[] input = nextLine.Split();

                int C = int.Parse(input[0]);
                int n = int.Parse(input[1]);
                int[,] items = new int[n,2];

                // items[value, weight]
                for(int i = 0; i < n; i++)
                {
                    input = Console.ReadLine().Split();
                    items[i,0] = int.Parse(input[0]);
                    items[i,1] = int.Parse(input[1]);
                }

                int[] resultMatrix = new int[(C+1)*(n+1)];

                for(int i = 1; i <= n; i++)
                {
                    int currentItemValue = items[i-1,0];
                    int currentItemWeight = items[i-1,1];
                    for(int j = 1; j <= C; j++)
                    {
                        int currrentIndex = i+j*(n+1);

                        if (currentItemWeight > j)
                        {
                            resultMatrix[currrentIndex] = resultMatrix[currrentIndex-1];
                        }
                        else
                        {
                            if (resultMatrix[currrentIndex-1] < (currentItemValue + resultMatrix[i-1+(j-currentItemWeight)*(n+1)]))
                            { 
                                resultMatrix[currrentIndex] = currentItemValue + resultMatrix[i-1+(j-currentItemWeight)*(n+1)];
                            }
                            else
                            {
                                resultMatrix[currrentIndex] = resultMatrix[currrentIndex-1];
                                
                            }
                        }
                    }
                }
                
                //PrintMatrix(resultMatrix);
                PrintResult(resultMatrix, n, C, items);

            }
            
        }


        private static void PrintMatrix(int[,] resultMatrix)
        {
            for(int i = 0; i < resultMatrix.GetLength(1); i++)
                {
                for(int j = 0; j < resultMatrix.GetLength(0); j++)
                {
                    Console.Write(resultMatrix[j,i]+",");
                    
                }
                    Console.WriteLine(resultMatrix[resultMatrix.GetLength(0)-1,i]);
            }
        }

        private static void PrintResult(int[] resultMatrix, int n, int C, int[,] items)
        {
            int noOfItems = 0;
            List<int> indices = new List<int>();

            int i = n;
            int j = C;
            int remainingValue = resultMatrix[i+j*(n+1)];

            while(i != 0 && j != 0 && remainingValue != 0)
            {

                int currrentIndex = i+j*(n+1);

                if(resultMatrix[currrentIndex] == resultMatrix[currrentIndex-1]){
                    i--;
                }
                else
                {
                    noOfItems++;
                    indices.Add(--i);
                    remainingValue -= items[i,0];
                    j -= items[i,1];
                }
            }

            Console.WriteLine(noOfItems);
            for(int p = noOfItems-1; p > 0; p--)
            {
                Console.Write(indices.ElementAt(p)+" ");
            }

            if(noOfItems > 0)
            {
                Console.WriteLine(indices.ElementAt(0));
            }

        }

    }

}