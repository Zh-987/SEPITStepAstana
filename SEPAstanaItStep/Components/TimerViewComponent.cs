namespace SEPAstanaItStep.Components
{
    public class TimerViewComponent
    {
        public string Invoke() {
            return $"Current Time: {DateTime.Now.ToString("HH:mm:ss")}";
        }
    }
}
