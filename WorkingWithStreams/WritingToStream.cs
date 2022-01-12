using System;
using System.IO;
using System.Text;

#pragma warning disable CA1062 // Validate arguments of public methods

namespace WorkingWithStreams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            int temp;
            while ((temp = streamReader.Read()) != -1)
            {
                outputWriter.Write(temp);
            }
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            int temp;
            while ((temp = streamReader.Read()) != -1)
            {
                outputWriter.Write((char)temp);
                outputWriter.Flush();
            }
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            int temp;
            while (contentReader.Peek() != -1)
            {
                temp = contentReader.Read();
                outputWriter.Write("{0:X2}", temp);
            }
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            int temp;
            outputWriter.Write("001 ");
            int i = 2;
            while ((temp = contentReader.Read()) != -1)
            {
                outputWriter.Write(((char)temp).ToString());
                if ((char)temp == '\n')
                {
                    outputWriter.Write("{0:d3} ", i++);
                }

                outputWriter.Flush();
            }

            outputWriter.WriteLine();
            outputWriter.Flush();
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            var sb = new StringBuilder();
            while (contentReader.Peek() != -1)
            {
                sb.Append((char)contentReader.Read());
            }

            while (wordsReader.Peek() != -1)
            {
                sb.Replace(wordsReader.ReadLine(), string.Empty);
            }

            outputWriter.Write(sb);
        }
    }
}
