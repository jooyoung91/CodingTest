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
            result = _mock.Add(50);
            Assert.IsFalse(result); // should return false since the node value is already present. 
        }
        [TestMethod()]
        public void NodeCount_Test()
        {
            _mock.Add(25);
            _mock.Add(30);
            _mock.Add(80);
            _mock.Add(55);
            _mock.Add(92);
            _mock.Add(88);
            _mock.Add(99);
            _mock.Add(100);

            int expectedNodeCount = 9;
            Assert.AreEqual(_mock.nodeCount, expectedNodeCount);
        }

        [TestMethod()]
        public void PrintNodeList_Test()
        {
            _mock.Add(25);
            _mock.Add(30);
            _mock.Add(80);
            _mock.Add(55);
            _mock.Add(92);
            _mock.Add(88);

            string value = _mock.InOrderTraversal();
            Assert.IsFalse(string.IsNullOrEmpty(value));
        }



    }
}