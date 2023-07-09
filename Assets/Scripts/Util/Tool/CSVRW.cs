using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

/// <summary>
/// Ư�� CSW ������ �а� ���� ��ũ��Ʈ
/// </summary>
public static class CSVRW
{
    /// <summary>
    /// ������ �д� �޼ҵ�
    /// </summary>
    /// <param name="fileName">���� �̸�</param>
    /// <returns>��ųʸ� ������ ��� ����</returns>
    public static Dictionary<string, int> ReadCSV(string fileName)
    {
        Dictionary<string, int> answer = new();         // ������ ��ųʸ�

        TextAsset data = GameManager.Resource.Load<Object>($"CSV/{fileName}") as TextAsset;
                                                        // �ؽ�Ʈ�������� ��ȯ�� ��� ���� ������
        string[] texts = data.text.Split("\n");         // �����͸� �ٹٲ� ������ ������ ���ڿ� �迭

        for (int i = 0; i < texts.Length; i++)          // �� ���ڿ� ��ҿ� ���Ͽ�
        {
            if (texts[i].Length <= 1)                   // ���̰� 1 ���϶�� ��� ����
                break;                                  // (���� ��� ������ ��� �����Ϳ� �� ���ڿ� �� ���� �߰��Ǳ� ����)
            string[] line = texts[i].Split(",");        // �������� ������ �� ���ڿ���
            answer.Add(line[0], int.Parse(line[1]));    // Ű�� ������ ����
        }

        return answer;                                  // ������ ��ųʸ��� ��ȯ
    }

    /// <summary>
    /// ��� ������ �����ϴ� �޼ҵ�
    /// </summary>
    public static void WriteCSV(string fileName, Dictionary<string, int> data)
    {
        StringBuilder sb = new();                           // ������ ��Ʈ������
        string delimiter = ",";                             // ������
        foreach(KeyValuePair<string, int> pair in data)     // �� ������ �ֿ� ���Ͽ�
        {
            // Ű, ������, ���� ����
            sb.Append(pair.Key);
            sb.Append(delimiter);
            sb.AppendLine(pair.Value.ToString());
        }
        Stream fileStream = new FileStream($"Assets/Resources/CSV/{fileName}.csv", FileMode.Create, FileAccess.Write);
                                                                    // ������ �ּ�, ������ ���ų� ���� ����
        StreamWriter outStream = new(fileStream, Encoding.UTF8);    // ��� ����
        outStream.WriteLine(sb);                                    // ��Ʈ�������� ����
        outStream.Close();                                          // ��� ����
    }
}
