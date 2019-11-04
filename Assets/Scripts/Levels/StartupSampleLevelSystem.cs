using Entities;
using UnityEngine;

namespace Systems
{
    public class StartupSampleLevelSystem : MonoBehaviour
    {
        private PrefabsHolder prefabsHolder;
        private const string fileUri = "https://yadi.sk/d/8t7ISX-EctmHIg";
        private Vector3 startPosition = new Vector3(-21.55f, minHeight, 0.69f);
        private MovementSystem movementSystem;
        private WalkerEntity walker;
        private readonly CameraControlSystem cameraControl = new CameraControlSystem();
        private const float minHeight = 0.5f;

        public void Start()
        {
            prefabsHolder = GameObject.Find("PrefabsHolder").GetComponent<PrefabsHolder>();
            //YandexDiskHelper.SaveFile(fileUri, "path1.txt");
            var pathComponent = FileDeserializer.DeserializeFile("path1.txt");
            pathComponent.Path = BezierCreateSystem.GetBezierCurves(pathComponent.Path);
            walker = new WalkerEntity(pathComponent);
            var walkerObj = Instantiate(prefabsHolder.WalkerPrefab, startPosition, Quaternion.identity);

            walker.Object = walkerObj;
            movementSystem = new MovementSystem();

            walker.Component.PathComponent.Path.AlignPointsByHeight(minHeight);
            walker.SetMovementParameters();

            var visualization = new PathVisualization();
            visualization.VisualizePath(pathComponent.Path, prefabsHolder);
        }

        public void Update()
        {
            movementSystem.MoveToNextPoint(walker);
            cameraControl.HandleUserInput();
        }
    }
}