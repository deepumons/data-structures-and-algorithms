import array as arr


class Vector:

    def __init__(self):
        self.__size = 0
        self.__capacity = 1
        self.__elements = arr.array('i', [0] * self.__capacity)

    # Check the size of the vector
    def size(self):
        return self.__size

    # Return the capacity of the vector
    def capacity(self):
        return self.__capacity

    # Check if the array is empty or not
    def is_empty(self):
        return (self.__size == 0)

    # Return an element at index
    def at(self, index):
        return self.__elements[index]

    def print_array(self):
        print(self.__elements)
        print("Size: ", self.__size, " Capacity: ", self.__capacity)

    def __resize(self, new_capacity):

        # print("Out of space. Resizing the array.")
        new_array = arr.array('i', [0] * new_capacity)

        # Increase the capacity
        self.__capacity = new_capacity

        # Copy the old array to the new array
        for i in range(self.__size):
            new_array[i] = self.__elements[i]

        return new_array

    def push(self, item):
        # print("Pushing ", item)
        index = self.__size
        # Check if there is space in the array
        if (self.__size < self.__capacity - 1):
            # print("Inserting at index:", index )
            self.__elements[index] = item
            self.__size += 1
        else:
            # Increase the capacity of the array
            self.__elements = self.__resize(self.__capacity * 2)

            # print("Inserting at index:", index)

            self.__elements[index] = item
            self.__size += 1

        self.print_array()

    def insert(self, index, item):
        print("Inserting ", item, " at index: ", index)

        if (index > self.__size):
            print("Array out of bounds. Unable to insert.")
        # See if we are inserting at the tail end.
        elif (index == self.__capacity - 1):
            self.push(item)
        else:
            # Check if we have space to insert the new item
            if (self.__size + 1 >= self.__capacity):
                self.__elements = self.__resize(self.__capacity * 2)

                # shift all elements 1 space to the right
                for i in range(self.__size + 1, index, -1):
                    self.__elements[i] = self.__elements[i-1]

                self.__elements[index] = item
                self.__size += 1

            self.print_array()

    def prepend(self, item):
        # This is same as inserting at index 0
        self.insert(0, item)

    def pop(self):
        index = self.__size - 1
        popped_value = self.__elements[index]
        self.__elements[index] = 0
        self.__size -= 1

        # See if we need to resize the array
        if (self.__size <= self.__capacity / 4):
            self.__elements = self.__resize(int(self.__capacity / 2))

        self.print_array()

        return popped_value

    def find(self, item):

        for i in range(self.__size):
            if(self.__elements[i] == item):
                return i

        return -1

    def delete(self, index):

        if (index >= self.__size):
            print("Array out of bounds. Unable to delete element at index: ",
                  index)
        else:

            # shift all the elements to the left by one
            for i in range(index, self.__size):
                self.__elements[i] = self.__elements[i+1]

            print("Deleting element at index: ", index)
            self.__elements[self.__size] = 0
            self.__size -= 1

            # See if we need to resize the array
            if (self.__size <= self.__capacity / 4):
                self.__elements = self.__resize(int(self.__capacity / 2))

            self.print_array()

    def remove(self, item):

        # Look for all instances of item in the array and remove
        more_items = True

        print("Deleting all instances of ", item)

        while(more_items):
            item_index = self.find(item)
            if (item_index >= 0):
                self.delete(item_index)
            else:
                more_items = False


# test code
v = Vector()
v.push(3)
v.prepend(2)
