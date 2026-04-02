using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Numerics;
using System.Xml;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
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
            Console.WriteLine($"Grade  : {(firstAbove90 > 0 ? firstAbove90.ToString() : "None found")}");

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
            Console.WriteLine($"Has 100: {grades.Contains(100)} ");

            //Step 8: Convert to List<string> 
            List<string> gradeLabels = grades.ConvertAll(x => $"Grade:{x}");
            Console.WriteLine("\n=== Grade Labels ===");
            PrintCollection(gradeLabels);

            #endregion

            #region Exercise 2: Leaderboard
            //Create a leaderboard that automatically sorts players by score.
            //1-Add: 500 = "Ahmed", 200 = "Sara", 800 = "Ali", 350 = "Mona"
            //2-Print all entries(they should be sorted by score automatically)
            //3-Access the first key and first value
            //4-Check if score 500 exists
            //5-Safely get the player with score 999
            //6-Remove the player with score 200 and print the updated list

            //Step 1: Add players 
            SortedList<int, string> leaderboard = new SortedList<int, string>();
            leaderboard.Add(500, "Ahmed");
            leaderboard.Add(200, "Sara");
            leaderboard.Add(800, "Ali");
            leaderboard.Add(350, "Mona");

            //Step 2: Print all entries  
            Console.WriteLine("\n=== Leaderboard (Sorted by Score) ===");
            foreach (KeyValuePair<int, string> entry in leaderboard)
                Console.WriteLine($" Score: {entry.Key} -> Player: {entry.Value}");

            //Step 3: Access first key and first value 
            Console.WriteLine("\n=== First Entry ===");
            Console.WriteLine($" First Key   : {leaderboard.Keys[0]}");
            Console.WriteLine($" First Value : {leaderboard.Values[0]}");

            //Step 4: Check if score 500 exists 
            Console.WriteLine("\n=== Check Score 500 ===");
            Console.WriteLine($" ContainsKey(500): {leaderboard.ContainsKey(500)}");

            //Step 5: Safely get the player with score 999 
            Console.WriteLine("\n=== Safe Lookup: Score 999 ===");
            if (leaderboard.TryGetValue(999, out string? playerName))
                Console.WriteLine($" Player: {playerName}");
            else
                Console.WriteLine(" No player found ");

            //Step 6: Remove score 200 and print updated list 
            leaderboard.Remove(200);
            Console.WriteLine("\n=== Updated Leaderboard (After Removing Score 200) ===");
            foreach (KeyValuePair<int, string> entry in leaderboard)
                Console.WriteLine($"  Score: {entry.Key} -> Player: {entry.Value}");
            #endregion

            #region Exercise 3: Phone Book
            //Build a phone book application.
            //1-Create a Collection with 4 contacts(name → phone number)
            //2-Add a new contact using [] syntax (add or update)
            //3-Try adding a duplicate using .Add() — catch the exception and print the error
            //4-Try adding a duplicate using .TryAdd() — print whether it succeeded
            //5-Search for a contact that doesn’t exist
            //6-Get a contact with a fallback of "Not Found"
            //7-Print all Keys on one line, then all Values on another line

            //Step 1: Create collection with 4 contacts 
            Dictionary<string, string> phoneBook = new()
            {
                ["Ahmed"] = "01001234567",
                ["Sara"] = "01119876543",
                ["Ali"] = "01234567890",
                ["Mona"] = "01556781234"
            };
            Console.WriteLine("\n=== Phone Book ===");
            foreach (KeyValuePair<string, string> contact in phoneBook)
                Console.WriteLine($"  {contact.Key}: {contact.Value}");

            //Step 2: Add or update using [] syntax 
            phoneBook["Laila"] = "01098765432";   // adds new contact
            phoneBook["Ahmed"] = "01001111111";   // updates existing contact
            Console.WriteLine("\n=== After [] Add/Update ===");
            foreach (KeyValuePair<string, string> contact in phoneBook)
                Console.WriteLine($"  {contact.Key}: {contact.Value}");

            //Step 3: Try adding a duplicate with .Add() → catch exception 
            Console.WriteLine("\n=== Add() Duplicate ===");
            try
            {
                phoneBook.Add("Sara", "00000000000");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }

            //Step 4: Try adding a duplicate with .TryAdd() 
            Console.WriteLine("\n=== TryAdd() Duplicate ===");
            bool added = phoneBook.TryAdd("Ali", "00000000000");
            Console.WriteLine($" TryAdd(\"Ali\"): {added}");

            //Step 5: Search for a contact that doesn't exist 
            Console.WriteLine("\n=== Search: Does 'Omar' Exist? ===");
            Console.WriteLine($" ContainsKey(\"Omar\"): {phoneBook.ContainsKey("Omar")}");

            if (phoneBook.TryGetValue("Omar", out string? omarPhone))
                Console.WriteLine($"  Omar's number: {omarPhone}");
            else
                Console.WriteLine("  Omar was not found in the phone book");

            //Step 6: Get a contact with fallback value 
            Console.WriteLine("\n=== Get with Fallback ===");
            string result = phoneBook.GetValueOrDefault("Omar", "Not Found");
            Console.WriteLine($" Omar's number: {result}");

            //Step 7: Print all Keys then all Values 
            Console.WriteLine("\n=== All Keys ===");
            Console.WriteLine(string.Join(", ", phoneBook.Keys));

            Console.WriteLine("\n=== All Values ===");
            Console.WriteLine(string.Join(", ", phoneBook.Values));
            #endregion

            #region Exercise 4: Unique Email Validator
            //Use Collection to manage unique email addresses.
            //1-Create a HashSet<string> with a case -insensitive comparer: new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            //2-Add these emails: "ahmed@test.com", "AHMED@test.com", "sara@test.com", "Sara@Test.Com"
            //3-Print Count — how many are actually stored? Explain why.
            //4-Create two sets: Set A = { 1, 2, 3, 4, 5 } and Set B = { 4,5,6,7,8}
            //5-Print the result of: UnionWith, IntersectWith, ExceptWith
            //6-Use IsSubsetOf to check if { 1,2} is a subset of Set A

            //Step 1 & 2: Create HashSet with case-insensitive comparer & add emails 
            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");   // duplicate of ahmed@test.com (case-insensitive)
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");    // duplicate of sara@test.com  (case-insensitive)

            Console.WriteLine("\n=== Stored Emails ===");
            foreach (string email in emails)
                Console.WriteLine($" {email}");

            //Step 3: Print Count and explain 
            Console.WriteLine($"\n=== Count: {emails.Count} ===");
            /*Only 2 emails are stored because HashSet does not allow duplicates.
              With OrdinalIgnoreCase, 'AHMED@test.com' is treated the same as 'ahmed@test.com', 
              and Sara@Test.Com' is treated the same as 'sara@test.com'.
            */
            Console.WriteLine("""
                                Only 2 emails are stored because HashSet does not allow duplicates.
                                With OrdinalIgnoreCase, 'AHMED@test.com' is treated the same as 'ahmed@test.com', 
                                and Sara@Test.Com' is treated the same as 'sara@test.com'.
                                """);

            //Step 4: Create Set A and Set B 
            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            Console.WriteLine("\n=== Set A: { 1, 2, 3, 4, 5 } ===");
            Console.WriteLine("=== Set B: { 4, 5, 6, 7, 8 } ===");

            //Step 5a: UnionWith 
            HashSet<int> union = [.. setA];
            union.UnionWith(setB);
            Console.Write("\n  Union (A | B)    : ");
            PrintCollection(union);        

            //Step 5b: IntersectWith 
            HashSet<int> intersect = [.. setA];
            intersect.IntersectWith(setB);
            Console.Write("\n  Intersect (A & B): ");
            PrintCollection(intersect);            

            //Step 5c: ExceptWith 
            HashSet<int> except = [.. setA];
            except.ExceptWith(setB);
            Console.Write("\n  Except (A - B)   : ");
            PrintCollection(except);

            //Step 6: IsSubsetOf — check if {1,2} is a subset of Set A 
            HashSet<int> small = [1, 2];
            Console.WriteLine($"\n=== Is {{1,2}} a subset of Set A? ===");
            Console.WriteLine($"  IsSubsetOf(setA): {small.IsSubsetOf(setA)}");

            #endregion
        }
    }
}
