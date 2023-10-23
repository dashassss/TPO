public class Main {
    public static void main(String[] args) {
        String text = "Это пример текста, который будет обработан. Удалим слова согласной буквой и длиной 4 буква.";
        System.out.println(text);
        int wordLengthToFilter = 5; // Заданная длина слова
        String consonants = "бвгджзйклмнпрстфхцчшщ"; // Согласные буквы

        // Разбиваем текст на слова
        String[] words = text.split("\\s+");

        // Создаем StringBuilder для сбора результата
        StringBuilder result = new StringBuilder();

        for (String word : words) {
            // Удаление знаков препинания
            word = word.replaceAll("[^\\p{L}\\p{N}]+", "");

            // Проверка длины и начальной буквы
            if (word.length() != wordLengthToFilter || word.isEmpty() || consonants.indexOf(Character.toLowerCase(word.charAt(0))) == -1) {
                // Если слово соответствует условиям, добавляем его в результат
                result.append(word).append(" ");
            }
        }

        // Выводим обработанный текст
        System.out.println(result.toString().trim());
    }
}
