using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Repository;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerProgressService : MonoBehaviour
{
   private PlayerProgressRepository _playerProgressRepository;
   private PlayerProgressModel _playerProgressModel;
   private void Awake()
   {
      _playerProgressRepository = GameApplication.RequireService<PlayerProgressRepository>();
      _playerProgressModel = _playerProgressRepository.Get();
      if(_playerProgressModel == null)
         CreatePlayerProgress(); 
   }
   
   [PublicAPI]
   public void NextLevel(int lvl)
   {
      _playerProgressModel.CurrentLevel=lvl;
      _playerProgressRepository.Save(_playerProgressModel);
   }
   
   private void CreatePlayerProgress()
   {
      _playerProgressModel = new PlayerProgressModel();
      _playerProgressRepository.Save(_playerProgressModel);
      
   }

   public int currentLevel => _playerProgressModel.CurrentLevel;
}
