using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();


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

            binarySearchTree.Insert(10);
            binarySearchTree.Insert(5);
            binarySearchTree.Insert(7);
            //binarySearchTree.Insert(6);
            binarySearchTree.Delete(5); 

        }
    }
}
