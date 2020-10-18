using System;
using UnityEngine;

namespace SVS
{
    public class PlayerInput : MonoBehaviour, IInput
    {
        public Action<Vector2> OnMovementInput { get; set; }
        public Action<Vector3> OnMovementDirectionInput { get; set; }
        // Start is called before the first frame update
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        private void Update()
        {
            GetMovementInput();
            GetMovementDirection();
        }

        private void GetMovementDirection()
        {
            var cameraForewardDirection = Camera.main.transform.forward;
            Debug.DrawRay(Camera.main.transform.position, cameraForewardDirection * 10, Color.red);
            var directionToMoveIn = Vector3.Scale(cameraForewardDirection, (Vector3.right + Vector3.forward));
            Debug.DrawRay(Camera.main.transform.position, cameraForewardDirection * 10, Color.red);
            OnMovementDirectionInput?.Invoke(directionToMoveIn);
        }

        private void GetMovementInput()
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            OnMovementInput?.Invoke(input);
        }
    }
}