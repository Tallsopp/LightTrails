using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Follow_Mouse : MonoBehaviour
{
    private GameController game1;

    public float speed = 8.0f;
    public float distanceFromCamera = 5.0f;

    private BoxCollider2D boxCollider;

    private Tile[] tileScript;
    public List<GameObject> tiles;

    private Transform firstChild;

    private void Start()
    {
        game1 = FindObjectOfType<GameController>();

        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;

        firstChild = transform.GetChild(0);
        firstChild.gameObject.SetActive(false);

        tileScript = FindObjectsOfType<Tile>();
        for (int i = 0; i < tileScript.Length; i++)
            tiles.Add(tileScript[i].gameObject);
    }

    void Update()
    {
        if (game1 != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = distanceFromCamera;
            Vector3 mouseScreenToWorld = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 position = Vector2.Lerp(transform.position, mouseScreenToWorld, 1.0f - Mathf.Exp(-speed * Time.deltaTime));
            transform.position = position;

            if (Input.GetMouseButtonDown(0))
            {
                boxCollider.enabled = true;
                firstChild.gameObject.SetActive(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                boxCollider.enabled = false;
                firstChild.gameObject.SetActive(false);

                if (game1.selectedTiles.Count > 0)
                {
                    game1.attempts++;
                    DeactivateAll();
                }
            }
        }
    }

    void DeactivateAll()
    {
        for (int i = 0; i < tileScript.Length; i++)
            tileScript[i].isActive = false;

        game1.CheckAllTiles();
        game1.selectedTiles.Clear();
    }
}
