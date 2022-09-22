using UnityEngine;

public class PrototypeHeroAnimEvents : MonoBehaviour
{
    // References to effect prefabs. These are set in the inspector
    [Header("Effects")]
    public GameObject m_RunStopDust;

    public GameObject m_JumpDust;
    public GameObject m_LandingDust;
    public GameObject m_DodgeDust;
    public GameObject m_WallSlideDust;
    public GameObject m_WallJumpDust;
    public GameObject m_AirSlamDust;
    public GameObject m_ParryEffect;

    private PrototypeHero m_player;
    private AudioManager_PrototypeHero m_audioManager;

    // Start is called before the first frame update
    private void Start()
    {
        m_player = GetComponentInParent<PrototypeHero>();
        m_audioManager = AudioManager_PrototypeHero.instance;
    }

    // Animation Events
    // These functions are called inside the animation files
    private void AE_resetDodge()
    {
        m_player.ResetDodging();
        float dustXOffset = 0.6f;
        float dustYOffset = 0.078125f;
        m_player.SpawnDustEffect(m_RunStopDust, dustXOffset, dustYOffset);
    }

    private void AE_setPositionToClimbPosition()
    {
        m_player.SetPositionToClimbPosition();
    }

    private void AE_runStop()
    {
        m_audioManager.PlaySound("RunStop");
        float dustXOffset = 0.6f;
        float dustYOffset = 0.078125f;
        m_player.SpawnDustEffect(m_RunStopDust, dustXOffset, dustYOffset);
    }

    private void AE_footstep()
    {
        m_audioManager.PlaySound("Footstep");
    }

    private void AE_Jump()
    {
        m_audioManager.PlaySound("Jump");

        if (!m_player.IsWallSliding())
        {
            float dustYOffset = 0.078125f;
            m_player.SpawnDustEffect(m_JumpDust, 0.0f, dustYOffset);
        }
        else
        {
            m_player.SpawnDustEffect(m_WallJumpDust);
        }
    }

    private void AE_Landing()
    {
        m_audioManager.PlaySound("Landing");
        float dustYOffset = 0.078125f;
        m_player.SpawnDustEffect(m_LandingDust, 0.0f, dustYOffset);
    }

    private void AE_Throw()
    {
        m_audioManager.PlaySound("Jump");
    }

    private void AE_Parry()
    {
        m_audioManager.PlaySound("Parry");
        float xOffset = 0.1875f;
        float yOffset = 0.25f;
        m_player.SpawnDustEffect(m_ParryEffect, xOffset, yOffset);
        m_player.DisableMovement(0.5f);
    }

    private void AE_ParryStance()
    {
        m_audioManager.PlaySound("DrawSword");
    }

    private void AE_AttackAirSlam()
    {
        m_audioManager.PlaySound("DrawSword");
    }

    private void AE_AttackAirLanding()
    {
        m_audioManager.PlaySound("AirSlamLanding");
        float dustYOffset = 0.078125f;
        m_player.SpawnDustEffect(m_AirSlamDust, 0.0f, dustYOffset);
        m_player.DisableMovement(0.5f);
    }

    private void AE_Hurt()
    {
        m_audioManager.PlaySound("Hurt");
    }

    private void AE_Death()
    {
        m_audioManager.PlaySound("Death");
    }

    private void AE_SwordAttack()
    {
        m_audioManager.PlaySound("SwordAttack");
    }

    private void AE_SheathSword()
    {
        m_audioManager.PlaySound("SheathSword");
    }

    private void AE_Dodge()
    {
        m_audioManager.PlaySound("Dodge");
        float dustYOffset = 0.078125f;
        m_player.SpawnDustEffect(m_DodgeDust, 0.0f, dustYOffset);
    }

    private void AE_WallSlide()
    {
        //m_audioManager.GetComponent<AudioSource>().loop = true;
        if (!m_audioManager.IsPlaying("WallSlide"))
            m_audioManager.PlaySound("WallSlide");
        float dustXOffset = 0.25f;
        float dustYOffset = 0.25f;
        m_player.SpawnDustEffect(m_WallSlideDust, dustXOffset, dustYOffset);
    }

    private void AE_LedgeGrab()
    {
        m_audioManager.PlaySound("LedgeGrab");
    }

    private void AE_LedgeClimb()
    {
        m_audioManager.PlaySound("RunStop");
    }
}