namespace BitPantry.StringWriters
{
    public interface IAppendWriterCollection
    {
        AppendStringWriter Standard { get; }
        AppendStringWriter Warning { get; }
        AppendStringWriter Error { get; }
        AppendStringWriter Debug { get; }
        AppendStringWriter Verbose { get; }

        AppendStringWriter GreyAccent { get; }
        AppendStringWriter BlueAccent { get; }
        AppendStringWriter GreenAccent { get; }
    }
}
