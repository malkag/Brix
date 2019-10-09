# Brix
## Brix programming assignment

#### [Exercise 1 - Supermarket flow](https://github.com/malkag/Brix/tree/master/Supermarket)
n = buyers' number, t=cashiers' number
- **Space complexity:** O(n+t)\
   The space for n buyers + the space for t cashiers (+their tasks)
- **Time complexity:** O(n)\
   Dequeueing a buyer takes O(1), it'll happen at least n times - 1 time for each buyer. (multithreading decreases only execution time and not time complexity)
 
#### [Exercise 2 - Finding a 5-long string in a 1M string file](https://github.com/malkag/Brix/tree/master/FindInFile)
- **Searching time complexity:** O(1)\
  Sorting a 5-long word is 5log5=O(1). Finding a key in a Dictionary is O(1)
