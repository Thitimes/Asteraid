using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    public float minX, maxX, minY, maxY;
    public float playerScaleX, playerScaleY;
    // Start is called before the first frame update
    void Start()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x  < minX + playerScaleX / 2.0f) pos.x = minX + playerScaleX / 2.0f;
        if (pos.x  > maxX - playerScaleX / 2.0f) pos.x  = maxX - playerScaleX / 2.0f;

        // vertical contraint
        if (pos.y  < minY + playerScaleY / 2.0f) pos.y  = minY + playerScaleY / 2.0f;
        if (pos.y  > maxY - playerScaleY / 2.0f) pos.y  = maxY - playerScaleY / 2.0f;

        // Update position
        transform.position = pos;
    }
}
