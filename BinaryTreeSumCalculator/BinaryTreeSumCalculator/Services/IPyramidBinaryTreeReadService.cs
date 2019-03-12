using PyramidBinaryTreeCalculator.Models;

namespace PyramidBinaryTreeCalculator.Services
{
    public interface IPyramidBinaryTreeReadService
    {
        PyramidBinaryTreeParameters ReadAndMapPyramidBinaryTree(string triangleTree);
    }
}
