import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

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

        char targetChar = 'о'; // Заданный символ

        // Разбиваем текст на слова
        String[] words = text.split("\\s+");

        // Создаем компаратор для сортировки
        Comparator<String> wordComparator = (word1, word2) -> {
            int charCount1 = countCharacterOccurrences(word1, targetChar);
            int charCount2 = countCharacterOccurrences(word2, targetChar);

            // Сравниваем по количеству символов
            int countComparison = Integer.compare(charCount2, charCount1);

            if (countComparison != 0) {
                // Если количество разное, сортируем по убыванию количества
                return countComparison;
            } else {
                // Если количество одинаково, сортируем по алфавиту
                return word1.compareToIgnoreCase(word2);
            }
        };

        // Сортируем слова
        List<String> sortedWords = Arrays.asList(words);
        sortedWords.sort(wordComparator);

        // Выводим отсортированные слова
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
