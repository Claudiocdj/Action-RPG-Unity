using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTransiterScript : MonoBehaviour {
 
    public MapScript nextMap;

    public Vector3 newPlayerPos;

    private CameraScript cam;
    private BoxCollider2D myBoxCollider;

    void Start() {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<CameraScript>();

        myBoxCollider = GetComponent<BoxCollider2D>();

        if (newPlayerPos.x != 0)
            myBoxCollider.size = new Vector2(0.5f, myBoxCollider.size.y);

        if (newPlayerPos.y != 0)
            myBoxCollider.size = new Vector2(myBoxCollider.size.x, 0.5f);

        if (newPlayerPos.x < 0)
            myBoxCollider.offset = new Vector2(-0.5f * myBoxCollider.size.x, 0);

        if (newPlayerPos.x > 0)
            myBoxCollider.offset = new Vector2(0.5f * myBoxCollider.size.x, 0);

        if (newPlayerPos.y > 0)
            myBoxCollider.offset = new Vector2(0, 0.5f * myBoxCollider.size.y);
        
        if (newPlayerPos.y < 0)
            myBoxCollider.offset = new Vector2(0, -0.5f * myBoxCollider.size.y);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {

            InstantiateObjsOnNewMap();

            RemoveObjectsOnCurrentMap();

            cam.minPos = nextMap.bottomLeftPos;

            cam.maxPos = nextMap.topRightPos;

            collider.transform.position += newPlayerPos;
        }
    }

    private void InstantiateObjsOnNewMap() {
        ObjectsMap[] ObjectsToInstantiate = nextMap.GetComponents<ObjectsMap>();

        if (ObjectsToInstantiate.Length > 0)
            foreach (var obj in ObjectsToInstantiate)
                obj.InstantiateEnemies();
    }

    private void RemoveObjectsOnCurrentMap() {
        ObjectsMap[] ObjectsToDestroy = transform.parent.gameObject.GetComponents<ObjectsMap>();

        if (ObjectsToDestroy.Length > 0)
            foreach (var obj in ObjectsToDestroy)
                obj.DestroyObjectsOnMap();
    }
}
