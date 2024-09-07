//Using  Kahn’s Algorithm
static bool CanFinish(int numCourses, int[][] prerequisites)
{
    //Initializing Graph and Array
    List<int>[] graph = new List<int>[numCourses];
    int[] inDegree = new int[numCourses];

    //Initialize each course's adjacency list
    for (int i = 0; i < numCourses; i++)
    {
        graph[i] = new List<int>();
    }

    //Building the graph and calculating in-degrees
    foreach (var prerequisite in prerequisites)
    {
        int course = prerequisite[0];
        int prerequisiteCourse = prerequisite[1];
        graph[prerequisiteCourse].Add(course); // prerequisiteCourse -> course
        inDegree[course]++; // Increase in-degree of the course
    }

    // Initialize a queue and all courses with in-degree of zero
    Queue<int> queue = new Queue<int>();
    for (int i = 0; i < numCourses; i++)
    {
        if (inDegree[i] == 0)
        {
            queue.Enqueue(i); 
        }
    }

    //Doing BFS/Kahn's Alghoritm
    int coursesTaken = 0;
    while (queue.Count > 0)
    {
        int course = queue.Dequeue();
        coursesTaken++;

        // Process each neighboring course
        foreach (var nextCourse in graph[course])
        {
            inDegree[nextCourse]--; // Reduce the in-degree of the neighboring course

            // If the in-degree becomes zero, add it to the queue
            if (inDegree[nextCourse] == 0)
                queue.Enqueue(nextCourse);
        }
    }
    //Check if we processed all courses
    return coursesTaken == numCourses;
}