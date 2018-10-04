using UnityEngine;

namespace Assets.Scripts
{
    public class MoveScript : MonoBehaviour
    {
        public float Speed = 10;
        public float RotateSpeed = 45;

        // Update is called once per frame
        void Update () {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.forward * -Speed * Time.deltaTime, Space.Self);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, -RotateSpeed * Time.deltaTime, Space.Self);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime, Space.Self);
            }
        }
    }
}
