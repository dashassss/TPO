import java.io.*;
import java.util.ArrayList;

public class UpdateStudentGrades {
    public static void main(String[] args) {
        String inputFileName = "student_grades.txt";
        String outputFileName = "updated_student_grades.txt";

        try {
            ArrayList<String> lines = new ArrayList<>();
            BufferedReader reader = new BufferedReader(new FileReader(inputFileName));

            // Чтение содержимого файла
            String line;
            while ((line = reader.readLine()) != null) {
                lines.add(line);
            }
            reader.close();

            // Обработка и запись фамилий студентов с баллами более 7
            BufferedWriter writer = new BufferedWriter(new FileWriter(outputFileName));
            for (String studentData : lines) {
                String[] parts = studentData.split(" ");
                if (parts.length >= 2) {
                    String name = parts[0];
                    double grade = Double.parseDouble(parts[1]);
                    if (grade > 7.0) {
                        name = name.toUpperCase(); // Преобразование в прописные буквы
                    }
                    writer.write(name + " " + grade);
                    writer.newLine();
                }
            }
            writer.close();
        } catch (IOException e) {
            System.err.println("Ошибка при чтении/записи файла: " + e.getMessage());
        }
    }
}
