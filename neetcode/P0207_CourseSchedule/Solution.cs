namespace neetcode.P0207_CourseSchedule;

// https://leetcode.com/problems/course-schedule/
// https://youtu.be/EgI5nU9etnU
public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var edge in prerequisites)
        {
            graph[edge[0]].Add(edge[1]);
        }

        var visited = new HashSet<int>();

        bool dfs(int course)
        {
            if (visited.Contains(course))
            {
                return false;
            }

            if (graph[course].Count == 0)
            {
                return true;
            }

            visited.Add(course);

            foreach (var nextCourse in graph[course])
            {
                if (!dfs(nextCourse))
                {
                    return false;
                }
            }

            visited.Remove(course);
            graph[course].Clear();

            return true;
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (!dfs(i))
            {
                return false;
            }
        }

        return true;
    }
}