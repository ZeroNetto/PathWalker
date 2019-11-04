using System;
using UnityEngine;

namespace Systems
{
    public class CameraControlSystem
    {
        private const float moveSpeed = 5f;
        private const float rotationSpeed = 5f;
        private const float scrollSpeed = 150f;
        private const float tolerance = 0.01f;

        public void HandleUserInput()
        {
            var camera = Camera.main;

            if (Input.GetKey("q"))
            {
                camera.transform.eulerAngles +=
                    new Vector3(0, -camera.transform.position.y * rotationSpeed, 0) * Time.deltaTime;
            }

            if (Input.GetKey("e"))
            {
                camera.transform.eulerAngles +=
                    new Vector3(0, camera.transform.position.y * rotationSpeed, 0) * Time.deltaTime;
            }

            camera.transform.position += camera.transform.right *
                                         (Time.deltaTime * moveSpeed * Math.Sign(Input.GetAxis("Horizontal")));
            camera.transform.position += new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z) *
                                         (Time.deltaTime * moveSpeed * Math.Sign(Input.GetAxis("Vertical")));

            if (Math.Abs(Input.GetAxis("Mouse ScrollWheel")) > tolerance)
            {
                camera.transform.position +=
                    scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0) *
                                      Time.deltaTime;
            }
        }
    }
}