namespace GradeCalculator.Shared
{
    public class GradeCalculator
    {
        public string ConvertScoreToGrade(int score)
        {
            var result = "F";

            if (score > 50)
            {
                result = "D";
            }
            if (score > 60)
            {
                result = "C";
            }
            if (score > 70)
            {
                result = "B";
            }
            if (score > 85)
            {
                result = "A";
            }
            if (score > 100 || score < 0)
            {
                result = null;
            }

            return result;
        }

        // ???
        //public void Print()
        //{
        //    throw new NotImplementedException();
        //}
    }
}