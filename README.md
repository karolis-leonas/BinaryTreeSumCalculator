# PyramidBinaryTreeCalculator
The main point of this application is to parse pyramid binary tree and get its maximum path sum, according to some requirements.

## Main logic flow:
* Since this is a .NET Core application, initial services are configured.
* Unparsed binary tree is read, parsed and structured accordingly via tree nodes (and they have children nodes, which also have their children nodes and so on until no children nodes exist).
* The app reads initial node, checks if it is odd/even and goes through the children nodes recursively according to following logic:
  - If application is on an even number, then the next (child) number it goes to must be odd, or vice versa (from odd to even number).
  - If bottom of pyramid is reached (i.e. node has no children and it resides in the lowest row of pyramid) then a found path and its sum must be added to the list of all found proper paths.
  - Once all proper paths are found and calculated, program finds the path with maximum sum, and returns it to main method.
* The result of maximum sum of proper path and its path is printed in console window.
* In case there are no proper paths, console shows that no paths were found.

### Authors:
* Karolis Leonas, 2019
