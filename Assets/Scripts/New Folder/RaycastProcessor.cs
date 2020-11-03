using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class RaycastProcessor
{

    const string layerThatReactsOnMouseClick = "Clickable";


    private RaycastHit2D[] GetRaycastHits()
    {
        int layer = 1 << LayerMask.NameToLayer(layerThatReactsOnMouseClick);

        var mousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var origin = new Vector2(mousePosition3D.x, mousePosition3D.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, Vector2.zero, 1000f, layer);
        return hits;

    }

    private RaycastHit2D[] GetRaycastHits(Vector3 point)
    {
        int layer = 1 << LayerMask.NameToLayer(layerThatReactsOnMouseClick);

        var origin= new Vector2(point.x, point.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, Vector2.zero, 1000f, layer);
        return hits;

    }

    private RaycastHit2D[] GetRaycastHitsInRadius(Vector3 origin, int radius)
    {
        RaycastHit2D[] hits = GetRaycastHits();

        List<Vector2> angls = new List<Vector2>();

        for (double i = 0; i < 3.14; i += 0.1)
        {
            angls.Add(new Vector2((float)Math.Cos(i), (float)Math.Sin(i)));
        }

        foreach (var angl in angls)
        {
            
                int layer = 1 << LayerMask.NameToLayer(layerThatReactsOnMouseClick);

                var origin2D = new Vector2(origin.x, origin.y);

                Vector2 target = new Vector2((radius * angl.x) + origin.x, (radius * angl.y) + origin.y);
           
                hits = hits.Concat(Physics2D.RaycastAll(origin2D, target, radius, layer, -100f, 100f)).ToArray();
           
            
        }

        return hits;
    }

    public GameObject[] GetObjects()
    {
        RaycastHit2D[] hits = GetRaycastHits();

        GameObject[] objects = hits.Select(s => s.collider.gameObject).ToArray();

        return objects;
    }

    public GameObject[] GetObjects(Vector3 point)
    {
        RaycastHit2D[] hits = GetRaycastHits(point);

        GameObject[] objects = hits.Select(s => s.collider.gameObject).ToArray();

        return objects;
    }

    public GameObject[] GetObjectsInRadius(Vector3 origin, int radius)
    {
        var hits = GetRaycastHitsInRadius(origin, radius);

        GameObject[] objects = hits.Select(s => s.collider.gameObject).Distinct().ToArray();
       
        return objects;
    }


}
