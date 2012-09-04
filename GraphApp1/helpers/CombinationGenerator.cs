using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src.helpers
{
    public class CombinationGenerator
    {
        private int n;
        private int[] currentState;
        private int currentLevel;
        private int cutoff;
        private Stack<CombinationData> arrayStack;
        private bool hasMore;
        private bool restrictLevel = false;
        private int restrictedLevel = 0;
        private bool firstRun = true; //Terrible yet quick solution to a problem

        public CombinationGenerator(int size, int seed)
        {
            if (seed > size)
            {
                Output.WriteLine("Seed was greater than vertex count, setting seed to vertex count");
                seed = size;
            }

            this.n = size;
            currentState = new int[size];
            currentLevel = seed;
            cutoff = 0;
            fillArrayWithLevel(currentLevel);
            arrayStack = new Stack<CombinationData>();
            hasMore = true;
        }

        public void Reset()
        {
            currentState = new int[n];
            currentLevel = 0;
            cutoff = 0;
            fillArrayWithLevel(currentLevel);
            arrayStack = new Stack<CombinationData>();
            hasMore = true;
            restrictedLevel = 0;
            restrictLevel = false;
        }

        public int[] GetNext()
        {
            if (firstRun)
            {
                firstRun = false;
                return currentState;
            }
            if (currentLevel == n)
            {
                currentLevel++;
                return currentState;
            }
            int next = cutoff;
            while (next < n-1 && currentState[next] != 1)
            {
                next++;
            }

            //If we've run out of combinations
            if (currentState[next] == 0)
            {
                bool foundValidStackItem = false;
                //Check the stack
                if (arrayStack.Count <= 0)
                {
                    currentLevel++;
                    fillArrayWithLevel(currentLevel);
                    cutoff = 0;
                    return currentState;
                }
                else
                {
                    while (arrayStack.Count > 0 && !foundValidStackItem)
                    {
                        CombinationData cd = arrayStack.Pop();
                        if (cd.array[cd.cutoff] == 0)
                        {
                            foundValidStackItem = true;
                            cutoff = cd.cutoff;
                            currentState = cd.array;
                        }
                    }

                    if (!foundValidStackItem)
                    {
                        currentLevel++;
                        if (currentLevel == n)
                        {
                            hasMore = false;
                        }
                        fillArrayWithLevel(currentLevel);
                        cutoff = 0;
                        return currentState;
                    }
                    else
                    {
                        return GetNext();
                    }
                }
            }
            else //We're on a 1
            {
                int[] array = new int[n];
                currentState[next] = 0;
                currentState[next - 1] = 1;

                Array.Copy(currentState, array, n);
                CombinationData cd = new CombinationData();
                cd.array = array;
                cd.cutoff = cutoff;
                arrayStack.Push(cd);

                cutoff = next;

                return currentState;
            }
        }

        public void RestrictToCurrentLevel()
        {
            restrictedLevel = currentLevel;
            restrictLevel = true;
        }

        public bool HasNext()
        {
            return hasMore && ((restrictLevel && currentLevel<= restrictedLevel) || (!restrictLevel));
        }

        private void fillArrayWithLevel(int l)
        {
            for (int i = 0; i < n - l; i++)
            {
                currentState[i] = 0;
            }
            for (int i = n - l; i < n; i++)
            {
                currentState[i] = 1;
            }
        }

        public int CurrentLevel()
        {
            return currentLevel;
        }
    }
}
