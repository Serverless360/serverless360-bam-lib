namespace Kovai.Serverless360.Bam
{
    public interface IBamActivityLogger
    {
	    void Debug(string message);
	    void Info(string message);
	    void Warning(string message);
	    void Error(string message);
	    void Fatal(string message);
    }
}
