using UnityEngine;

namespace Assets.Scripts
{
    public class Swinging : MonoBehaviour
    {
        // Times per second?
        public float Speed = 15;

        public float SwingAngle = 90;

        public Vector3 SwingDirection = Vector3.right;

        public float StartTime = 0;

        private float timer = 0;

        private bool _forward = true;

        void Start()
        {
            timer = StartTime / 100;
        }

        void Update()
        {

            if (timer >= 1)
            {
                _forward = false;
            }

            if (timer <= 0)
            {
                _forward = true;
            }

            if (_forward)
            {
                timer += Time.deltaTime * Speed;
            }
            else
            {
                timer -= Time.deltaTime * Speed;
            }

            transform.localRotation = Quaternion.LerpUnclamped(Quaternion.AngleAxis(SwingAngle, SwingDirection),
                Quaternion.AngleAxis(-SwingAngle, SwingDirection), timer);
        }
    }
}