using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileHandler :MonoBehaviour
{
    Collider2D[] nearestHexes = new Collider2D[7];
    List<GameObject> coloredHexes = new List<GameObject>();
    TextMesh textMesh;
    SpriteRenderer sprite;
    Color basicColor;
    private void Start()
    {
        textMesh = transform.GetChild(0).GetComponent<TextMesh>();
        sprite = GetComponent<SpriteRenderer>();
        basicColor = sprite.color;
        textMesh.text = new Vector2(Mathf.CeilToInt( gameObject.transform.position.x), Mathf.CeilToInt(gameObject.transform.position.y)).ToString();
    }
    private void OnMouseEnter()
    {
        sprite.color = Color.red;
        SelectNearHex(new Vector2(transform.position.x, transform.position.y));
        
    }
    private void OnMouseExit()
    {
        ClearTiles();
        sprite.color = basicColor;
    }
    //private void OnMouseDown()
    //{
    //    Vector2 clickPosition = new Vector2(transform.position.x, transform.position.y);
    //    ClearTiles();
    //    SelectNearHex(clickPosition);
    //}

    void ClearTiles()
    {
        foreach (GameObject coloredHex in coloredHexes)
        {
            coloredHex.GetComponent<SpriteRenderer>().color = basicColor;
        }
        coloredHexes.Clear();
    }
    void SelectNearHex(Vector2 startPos)
    {
        Physics2D.OverlapCircleNonAlloc(startPos, 0.5f, nearestHexes);
        if (nearestHexes.Length > 1)
        {
            foreach (Collider2D collider in nearestHexes)
            {
                if (collider.gameObject == gameObject || collider.gameObject == null) continue;
                collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                coloredHexes.Add(collider.gameObject);
            }
        }

    }
}
