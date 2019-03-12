using PyramidBinaryTreeCalculator.Models;

namespace PyramidBinaryTreeCalculator.Services.PyramidBinaryTreeReadService
{
    public interface IPyramidBinaryTreeReadService
    {
        PyramidBinaryTreeParameters ReadAndMapPyramidBinaryTree(string triangleTree);
    }
}
