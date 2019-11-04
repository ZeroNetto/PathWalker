using Entities;
using UnityEngine;

namespace Systems
{
    public class StartupSampleLevel2System : MonoBehaviour
    {
        private PrefabsHolder prefabsHolder;
        private const string fileUri = "https://yadi.sk/d/wnJin3c6CrQF-g";
        private Vector3 startPosition = new Vector3(-21.55f, minHeight, 0.69f);
        private MovementSystem movementSystem;
        private WalkerEntity walker;
        private readonly CameraControlSystem cameraControl = new CameraControlSystem();
        private const float minHeight = 0.5f;

        public void Start()
        {
            prefabsHolder = GameObject.Find("PrefabsHolder").GetComponent<PrefabsHolder>();
            //YandexDiskHelper.SaveFile(fileUri, "path2.txt");
            var pathComponent = FileDeserializer.DeserializeFile("path2.txt");
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