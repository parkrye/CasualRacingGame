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
    public static Dictionary<string, List<string>> ReadCSV(string fileName)
    {
        Dictionary<string, List<string>> answer = new();         // ������ ��ųʸ�

        TextAsset data = GameManager.Resource.Load<Object>($"CSV/{fileName}") as TextAsset;
                                                            // �ؽ�Ʈ�������� ��ȯ�� ��� ���� ������
        string[] texts = data.text.Split("\n");             // �����͸� �ٹٲ� ������ ������ ���ڿ� �迭

        for (int i = 0; i < texts.Length; i++)              // �� ���ڿ� ��ҿ� ���Ͽ�
        {
            if (texts[i].Length <= 1)                       // ���̰� 1 ���϶�� ��� ����
                break;                                      // (���� ��� ������ ��� �����Ϳ� �� ���ڿ� �� ���� �߰��Ǳ� ����)
            string[] line = texts[i].Split(",");            // �������� ������ ���ڿ�����
            List<string> list = new();
            for (int j = 1; j < line.Length; j++)
                list.Add(line[j]);
            answer.Add(line[0], list);                      // ù��°�� Ű��, �������� ����Ʈ�� ����
        }

        return answer;                                      // ������ ��ųʸ��� ��ȯ
    }

    /// <summary>
    /// ��� ������ �����ϴ� �޼ҵ�
    /// </summary>
    public static void WriteCSV(string fileName, Dictionary<string, List<int>> data)
    {
        StringBuilder sb = new();                               // ������ ��Ʈ������
        string delimiter = ",";                                 // ������
        foreach (KeyValuePair<string, List<int>> pair in data)  // �� ������ �ֿ� ���Ͽ�
        {
            sb.Append(pair.Key);                                // Ű
            for (int i = 0; i < data[pair.Key].Count; i++)
            {
                sb.Append(delimiter);                           // ������
                sb.Append(pair.Value[i]);                       // �� ���� �ݺ�
            }
            sb.AppendLine();                                    // �ٹٲ��� �����ϱ⸦ �ݺ�
        }
        Stream fileStream = new FileStream($"Assets/Resources/CSV/{fileName}.csv", FileMode.Create, FileAccess.Write);
                                                                    // ������ �ּ�, ������ ���ų� ���� ����
        StreamWriter outStream = new(fileStream, Encoding.UTF8);    // ��� ����
        outStream.WriteLine(sb);                                    // ��Ʈ�������� ����
        outStream.Close();                                          // ��� ����
    }
}
