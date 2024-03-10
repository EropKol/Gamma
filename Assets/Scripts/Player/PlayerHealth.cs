using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100;
    public RectTransform ValueRectTransform;

    public GameObject GameplayUI;
    public GameObject GameOverScreen;

    public Animator PlayerAnim;

    private float _maxHealth;

    private void Start()
    {
        _maxHealth = Health;
    }

    public void DealDamage(float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Dead();
        }

        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(Health / _maxHealth, 1);
    }

    void Dead()
    {
        PlayerAnim.SetBool("IsDead", true);

        GameplayUI.SetActive(false);
        GameOverScreen.SetActive(true);
        GameOverScreen.GetComponent<Animator>().SetTrigger("OnStart");

        GetComponent<PlayerController>().enabled = false;
        GetComponentInChildren<FireBallCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<Reload>().enabled = true;
    }

    public void Heal(float Heal)
    {
        Health += Heal;
        Health = Mathf.Clamp(Health, 0, _maxHealth);
        DrawHealthBar();
    }
}
