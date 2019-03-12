using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PyramidBinaryTreeCalculator.Models;

namespace PyramidBinaryTreeCalculator.Services
{
    public class PyramidBinaryTreeReadService: IPyramidBinaryTreeReadService
    {
        public PyramidBinaryTreeParameters ReadAndMapPyramidBinaryTree(string unparsedTree)
        {
            var treeRows = new List<List<int>>();

            using (var stringReader = new StringReader(unparsedTree))
            {
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    var treeRowValues = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                    treeRows.Add(treeRowValues);
                }
            }

            var pyramidBinaryTree = new PyramidBinaryTreeParameters()
            {
                InitialNode = CreateBinaryTreeNode(treeRows, 0, 0)
            };

            return pyramidBinaryTree;
        }

        private PyramidBinaryTreeNode CreateBinaryTreeNode(List<List<int>> treeRows, int rowIndex, int columnIndex)
        {
            PyramidBinaryTreeNode treeNode = null;
            if (treeRows.Count > rowIndex && treeRows[rowIndex].Count > columnIndex)
            {
                treeNode = new PyramidBinaryTreeNode()
                {
                    Value = treeRows[rowIndex][columnIndex],
                    DepthLevel = rowIndex + 1,
                    LeftChildNode = CreateBinaryTreeNode(treeRows, rowIndex + 1, columnIndex),
                    RightChildNode = CreateBinaryTreeNode(treeRows, rowIndex + 1, columnIndex + 1),
                };
            }

            return treeNode;
        }
    }
}
