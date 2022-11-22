using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalagaPlayer : BasePlayer
{
    [Header("Galaga")]
    public Rigidbody2D rigidBody;

    public Transform bulletSpawnParent, spawnPoint;
    public GalagaBullet bulletPrefab;

    public float shootCooldownTime = 0.5f;
    public bool isOnCooldown;

    public override void MoveDirection(Direction direction){
        switch (direction)
        {
            case Direction.Left:
                    rigidBody.MovePosition(rigidBody.position - (Vector2.right * GameManager.HorizontalSpeed(maxSpeed) * Time.deltaTime));
                break;
            case Direction.Right:
                    rigidBody.MovePosition(rigidBody.position + (Vector2.right * GameManager.HorizontalSpeed(maxSpeed) * Time.deltaTime));
                break;
            default:
                Debug.Log("Esto no se puede");
                break;
        }
    }

    public override void Shoot(){
        if(!isOnCooldown){
            StartCoroutine(ShootCoroutine());
        }
    }

    IEnumerator ShootCoroutine(){
        isOnCooldown = true;
        // Debug.Log("Shoot Misil");

        GalagaBullet currentBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        currentBullet.transform.SetParent(bulletSpawnParent);
        currentBullet.transform.localScale = Vector3.one;
        currentBullet.StartMovement(Vector2.up);

        yield return new WaitForSeconds(shootCooldownTime);
        // Debug.Log("Can shoot agains");
        isOnCooldown = false;
    }

    public override void ProcessCollision(){
        Debug.Log("Procesando Colisión Dese Pong");
    }
}