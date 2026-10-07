// https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1
// 4 kyu

internal static class Snail
{
    private enum Direction
    {
        RIGHT,
        DOWN,
        LEFT,
        UP,
    }

    public static int[] Solve(int[][] array)
    {
        // PSEUDO PSUEDO CODE
        // move like a snail:
        // maintain an bool[][] visited
        // move through matrix using x and y coordinates keeping an eye on visited
        // PSUEDO CODE
        // x=y=0
        // int[] result
        // direction = DIRECTION.RIGHT
        // while(!endReached)
        //  if (allSuroundingBlocksAreVisited) endReached = true;
        //  if (direction == RIGHT)
        //   if visited[x+1][y] direction = DOWN; continue;
        //   result.add visited[x+1][y]; x++;
        if (array.Length == 1 && array[0].Length == 0)
        {
            return Array.Empty<int>();
        }

        int[] result = new int[array.Length * array.Length];
        int resultIndex = 0;
        int x = 0, y = 0;
        Direction direction = Direction.RIGHT;
        bool reachedTheMiddle = false;
        bool[][] visited = new bool[array.Length][];
        for (int i = 0; i < visited.Length; i++)
        {
            visited[i] = new bool[array.Length];
        }

        while (!reachedTheMiddle)
        {
            result[resultIndex++] = array[y][x];
            visited[y][x] = true;

            if (AllSurroundingBlocksWereVisited(x, y, array.Length, visited))
            {
                reachedTheMiddle = true;
                continue;
            }

            switch (direction)
            {
                case Direction.RIGHT:
                    if (x == array.Length - 1 || visited[y][x + 1])
                    {
                        direction = Direction.DOWN;
                        y++;
                    }
                    else
                    {
                        x++;
                    }

                    break;
                case Direction.DOWN:
                    if (y == array.Length - 1 || visited[y + 1][x])
                    {
                        direction = Direction.LEFT;
                        x--;
                    }
                    else
                    {
                        y++;
                    }

                    break;
                case Direction.LEFT:
                    if (x == 0 || visited[y][x - 1])
                    {
                        direction = Direction.UP;
                        y--;
                    }
                    else
                    {
                        x--;
                    }

                    break;
                case Direction.UP:
                    if (y == 0 || visited[y - 1][x])
                    {
                        direction = Direction.RIGHT;
                        x++;
                    }
                    else
                    {
                        y--;
                    }

                    break;
            }
        }

        return result;

        static bool AllSurroundingBlocksWereVisited(int x, int y, int arrayLength, bool[][] visited)
         =>
         (x == arrayLength - 1 || visited[y][x + 1]) &&
         (y == arrayLength - 1 || visited[y + 1][x]) &&
         (x == 0 || visited[y][x - 1]) &&
         (y == 0 || visited[y - 1][x]);
    }
}
