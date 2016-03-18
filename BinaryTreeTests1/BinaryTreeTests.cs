using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Test
{
    [TestClass()]
    public class BinaryTreeTests
    {
        private IBinaryTree<Int32> _mock;

        [TestInitialize]
        public void TestInit()
        {
            _mock = new BinaryTree<int>(50);
        }

        [TestMethod]
        public void TestAdd()
        {
            // Arrange (TODO add a few test integers)
            _mock.Add(30);
            // Act (TODO more additions to cover all cases)

            bool additionSuccess1 = _mock.Add(10); // Unique Integer: true 
            bool additionFail = _mock.Add(30); // Dulpicated Integer: false
            // Assert (TODO)

            Assert.IsTrue(additionSuccess1, "Fail to add new node");
            Assert.IsFalse(additionFail, "Duplicated node has been added");

        }

        [TestMethod]
        public void TestDelete()
        {
            // Arrange (TODO add a few values here to the tree to delete)
            _mock.Add(30);
            _mock.Add(40);
            _mock.Add(20);
            _mock.Add(10);
            _mock.Add(45);
            _mock.Add(80);
            _mock.Add(70);
            _mock.Add(60);
            _mock.Add(90);
            _mock.Add(95);
            _mock.Add(100);

            // Act (TODO add more deletions to cover all cases)
            bool deletionLeftLeafSuccess = _mock.Delete(100); 
            bool deletionRightLeafSuccess = _mock.Delete(95); 
            bool deletionNodewithLeftChildSuccess = _mock.Delete(20);
            bool deletionNodewithRightChildSuccess = _mock.Delete(40);
            bool deleteNonExistFail = _mock.Delete(10000);
            bool deleteHeaderSuccess = _mock.Delete(50);

            Assert.IsTrue(deletionLeftLeafSuccess, "Failed to delete left leaf node");
            Assert.IsTrue(deletionRightLeafSuccess, "Failed to delete right leaf node");
            Assert.IsTrue(deletionNodewithLeftChildSuccess, "Failed to delete node with left child");
            Assert.IsTrue(deletionNodewithRightChildSuccess, "Failed to delete node with right child");
            Assert.IsFalse(deleteNonExistFail, "Nonkown node has been deleted");
            Assert.IsTrue(deleteHeaderSuccess, "Header has not been deleted");
            // Assert (TODO)
        }

        [TestMethod]
        public void TestInOrderTravesal()
        {
            // Arrange (TODO add a few test integers here)
            int[] values = new int[] { 50, 30, 40, 20, 10, 45, 80, 70, 60, 90, 95, 100 };
            foreach (int i in values)
                _mock.Add(i); //50 is head and will not be added. 

            // Act
            string result = _mock.InOrderTraversal();

            //Since the Add() works like BTS, The in-order should travel like ascending order. 
            string[] expectedOrder = values.OrderBy(i => i).Select(i => i.ToString()).ToArray();
            string compareOrder = string.Format("[{0}]", string.Join(",", expectedOrder));

            // Delete all nodes and test print 
            foreach (int i in values)
                _mock.Delete(i);
            string noNodeTravelPrint = _mock.InOrderTraversal();

            // Assert (TODO)
            Assert.AreEqual(result, compareOrder, "In Order Travel returns wrong value");
            Assert.AreEqual(noNodeTravelPrint, "[]", "In Order Travel without nodes returns wrong value" );
            Assert.IsFalse(string.IsNullOrEmpty(noNodeTravelPrint), "In Order Travel wihtout nodes retuns blank");
        }
    }
}