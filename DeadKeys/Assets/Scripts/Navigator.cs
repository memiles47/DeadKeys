﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Navigator : MonoBehaviour
    {
        // Reference to current camera position
        public int CurrentNode;
        private Animator _thisAnimator;
        private int AnimStateHash = Animator.StringToHash("NavState");
        private int AIEnemies = 0;

        // Reference to NPC die event
        public UnityEvent EnemyDie;

        // Reference to navigator button
        private Button _navigatorButton;

        private static Navigator _mThisInstance;

        // _thisTyper Created to have TypedWord visible in the inspector
        private Typer _thisTyper;

        // Reference to singleton instance
        public static Navigator ThisInstance
        {
            get
            {
                // Get or create singleton instance
                if (_mThisInstance == null)
                {
                    var go = new GameObject("Navigator");
                    _mThisInstance = go.AddComponent<Navigator>();
                }
                return _mThisInstance;
            }
            set
            {
                // If not null then we already have instance
                if (_mThisInstance != null)
                {
                    //If different, then remove duplicate immediatly
                    if (_mThisInstance.GetInstanceID() != value.GetInstanceID())
                        DestroyImmediate(value.gameObject);
                    return;
                }
                // If new, then create new singleton instance
                _mThisInstance = value;
            }
        }

        public void Awake()
        {
            ThisInstance = this;
            _thisAnimator = GetComponent<Animator>();
            _navigatorButton = GameObject.FindGameObjectWithTag("NavigatorButton").GetComponent<Button>();
            HideMoveButton();

            // Getting referecne to the Typer Object to display TypedWord in the inspector
            _thisTyper = GameObject.FindGameObjectWithTag("typer").GetComponent<Typer>();
        }

        public void Next()
        {
            ResetTyping();
            // Reset typing
            //Typer.TypedWord = string.Empty;

            ++CurrentNode;
            _thisAnimator.SetInteger(AnimStateHash, CurrentNode);
        }

        public void Prev()
        {
            ResetTyping();
            // Reset typing
            //Typer.TypedWord = string.Empty;

            --CurrentNode;
            _thisAnimator.SetInteger(AnimStateHash, CurrentNode);
        }

        // Show buttton if there are no remaining enemies
        public void ShowMoveButton()
        {
            // To be defined
            if (AIEnemies > 0)
                return;

            _navigatorButton.gameObject.SetActive(true);
        }

        // Hide navigation button
        public void HideMoveButton()
        {
            _navigatorButton.gameObject.SetActive(false);
        }

        // Method to reset typing
        public void ResetTyping()
        {
            Typer.TypedWord = string.Empty;
        }
    }
}
