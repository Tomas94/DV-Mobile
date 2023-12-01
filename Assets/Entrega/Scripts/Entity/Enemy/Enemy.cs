using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : Entity, IPooleableObject<Enemy>
{
    public Action OnDesactivar;
    ObjectPool<Enemy> _enemyPool;

    [HideInInspector] public bool outOfScreen;

    public void Initialize(ObjectPool<Enemy> op)
    {
        _enemyPool = op;
    }

    public override void Disparar()
    {
        var x = OP_BulletManager.instance.bulletPools[1].pool.Get();
        x.Initialize(OP_BulletManager.instance.bulletPools[1].pool);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }

    public override void Die(int deathPoints)
    {
        ScoreManager.Instance._levelScore.IncrementScore(deathPoints);
        RefillStock(this);
    }

    public void RefillStock(Enemy enemy)
    {
        _enemyPool?.RefillStock(enemy);
        OnDesactivar?.Invoke();
    }
    

    public virtual void TurnOn(Enemy x)
    {
        x.gameObject.SetActive(true);
    }

    public virtual void TurnOff(Enemy x)
    {
        x.gameObject.SetActive(false);

    }

    protected void SetLife(float maxLife)
    {
        currentLife = maxLife;
    }

    protected void ResetMaxLife(Enemy enemy, float maxLife)
    {
        enemy.currentLife = maxLife;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetTrigger")) RefillStock(this);

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if(!player._isShielded) player.TakeDamage(Fw_Pointer.AllEnemiesID.impactDamage);
            RefillStock(this);
        }
    }
}
