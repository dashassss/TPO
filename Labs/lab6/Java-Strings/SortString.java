import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

//Отсортировать слова в тексте по убыванию количества вхождений заданно-го символа, а в случае равенства — по алфавиту.
public class SortString {
    public static void main(String[] args) {
        String text = "Молоко\n" +
                "Городской\n" +
                "Оранжевый\n" +
                "Компьютер\n" +
                "Окно\n" +
                "Кот\n" +
                "Воробей\n" +
                "Океан\n" +
                "Подорожник\n" +
                "Оборонитель";

        char targetChar = 'о';


        String[] words = text.split("\\s+");


        Comparator<String> wordComparator = (word1, word2) -> {
            int charCount1 = countCharacterOccurrences(word1, targetChar);
            int charCount2 = countCharacterOccurrences(word2, targetChar);


            int countComparison = Integer.compare(charCount2, charCount1);

            if (countComparison != 0) {

                return countComparison;
            } else {

                return word1.compareToIgnoreCase(word2);
            }
        };


        List<String> sortedWords = Arrays.asList(words);
        sortedWords.sort(wordComparator);


        System.out.println("Слова, отсортированные по количеству символа '" + targetChar + "' и алфавиту:");
        for (String word : sortedWords) {
            System.out.println(word);
        }
    }

    // Метод для подсчета количества вхождений символа в строку
    private static int countCharacterOccurrences(String str, char targetChar) {
        return (int) str.chars().filter(ch -> ch == targetChar).count();
    }

}
