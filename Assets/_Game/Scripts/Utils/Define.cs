namespace TowerDefense.Utils
{
    public class Define
    {
        public enum EnemyStyle
        {
            Unknown,
            BlueEnemy,
            RedEnemy,
            BlackEnemy

        }
        public enum GameplayTags
        {
            Enemy,
            MainBase
        }

        public enum Tower
        {
            FireTower,
            EnegeryTower
        }

        public enum SceneType
        {
            Unknown,
            LoadingScene,
            Game
        }

        public enum PopupType
        {
            Unknown,
            GameOver,
            Win
        }
    }
}