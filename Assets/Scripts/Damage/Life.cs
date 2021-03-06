﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    public int life;
    public int currentLife;
    public int secondsInvunerableEffect;

    private LifeBar lifeBar;

    public void AddLife(int lifePoints) {
        life += lifePoints;

        lifeBar.SetTotalLife(life);

        lifeBar.Actualize(currentLife);
    }

    public void Heal(int lifePoints) {
        currentLife += lifePoints;

        if (currentLife > life) currentLife = life;

        lifeBar.Actualize(currentLife);
    }

    protected virtual void Start() {
        GameObject lifeBarPrefab = Resources.Load<GameObject>("Prefabs/LifeBar");

        GameObject lifeBarInst = Instantiate(lifeBarPrefab, transform.position, Quaternion.identity);

        lifeBarInst.transform.parent = transform;

        lifeBar = lifeBarInst.GetComponent<LifeBar>();

        lifeBar.SetTotalLife(currentLife);
    }

    public virtual void Damage(int damage, Collider2D collision) {
        StartCoroutine(DamageEffect());

        currentLife -= damage;

        lifeBar.Actualize(currentLife);

        FloatingHitController.CreateFloatingHit(damage.ToString(), transform);

        if (currentLife <= 0) {
            LootScript loot = gameObject.GetComponent<LootScript>();

            if (loot != null) loot.InstantiateLoot();

            Destroy(gameObject);
        }
    }

    private IEnumerator DamageEffect() {
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();

        for (int i = 0; i < secondsInvunerableEffect * 5; i++) {
            mySprite.color = Color.red;
            yield return new WaitForSeconds(.1f);
            mySprite.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }
}
