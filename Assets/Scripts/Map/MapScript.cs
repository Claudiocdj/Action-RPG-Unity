using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapScript : MonoBehaviour {

    [HideInInspector]
    public Vector2 bottomLeftPos;

    [HideInInspector]
    public Vector2 topRightPos;

    private Tilemap myTilemap;

    private void Start() {
        
        myTilemap =  this.transform.Find("Background L1").GetComponent<Tilemap>();

        myTilemap.ResizeBounds();

        bottomLeftPos = myTilemap.localBounds.min;

        topRightPos = myTilemap.localBounds.max;
    }
}
