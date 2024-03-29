﻿using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace BinarySearchTree
{
    [DebuggerDisplay("{value}")]
    class Node<T>
    {
        public T value;

        public Node<T> rightChild;
        public Node<T> leftChild;
        public Node<T> Parent;

        public Node(T value)
        {
            this.value = value;
        }

        public bool isRightChild()
        {
            if (this.Parent != null && this.Parent.rightChild == this)
            {
                return true;
            }
            return false;
        }

        public bool isLeftChild()
        {
            if (this.Parent != null && this.Parent.leftChild == this)
            {
                return true;
            }
            return false;
        }

    }


    class BinarySearchTree<T>
        where T : IComparable<T>
    {
        public Node<T> root;


        public int Count { get; private set; }
        public BinarySearchTree()
        {
            Count = 0;
        }

        public Node<T> Search(T value)
        {
            Node<T> current = root;
            while (current != null)
            {
                int temp = value.CompareTo(current.value);

                if (temp < 0)
                {
                    current = current.leftChild;
                }
                else if (temp > 0)
                {
                    current = current.rightChild;
                }
                else if (temp == 0)
                {
                    return current;
                }
            }

            return null;
        }


        public T Minimum()
        {
            Node<T> temp = root;
            while (temp.leftChild != null)
            {
                temp = temp.leftChild;
            }
            return temp.value;
        }

        public T Maximum()
        {
            Node<T> temp = root;
            while (temp.rightChild != null)
            {
                temp = temp.rightChild;
            }
            return temp.value;
        }


        public void Insert(T value)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(value);
            }
            else
            {
                Node<T> temp = root;
                bool foundParent = false;
                while (!foundParent)
                {
                    if (value.CompareTo(temp.value) >= 0)
                    {
                        if (temp.rightChild == null)
                        {
                            foundParent = true;
                            break;
                        }
                        temp = temp.rightChild;
                    }
                    else
                    {
                        if (temp.leftChild == null)
                        {
                            foundParent = true;
                            break;
                        }
                        temp = temp.leftChild;
                    }
                }

                if (value.CompareTo(temp.value) > 0)
                {
                    temp.rightChild = new Node<T>(value);
                    temp.rightChild.Parent = temp;
                }
                else
                {
                    temp.leftChild = new Node<T>(value);
                    temp.leftChild.Parent = temp;
                }
            }
            Count++;
        }

        public void Delete(T value)
        {
            Node<T> temp = this.Search(value);

            if (temp.rightChild == null && temp.leftChild == null)
            {
                if (temp.isRightChild())
                {
                    temp.Parent.rightChild = null;
                }
                else if (temp.isLeftChild())
                {
                    temp.Parent.leftChild = null;
                }
            }
            else if (temp.leftChild != null && temp.rightChild != null)
            {
                Node<T> current = temp.leftChild;

                while (current.rightChild != null)
                {
                    current = current.rightChild;
                }

                if (current.leftChild != null)
                {
                    current.Parent.rightChild = current.leftChild;
                }
                temp.value = current.value;

            }
            else
            {
                if (temp.Parent != null)
                {
                    if (temp.isLeftChild())
                    {
                        if (temp.rightChild != null)
                        {
                            temp.Parent.leftChild = temp.rightChild;
                        }
                        else
                        {
                            temp.Parent.leftChild = temp.leftChild;
                        }
                    }
                    else if (temp.isRightChild() && temp.rightChild != null)
                    {
                        if (temp.rightChild != null)
                        {
                            temp.Parent.rightChild = temp.rightChild;
                        }
                        else
                        {
                            temp.Parent.rightChild = temp.leftChild;
                        }
                    }
                }
                else if (temp == root)
                {
                    if (temp.leftChild != null)
                    {
                        root = temp.leftChild;
                        root.Parent = null;
                    }
                    else
                    {
                        root = temp.rightChild;
                        root.Parent = null;
                    }
                }
            }
            Count--;
        }

        public List<Node<T>> Preorder()
        {
            List<Node<T>> list = new List<Node<T>>();

            Stack<Node<T>> stak = new Stack<Node<T>>();

            stak.Push(root);

            Node<T> current = root;


            while (stak.Count > 0)
            {
                list.Add(current);
                if (current.rightChild != null)
                {
                    stak.Push(current.rightChild);
                }
                if (current.leftChild != null)
                {
                    stak.Push(current.leftChild);
                }
                current = stak.Pop();
            }
            return list;
        }

        public Stack<Node<T>> postOrder()
        {
            Stack<Node<T>> list = new Stack<Node<T>>();
            Stack<Node<T>> stack = new Stack<Node<T>>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                Node<T> current = stack.Pop();

                list.Push(current);

                if (current.leftChild != null)
                {
                    stack.Push(current.leftChild);
                }

                if (current.rightChild != null)
                {
                    stack.Push(current.rightChild);
                }
            }

            return list;
        }


        public Queue<Node<T>> InOrder()
        {
            Queue<Node<T>> list = new Queue<Node<T>>();
            Stack<Node<T>> stack = new Stack<Node<T>>();

            Node<T> current = root;

            stack.Push(root);

            
            while (stack.Count > 0)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.leftChild;
                }
                else
                {
                    current = stack.Pop();
                    if (!list.Contains(current))
                    {
                        list.Enqueue(current);
                    }
                    current = current.rightChild;
                }
            }
            return list; 
        }

        public Queue<Node<T>> BreadthFirst()
        {
            Queue<Node<T>> list = new Queue<Node<T>>();
            Queue<Node<T>> temp = new Queue<Node<T>>();

            Node<T> current = root;

            temp.Enqueue(current);
            while (temp.Count > 0)
            {
                current = temp.Dequeue();
                if (current.leftChild != null)
                {
                    temp.Enqueue(current.leftChild);
                }
                if (current.rightChild != null)
                {
                    temp.Enqueue(current.rightChild);
                }
                //if (!list.Contains(current))
                //{
                    list.Enqueue(current);
                //}
                
            }




            return list; 
        }

    }
}
