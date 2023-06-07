using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;
using TMPro;


namespace CirclePiecesUI
{
    public class WheelMain : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] GameObject linesPrefab;
        [SerializeField] Transform linesParent;
        [SerializeField] Transform wheelCircle;
        [SerializeField] GameObject circlePiecesPrefab;
        [SerializeField] Transform circlePiecesParent;

        public TMP_Text DrawnCategory;
        public Button SpinButton;
        public GameObject ButtonText;

        private System.Random rand = new System.Random();

        // Data

        private float pieceAngle;
        private float halfPieceAngle;
        private float halfPieceAngleWithWalls;

        public CirclePieces[] circlePieces;

        private Vector2 pieceMinSize = new Vector2(81f, 146f);
        private Vector2 pieceMaxSize = new Vector2(144f, 213f);

        private int minPieces = 2;
        private int maxPieces = 12;

        private bool isSpinning = false;

        [SerializeField] float spinDuration = 11f;
        private Vector3 targetRotation;

        void Start()
        {
            circlePieces = AdjustmentsCategories.dataPieces;
            // Oblicza iloœæ stopni ka¿dej czeœci ko³a i rozpoczyna generacje
            pieceAngle = 360f / circlePieces.Length;
            halfPieceAngle = pieceAngle / 2f;
            halfPieceAngleWithWalls = halfPieceAngle - (halfPieceAngle / 4f);
            Generation();
        }

         private void Generation()
         {
            // Oblicza wielkoœæ ka¿dej czeœci ko³a na podstawie minimalnej oraz maksymalnej iloœci ich czêœci
             circlePiecesPrefab = Instantiate(circlePiecesPrefab, circlePiecesParent.position, Quaternion.identity, circlePiecesParent);

             RectTransform rt = circlePiecesPrefab.transform.GetChild(0).GetComponent<RectTransform>();
             float pieceWidth = Mathf.Lerp(pieceMinSize.x, pieceMaxSize.x, 1f - Mathf.InverseLerp(minPieces, maxPieces, circlePieces.Length));
             float pieceHeight = Mathf.Lerp(pieceMinSize.y, pieceMaxSize.y, 1f - Mathf.InverseLerp(minPieces, maxPieces, circlePieces.Length));
             rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pieceWidth);
             rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pieceHeight);


             for (int i = 0; i < circlePieces.Length; i++)
             {
                 // Tworzy linie, ikony oraz nazwy
                 CirclePieces circlePiece = circlePieces[i];
                 Transform pieceTransform = Instantiate(circlePiecesPrefab, circlePiecesParent.position, Quaternion.identity, circlePiecesParent).transform.GetChild(0);
                 Transform lineTrns = Instantiate(linesPrefab, linesParent.position, Quaternion.identity, linesParent).transform;

                 // Kod poni¿ej s³u¿y do przypisania prefabom danych z tabeli
                 pieceTransform.GetChild(0).GetComponent<Image>().sprite = circlePiece.Icon;
                 pieceTransform.GetChild(1).GetComponent<Text>().text = circlePiece.Label;
                 pieceTransform.GetChild(2).GetComponent<Text>().text = circlePiece.Amount.ToString();

                 // Kod poni¿ej s³uzy do ustawienia na poprawne po³o¿enie ikon, lini, nazw itp.
                 lineTrns.RotateAround(circlePiecesParent.position, Vector3.back, (pieceAngle * i) + halfPieceAngle);
                 pieceTransform.RotateAround(circlePiecesParent.position, Vector3.back, pieceAngle * i);
             }
             Destroy(circlePiecesPrefab);
         }

        private int GetRandomPiece() // DEV
        {
            int i = (rand.Next(circlePieces.Length) + 1); // 1-12
            Debug.Log("Random generated number is: " + i);
            return i;
        }

        private void Update()
        {
            if (isSpinning)
                return;
            if (Input.GetKeyDown(KeyCode.Space)) {
                spin();
            }
        }
        private void spin()
        {
            if (isSpinning)
                return;
            //Wybieranie losowej czêsci ko³a i obliczanie miejsca w które mo¿e wypaœæ
            isSpinning = true;
            DrawnCategory.text = null;
            ButtonText.SetActive(false);
            SpinButton.interactable = false;
            int i = rand.Next(circlePieces.Length); // 1-12
            float angle = -(pieceAngle * i);
            float leftOffset = (angle + halfPieceAngleWithWalls) % 360;
            float rightOffset = (angle - halfPieceAngleWithWalls) % 360;
            float randomAngle = Random.Range(leftOffset, rightOffset);
            targetRotation = Vector3.back * (randomAngle + 1 * 180 * spinDuration);
            Debug.Log("Selected Rotation: " + targetRotation + " Selected index: " + i);
            Debug.Log("LeftOffset: " + leftOffset + " RightOffset: " + rightOffset + " RandomAngle: " + randomAngle);
            //Obracanie siê ko³a na podstawie podanych wartoœci
            wheelCircle
            .DORotate(targetRotation, spinDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutQuart)
            .OnComplete(() => {
                DrawnCategory.text = circlePieces[i].Label;
                SpinButton.interactable = true;
                ButtonText.SetActive(true);
                isSpinning = false;
            });
        }
    }
}
