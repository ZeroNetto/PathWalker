using System;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class PathComponent
    {
        public bool IsLooped { get; set; }
        public List<Vector3> Path { get; set; }
        public float FinishTime { get; set; }
    }
}
