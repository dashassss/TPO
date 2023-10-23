import java.io.*;
import java.util.Arrays;

public class DirectoryTreePrinter {
    public static void main(String[] args) {
        if (args.length == 1) {
            String path = args[0];
            File fileOrDirectory = new File(path);

            if (fileOrDirectory.isDirectory()) {
                printDirectoryTree(fileOrDirectory, "");
            } else if (fileOrDirectory.isFile() && path.toLowerCase().endsWith(".txt")) {
                processTextFile(fileOrDirectory);
            } else {
                System.out.println("Указанный путь не является директорией или текстовым файлом.");
            }
        } else {
            System.out.println("Пожалуйста, укажите путь к директории или текстовому файлу в аргументах командной строки.");
        }
    }
    private static void printDirectoryTree(File directory, String prefix) {
        System.out.println(prefix + directory.getName());
        File[] files = directory.listFiles();
        if (files != null) {
            Arrays.sort(files);
            for (int i = 0; i < files.length; i++) {
                if (i == files.length - 1) {
                    System.out.print(prefix + "└───");
                    printFileOrDirectory(files[i], prefix + "    ");
                } else {
                    System.out.print(prefix + "├───");
                    printFileOrDirectory(files[i], prefix + "│   ");
                }
            }
        }
    }
    private static void printFileOrDirectory(File file, String prefix) {
        if (file.isDirectory()) {
            printDirectoryTree(file, prefix);
        } else {
            System.out.println(file.getName());
        }
    }

    private static void processTextFile(File file) {
        try (BufferedReader reader = new BufferedReader(new FileReader(file))) {
            int folderCount = 0;
            int fileCount = 0;
            int totalFileNameLength = 0;
            int totalFileCountInFolder = 0;

            String line;
            while ((line = reader.readLine()) != null) {
                if (line.contains("|")) {
                    folderCount++;
                    if (totalFileCountInFolder > 0) {
                        totalFileCountInFolder--;
                    }
                } else if (line.contains("└───") || line.contains("├───")) {
                    totalFileCountInFolder++;
                } else if (line.trim().endsWith(".mp3")) {
                    fileCount++;
                    totalFileNameLength += line.trim().length();
                }
            }

            double avgFilesPerFolder = (double) fileCount / (folderCount + 1);
            double avgFileNameLength = (double) totalFileNameLength / fileCount;

            System.out.println("Количество папок: " + folderCount);
            System.out.println("Количество файлов: " + fileCount);
            System.out.println("Среднее количество файлов в папке: " + avgFilesPerFolder);
            System.out.println("Средняя длина названия файла: " + avgFileNameLength);
        } catch (IOException e) {
            System.out.println("Ошибка при чтении файла: " + e.getMessage());
        }
    }

}

