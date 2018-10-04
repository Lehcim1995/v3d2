using UnityEngine;

namespace Assets.Scripts
{
    public class CreateRobot : MonoBehaviour
    {
        void Start()
        {
            GameObject robot;
            CreateRobotObject(out robot);

            // find camera and make him look at the object
            GameObject cam = Camera.main.gameObject;
            cam.GetComponent<LookAt>().LookAtObject = robot;

        }

        GameObject CreateCubeObject(string objectName, float depth = 10, float width = 10, float height = 10,
            Color color = new Color(), Vector3 center = new Vector3())
        {
            GameObject gameObject = new GameObject(objectName);
            gameObject.AddComponent<MeshFilter>();
            gameObject.AddComponent<MeshRenderer>();
            CreateCube cube = gameObject.AddComponent<CreateCube>();

            cube.CubeColor = color;
            cube.Depth = depth;
            cube.Height = height;
            cube.Width = width;
            cube.Center = center;

            return gameObject;
        }

        GameObject CreateCylinderObject(string objectName, int smoothness = 16, float width = 10, float height = 10,
            Color color = new Color(), Vector3 center = new Vector3())
        {
            GameObject gameObject = new GameObject(objectName);
            gameObject.AddComponent<MeshFilter>();
            gameObject.AddComponent<MeshRenderer>();
            CreateCylinder cylinder = gameObject.AddComponent<CreateCylinder>();

            cylinder.Smoothness = smoothness;
            cylinder.CylinderColor = color;
            cylinder.CylinderHeight = height;
            cylinder.CylinderWidth = width;
            cylinder.Center = center;

            return gameObject;
        }

        void AddSwinging(GameObject theObject, float speed, float angle, float start, Vector3 direction)
        {
            Swinging swinging = theObject.AddComponent<Swinging>();

            swinging.Speed = speed;
            swinging.SwingAngle = angle;
            swinging.StartTime = start;
            swinging.SwingDirection = direction;
        }


        void CreateRobotObject(out GameObject theRobot)
        {
            GameObject robot = new GameObject("Robot");
            MoveScript move = robot.AddComponent<MoveScript>();
            move.Speed = 35f;

            CreateHeadObject(robot.transform);
            CreateBodyObject(robot.transform);
            CreateArmsObject(robot.transform);
            CreateLegsObject(robot.transform);

            theRobot = robot;
        }

        void CreateHeadObject(Transform parent)
        {
            GameObject head = CreateCubeObject("Head", depth: 3f, height: 3f, width: 3f, center: new Vector3(1.5f, 0, 1.5f),
                color: new Color(0.5f, 0.2f, 1f));
            head.transform.position = new Vector3(0, 20, 0);

            AddSwinging(head, 3, 10, 0, Vector3.up);

            head.transform.SetParent(parent.transform);
        }

        void CreateBodyObject(Transform parent)
        {
            GameObject body = CreateCubeObject("Body", depth: 4f, width: 8f, center: new Vector3(4, 5, 2));
            body.transform.position = new Vector3(0, 15, 0);

            body.transform.SetParent(parent.transform);
        }

        void CreateArmsObject(Transform parent)
        {
            GameObject leftArm = CreateCylinderObject("LeftArm", 16, 2, 10, Color.blue, new Vector3(0, 5f, 0));
            leftArm.transform.position = new Vector3(-6, 20, 0);
            AddSwinging(leftArm, 2, 45, 100, Vector3.right);

            GameObject rightArm = CreateCylinderObject("RightArm", 16, 2, 10, Color.red, new Vector3(0, 5f, 0));
            rightArm.transform.position = new Vector3(6, 20, 0);
            AddSwinging(rightArm, 2, 45, 0, Vector3.right);

            leftArm.transform.SetParent(parent);
            rightArm.transform.SetParent(parent);
        }

        void CreateLegsObject(Transform parent)
        {
            GameObject leftLeg = CreateCylinderObject("LeftLeg", 16, 2, 10, Color.blue, new Vector3(0, 5f, 0));
            leftLeg.transform.position = new Vector3(-2, 10, 0);
            AddSwinging(leftLeg, 2, 45, 0, Vector3.right);

            GameObject rightLeg = CreateCylinderObject("RightLeg", 16, 2, 10, Color.red, new Vector3(0, 5f, 0));
            rightLeg.transform.position = new Vector3(2, 10, 0);
            AddSwinging(rightLeg, 2, 45, 100, Vector3.right);

            leftLeg.transform.SetParent(parent);
            rightLeg.transform.SetParent(parent);
        }
    }
}