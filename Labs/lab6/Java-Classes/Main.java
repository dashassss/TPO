import java.text.SimpleDateFormat;
import java.util.Date;

public class Main {
    public static void main(String[] args) {
        Student[] students = new Student[5];
        students[0] = new Student(1, "Иванов", "Иван", "Иванович", new Date(98, 4, 15), "Адрес1",
                "1234567890", "ИТ", 2, "2");
        students[1] = new Student(2, "Петров", "Петр", "Петрович", new Date(97, 2, 10), "Адрес2",
                "9876543210", "ТОВ", 1, "2");
        students[2] = new Student(3, "Сидоров", "Сидор", "Сидорович", new Date(99, 8, 25), "Адрес3",
                "5555555555", "ИТ", 2, "5");
        students[3] = new Student(4, "Александров", "Александр", "Александрович", new Date(96, 10, 5), "Адрес4",
                "1111111111", "ИТ", 3, "5");
        students[4] = new Student(5, "Никитин", "Никита", "Никитич", new Date(100, 3, 20), "Адрес5",
                "9999999999", "ТОВ", 1, "8");

        // a) список студентов заданного факультета
        String desiredFaculty = "ИТ";
        System.out.println("Студенты факультета " + desiredFaculty + ":");
        for (Student student : students) {
            if (student.getFaculty().equals(desiredFaculty)) {
                System.out.println(student);
            }
        }

        // b) списки студентов для каждого факультета и курса
        System.out.println("Списки студентов по факультетам и курсам:");
        for (Student student : students) {
            System.out.println("Факультет: " + student.getFaculty() + ", Курс: " + student.getCourse());
            System.out.println(student);
        }

        // c) список студентов, родившихся после заданного года
        int desiredYear = 1998;
        System.out.println("Студенты, родившиеся после " + desiredYear + ":");
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy");
        for (Student student : students) {
            int birthYear = Integer.parseInt(sdf.format(student.getBirthDate()));
            if (birthYear > desiredYear) {
                System.out.println(student);
            }
        }

        // d) список учебной группы
        String desiredGroup = "2";
        System.out.println("Студенты группы " + desiredGroup + ":");
        for (Student student : students) {
            if (student.getGroup().equals(desiredGroup)) {
                System.out.println(student);
            }
        }
    }
}