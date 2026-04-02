using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace G_NET_26_Advanced_03
{
    internal class Program

    {
        public static void PrintCollection<T>(IEnumerable<T> collection, string separator = ", ")
        {
            Console.WriteLine(string.Join(separator, collection));
        }
        static void Main(string[] args)
        {
            #region Exercise 1: Student Grade Manager
            //Create a program that manages student grades using One Of Collections
            //1-Create a Collection with these grades: 85, 92, 78, 95, 88, 70, 100, 65
            //2-Print the collection, Count, first and last grade
            //3-Sort the grades ascending, then print
            //4-Get the first grade above 90
            //5-Get all grades below 75(failing grades)
            //6-Remove all failing grades(below 75)
            //7-Check if any grade equals 100
            //8-Create a List<string> where each grade becomes "Grade: X"

            //Step 1: Create the collection 
            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            //Step 2: Print collection info 
            Console.WriteLine("=== Original Grades ===");
            Console.Write("Grades : ");
            PrintCollection(grades);

            //Step 3: Sort ascending (Bubble Sort) 
            grades.Sort();
            Console.WriteLine("\n=== Sorted Grades (Ascending) ===");
            Console.Write("Grades : ");
            PrintCollection(grades);

            //Step 4: First grade above 90 
            int firstAbove90 = grades.Find(x => x > 90);
            Console.WriteLine("\n=== First Grade Above 90 ===");
            Console.WriteLine($"Grade  : {(firstAbove90 > 0 ? firstAbove90.ToString() : "None found")}" );

            //Step 5: All failing grades (below 75) 
            List<int> failingGrades = grades.FindAll(x => x < 75);
            Console.WriteLine("\n=== Failing Grades (Below 75) ===");
            if (failingGrades.Count == 0)
                Console.WriteLine("Failing Grades : None");
            else
                Console.Write("Failing Grades : ");
            PrintCollection(failingGrades);

            //Step 6: Remove all failing grades 
            grades.RemoveAll(x => x < 75);
            Console.WriteLine("\n=== After Removing Failing Grades ===");
            Console.Write("Grades : ");
            PrintCollection(grades);

            //Step 7: Check if any grade equals 100 
            Console.WriteLine("\n=== Check if any grade equals 100 ===");
            Console.WriteLine($"Has 100: {grades.Contains(100) } " );

            //Step 8: Convert to List<string> 
            List<string> gradeLabels = grades.ConvertAll(x => $"Grade:{x}");
            Console.WriteLine("\n=== Grade Labels ===");
            PrintCollection(gradeLabels);

            #endregion
        }
    }
}
