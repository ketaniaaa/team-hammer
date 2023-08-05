using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColorWhenHit : MonoBehaviour
{
    public void OnHit()
    {
        StartCoroutine(FlashWhenHit());
    }

    IEnumerator FlashWhenHit()
    {
        SpriteRenderer sprite= gameObject.GetComponent<SpriteRenderer>();
        Color originalColor= sprite.material.color;
        sprite.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        sprite.material.color = originalColor;
    }
}
