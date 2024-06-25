using System;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sortierverfahren;



internal class Program
{
    static void Main(string[] args)
    {
        //              --   Beispiele zur Zeitkomplexität   --

        // Die Zeitkomplexität O(1)

        string[] names = new string[]
        {
            "Thomas",
            "Lasse",
            "Timon",
            "Alina",
            "Sabine"
        };

        string myName = names[2];  // Einfaches Suchen nach einem bestimmten Element

        //--------------------------------------------------------------------------

        // Die Zeitkomplexität O(n)

        static double Average(double[] numbers)  
        {
            double sum = 0;

            foreach (double num in numbers)
                sum += num;

            return sum / numbers.Length;   
        }

        // Dadurch dass ALLE Elemente (n) mit einbezogen werden, steigt auch der Aufwand linear mit, wenn die Anzahl größer wird

        double[] numbers = new double[]  
        {
            25,
            55,
            17,
            87,
            100
        };
        
        Console.WriteLine(Average(numbers));

        //--------------------------------------------------------------------------


        main();


        //--------------------------------------------------------------------------


        // Random Zahlen
        void randomZahlen()
        {
            Console.Clear();
            Random zufallszahlen = new Random();
            DateTime zeit1 = DateTime.Now;
            int zahl = 0;
            int anzahl;

            Console.WriteLine("\n Wie viele Zahlen zwischen 1 und 100 möchtest du ausgeben?");
            anzahl = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[] gesamt = new int[anzahl];

            for (int i = 0; i < anzahl; i++)
            {
                zahl = zufallszahlen.Next(1, 101);
                gesamt[i] = zahl;
                if (i > 0 && i % 10 == 0)
                {
                    // Thread.Sleep(100);
                    Console.WriteLine();
                }
                Console.Write("\t" + zahl);
            }
            Console.WriteLine("\n\nDu hast " + gesamt.Length + " Zahlen bekommen.");
            DateTime zeit2 = DateTime.Now;
            /*Console.WriteLine("zahl:{0}", zahl);*/
            Console.WriteLine("\n\n gebrauchte Zeit:/n{0:T}", zeit2 - zeit1 + " sec");

            Console.WriteLine("\n\n --------------------------------------");
            Console.WriteLine(" Sortieren mit Bubble Sort        | 1 |");
            Console.WriteLine(" Sortieren mit Insertion Sort     | 2 |");
            Console.WriteLine(" Sortieren mit Selection Sort     | 3 |");
            Console.WriteLine(" Sortieren mit Quick Sort (Bsp.)  | 4 |");
            Console.WriteLine("\n Nochmal  | 9 |        zurück   | 0 |");
            string auswahl = Console.ReadLine();
            if (auswahl == "9")
            {
                randomZahlen();
            } else if (auswahl == "1")
            {
                Console.WriteLine("\n  Bubble Sort  \n");
                Bubblesort(gesamt);
                back();
            }else if (auswahl == "2")
            {
                Console.WriteLine("\n  Insertion Sort  \n");
                InsertionSort(gesamt);
                back();
            }else if (auswahl == "3")
            {
                Console.WriteLine("\n  Selection Sort  \n");
                SelectionSort(gesamt);
                back();
            }else if (auswahl == "4")
            {
                Console.WriteLine("\n  Quick Sort (Beispiel) \n");
                Quicksort();
                back();
            }else if (auswahl == "0")
            {
                Console.WriteLine(" OK :) ");
                Thread.Sleep(500);
                back();
            }
        }
        

        void main()
        {
            Console.Clear();
            Console.Write("\n Sortieralgorithmen \n\n");
            Console.Write("    Bubble Sort       | 1 | \n");
            Console.Write("    Insertion Sort    | 2 | \n");
            Console.Write("    Random Zahlen     | 3 | \n");
            Console.Write("\n    zurück            | 0 | \n");
            Console.Write("\n\n  Auswahl: ");
            int select = Convert.ToInt32(Console.ReadLine());
            switch (select)
            {
                case 1:
                    bubbleSort();
                    break;
                case 2:
                    insertionSort();
                    break;
                case 3:
                    randomZahlen();
                    break;
                case 0:
                    abbruch();
                    break;
                default:
                    Console.WriteLine("  ungültige Eingabe");
                    main();
                    break;
            }
        }
        void abbruch()
        {
            main();
        }
        void back()
        {
            Console.WriteLine("\n  --  zurück  --    | 0 | \n");
            string eingabe = Console.ReadLine();
            switch (eingabe)
            {
                case "0":
                    main();
                    break;
                default:
                    Console.WriteLine(" Falsche Eingabe!");
                    break;
            }
        }



        //                                 _______________
        //________________________________|  BUBBLE SORT  |_________________________________\\

        // Die Zeitkomplexität ist O(n2) > aufgrund verschachtelter for-Schleifen

        void bubbleSort()                                                                //
        {                                                                                //
            // macht sauber                                                              //
            Console.Clear(); 

            Console.WriteLine("\n   Bubble Sort \n");

            // Unsortiertes Array definiert und initialisiert 
            int[] numbers = { 5, 8, 3, 1, 9, 4, 6, 2, 7 };

            // Ausgabe des unsortierten Arrays
            foreach (int num in numbers)
                Console.Write(num + " ");
            Console.Write("-- Start\n");


            //                             ________________________
            //                          --| Beginn des Algorithmus |--

            // temporäre Variable zum Zwischenspeichern um zu tauschen
            int temp;

            //____________
            // Startzeit |
            DateTime zeit1 = DateTime.Now;

            // erste for-Schleife um auf jedes Element im Array zu iterieren
            for (int i = 0; i < numbers.Length - 1; i++)
            {

                // zweite for-Schleife für das nächste Element zum Vergleich
                for (int j = 0; j < numbers.Length - (1 + i); j++)  // +i geht schneller, weil Elemente auf dem
                                                                    //    richtigen Platz nicht mehr berücksichtigt werden müssen
                {
                    // Vergleich des nächsten Elements im Array
                    if (numbers[j] > numbers[j + 1])
                    {
                        // Tausch                         beim 2. Lauf trifft 8 auf 3
                        temp = numbers[j + 1];         //                temp  =  3
                        numbers[j + 1] = numbers[j];   //    Index vom Wert 3  zu  8
                        numbers[j] = temp;             //    Index vom Wert 8  zu  3 (temp)
                    }
                }
                // Ausgabe der Phasen des Algorithmus
                foreach (int num in numbers)
                {
                    Thread.Sleep(50);
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }

            //____________
            //  Endzeit  |
            DateTime zeit2 = DateTime.Now;
            Console.WriteLine("\n\n gebrauchte Zeit:/n{0:T}", zeit2 - zeit1 + " sec");


            Console.WriteLine("\n--------------------------|\n");
            back();
        }
        static int[] Bubblesort(int[] numbers)
        {
            //____________
            // Startzeit |
            DateTime zeit1 = DateTime.Now;

            int temp;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - (1 + i); j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }

                /*                foreach (int num in numbers)
                                {
                                    Console.Write(num + "  ");
                                }
                                Console.WriteLine();*/

            }

            foreach (int num in numbers)
            {
                Console.Write(num + "  ");
            }
            Console.WriteLine();

            //____________
            //  Endzeit  |
            DateTime zeit2 = DateTime.Now;
            Console.WriteLine("\n\n gebrauchte Zeit:/n{0:T}", zeit2 - zeit1 + " sec");

            return numbers;     
        } 
        

        //                                __________________
        //_______________________________|  INSERTION SORT  |_______________________________\\
 
        void insertionSort()
        {
            Console.Clear();
            Console.WriteLine("  Insertion Sort \n");
            int[] numbers2 = { 5, 8, 3, 1, 9, 4, 6, 2, 7 };
            foreach (int num in numbers2)
                Console.Write(num + " ");
            Console.Write("-- Start\n");

            InsertionSort(numbers2);

            back();
        }
        static void InsertionSort(int[] arrayToSort)
        {
            //____________
            // Startzeit |
            DateTime zeit1 = DateTime.Now;


            for (int i = 1; i < arrayToSort.Length; i++)
            {
                int valueToSort = arrayToSort[i];
                int k = i;

                while (k > 0 && arrayToSort[k - 1] > valueToSort)
                {
                    arrayToSort[k] = arrayToSort[k - 1];
                    k--;
                }


                arrayToSort[k] = valueToSort;

                /*                for (int j = 0; j < arrayToSort.Length; j++) 
                                {
                                    if (arrayToSort[j] % 10 == 0)
                                    {
                                        Console.WriteLine();
                                    }
                                    // Thread.Sleep(50);
                                    Console.Write(j + " ");
                                }*/

/*                foreach (int num in arrayToSort)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();*/
            }

            foreach (int num in arrayToSort)
            {
                Console.Write(num + "  ");
            }
            Console.WriteLine();

            //____________
            //  Endzeit  |
            DateTime zeit2 = DateTime.Now;
            Console.WriteLine("\n\n gebrauchte Zeit:/n{0:T}", zeit2 - zeit1 + " sec");
        }

        //                                __________________
        //_______________________________|  SELECTION SORT  |_______________________________\\

        void selectionSort()
        {
            Console.Clear();
            Console.WriteLine("  Selection Sort \n");
            int[] numbers2 = { 5, 8, 3, 1, 9, 4, 6, 2, 7 };
            foreach (int num in numbers2)
                Console.Write(num + " ");
            Console.Write("-- Start\n");

            SelectionSort(numbers2);

            back();
        }
        static void SelectionSort(int[] unsortedList)
        {
            //____________
            // Startzeit |
            DateTime zeit1 = DateTime.Now;


            int MinIndex = 0;
            int MinimumValueFound = 0; // temporär

            for (int i = 0; i < unsortedList.Length; i++)
            {

                MinIndex = i;

                for (int j = i + 1; j < unsortedList.Length; j++)
                {
                    if (unsortedList[j] < unsortedList[i])
                    {
                        MinIndex = j;
                    }
                }

                MinimumValueFound = unsortedList[MinIndex];
                unsortedList[MinIndex] = unsortedList[i];
                unsortedList[i] = MinimumValueFound;
            }

            foreach (int num in unsortedList)
            {
                Console.Write(num + "  ");
            }
            Console.WriteLine();

            //____________
            //  Endzeit  |
            DateTime zeit2 = DateTime.Now;
            Console.WriteLine("\n\n gebrauchte Zeit:/n{0:T}", zeit2 - zeit1 + " sec");
        }

        //                                  ______________
        //_________________________________|  QUICK SORT  |_______________________________\\

        void Quicksort()
        {
            // Quick Sort
            static void Quick_Sort(int[] arr, int left, int right)
            {
                // Check if there are elements to sort
                if (left < right)
                {
                    // Find the pivot index
                    int pivot = Partition(arr, left, right);

                    // Recursively sort elements on the left and right of the pivot
                    if (pivot > 1)
                    {
                        Quick_Sort(arr, left, pivot - 1);
                    }
                    if (pivot + 1 < right)
                    {
                        Quick_Sort(arr, pivot + 1, right);
                    }
                }
            }

            // Method to partition the array
            static int Partition(int[] arr, int left, int right)
            {
                // Select the pivot element
                int pivot = arr[left];

                // Continue until left and right pointers meet
                while (true)
                {
                    // Move left pointer until a value greater than or equal to pivot is found
                    while (arr[left] < pivot)
                    {
                        left++;
                    }

                    // Move right pointer until a value less than or equal to pivot is found
                    while (arr[right] > pivot)
                    {
                        right--;
                    }

                    // If left pointer is still smaller than right pointer, swap elements
                    if (left < right)
                    {
                        if (arr[left] == arr[right]) return right;

                        int temp = arr[left];
                        arr[left] = arr[right];
                        arr[right] = temp;
                    }
                    else
                    {
                        // Return the right pointer indicating the partitioning position
                        return right;
                    }
                }
            }

            static void Main2(string[] args)
            {
                int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

                Console.WriteLine("Original array : ");
                foreach (var item in arr)
                {
                    Console.Write(" " + item);
                }
                Console.WriteLine();

                // Call Quick Sort to sort the array
                Quick_Sort(arr, 0, arr.Length - 1);

                Console.WriteLine();
                Console.WriteLine("Sorted array : ");

                foreach (var item in arr)
                {
                    Console.Write(" " + item);
                }
                Console.WriteLine();
            }
        }






        /*        string[] satz = { "Sortieren", "macht", "richtig", "Spaß", "und", "hilft", "beim", "finden" };
                for (int i = 0; i < satz.Length; i++)
                {
                    for (int j = i + 1; j < satz.Length; j++)
                    {
                        if (satz[j].CompareTo(satz[i]) < 0)
                        {
                            string wort = satz[i];
                            satz[i] = satz[j];
                            satz[j] = wort;
                        }
                    }
                    Console.Write(satz[i] + " ");
                }
                Console.WriteLine();*/

        // -----------------------

    }


    

}
