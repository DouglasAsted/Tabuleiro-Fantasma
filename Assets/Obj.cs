using UnityEngine;

public class Obj : MonoBehaviour
{
    public int team;
    public int objIndex;

    bool pressed;

	void Update ()
    {
		if(pressed == true)
        {
            gameObject.transform.localScale = new Vector2(7.5f, 7.5f);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
            if (Input.GetMouseButtonUp(0))
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
                gameObject.transform.localScale = new Vector2(5, 5);
                pressed = false;
            }
        }
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(pressed == false)
        {
            Debug.Log(collision.GetComponent<BoardObj>().boardIndex);
        }
    }
}