using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class PathVisualization : MonoBehaviour
    {
        private const float markHeight = 0.01f;

        public void VisualizePath(List<Vector3> path, PrefabsHolder prefabsHolder)
        {
            foreach (var point in path)
            {
                var markPlace = point;
                markPlace.y = markHeight;
                Instantiate(prefabsHolder.MarkPrefab, markPlace, Quaternion.Euler(90, 0, 0));
            }
        }
    }
}
