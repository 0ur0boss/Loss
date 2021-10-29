using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{

    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;


        public float maxSpeed = 10;

        public float littlejumpoffset;

        public float jumpTakeOffSpeed = 10;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        public Collider2D collider2d;
        public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        public Rigidbody2D rb2D;

        bool isGoingLeft = false;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;

        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();

        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = (jumpTakeOffSpeed * 2) * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = (velocity.y * 2) * (model.jumpDeceleration * 2);
                }
            }

            if (move.x > 0.01f)
            {
                if (isGoingLeft)
                {
                    isGoingLeft = false;
                    transform.Translate(new Vector3(-littlejumpoffset, 0));
                }
                // transform.rotation = Quaternion.Euler(0, 0, 0);
                rb2D.transform.rotation = Quaternion.Euler(0, 0, 0);

               
            }
            else if (move.x < -0.01f)
            {
                if (!isGoingLeft)
                {
                    isGoingLeft = true;
                    transform.Translate(new Vector3(-littlejumpoffset, 0));
                }
                //transform.rotation = Quaternion.Euler(0, -180, 0);
                rb2D.transform.rotation = Quaternion.Euler(0, -180, 0);

            }



            targetVelocity = (move * 10) * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }


    }
}

