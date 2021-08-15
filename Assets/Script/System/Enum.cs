using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Data
{
	public enum GameState
	{
 
		beforeEnter = -1,  //进入游戏之前
		 
		EnterNoTeach = 0,
		 
		EnterTeached = 1,
		 
		WalkRight = 2
	}
    public enum PlayerDataType
    {
        None = -1,
        Gold,
        HighScore,
        CoinUpgrade,
        CrownUpgrade,
        FateUpgrade,
        InitialTime,
        RewardTime,
        BombUpgrade,
    }

    public enum GameDataType
    {
        None = -1,
        StopAudio,
        Stage,
        Date,
        GiftCount,
        FirstTimePlay,
    }

    public enum CatType
    {
        None = -1,
		None2 = 0,
        A = 1,
		B  = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8,
        I = 9,
        J = 10,
        K = 11,
        L = 12,
        M = 13,
        N = 14,
        O = 15,
        P = 16,
        Q = 17,
        R = 18,
        S = 19,
        T = 20,
        U = 21,
        V = 22,
    }
	public enum CatState
	{
		None = -1,
		readyMove,
		Moving,
		Idle,
	}
	public enum StopType
	{
		None = -1,
		SameColorStop,
		FootStop 
	}
    public enum TaskType
    {
        None = -1,
        Disposable,
        Total,
        Bom,
    }

    public enum SceneType
    {
        None = -1,
        Menu,
        Normal,
        Stage,
    }

    public enum DirectionType
    {
        None = -1,
        Directions4,
        Directions8,
        Directions12,
        Directions24,
    }

    public enum AdType
    {
        None,
        InterstitialAd,
        VideoAd,
        Incentivized,
    }

    public enum AdAwardType
    {
        None,
        Gold,
        Time,
    }
}