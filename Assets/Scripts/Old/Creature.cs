using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour {

    public int life;
    public float speed;
    public bool isInvunerable;
    public int secondsInvunerableEffect;

    private LifeBar lifeBar;
    
    protected virtual void Start() {
        GameObject lifeBarPrefab = Resources.Load<GameObject>("Prefabs/LifeBar");

        GameObject lifeBarInst = Instantiate(lifeBarPrefab, transform.position,Quaternion.identity);

        lifeBarInst.transform.parent = transform;

        lifeBar = lifeBarInst.GetComponent<LifeBar>();

        lifeBar.SetTotalLife(life);
    }

    public virtual void Damage(int damage) {
        StartCoroutine(DamageEffect());
        
        life -= damage;

        lifeBar.Actualize(life);

        FloatingHitController.CreateFloatingHit(damage.ToString(), transform);

        if (life <= 0) Destroy(gameObject);
    }

    private IEnumerator DamageEffect() {
        isInvunerable = true;

        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();

        for (int i = 0; i < secondsInvunerableEffect * 5; i++) {
            mySprite.color = Color.red;
            yield return new WaitForSeconds(.1f);
            mySprite.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }

        isInvunerable = false;
    }

    public abstract void Move(Vector3 moveInput);
}
