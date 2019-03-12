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
            var initialRouteSum = 0;

            var initialNodeSumResults = new PyramidBinaryTreeSumResults()
            {
                Route = new List<int>(),
                RouteSum = initialRouteSum
            };

            CalculateSumAndPathFromTreeNode(allProperPyramidBinaryTreeResults, pyramidBinaryTreeParameters.InitialNode,
                initialNodeSumResults, !isInitialNodeEven, pyramidBinaryTreeParameters.Depth);

            var maximumSumResult = allProperPyramidBinaryTreeResults.Any() 
                ? allProperPyramidBinaryTreeResults.Aggregate((firstItem, nextItem) =>  nextItem.RouteSum > firstItem.RouteSum ? nextItem : firstItem)
                : null;

            return maximumSumResult;
        }

        private void CalculateSumAndPathFromTreeNode(List<PyramidBinaryTreeSumResults> allProperPyramidBinaryTreeResults, 
            PyramidBinaryTreeNode currentTreeNode, PyramidBinaryTreeSumResults previousNodeSumResults, bool isFollowingNodeEven, int pyramidBinaryTreeDepth)
        {
            var newRoute = new List<int>(previousNodeSumResults.Route) {currentTreeNode.Value};
            var newRouteSum = previousNodeSumResults.RouteSum + currentTreeNode.Value;

            var currentNodeSumResults = new PyramidBinaryTreeSumResults()
            {
                RouteSum = newRouteSum,
                Route = newRoute
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
