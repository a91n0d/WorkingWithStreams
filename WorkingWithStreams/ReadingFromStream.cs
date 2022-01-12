using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class ReadingFromStream
    {
        public static string ReadAllStreamContent(StreamReader streamReader)
        {
            return streamReader.ReadToEnd();
        }

        public static string[] ReadLineByLine(StreamReader streamReader)
        {
            var readLineByLine = new List<string>();
            string str;
            while ((str = streamReader.ReadLine()) != null)
            {
                readLineByLine.Add(str);
            }

            return readLineByLine.ToArray();
        }

        public static StringBuilder ReadOnlyLettersAndNumbers(StreamReader streamReader)
        {
            var readOnlyLettersAndNumbers = new StringBuilder();
            while (char.IsLetterOrDigit((char)streamReader.Peek()))
            {
                readOnlyLettersAndNumbers.Append((char)streamReader.Read());
            }

            return readOnlyLettersAndNumbers;
        }

        public static char[][] ReadAsCharArrays(StreamReader streamReader, int arraySize)
        {
            long stremReaderLenght = streamReader.BaseStream.Length;
            int len = (int)(stremReaderLenght / arraySize) + ((stremReaderLenght % arraySize > 0) ? 1 : 0);
            var readAsCharArrays = new char[len][];
            int i = 0;
            int j = 0;
            var tempList = new List<char>();
            while (j != len)
            {
                if (i == arraySize)
                {
                    readAsCharArrays[j++] = tempList.ToArray();
                    i = 0;
                    tempList = new List<char>();
                    continue;
                }

                if (streamReader.Peek() > 0)
                {
                    tempList.Add((char)streamReader.Read());
                }

                i++;
            }

            return readAsCharArrays;
        }
    }
}
