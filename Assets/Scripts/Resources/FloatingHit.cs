using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHit : MonoBehaviour {
    public Animator myAnimator;

    private Text damageText;

    private void OnEnable() {
        AnimatorClipInfo[] clipInfo = myAnimator.GetCurrentAnimatorClipInfo(0);

        Destroy(gameObject, clipInfo[0].clip.length);

        damageText = myAnimator.GetComponent<Text>();
    }

    public void SetText(string text) {
        damageText.text = text;
    }
}
