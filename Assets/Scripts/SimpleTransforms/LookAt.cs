using UnityEngine;

namespace Assets.Scripts
{
    public class LookAt : MonoBehaviour
    {
    
        public GameObject LookAtObject;

        void Update ()
        {
            transform.LookAt(LookAtObject.transform);
            
        }
    }
}
