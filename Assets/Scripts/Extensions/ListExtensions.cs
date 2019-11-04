using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public static class ListExtensions
    {
        public static void AlignPointsByHeight(this List<Vector3> points, float height)
        {
            points.ForEach(point => point.y = height);
        }

        public static float GetLengthOfPath(this List<Vector3> points)
        {
            if (points.Count < 2)
            {
                return 0;
            }

            var currentPoint = points[0];
            var nextPoint = points[1];
            var sumLength = 0f;
            for (var i = 1; i < points.Count - 1; i++)
            {
                sumLength += Vector3.Distance(currentPoint, nextPoint);
                currentPoint = nextPoint;
                nextPoint = points[i + 1];
            }

            sumLength += Vector3.Distance(currentPoint, nextPoint);

            return sumLength;
        }
    }
}
