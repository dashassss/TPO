import java.util.*;

public class TextAnalyzer {
    public static void main(String[] args) {
        String text = "Это первое предложение. Это второе предложение. Третье предложение.";


        String[] sentences = text.split("\\.");

        if (sentences.length < 2) {
            System.out.println("Текст должен содержать как минимум два предложения.");
            return;
        }


        String[] firstSentenceWords = sentences[0].trim().split(" ");


        Set<String> firstSentenceWordsSet = new HashSet<>();
        for (String word : firstSentenceWords) {
            firstSentenceWordsSet.add(word.toLowerCase());
        }


        List<String> uniqueWords = new ArrayList<>();


        for (int i = 1; i < sentences.length; i++) {
            String[] sentenceWords = sentences[i].trim().split(" ");
            for (String word : sentenceWords) {
                if (!firstSentenceWordsSet.contains(word.toLowerCase())) {
                    uniqueWords.add(word);
                }
            }
        }


        System.out.println("Уникальные слова в первом предложении, которых нет ни в одном из остальных предложений:");
        for (String word : uniqueWords) {
            System.out.println(word);
        }
    }
}



