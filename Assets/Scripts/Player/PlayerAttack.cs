using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private AudioClip bulletSound;
    [SerializeField] private AudioClip gunReload;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private int bulletsShot = 0;
    private bool reloading;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.CanAttack() && !reloading)
        {
            Attack();
            bulletsShot++;

            // Pøepnutí na animaci pøebití po vystøílení 15 nábojù
            if (bulletsShot >= 15 && !reloading)
            {
                Reload();
                anim.SetTrigger("reload");
                reloading = true;
            }
        }

        // Pøebití kdykoliv pøi stisku klávesy "R"
        if (Input.GetKeyDown(KeyCode.R) && !reloading)
        {
            Reload();
            anim.SetTrigger("reload");
            reloading = true;
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(bulletSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        //pool bullets
        bullets[FindBullet()].transform.position = bulletPoint.position;
        bullets[FindBullet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    public void Reload()
    {
        SoundManager.instance.PlaySound(gunReload);
        bulletsShot = 0;
        reloading = false;
    }
}