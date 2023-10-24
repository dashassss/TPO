public class Main {
    //Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
    public static void main(String[] args) {
        String text = "Это пример текста, который будет обработан. Удалим слова согласной буквой и длиной 5 букв.";
        System.out.println(text);
        int wordLengthToFilter = 5; // Заданная длина слова
        String consonants = "бвгджзйклмнпрстфхцчшщ"; // Согласные буквы


        String[] words = text.split("\\s+");


        StringBuilder result = new StringBuilder();

        for (String word : words) {

            word = word.replaceAll("[^\\p{L}\\p{N}]+", "");


            if (word.length() != wordLengthToFilter || word.isEmpty() || consonants.indexOf(Character.toLowerCase(word.charAt(0))) == -1) {

                result.append(word).append(" ");
            }
        }


        System.out.println(result.toString().trim());
    }
}
