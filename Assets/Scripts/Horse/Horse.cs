using UnityEngine;

public class Horse : MonoBehaviour
{
    [SerializeField] HorseData horseData;
    public HorseData Data { get { return horseData; } }
    [SerializeField] Material[] materials;
    [SerializeField] SkinnedMeshRenderer[] body, fur, accesory;

    [ContextMenu("Setting")]
    public void Initialize(string horseName)
    {
        horseData.horseName = horseName;
        horseData.speed = 30;
        horseData.power = 10;
        horseData.intelligence = 20;

        // �ܰŸ� ǥ��
        //horseData.stamina = 30;

        // ���� ǥ��
        //horseData.stamina = 60;

        // �߰Ÿ� ǥ��
        //horseData.stamina = 80;

        // ��Ÿ� ǥ��
        horseData.stamina = 55;

        horseData.speed += Random.Range(-horseData.speed * 0.1f, horseData.speed * 0.1f);
        horseData.stamina += Random.Range(-horseData.stamina * 0.1f, horseData.stamina * 0.1f);
        horseData.power += Random.Range(-horseData.power * 0.1f, horseData.power * 0.1f);
        horseData.intelligence += Random.Range(-horseData.intelligence * 0.1f, horseData.intelligence * 0.1f);

        int material = Random.Range(0, materials.Length);
        for(int i = 0; i < body.Length; i++)
            body[i].material = materials[material];

        material = Random.Range(0, materials.Length);
        for(int i = 0; i < fur.Length; i++)
            fur[i].material = materials[material];

        for(int i = 0; i < accesory.Length; i++)
            accesory[i].material = materials[Random.Range(0, materials.Length)];
    }

    public void RestartAnimator()
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled = false;
        animator.enabled = true;
    }
}
