using System;
using UnityEngine;
using System.Collections;

public enum WeaponDirection
{
    FORWARD,
    CONE,
    CIRCLE
}

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;
    private Transform _shotSpawn;
    public float FireRate;
    public WeaponDirection DirectionType;

    public float Angle;
    public int NbShots;

    public bool HasMunitions = false;
    public int MaxMunitions;
    public int CurrentMunitions { get; private set; }
    public float ReloadTime;



    void Start()
    {
        _shotSpawn = transform.Find("ShotSpawn");
    }

    public void Reload()
    {
        CurrentMunitions = MaxMunitions;
    }

    public void Fire()
    {
        GameObject currentBullet;
        MoveController bulletMove;
        switch (DirectionType)
        {
            case (WeaponDirection.FORWARD):

                currentBullet = Instantiate(Bullet, _shotSpawn.position, Quaternion.identity) as GameObject;
                bulletMove = currentBullet.GetComponent<MoveController>();
                bulletMove.Direction = transform.right;
                break;

            case (WeaponDirection.CIRCLE):

                for (int i = 0; i < NbShots; i++)
                {
                    float value = (float)i / (float)NbShots;
                    float teta = (Mathf.PI * 2) * value + _shotSpawn.localRotation.z;
                    double phi = -Math.PI / 2;

                    float pX = _shotSpawn.position.x + (float)(Math.Sin(phi) * Math.Cos(teta));
                    float pY = _shotSpawn.position.y + (float)(Math.Sin(phi) * Math.Sin((teta)));

                    Vector2 firePoint = new Vector2(pX, pY);

                    Vector2 fireDirection = new Vector2(firePoint.x - _shotSpawn.position.x, firePoint.y - _shotSpawn.position.y);
                    fireDirection.Normalize();

                    currentBullet = Instantiate(Bullet, _shotSpawn.position, Quaternion.identity) as GameObject;
                    bulletMove = currentBullet.GetComponent<MoveController>();
                    bulletMove.Direction = fireDirection;
                }

                break;
        }
    }

}
