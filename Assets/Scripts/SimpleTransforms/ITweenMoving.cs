using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITweenMoving : MonoBehaviour {

    public List<GameObject> points;
    float percentsPerSecond = 0.02f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1

    void Start()
    {

        iTween.Init(gameObject);
        iTween.PutOnPath(gameObject, points.ConvertAll(new System.Converter<GameObject, Vector3>(Convert)).ToArray(), 0f);

    }

    void Update()
    {
        currentPathPercent += percentsPerSecond * Time.deltaTime;
        iTween.PutOnPath(gameObject, points.ConvertAll(new System.Converter<GameObject, Vector3>(Convert)).ToArray(), currentPathPercent);
    }

    private void OnDrawGizmos()
    {
        iTween.DrawPath(points.ConvertAll(new System.Converter<GameObject, Vector3>(Convert)).ToArray());

    }

    public static Vector3 Convert(GameObject go)
    {
        return new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
    }
}
