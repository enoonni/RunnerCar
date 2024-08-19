namespace GameData.Player.PlayerCarStats
{
    public class CarStats
    {
        private static CarStats _instance = new CarStats();
        public static CarStats Instance
        {
            get;
        }

        private int _health;
        private float _speed;

        public CarStats()
        {            
        }


    }
}