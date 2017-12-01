namespace DvorakTrainer
{
    // this class contains all timer - related code

    class GameTimer
    {
        private int m_timerCount;

        public int TimerCount
        {
            get{return m_timerCount;}
            set{this.m_timerCount = value;}
        }

        public GameTimer()
        {
            m_timerCount = 0;
        }

    }
}
