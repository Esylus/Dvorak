namespace DvorakTrainer.Entities
{
   public class Statistics
   {
        // this class contains all code related to tracking a users score in a practice session

       public decimal Correct { get; set; }
       public decimal Total { get; set; }
       public decimal Accuracy { get; set; }
       public int TotalPoints { get; set; }

        public Statistics()
       {// constructor initializes fields

           Correct = 0;
           Total = 0;
           Accuracy = 0;
           TotalPoints = 0;

       }
 
       public decimal calculateAccuracy(decimal correct, decimal total)
       {
           decimal accuracy = (correct / total);
           Accuracy = accuracy;
           return accuracy; 
       }
    }
}
