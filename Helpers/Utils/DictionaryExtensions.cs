namespace Helpers.Utils;

public static class DictionaryExtensions
{
    public static SortedDictionary<int, SortedSet<string>> FrequencyReverse(this IDictionary<string, int> frequencyContainer)
    {
        var sortedSections = new SortedDictionary<int, SortedSet<string>>(new DescendingComparer<int>());

        foreach (var wordPair in frequencyContainer)
        {
            if (sortedSections.ContainsKey(wordPair.Value))
            {
                sortedSections[wordPair.Value].Add(wordPair.Key);
            }
            else
            {
                sortedSections[wordPair.Value] =
                [
                    wordPair.Key
                ];
            }
        }

        return sortedSections;
    }
}
