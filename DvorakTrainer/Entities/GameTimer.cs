namespace DvorakTrainer.Entities
{
    // this class contains all timer - related code

    class GameTimer
    {

        public int TimerCount { get; set; }      

        public GameTimer()
        {
            TimerCount = 600;      // set how long each round should take 
        }

    }
}
