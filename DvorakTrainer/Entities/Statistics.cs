namespace DvorakTrainer
{
   public class Statistics
   {
        // this class contains all code related to tracking a users score in a practice session

       private decimal m_correct;
       private decimal m_total;
       private decimal m_score;

       public decimal Correct
       {
           get{return m_correct;}
           set{this.m_correct = value;}
       }
       public decimal Total
       {
           get { return m_total; }
           set { this.m_total = value; }
       }
       public decimal Score
       {
           get { return m_score; }
           set { this.m_score = value; }
       }

       public Statistics()
       {// constructor initializes fields
           m_correct = 0;
           m_total = 0;
           m_score = 0;
       }
 
       public decimal calculateScore(decimal correct, decimal total)
       {
           decimal score = (correct / total);
           m_score = score;
           return score; 
       }

      

    }
}
