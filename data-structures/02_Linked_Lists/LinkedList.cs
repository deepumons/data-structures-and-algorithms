public class ListNode {
	int item;
	ListNode next;
	
	public int Item {
		get { return item; }
	}
	
	public ListNode Next {
		get { return this.next; }
		set { this.next = value; }
	}
	
	public ListNode(int item) {
		this.item = item;
		this.next = null;
	}
	
	public ListNode(int item, ListNode next) {
		this.item = item;
		this.next = next;
	}
}

public class LinkedList {
	
	private ListNode head;
	private int size;
	
	public LinkedList() {
		head = null;
		size = 0;
	}
	
	public int Size() {
		return size;
	}
	
	public bool IsEmpty() {
		return (head == null);
	}
	
	public void PushFront(int item) {		
		head = new ListNode(item, head);
		size++;
	}
	
	private ListNode NodeAt(int index) {
		
		if ((index < -1) || (index > this.Size())) {
			System.Console.WriteLine("Index out of bounds. Unable to find node.");
			return null;
		}
			
		int i = 1;
		ListNode currentNode = head;
		
		while(currentNode.Next != null)
		{
			if (i == index)
				break;
			
			currentNode = currentNode.Next;
			i++;
		}
		return currentNode;
	}
	
	public int ValueAt(int index) {
		
		ListNode node = NodeAt(index);
		
		if(node != null)
			return node.Item;
		else
			return -1;
	}
	
	public int PopFront() {
		
		ListNode popNode;
		
		if(head != null) {			
			popNode = head;
			head = popNode.Next;
			size--;
			return popNode.Item;
		}
		
		return -1;
	}
	
	public void PushBack(int item) {
		
		ListNode newNode = new ListNode(item);
		
		if (head != null) {
			ListNode currentNode = head;
		
			// Iterate and find the last node		
			while(currentNode.Next != null)
				currentNode = currentNode.Next;
			
			currentNode.Next = newNode;
		}
		else {
			head = newNode;
		}
		
		size++;
	}
	
	
	public int PopBack() {
		
		int item = -1;
		
		if (head != null) {
			item = ValueAt(size);
			
			if (size == 1)
				head = null;			
			else
				(NodeAt(size-1)).Next = null;
			
			size--;
		}
		
		return item;
	}
	
	public int Front() {
		if (head != null)
			return head.Item;
		
		return -1;
	}
	
	public int Back() {
		if (head != null)
			return ValueAt(size);
		
		return -1;
	}
	
	public void Insert(int index, int item) {
		if(index > 0 && index <= size) {
			if (index == 1)
				PushFront(item);
			else if(index == size)
				PushBack(item);
			else {
				// Find the current node at index
				ListNode nodeAtIndex = NodeAt(index);
				
				ListNode newNode = new ListNode(item, nodeAtIndex);
				
				NodeAt(index-1).Next = newNode;
				
				size++;
			}			
		}
	}
	
	public void Print() {
		if (head != null) {
			ListNode currentNode = head;
			
			while(currentNode != null) {
				System.Console.Write(" {0}", currentNode.Item);
				currentNode = currentNode.Next;
			}
			System.Console.WriteLine();
		}
	}
	
	public void Erase(int index) {
		if(index > 0 && index <= size) {
			if (index == 1 ) {
				PopFront();
			}
			else if (index == size) {
				PopBack();
			}
			else {
				ListNode node = NodeAt(index-1);
				node.Next = (node.Next).Next;
				size--;
			}
			
		}
	}
	
	public int ValueNFromEnd(int index) {
		index = size - index + 1;
		
		if(index > 0 && index <= size)
			return ValueAt(index);
		else
			return -1;
	}
	
	public LinkedList ReverseList() {		
		if (!this.IsEmpty()) {
			ListNode currentNode = head;
			LinkedList reversedList = new LinkedList();
			
			while(currentNode != null) {				
				reversedList.PushFront(currentNode.Item);
				currentNode = currentNode.Next;
			}
			
			return reversedList;
		}
		
		return null;
	}
	
	public void RemoveValue(int item) {		
		if(!this.IsEmpty()) {
			ListNode currentNode = head;
			int index = 1;
			
			while(currentNode != null) {
				if(currentNode.Item == item)
					break;
				
				currentNode = currentNode.Next;
				index++;
			}
			
			// Remove the item
			Erase(index);
		}
	}
	

	
	public static void Main(string[] args) {
	
	LinkedList list = new LinkedList();	
	
	list.PushFront(1);
	System.Console.WriteLine("List size: {0}. Is list empty?: {1}", list.Size(), list.IsEmpty());	 
	list.PushFront(2);
	//System.Console.WriteLine("Popped item: {0}", list.PopFront());
	list.PushFront(3);	
	list.PushFront(4);
	//System.Console.WriteLine("Popped item: {0}", list.PopFront());
	list.PushFront(5);
	System.Console.WriteLine("Index {0}, Value: {1}", 1, list.ValueAt(1));
	System.Console.WriteLine("Index {0}, Value: {1}", 2, list.ValueAt(2));
	System.Console.WriteLine("Index {0}, Value: {1}", 3, list.ValueAt(3));
	System.Console.WriteLine("Index {0}, Value: {1}", 4, list.ValueAt(4));
	System.Console.WriteLine("Index {0}, Value: {1}", 5, list.ValueAt(5));
	System.Console.WriteLine("Popped item: {0}", list.PopBack());	
	list.Print();
	list.ValueNFromEnd(2);
	System.Console.WriteLine("Last - Index {0}, Value: {1}", 5, list.ValueNFromEnd(5));
	
	list = list.ReverseList();
	list.Print();
	
	list.RemoveValue(5);
	list.Print();
	list.RemoveValue(3);
	list.Print();
	
	System.Console.WriteLine("List size: {0}. Is list empty?: {1}", list.Size(), list.IsEmpty());
	}
}

