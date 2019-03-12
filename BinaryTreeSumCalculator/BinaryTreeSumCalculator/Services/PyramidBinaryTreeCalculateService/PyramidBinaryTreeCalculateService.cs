using System.Collections.Generic;
using System.Linq;
using PyramidBinaryTreeCalculator.Models;

namespace PyramidBinaryTreeCalculator.Services.PyramidBinaryTreeCalculateService
{
    public class PyramidBinaryTreeCalculateService : IPyramidBinaryTreeCalculateService
    {
        public PyramidBinaryTreeSumResults CalculatePyramidBinaryTreeMaximumSumResults(PyramidBinaryTreeParameters pyramidBinaryTreeParameters)
        {
            var isInitialNodeEven = pyramidBinaryTreeParameters.InitialNode.Value % 2 == 0;
            var allProperPyramidBinaryTreeResults = new List<PyramidBinaryTreeSumResults>();
            var initialPathSum = 0;

            var initialNodeSumResults = new PyramidBinaryTreeSumResults()
            {
                Path = new List<int>(),
                PathSum = initialPathSum
            };

            CalculateSumAndPathFromTreeNode(allProperPyramidBinaryTreeResults, pyramidBinaryTreeParameters.InitialNode,
                initialNodeSumResults, !isInitialNodeEven, pyramidBinaryTreeParameters.Depth);

            var maximumSumResult = allProperPyramidBinaryTreeResults.Any() 
                ? allProperPyramidBinaryTreeResults.Aggregate((firstItem, nextItem) =>  nextItem.PathSum > firstItem.PathSum ? nextItem : firstItem)
                : null;

            return maximumSumResult;
        }

        private void CalculateSumAndPathFromTreeNode(List<PyramidBinaryTreeSumResults> allProperPyramidBinaryTreeResults, 
            PyramidBinaryTreeNode currentTreeNode, PyramidBinaryTreeSumResults previousNodeSumResults, bool isFollowingNodeEven, int pyramidBinaryTreeDepth)
        {
            var newPath = new List<int>(previousNodeSumResults.Path) {currentTreeNode.Value};
            var newPathSum = previousNodeSumResults.PathSum + currentTreeNode.Value;

            var currentNodeSumResults = new PyramidBinaryTreeSumResults()
            {
                Path = newPath,
                PathSum = newPathSum
            };

            if (currentTreeNode.LeftChildNode == null && currentTreeNode.RightChildNode == null && currentTreeNode.DepthLevel == pyramidBinaryTreeDepth)
            {
                allProperPyramidBinaryTreeResults.Add(currentNodeSumResults);
            }
            else
            {
                if (currentTreeNode.LeftChildNode != null && ((currentTreeNode.LeftChildNode.Value % 2 == 0) == isFollowingNodeEven))
                {
                    CalculateSumAndPathFromTreeNode(allProperPyramidBinaryTreeResults, currentTreeNode.LeftChildNode, currentNodeSumResults, !isFollowingNodeEven, pyramidBinaryTreeDepth);
                }
                if (currentTreeNode.RightChildNode != null && ((currentTreeNode.RightChildNode.Value % 2 == 0) == isFollowingNodeEven))
                {
                    CalculateSumAndPathFromTreeNode(allProperPyramidBinaryTreeResults, currentTreeNode.RightChildNode, currentNodeSumResults, !isFollowingNodeEven, pyramidBinaryTreeDepth);
                }
            }
        }
    }
}
