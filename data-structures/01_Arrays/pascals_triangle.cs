class PascalsTriangle
{
	public static void Main(string[] args)
	{
		int n = 10;
		
		// declare a jagged array
		int[][] pt = new int[n][];
		
		for(int i = 0; i < n; i++)
		{
			// array to hold the rows of the triangle
			pt[i] = new int[i+1];			
			
			// Set values for the first & last cell
			pt[i][0] = 1;
			pt[i][i] = 1;
			
			// compute the values for cells in the middle			
			for(int j = 1; j < i; j++)
				pt[i][j] = pt[i-1][j-1] + pt[i-1][j];
		}
		
		for(int i = 0; i < pt.Length; i++)
		{
				for(int j = 0; j < pt[i].Length; j++)
					System.Console.Write("{0} ", pt[i][j]);
			
			System.Console.WriteLine();
		}		
	}
}