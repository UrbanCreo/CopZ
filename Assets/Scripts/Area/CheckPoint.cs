using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform previousArea;
    [SerializeField] private Transform nextArea;
    [SerializeField] private CameraController cam;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x < transform.position.x)
                cam.MoveToNewArea(nextArea);
            else
                cam.MoveToNewArea(previousArea);
        }

        if (anim != null)
            anim.SetBool("constantFlutter", true);
        else
            Debug.LogWarning("Animator component is missing on CheckPoint.");
    }
}