using UnityEngine;

public class Alvo : MonoBehaviour
{
    public GameManager gameManager;
    public int pontos = 10;

    void OnCollisionEnter(Collision collision)
    {
        // Se o objeto que bateu tiver o script "Bala", ele conta o ponto
        if (collision.gameObject.GetComponent<Bala>() != null)
        {
            gameManager.AdicionarScore(pontos);
            Destroy(gameObject); // O alvo é destruído
        }
    }
}