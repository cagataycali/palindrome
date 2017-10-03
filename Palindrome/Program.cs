/* 14253019 - Çağatay Çalı */
using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Palindrom
{
	class MainClass
	{
		public static void Main()
		{

			var stack = new Stack();
			var que = new Queue();

			Console.WriteLine("Check the text is palindrome or not, can type this text to below for testing purposes");
			Console.WriteLine("> alyarısını sırayla");

			// Get input from command line.
			string text = Console.ReadLine();
			string output = text; // Just monkey style copy input for result output.
			bool isPalindrome = true;

			/* 
			  Regex for remove all non alphanumeric characters
			  from a string except dash and space characters.
			  Source: https://stackoverflow.com/a/6067604/8542909
			 */
			text = Regex.Replace(text, @"[^\w\s\-]*", "");

			// Remove all whitespace from string. Source: https://stackoverflow.com/a/16346178/8542909
			text = text.Replace(" ", string.Empty);
			// Lowercase for english chars like as I i etc.
			text = text.ToLower();

			// Push and enqueue per char.
			for (int i = 0; i < text.Length; i++)
			{
				stack.Push(text[i]);
				que.Enqueue(text[i]);
			}

			// Check stack and que.
			for (int i = 0; i < text.Length; i++)
			{
				object pickStack = stack.Pop();
				object pickQue = que.Dequeue();
				if (!pickQue.Equals(pickStack))
				{
					isPalindrome = false;
					break;
				}
			}

			Console.WriteLine("{0} {1} palindrome.", output, isPalindrome ? "is" : "isn't");
		}
	}
}
