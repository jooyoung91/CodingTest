using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Interface;

namespace Practice.Test
{
    [TestClass()]
    public class BinaryTreeTests
    {
        private IBinaryTree<Int32> _mock;

        [TestInitialize()]
        public void TestInit()
        {
            BinaryTree<Int32> btree = new BinaryTree<int>(50);
            _mock = (IBinaryTree<Int32>)btree;
        }


        /// <summary>
        /// Add non-duplicated value into the tree 
        /// </summary>
        /// 
        [TestMethod()]
        public void Add_Normal_Value_Node_Test()
        {
            bool result = _mock.Add(1);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Add_Duplicated_Value_Test()
        {
            bool result = true;
            int[] values = GetNonUniqueValues();
            foreach(int i in values)
            {
                result = _mock.Add(i);
                if (!result)
                    break;
            }
            Assert.IsFalse(result); // should return false since the node value is already present. 
        }
        [TestMethod()]
        public void NodeCount_Test()
        {
            int[] values = GetUniqueValues();
            foreach (int i in values)
            {
                _mock.Add(i);
            }

            int expectedNodeCount = values.Length;
            Assert.AreEqual(_mock.nodeCount, expectedNodeCount);
        }

        [TestMethod()]
        public void PrintNodeList_Test()
        {
            int[] values = GetUniqueValues();
            foreach( int i in values)
            {
                _mock.Add(i);
            }
            string value = _mock.InOrderTraversal();
            Assert.IsFalse(string.IsNullOrEmpty(value));
        }

        [TestMethod]
        public void PrintedNode_Has_All_Added_Unique_Valule_Nodes()
        {
            int[] values = GetUniqueValues();
            foreach(int i in values)
            {
                _mock.Add(i);
            }
            string printedValues = _mock.InOrderTraversal();

            var result = from s in printedValues.Split(',')
                         where !values.Contains(Convert.ToInt32(s))
                         select s;
            Assert.IsTrue(result.FirstOrDefault() == null);
        }

        [TestMethod]
        public void PrintedNode_Has_All_Added_NonUnique_Valule_Nodes()
        {
            int[] values = GetNonUniqueValues();
            foreach (int i in values)
            {
                _mock.Add(i);
            }
            string printedValues = _mock.InOrderTraversal();

            var result = from s in printedValues.Split(',')
                         where !values.Contains(Convert.ToInt32(s))
                         select s;
            Assert.IsTrue(result.FirstOrDefault() == null);
        }

        [TestMethod]
        public void Node_Delete_Test()
        {
            bool result = false;
            int[] values = GetUniqueValues();
            foreach (int i in values)
            {
                _mock.Add(i);
            }
            string printedValues = _mock.InOrderTraversal();
            result = _mock.Delete(60);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Node_Delete_And_Present_Test()
        {
            bool result = false;
            int[] values = GetUniqueValues();
            foreach (int i in values)
            {
                _mock.Add(i);
            }
            result = _mock.Delete(60);
            string printedValues = _mock.InOrderTraversal();

            var find = from s in printedValues.Split(',')
                       where s == (60).ToString()
                       select s;
            Assert.IsTrue(find.FirstOrDefault() == null);
        }

        public int[] GetUniqueValues()
        {
            return new int[] { 50, 3, 32, 52, 60, 45, 66, 70 };
        }

        public int[] GetNonUniqueValues()
        {
            return new int[] { 50, 2, 83, 42, 5, 83, 5, 19, 35, 64 };
        }
    }
}