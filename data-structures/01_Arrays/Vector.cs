class Vector
{
	private int[] elements;
	private int size;
	private int capacity;
	
	private Vector()
	{
		elements = new int[1];
		size = 0;
		capacity = 1;
	}
	
	public int Size()
	{
		return size;
	}
		
	public int Capacity()
	{
		return capacity;
	}
		
	public bool IsEmpty()
	{
		return (size == 0);
	}
	
	public int At(int index)
	{
		return elements[index];
	}
	
	private int[] Resize(int new_capacity)
	{
		int[] new_elements = new int[new_capacity];
				
		// copy the old array to the new array
		for(int i = 0; i < size; i++)
			new_elements[i] = elements[i];
		
		capacity = new_capacity;
		
		return new_elements;
	}
	
	// insert an item at the end of the vector
	public void Push(int item)
	{
		if(size == capacity)
			elements = Resize(capacity * 2);
		
		elements[size] = item;
		size++;
	}

	public void Insert(int index, int item)
	{
		if (size + 1 == capacity)
			elements = Resize(capacity * 2);
		
		// Shift all the elements after the index to the right to free up space
		for(int i = size; i > index; i--)
			elements[i] = elements[i-1];
		
		// insert the new item at index
		elements[index] = item;
		size++;
	}
	
	public void Prepend(int item)
	{
		Insert(0, item);
	}
	
	
	public void Display()
	{
		foreach(int element in elements)
				System.Console.Write("{0} ", element);
				
		System.Console.WriteLine();
	}
	
	public int Pop()
	{
		int index = size - 1;		
		int item = elements[index];
		
		elements[index] = 0;
		size--;
		
		// Resize the array if necessary
		if (size == capacity / 4)
			elements = Resize(capacity / 2);
		
		return item;
	}
	
	public void Delete(int index)
	{
		// Shift all elements to the left
		for(int i = index; i < size; i++)
			elements[i] = elements[i+1];
		
		size--;
		elements[size] = 0;
		
		// Resize the array if necessary
		if (size == capacity / 4)
			elements = Resize(capacity / 2);
	}
	
	public int Find(int item)
	{
		for(int i=0; i < size; i++)
				if(elements[i] == item)
					return i;
				
		return -1;		
	}
	
	public void Remove(int item)
	{
		int index = Find(item);		
		
		while(index > -1)
		{
			Delete(index);
			index = Find(item);
		}
	}
	
	
	
	public static void Main(string[] args)	
	{
		Vector v = new Vector();
		
		System.Console.WriteLine("Vector size: {0}", v.Size());
		System.Console.WriteLine("Vector capacity: {0}", v.Capacity());
		System.Console.WriteLine("Is the vector empty: {0}", v.IsEmpty());
		
		v.Push(1);
		v.Display();
		
		v.Push(99);
		v.Display();
		
		v.Push(99);
		v.Display();
		
		v.Push(99);
		v.Display();
		
		v.Push(5);
		v.Display();
		
		v.Insert(0, 99);
		v.Display();
		
		v.Insert(2, 100);
		v.Display();
		
		v.Insert(5, 99);
		v.Display();
		
		v.Prepend(99);
		v.Display();
		
		System.Console.WriteLine("Element {0} found at index: {1}", 100, v.Find(100));
		v.Display();
		
		v.Remove(99);
		v.Display();
		
		System.Console.WriteLine("Vector size: {0}", v.Size());
		System.Console.WriteLine("Vector capacity: {0}", v.Capacity());
		System.Console.WriteLine("Is the vector empty: {0}", v.IsEmpty());
		
		
	}
	
	
}