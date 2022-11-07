namespace neetcode.P0207_CourseSchedule;

// https://leetcode.com/problems/course-schedule/
// https://youtu.be/EgI5nU9etnU
public class Solution
{
    private bool IsCyclic(List<int>[] graph, int course, bool[] visited)
    {
        if (visited[course])
        {
            return true;
        }

        visited[course] = true;

        foreach (var nextCourse in graph[course])
        {
            if (IsCyclic(graph, nextCourse, visited))
            {
                return true;
            }
        }

        visited[course] = false;

        return false;
    }

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

        var visited = new bool[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            if (visited[i] == false)
            {
                if (IsCyclic(graph, i, visited))
                {
                    return false;
                }
            }
        }

        return true;
    }
}