using System;
using System.Collections.Generic;

namespace Jumper.Core
{
    public class Calculator
    {
        public bool HasPathToFirstElement(List<int> input)
        {
            if (input.Count == 1) return true;

            var jumpToTopPathHavingElementDistance = 1;
            for (int i = input.Count - 2; i >= 0; i--)
            {
                if (input[i] >= jumpToTopPathHavingElementDistance)
                {
                    jumpToTopPathHavingElementDistance = 1;
                }
                else
                {
                    jumpToTopPathHavingElementDistance++;
                }

                if (i == 0 && input[i] >= jumpToTopPathHavingElementDistance) 
                {
                    return true;
                }
            }

            return false;
        }

        public Dictionary<int,int> GetLongestPath(List<int> input) 
        {
            var path =  new Dictionary<int, int> { { input.Count-1, input[input.Count - 1] } } ;
            if (input.Count == 1) return path;

            var jumpToTopPathHavingElementDistance = 1;
            for (int i = input.Count - 2; i >= 0; i--)
            {
                if (input[i] >= jumpToTopPathHavingElementDistance)
                {
                    path.Add(i, jumpToTopPathHavingElementDistance);
                    jumpToTopPathHavingElementDistance = 1;
                }
                else
                {
                    jumpToTopPathHavingElementDistance++;
                }

                if (i == 0 && input[i] >= jumpToTopPathHavingElementDistance)
                {
                    return path;
                }
            }

            return null;
        }

        public List<int> GetShortestPath(List<int> data) {
            var longestPath = GetLongestPath(data);
            return longestPath == null ? null : GetShortestPath(data, longestPath);
        }

        public List<int> GetShortestPath(List<int> data, Dictionary<int, int> longestPath)
        {
            var currentElement = 0;
            var shortestPath = new List<int> { currentElement };
            while (currentElement != data.Count - 1) 
            {
                var longestPotentialJump = data[currentElement];
                while (!longestPath.ContainsKey(currentElement + longestPotentialJump))
                {
                    longestPotentialJump--;
                }
                shortestPath.Add(currentElement + longestPotentialJump);
                currentElement += longestPotentialJump;
            }

            return shortestPath;
        }
    }
}
