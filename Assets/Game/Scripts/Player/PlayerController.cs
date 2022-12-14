using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IDamageable))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private DialogUI dialogUI;
    [SerializeField] private TarotUI tarotUI;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D playerRb;
    private PlayerInput playerInput;
    [SerializeField] public GameObject weaponObject;
    public IWeapon weapon { get; private set; }
    IDamageable damageable;

    public DialogUI DialogUI => dialogUI;
    public TarotUI TarotUI => tarotUI;
    public IInteractable Interactable {get; set;}

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<IDamageable>();
        damageable.DeathEvent += OnDamage;

        if (weaponObject != null)
        {
            weapon = weaponObject.GetComponent<IWeapon>();
        }
    }

    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DeathEvent -= OnDamage;
        }
    }

    void FixedUpdate()
    {

        if(dialogUI != null) if(dialogUI.IsOpen ) return;
        if(tarotUI != null) if(tarotUI.IsOpen) return;
        playerRb.MovePosition(playerRb.position + playerInput.GetMovementInput().normalized * moveSpeed);

        //Attack
        if (weapon != null && playerInput.IsAttackButtonDown())
        {
            weapon.Attack();

            /*if(weapon.IsAttacking)
            {
                SoundManager.instance.PlaySingle(atkfx);
            }*/
        }

        if(playerInput.IsInteractionButtomDown())
        {
            Interactable?.Interact(this);
        }
    }

    private void OnDamage()
    {
        if (damageable.IsDead)
        {
            Destroy(gameObject);
            //Tela de Morte
            //SoundManager.instance.PlaySingle(deadfx);

        }
        else if (!damageable.IsDead)
        {
            CameraShake.Instance.CameraShaker(15f, 0.1f);
            //SoundManager.instance.PlaySingle(damagefx);
        }
    }
}