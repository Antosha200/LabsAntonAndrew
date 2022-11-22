import java.io.File;
import java.io.FileNotFoundException;
import java.net.URL;
import java.util.ArrayList;
import java.util.Scanner;

public class Lab {

    public static final int CRITERIA_COUNT = 4;
    public static final boolean[] CRITERIA_MAX_MIN = {false, false, true, true};
    public static ArgumentCriteriaMatrix argumentCriteriaMatrix;

    public static void main(String[] args) {

        File file = new File("D:\\AntonGit\\LabsAntonAndrew\\Оптимизация проектных решений\\Lab3\\out\\production\\Lab3\\input.txt");
        Scanner scanner;
        try {
            scanner = new Scanner(file);
            argumentCriteriaMatrix = new ArgumentCriteriaMatrix(scanner);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        argumentCriteriaMatrix.printMatrix();

    }
}
