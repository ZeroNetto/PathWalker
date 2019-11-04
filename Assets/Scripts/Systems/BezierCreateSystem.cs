using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class BezierCreateSystem
    {
        public static List<Vector3> GetBezierCurves(List<Vector3> path, int segmentCount = 50)
        {
            if (path.Count < 4)
            {
                return path;
            }

            var newPath = new List<Vector3>();
            var curveCount = path.Count / 3;
            for (var j = 0; j < curveCount; j++)
            {
                for (var i = 1; i <= segmentCount; i++)
                    AddBezierPoints(path, newPath, j * 3, segmentCount, i);
            }

            return newPath;
        }

        private static void AddBezierPoints(List<Vector3> path, List<Vector3> newPath, int nodeIndex, int segmentCount, int currentIteration)
        {
            var t = currentIteration / (float)segmentCount;
            var bezierPoint = CalculateBezierPoint(
                t,
                path[nodeIndex],
                path[nodeIndex + 1],
                path[nodeIndex + 2],
                path[nodeIndex + 3]);
            newPath.Add(bezierPoint);
        }

        private static Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            var u = 1 - t;
            var tt = t * t;
            var uu = u * u;
            var uuu = uu * u;
            var ttt = tt * t;

            var p = uuu * p0;
            p += 3 * uu * t * p1;
            p += 3 * u * tt * p2;
            p += ttt * p3;

            return p;
        }
    }
}
