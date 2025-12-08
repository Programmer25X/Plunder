using UnityEngine;

public class DCC_PC_Health : MonoBehaviour
{
    private const float maxHealth = 100.0f;
    private float currentHealth;
    private Vector3 respawnPosition;

    private GameObject pcHealthBar;
    private Material healthBarMaterial;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        respawnPosition = transform.position;
        CreateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        UpdateHealthBar();
    }

    private void CheckHealth()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            characterController.enabled = false;
            transform.position = respawnPosition;
            currentHealth = maxHealth;
            characterController.enabled = true;
        }
    }

    public void RecieveDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void SetCheckpointLocation(Vector3 newCheckpointPosition)
    {
        respawnPosition = newCheckpointPosition; 
    }

    private void UpdateHealthBar()
    {
        pcHealthBar.transform.localScale = new Vector3(currentHealth / maxHealth, 0.2f, 0.2f);

        if (currentHealth >= maxHealth * 0.75f)
        {
            healthBarMaterial.color = Color.green;
        }
        else if ((currentHealth < maxHealth * 0.75f) && (currentHealth >= maxHealth * 0.25f))
        {
            healthBarMaterial.color = Color.yellow;
        }
        else if (currentHealth < maxHealth * 0.25f)
        {
            healthBarMaterial.color = Color.red;
        }
    }

    private void CreateHealthBar()
    {
        const string healthBarName = "PC_Health_Bar";
        pcHealthBar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pcHealthBar.name = healthBarName;
        pcHealthBar.transform.parent = this.transform;
        pcHealthBar.transform.localPosition = new Vector3(0, 1.5f, 0);
        pcHealthBar.transform.localScale = new Vector3(1.0f, 0.2f, 0.2f);
        healthBarMaterial = pcHealthBar.GetComponent<Renderer>().material;
    }
}
