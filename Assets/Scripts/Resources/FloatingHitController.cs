using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FloatingHitController : MonoBehaviour {
    private static FloatingHit popupHit;
    private static GameObject canvas;
    
    public static void Initialize() {
        canvas = GameObject.Find("Canvas");

        popupHit = Resources.Load<FloatingHit>("Prefabs/HitAnim");
    }

    public static void CreateFloatingHit(string text, Transform location) {
        Initialize();

        FloatingHit instance = Instantiate(popupHit);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);

        instance.transform.SetParent(canvas.transform,false);

        screenPosition = new Vector2(screenPosition.x, screenPosition.y);

        instance.transform.position = screenPosition;

        instance.SetText(text);
    }
}