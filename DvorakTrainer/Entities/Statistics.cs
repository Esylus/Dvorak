namespace DvorakTrainer.Entities
{
   public class Statistics
   {
        // this class contains all code related to tracking a users score in a practice session

       public decimal Correct { get; set; }
       public decimal Total { get; set; }
       public decimal Score { get; set; }

        public Statistics()
       {// constructor initializes fields

           Correct = 0;
           Total = 0;
           Score = 0;

       }
 
       public decimal calculateScore(decimal correct, decimal total)
       {
           decimal score = (correct / total);
           Score = score;
           return score; 
       }
    }
}
