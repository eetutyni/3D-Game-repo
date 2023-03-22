using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthFlashPanel hpFlash;
    
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausemenu;
    [SerializeField] Slider healthbar;

    [SerializeField] private Animator animator;

    public int maxHealth;
    public int curHealth;

    public bool Alive;
   
    void Start()
    {
        curHealth = maxHealth;
        Alive = true;

        healthbar.value = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        if (curHealth <= 0) Die();

        if (curHealth < 100) ShowHp();

        UpdateHealth((float)curHealth / (float)maxHealth);

        hpFlash.HitFlash();
    }

    public void AddHealth(int amountt)
    {
        curHealth += amountt;
        UpdateHealth((float)curHealth / (float)maxHealth);

        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
            HideHp();
        }
    }

    public void Die()
    {
        Destroy(pausemenu);
        Alive = false;
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UpdateHealth(float fraction)
    {
        healthbar.value = fraction;
    }

    // Show HP bar
    public void ShowHp()
    {
        animator.Play("FadeIn");
    }

    // Hide HP bar
    public void HideHp()
    {
        animator.Play("FadeOut");
    }
}
