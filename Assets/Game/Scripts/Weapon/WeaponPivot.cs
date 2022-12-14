using UnityEngine;

public class WeaponPivot : MonoBehaviour
{    
    public Vector2 PointerPosition{get; set;}
    
    public SpriteRenderer characterRenderer, waeponRenderer;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        PointerPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = (PointerPosition-(Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if(direction.x < 0)
        {
            scale.y = -1;
        }else if(direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            waeponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }else
        {
            waeponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }
}
