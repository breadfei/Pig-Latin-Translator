Console.WriteLine("Welcome to the Pig Latin translator!");

//loops the program
bool runLoop = true;
do
{
    //getting input
    Console.WriteLine("Please input a word to be translated.");
    string input = Console.ReadLine().Trim();
    //loop runs if string is empty or a number or symbol is present
    while (input == "" || input.IndexOf("1") != -1 || input.IndexOf("2") != -1 || input.IndexOf("3") != -1 ||
        input.IndexOf("4") != -1 || input.IndexOf("5") != -1 || input.IndexOf("6") != -1 || input.IndexOf("7") != -1 ||
        input.IndexOf("8") != -1 || input.IndexOf("9") != -1 || input.IndexOf("0") != -1 || input.IndexOf("@") != -1 ||
        input.IndexOf("#") != -1 || input.IndexOf("$") != -1 || input.IndexOf("%") != -1 || input.IndexOf("^") != -1 ||
        input.IndexOf("&") != -1 || input.IndexOf("*") != -1 || input.IndexOf("(") != -1 || input.IndexOf(")") != -1)
    {
        Console.WriteLine("Please enter a word. No numbers or symbols are allowed");
        input = Console.ReadLine().Trim();
    }

    //splits the input into an array to allow translation of phrases
    string[] word = input.Split(" ");
    for (int n = 0; n < word.Length; n++)
    {

        //getting index of first vowel

        //stores the index
        int indexVowel = word[n].Length;

        //lists what to check for (vowels in this case)
        string[] vowelList = ["a", "e", "i", "o", "u", "A", "E", "I", "O", "U"];

        //for loop checks the index of each item in vowelList
        //if the index is less than the previous and isn't -1, then it becomes the min
        for (int i = 0; i < 10; i++)
        {
            if (word[n].IndexOf(vowelList[i]) != -1)
            {
                indexVowel = Math.Min(indexVowel, word[n].IndexOf(vowelList[i]));
            }
        }

        //performing actions
        if (indexVowel == 0)
        {
            Console.WriteLine(translateVowel(word[n]));
        }
        else
        {
            Console.Write(translateConsonant(word[n], indexVowel));
        }

        //just adds way
        static string translateVowel(string input)
        {
            return input + "way ";
        }

        //removes the end of word, saves it
        //removes the start of word, save it to another variable
        //adds it all together to successfully translate it
        static string translateConsonant(string input, int indexNum)
        {
            string wordStart = input.Remove(indexNum);
            string wordEnd = input.Remove(0, indexNum);
            return wordEnd + wordStart + "ay ";
        }
    }
    //continue prompt
    Console.WriteLine("\nWould you like to continue? y/n");
    string answer = "";
    do
    {
        answer = Console.ReadLine();
        if (answer == "y")
        {
            break;
        }
        else if (answer == "n")
        {
            runLoop = false;
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    } while (answer != "n");
} while (runLoop);

Console.WriteLine("Thank you for using the Pig Latin Translator.");