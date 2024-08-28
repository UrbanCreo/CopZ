using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private float levitationSpeed = 1f;
    [SerializeField] private float levitationHeight = 0.5f;

    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        Levitate();
    }

    private void Levitate()
    {
        //Use sinus funciton for move up and down
        float levitationOffset = Mathf.Sin(Time.time * levitationSpeed) * levitationHeight;

        //Set new object position
        transform.position = new Vector2(initialPosition.x, initialPosition.y + levitationOffset);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}