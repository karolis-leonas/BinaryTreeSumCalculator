using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PyramidBinaryTreeCalculator.Models;

namespace PyramidBinaryTreeCalculator.Services.PyramidBinaryTreeReadService
{
    public class PyramidBinaryTreeReadService: IPyramidBinaryTreeReadService
    {
        public PyramidBinaryTreeParameters ReadAndMapPyramidBinaryTree(string unparsedTree)
        {
            var pyramidBinaryTreeRows = new List<List<int>>();

            using (var reader = new StringReader(unparsedTree))
            {
                for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    var pyramidTreeRowValues = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                    pyramidBinaryTreeRows.Add(pyramidTreeRowValues);
                }
            }

            var initialRowIndex = 0;
            var initialColumnIndex = 0;
            var pyramidBinaryTreeParameters = new PyramidBinaryTreeParameters()
            {
                Depth = pyramidBinaryTreeRows.Count,
                InitialNode = CreateBinaryTreeNode(pyramidBinaryTreeRows, initialRowIndex, initialColumnIndex)
            };

            return pyramidBinaryTreeParameters;
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
