using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;


//Task 1 - Reverse Array
int[] arrayToReverse = { 15, 2, 4, 6, 8, 9, 10, 11, 12, 14, 6, 17 };
ReverseArray(arrayToReverse);


//Task 2 - Palindrome
string palindromeToTest = "abut-1-tuba";
IsPalindrome(palindromeToTest);


//Task 3 - Permutation
int[] array1 = { 6, 7, 3, 2, 4, 8, 11, 5, 9, 13, 2 };
int[] array2 = { 6, 3, 7, 2, 8, 4, 11, 9, 5, 13, 2 };
Permutation(array1, array2);


//Task 4 - Powers of 2
List<uint> list = new() { 5, 3, 7, 4, 12, 2, 1, 0, 512 };
PowersOf2(list);


//Task 5 - Finding primes
int[] primeArrayStarts = { 1, 1, 1 };
int[] primeArrayEnds = { 100, 1000, 10000 };
FindPrimes(primeArrayStarts.Length, primeArrayStarts, primeArrayEnds);


//Task 6 - Common digit
int[] array = { 4, 7, 3, 2, 2, 2, 3, 3 };
CommonDigit(array);


//Task 7 - Digit sum
uint[] digitSumArray = { 77, 73, 86, 83, 86 };
DigitSum(digitSumArray);




//Task 1 - Reverse Array
void ReverseArray(int[] inputArray)
{
    int[] reversedArray = new int[inputArray.Length];
    int j = 0;
    for (int i = inputArray.Length - 1; i >= 0; i--)
    {
        reversedArray[j] = inputArray[i];
        j++;
    }

    Console.WriteLine("Task 1 - Reverse Array");
    for (int i = 0; i < reversedArray.Length - 1; i++)
    {
        Console.Write(reversedArray[i] + ", ");
    }
    Console.WriteLine(reversedArray[^1]);
    Console.WriteLine();
}

//Task 2 - Palindrome
void IsPalindrome(string s)
{
    s = Regex.Replace(s, "[^a-zA-Z0-9]", "");
    bool isPalindrome = true;

    for (int i = 0; i < s.Length / 2; i++)
    {
        if (!s[i].Equals(s[s.Length - 1 - i]))
        {
            isPalindrome = false;
            break;
        }
    }
    Console.WriteLine("Task 2 - Palindrome");
    Console.WriteLine(isPalindrome ? "YES" : "NO");
    Console.WriteLine();
}

//Task 3 - Permutation
void Permutation(int[] array1, int[] array2)
{
    Array.Sort(array1);
    Array.Sort(array2);
    bool isPermutation = true;

    for (int i = 0; i < array1.Length; i++)
    {
        if (array1[i] != array2[i])
        {
            isPermutation = false;
            break;
        }
    }
    Console.WriteLine("Task 3 - Permutation");
    Console.WriteLine(isPermutation ? "YES" : "NO");
    Console.WriteLine();
}

//Task 4 - Powers of 2
void PowersOf2(List<uint> list)
{
    List<uint> listofPowersOf2 = new();

    for (int i = 0; i < list.Count; i++)
    {
        if (BitOperations.IsPow2(list[i]))
        {
            listofPowersOf2.Add(list[i]);
        }
    }
    listofPowersOf2.Sort();
    listofPowersOf2 = listofPowersOf2.Distinct().ToList();

    Console.WriteLine("Task 4 - Powers of 2");
    if (listofPowersOf2.Count == 0)
    {
        Console.WriteLine("NA");
    }
    else
    {
        for (int i = 0; i < listofPowersOf2.Count - 1; i++)
        {
            Console.Write(listofPowersOf2[i] + ", ");
        }
        Console.WriteLine(listofPowersOf2[^1]);
    }
    Console.WriteLine();
}

//Task 5 - Finding primes
void FindPrimes(int T, int[] m, int[] n)
{
    Console.WriteLine("Task 5 - Find Primes");
    bool isPrime;
    int primeCount = 0;

    for (int i = 0; i < T; i++)
    {
        for (int j = m[i]; j < n[i]; j++)
        {
            if (j == 0 || j == 1) continue;
            if (j == 2 || j == 3 || j == 5)
            {
                primeCount++;
                continue;
            }
            if (j % 2 == 0) continue;
            if (j % 3 == 0) continue;
            if (j % 5 == 0) continue;

            isPrime = true;
            for (int k = 2; k <= (int)Math.Ceiling(Math.Sqrt(j)); k++)
            {
                if (j % k == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                primeCount++;
            }

        }
        Console.WriteLine(primeCount);
        primeCount = 0;
    }
}

//Task 6 - Common digit
void CommonDigit(int[] array)
{
    StringBuilder sb = new();
    foreach (int number in array)
    {
        sb.Append(number);
    }

    string s = sb.ToString();
    int commonDigit = 0;
    int count = 0;
    int tempMaxCount = 0;

    for (int i = 0; i < 10; i++)
    {
        foreach (char c in s)
        {
            if (int.Parse(c.ToString()) == i)
            {
                count++;
            }
        }
        if (count >= tempMaxCount && i > commonDigit)
        {
            commonDigit = i;
            tempMaxCount = count;
        }
        count = 0;
    }
    Console.WriteLine("Task 6 - Common Digit");
    Console.WriteLine(commonDigit);
    Console.WriteLine();
}

//Task 7 - Digit sum
void DigitSum(uint[] array)
{
    string s;
    int digitSum = 0;
    int largestSum = 0;
    int largestIndex = 0;

    for (int i = 0; i < array.Length; i++)
    {
        s = array[i].ToString();
        foreach (char c in s)
        {
            digitSum += int.Parse(c.ToString());
        }
        if (digitSum > largestSum && array[i] > array[largestIndex])
        {
            largestSum = digitSum;
            largestIndex = i;
        }
        digitSum = 0;
    }
    Console.WriteLine("Task 7 - Digit Sum");
    Console.WriteLine(largestIndex);
    Console.WriteLine();
}
