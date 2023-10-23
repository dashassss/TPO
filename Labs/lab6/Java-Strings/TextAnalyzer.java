import java.util.*;

public class TextAnalyzer {
    public static void main(String[] args) {
        String text = "Это первое предложение. Это второе предложение. Третье предложение.";

        // Разбиваем текст на предложения
        String[] sentences = text.split("\\.");

        if (sentences.length < 2) {
            System.out.println("Текст должен содержать как минимум два предложения.");
            return;
        }

        // Разбиваем первое предложение на слова
        String[] firstSentenceWords = sentences[0].trim().split(" ");

        // Создаем множество для хранения слов из первого предложения
        Set<String> firstSentenceWordsSet = new HashSet<>();
        for (String word : firstSentenceWords) {
            firstSentenceWordsSet.add(word.toLowerCase()); // Приводим к нижнему регистру для сравнения
        }

        // Создаем список для хранения слов, которых нет в остальных предложениях
        List<String> uniqueWords = new ArrayList<>();

        // Проходим по остальным предложениям и добавляем слова из первого предложения, которых нет в них
        for (int i = 1; i < sentences.length; i++) {
            String[] sentenceWords = sentences[i].trim().split(" ");
            for (String word : sentenceWords) {
                if (!firstSentenceWordsSet.contains(word.toLowerCase())) {
                    uniqueWords.add(word);
                }
            }
        }

        // Выводим уникальные слова из первого предложения
        System.out.println("Уникальные слова в первом предложении, которых нет ни в одном из остальных предложений:");
        for (String word : uniqueWords) {
            System.out.println(word);
        }
    }
}



