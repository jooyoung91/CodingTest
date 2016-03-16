using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Practice.Interface
{
    /// <summary>
    /// Defines the standards for a binary tree. Makes no assumptions as to what kind of
    /// binary tree implements this
    /// </summary>
    /// <typeparam name="T">Any object</typeparam>
    public interface IBinaryTree<T>
    {
        /// <summary>
        /// Adds a new element to the tree if it is not already present. Equality checks
        /// should be done using the T type's .Equals()
        /// </summary>
        /// <param name="addition">The element to add to the tree</param>
        /// <returns>Whether or not the element was actually added to the tree</returns>
        bool Add(T addition);

        /// <summary>
        /// Deletes the item out of the tree if it is present. Equality checks
        /// should be done using the T type's .Equals()
        /// </summary>
        /// <param name="target"></param>
        /// <returns>Whether or not the element was actually deleted from the tree</returns>
        bool Delete(T target);

        /// <summary>
        /// Traverses the binary tree using the In Order algorithm
        /// and generates a comma delimited list. Representing the
        /// elements as strings should be done using the T type's .ToString()
        /// A null (empty) tree should still return "[]"
        /// </summary>
        /// <returns>A comma delimited list as a string of the values, e.g. [e1, e2]</returns>
        string InOrderTraversal();

        /// <summary>
        /// Keep the number of nodes
        /// </summary>
        /// <returns>Number of nodes</returns>
        int nodeCount { get; set; }
    }

    public class Node<T>
    {
        public T data;
        public Node<T> left;
        public Node<T> right;

        public Node(T initData)
        {
            data = initData;
            left = null;
            right = null;
        }

        public string printData()
        {
            var value = data == null ? string.Empty : data.ToString();
            return value;
        }
    }

    public class BinaryTree<T> : Practice.Interface.IBinaryTree<T>
    {
        private Node<T> top = null;

        public int nodeCount { get; set; }

        StringBuilder nodeTravel = new StringBuilder();

        // Constructor with Top node vaule
        public BinaryTree(T initData)
        {
            top = new Node<T>(initData);
            nodeCount = 1;
        }

        public bool Add(T addition)
        {
            bool result = false;
            if (addition == null)
                return result;
            else
            {
                //Call recursive function to add new node. 
                result = AddNewNode(ref top, addition);
                if (result)
                    nodeCount++;
                return result;
            }
        }

        private bool AddNewNode(ref Node<T> currentNode, T addition)
        {
            if (currentNode == null)
            {
                //Set current node if current node is null
                currentNode = new Node<T>(addition);
                return true;
            }
            else if (currentNode.data.Equals(addition))
            {
                //return false if current node has the same data. 
                return false;
            }
            else
            {
                // Compare new value with current node value and add to left/right 
                int result = Comparer.DefaultInvariant.Compare(currentNode.data, addition);
                if (result > 0) // new value is smaller 
                    return AddNewNode(ref currentNode.left, addition);
                else if (result < 0) // new value is bigger
                    return AddNewNode(ref currentNode.right, addition);

                return false;
            }
        }

        public bool Delete(T target)
        {
            bool result = false;
            if (target == null)
                return result;
            else
            {
                int curretnCount = nodeCount;
                Delete(ref top, target);
                //currentCount should be less then nodeCount if any of nodes has been deleted. 
                return curretnCount != nodeCount;
            }

        }

        public string InOrderTraversal()
        {
            InOrder(top);
            // Add current node to string builder. 
            string printList = nodeTravel.ToString().TrimEnd(',');
            // Clear the string bulider. 
            nodeTravel.Clear();
            return printList;

        }

        private void InOrder(Node<T> node)
        {
            if (node != null)
            {
                InOrder(node.left);
                // Add current node value to String Builder. 
                nodeTravel.Append(string.Format("{0}{1}", node.printData(), ","));
                InOrder(node.right);
            }
        }

        private void Delete(ref Node<T> node, T target)
        {
            if (node != null)
            {
                if (node.data.Equals(target))
                {
                    //Delete current node and sub nodes. 
                    DeleteNode(ref node);
                }
                else
                {
                    // Keep searching the target node
                    Delete(ref node.left, target);
                    Delete(ref node.right, target);
                }
            }
        }

        private void DeleteNode(ref Node<T> node)
        {
            if (node != null)
            {
                // Delete sub nodes. 
                DeleteNode(ref node.left);
                DeleteNode(ref node.right);
                node = null;
                nodeCount--;
            }
        }
    }

    public class CodingTest
    {
        public static void Main()
        {

        }
    }

}