using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<char> binarySearchTree = new BinarySearchTree<char>();


            //binarySearchTree.Insert(6);
            //binarySearchTree.Insert(1);
            //binarySearchTree.Insert(7);
            //binarySearchTree.Insert(10);
            //binarySearchTree.Insert(3);
            //binarySearchTree.Insert(2);
            //binarySearchTree.Insert(9);
            //binarySearchTree.Insert(4);
            //binarySearchTree.Insert(8);

            //Node<int> temp = binarySearchTree.Search(2);
            //Console.WriteLine(temp.value); 

            binarySearchTree.Insert('F');
            binarySearchTree.Insert('B');  
            binarySearchTree.Insert('G');  
            binarySearchTree.Insert('A');  
            binarySearchTree.Insert('D');
            binarySearchTree.Insert('I');  
            binarySearchTree.Insert('C');  
            binarySearchTree.Insert('E');  
            binarySearchTree.Insert('H');

            var result = binarySearchTree.BreadthFirst();

            }
    }
}
