using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalAttack : MonoBehaviour
{
    [SerializeField] Transform Attacker; 
    [SerializeField] MousePosition mouse;
    [SerializeField] GameObject attackProjectilePrefab;
    [SerializeField] float projectileSpeed=5;
    [SerializeField] float attackCD = 1f; 

    public void PerformNormalAttack(InputAction.CallbackContext context)
    {
        if (attackCD <= 0)
        {
            if (context.started)
            {
                //getting how much to rotate
                Vector3 mouseLocation= mouse.GetMouseLocation();
                float rotationz= PlayerDirection.CalculateRotationInDegreeFromTwoPoints(Attacker.transform.position, mouseLocation);

                //changing the difference from vector to direction
                Vector3 difference = mouseLocation - Attacker.transform.position;
                float distance = difference.magnitude;
                Vector2 direction = difference/distance;
                ShootProjectile(direction, rotationz);

                attackCD = 1f; 
            }
        }

    }

    void ShootProjectile(Vector2 direction, float rotationz)
    {
        GameObject attackTemp= Instantiate(attackProjectilePrefab);
        attackTemp.transform.position = Attacker.transform.position;
        attackTemp.transform.rotation = Quaternion.Euler(0f, 0f, rotationz);
        attackTemp.gameObject.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    private void Update()
    {
        attackCD -= Time.deltaTime;
    }
}
