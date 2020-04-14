using System.Collections.Generic;

namespace cesar.utils
{
    public class Tools
    {
        /*
            1. Replacing characters in place:

            Given an array of characters, write a method to replace all the spaces with “&32”.
            You may assume that the array has sufficient slots at the end to hold the additional
            characters, and that you are given the “true” length of the array. (Please perform this
            operation in place with no other auxiliary structure).

            Example:
         
            Input: “User is not allowed “, 19
            Output: “User&32is&32not&32allowed”
        */
        public static string ReplacingCharacters(string text, int size)
        {
            string _finalText = "";
            foreach (char part in text.Substring(0,size))
            {
                _finalText += part == ' ' ? "&32" : part.ToString();
            }

            return _finalText;
        }

        /*
            2. Check words with jumbled letters:

            Our brain can read texts even if letters are jumbled, like the following sentence: “Yuo
            cna porbalby raed tihs esaliy desptie teh msispeillgns.”Given two strings, write a
            method to decide if one is a partial­permutation of the other. Consider a
            partial­permutation only if:

            ­ The first letter hasn’t changed place
­             If word has more than 3 letters, up to 2/3 of the letters have changed place

            Examples:
                you, yuo ­> true
                probably, porbalby ­> true
                despite, desptie ­> true
                moon, nmoo ­> false
                misspellings, mpeissngslli ­> false
         */        
        public static bool IsJumbled(string t1, string t2)
        {
            Dictionary<char, int> _lettersT1 = new Dictionary<char, int>();
            Dictionary<char, int> _lettersT2 = new Dictionary<char, int>();

            int _max = t1.Length > 3 ? t1.Length * 2 / 3 : 2;

            int _dif = 0, _pos = 0, _jamb = 0;

            if (t1.Equals(t2)) return true;
            if ((t1[0] != t2[0]) || (t1.Length != t2.Length))
            {
                return false;
            }

            foreach (char _char in t1)
            {
                if (_lettersT1.ContainsKey(_char))
                {
                    _lettersT1[_char]++;
                }
                else
                {
                    _lettersT1.Add(_char, 1);
                }
            }

            foreach (char _char in t2)
            {
                if (_lettersT2.ContainsKey(_char))
                {
                    _lettersT2[_char]++;
                }
                else
                {
                    _lettersT2.Add(_char, 1);
                }
            }

            foreach (char _char in t1)
            {
                if (_lettersT1[_char] != _lettersT2[_char]) _dif++;
                if (t1[_pos] != t2[_pos]) _jamb++;
                _pos++;
            }

            if (_dif > 0) return false;
            
            if (_jamb > _max) return false;

            return true;
        }
        
        /*
            3. Check words with typos:

            There are three types of typos that can be performed on strings: insert a character,
            remove a character, or replace a character. Given two strings, write a function to
            check if they are one typo (or zero typos) away.

            Examples:
                pale, ple ­> true
                pales, pale ­> true
                pale, bale ­> true
                pale, bake ­> false
         */
        public static bool IsTypo(string t1, string t2)
        {   
            int dif = 0, jump = 0;
            if (t1 == t2) return true;

            if (t1.Length > t2.Length)
            {                
                for (int i = 0; i < t1.Length; i++)
                {
                    if (i + jump == t1.Length-1) return jump <= 1;
                    if (t1[i+jump] != t2[i])
                    {
                        if (i + 1 == t1.Length-1) return jump <= 1;
                        if (t1[i+ ++jump] != t2[i])
                        {
                            if (jump > 1) return false;
                        }
                    }
                }
                if (jump > 1) return false;
            }
            else
            {
                for (int i = 0; i < t1.Length; i++)
                {
                    if (t1[i] != t2[i])
                    {
                        if (++dif > 1) return false;
                    }
                }
            }

            return true;
        }

        /*
            5. Remove duplicates on email thread:

            When different email clients are used on a same thread, the discussion get messy
            because old messages are included again and get duplicated. Given a email thread
            (represented by a singly unsorted linked list of messages), write a function that
            remove duplicated messages from it
        */
        public static LinkedList<string> RemoveDuplicates(LinkedList<string> linkedList)
        {
            LinkedList<string> ll = linkedList;
            List<string> foundedList = new List<string>();
            List<string> duplicatedList = new List<string>();

            LinkedListNode<string> current = ll.First;

            while (current.Next != null)
            {
                if (!foundedList.Contains(current.Value))
                {
                    foundedList.Add(current.Value);
                }
                else
                {
                    duplicatedList.Add(current.Value);
                }
                current = current.Next;
            }

            if (duplicatedList.Count>0)
            {
                foreach (string item in duplicatedList)
                {
                    ll.Remove(ll.Find(item));
                }
            }            

            return ll;
        }

        /*
            7. Linked List Intersection:
            
            If two requests on the queue have linked lists that intersect (like the example below),
            previous service could be improved to process only the difference between them.
            Write a method that receives two singly linked lists and return the intersecting node
            of the two lists (if exists). Note that the intersection is defined by reference, not value.
            (No need to change previous answer).
        */
        public static LinkedListNode<string> GetIntesection(LinkedList<string> linkedList1, LinkedList<string> linkedList2)
        {
            LinkedListNode<string> node = null;
            LinkedListNode<string> current1 = linkedList1.First;
            LinkedListNode<string> current2 = linkedList1.First;

            while (current1.Next != null)
            {
                current2 = linkedList1.First;
                while (current2.Next != null)
                {
                    if (current1.Value == current2.Value) return current1;
                    current2 = current2.Next;
                }
                current1 = current1.Next;
            }

            return null;
        }
    }
}
