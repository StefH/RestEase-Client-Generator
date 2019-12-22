namespace RestEaseClientCodeGeneratorVSIX
{
    public interface IProgressReporter
    {
        void Progress(uint progress, uint total = 100);
    }
}
