using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowPointer : MonoBehaviour
{
   public float offsetRowPointer = 2f;

   [SerializeField]
   private PhysicalRow _physicalRow;

   private int _currentIndex = 0;

   private void Start()
   {
      SetRowPointerOnNextPosition();
      Metronome.instance.OnPlayTickEvent += SetRowPointerOnNextPosition;
   }

   private void OnDisable()
   {
      Metronome.instance.OnPlayTickEvent -= SetRowPointerOnNextPosition;
   }

   private void SetRowPointerOnNextPosition()
   {
      var currentRowSlot = _physicalRow.rowSlotsActive[_currentIndex];
      
      var rowPointerPos = currentRowSlot.transform.position;
      rowPointerPos.y += offsetRowPointer;
      
      this.transform.position = rowPointerPos;
      
      currentRowSlot.PlayRowSlot();
      
      _currentIndex++;
      if (_currentIndex == _physicalRow.rowSlotsActive.Count)
         _currentIndex = 0;
   }
   
}
