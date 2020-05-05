using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameController game1;
    private SpriteRenderer spriteRenderer;

    public int val = 0;

    public float speed;

    public Sprite[] tileImages;

    public int tileIndex;

    public bool isActive;
    public bool isFading;

    private float timer = 0;

    private void Start(){
        game1 = FindObjectOfType<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = tileImages[0];
        isActive = false;
    }

    private void Update(){
        if (!isFading)
        {
            switch (val)
            {
                case 0:
                    timer += speed * Time.deltaTime;
                    if (timer >= 1f) val++;
                    break;
                default:
                    if (isActive == false)
                        spriteRenderer.sprite = tileImages[0];
                    if (isActive == true)
                        spriteRenderer.sprite = tileImages[1];
                    break;
            }
        }
        else if(isFading)
        {
            //speed = 1f;
            switch (val)
            {
                case 0:  //fade in with normal image
                    spriteRenderer.sprite = tileImages[0];
                    timer += speed * Time.deltaTime;
                    if (timer >= 1f) val++;
                    break;
                case 1:  //fade out normal image
                    timer -= speed * Time.deltaTime;
                    if (timer <= 0f) val++;
                        break;
                case 2:  //fade in with new image
                    timer += speed * Time.deltaTime;
                    spriteRenderer.sprite = tileImages[1];
                    if (timer >= 1f) val++;
                    break;
                case 3:  //fade out new image
                    timer -= speed * Time.deltaTime;
                    if (timer <= 0f) val++;
                    break;
                case 4:
                    spriteRenderer.sprite = tileImages[0];
                    isFading = false;
                    val = 0;
                    break;
            }
        }
        spriteRenderer.color = new Color(1f, 1f, 1f, timer);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            if (!isActive)
                game1.selectedTiles.Add(gameObject);

            isActive = true;
        }
    }
}
