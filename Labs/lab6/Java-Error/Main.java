import java.util.ArrayList;
import java.util.List;

// Исключение для недопустимых оценок
class InvalidGradeException extends Exception {
    public InvalidGradeException(String message) {
        super(message);
    }
}

// Исключение для отсутствия предметов у студента (должен быть хотя бы один)
class NoSubjectsException extends Exception {
    public NoSubjectsException(String message) {
        super(message);
    }
}

// Исключение для отсутствия студентов в группе
class NoStudentsInGroupException extends Exception {
    public NoStudentsInGroupException(String message) {
        super(message);
    }
}

// Исключение для отсутствия групп на факультете
class NoGroupsOnFacultyException extends Exception {
    public NoGroupsOnFacultyException(String message) {
        super(message);
    }
}

// Исключение для отсутствия факультетов в университете
class NoFacultiesInUniversityException extends Exception {
    public NoFacultiesInUniversityException(String message) {
        super(message);
    }
}

// Класс, представляющий оценку по предмету
class Grade {
    private int value;

    public Grade(int value) throws InvalidGradeException {
        if (value < 0 || value > 10) {
            throw new InvalidGradeException("Оценка должна быть от 0 до 10");
        }
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}

// Класс, представляющий студента
class Student {
    private String name;
    private List<Grade> grades;

    public Student(String name) {
        this.name = name;
        this.grades = new ArrayList<>();
    }

    public void addGrade(Grade grade) {
        grades.add(grade);
    }

    public List<Grade> getGrades() {
        return grades;
    }
    public double calculateAverageGrade() throws NoSubjectsException {
        if (grades.isEmpty()) {
            throw new NoSubjectsException("Студент не имеет предметов");
        }
        double sum = 0;
        for (Grade grade : grades) {
            sum += grade.getValue();
        }
        return sum / grades.size();
    }
}

// Класс, представляющий группу
class Group {
    private String name;
    private List<Student> students;

    public Group(String name) {
        this.name = name;
        this.students = new ArrayList<>();
    }

    public void addStudent(Student student) {
        students.add(student);
    }

    public double calculateAverageGrade(String subject) throws NoStudentsInGroupException, NoSubjectsException {
        if (students.isEmpty()) {
            throw new NoStudentsInGroupException("В группе отсутствуют студенты");
        }
        double sum = 0;
        int count = 0;
        for (Student student : students) {
            for (Grade grade : student.getGrades()) {
                if (subject.equals("название_предмета")) {
                    sum += grade.getValue();
                    count++;
                }
            }
        }
        if (count == 0) {
            throw new NoSubjectsException("В группе нет студентов с предметом: " + subject);
        }
        return sum / count;
    }
}

// Класс, представляющий факультет
class Faculty {
    private String name;
    private List<Group> groups;

    public Faculty(String name) {
        this.name = name;
        this.groups = new ArrayList<>();
    }

    public void addGroup(Group group) {
        groups.add(group);
    }

    public double calculateAverageGrade(String subject) throws NoGroupsOnFacultyException, NoStudentsInGroupException, NoSubjectsException {
        if (groups.isEmpty()) {
            throw new NoGroupsOnFacultyException("На факультете отсутствуют группы");
        }
        double sum = 0;
        int count = 0;
        for (Group group : groups) {
            try {
                sum += group.calculateAverageGrade(subject);
                count++;
            } catch (NoStudentsInGroupException e) {
                // Продолжаем обработку других групп
            }
        }
        if (count == 0) {
            throw new NoStudentsInGroupException("На факультете отсутствуют группы с предметом: " + subject);
        }
        return sum / count;
    }
}

// Класс, представляющий университет
class University {
    private String name;
    private List<Faculty> faculties;

    public University(String name) {
        this.name = name;
        this.faculties = new ArrayList<>();
    }

    public void addFaculty(Faculty faculty) {
        faculties.add(faculty);
    }

    public double calculateAverageGrade(String subject) throws NoFacultiesInUniversityException, NoGroupsOnFacultyException, NoStudentsInGroupException, NoSubjectsException {
        if (faculties.isEmpty()) {
            throw new NoFacultiesInUniversityException("В университете отсутствуют факультеты");
        }
        double sum = 0;
        int count = 0;
        for (Faculty faculty : faculties) {
            try {
                sum += faculty.calculateAverageGrade(subject);
                count++;
            } catch (NoGroupsOnFacultyException e) {
                // Продолжаем обработку других факультетов
            }
        }
        if (count == 0) {
            throw new NoGroupsOnFacultyException("В университете отсутствуют факультеты с предметом: " + subject);
        }
        return sum / count;
    }
}


public class Main {
    public static void main(String[] args) {
        try {
            // Создаем объекты университета, факультетов, групп и студентов
            University university = new University("My University");

            Faculty faculty1 = new Faculty("Faculty of Science");
            Faculty faculty2 = new Faculty("Faculty of Arts");

            Group group1 = new Group("Group A");
            Group group2 = new Group("Group B");

            Student student1 = new Student("John");
            Student student2 = new Student("Alice");

            // Добавляем оценки студентам
            student1.addGrade(new Grade(8));
            student1.addGrade(new Grade(7));
            student1.addGrade(new Grade(5));
            student2.addGrade(new Grade(9));
            student2.addGrade(new Grade(10));

            // Добавляем студентов в группы
            group1.addStudent(student1);
            group2.addStudent(student2);

            // Добавляем группы на факультеты
            faculty1.addGroup(group1);
            faculty2.addGroup(group2);

            // Добавляем факультеты в университет
            university.addFaculty(faculty1);
            university.addFaculty(faculty2);

            // Вычисляем средний балл студента
            double student1AverageGrade = student1.calculateAverageGrade();
            System.out.println("Средний балл студента 1: " + student1AverageGrade);

            // Вычисляем средний балл по предмету в группе на факультете
            double averageGradeInGroup1 = group1.calculateAverageGrade("название_предмета");
            System.out.println("Средний балл по предмету в Group A: " + averageGradeInGroup1);

            // Вычисляем средний балл по предмету для всего университета
            double averageGradeInUniversity = university.calculateAverageGrade("название_предмета");
            System.out.println("Средний балл по предмету в университете: " + averageGradeInUniversity);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}