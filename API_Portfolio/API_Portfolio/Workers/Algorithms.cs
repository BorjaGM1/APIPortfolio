namespace API_Portfolio.Workers
{
    public class Algorithms : IAlgorithms
    {

        IConfiguration _config;

        public Algorithms(IConfiguration config)
        {
            _config = config;
        }

        public int[][] GetMagicSquare(int size)
        {
            int[][] magicSqare = new int[size][];
            HashSet<int> numsUsed = new HashSet<int>();

            // M = n(n^2+1)/2
            int m = size*((size*size)+1) / 2;

            for(int i = 0; i < size; i++)
            {
                int sumResult = 0;

                while (sumResult != m)
                {
                    HashSet<int> usedBuffer = new HashSet<int>();
                    int[] rowBuffer = new int[size];
                    sumResult = 0;

                    for (int j = 0; j < size; j++)
                    {
                        int r = size;

                        while (numsUsed.Contains(r) || usedBuffer.Contains(r))
                        {
                            r = new Random().Next(size * size);
                        }

                        numsUsed.Add(r);
                        usedBuffer.Add(r);
                        rowBuffer[j] = r;
                    }

                    sumResult = rowBuffer.Aggregate((a, b) => a + b);

                    if (sumResult == m)
                    {
                        magicSqare[i] = rowBuffer;

                        foreach (int k in usedBuffer)
                        {
                            numsUsed.Add(k);
                        }
                    }
                }
            }

            foreach(var w in magicSqare)
            {
                foreach (var t in w)
                {
                    Console.WriteLine(t);
                }
            }

            return magicSqare;
        }

        public int[][] GetMagicSquareMock()
        {
            int[][] result = new int[3][];
            int n = 1;

            for (int i = 0; i < 3; i++)
            {
                int[] row = new int[3];

                for (int j = 0; j < 3; j++)
                {
                    row[j] = n;
                    n++;
                }

                result[i] = row;
            }

            return result;
        }
    }
}
