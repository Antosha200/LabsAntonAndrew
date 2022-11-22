import java.io.File;
import java.io.FileNotFoundException;
import java.net.URL;
import java.util.ArrayList;
import java.util.Scanner;

public class Lab {

    public static final int CRITERIA_COUNT = 4;
    public static final boolean[] CRITERIA_MAX_MIN = {false, false, true, true};
    public static final double[] LAMBDAS = {0.25, 0.25, 0.3, 0.2};
    public static final double RESTRICTION_AREA_MIN = 0;
    public static final double RESTRICTION_AREA_MAX = 1;
    public static ArgumentCriteriaMatrix argumentCriteriaMatrix;

    public static void main(String[] args) {

        //File file = new File("D:\\AntonGit\\LabsAntonAndrew\\Оптимизация проектных решений\\Lab3\\out\\production\\Lab3\\input.txt");
        File file = new File("D:\\Учёба\\4 курс\\LabsAntonAndrew\\Оптимизация проектных решений\\Lab3\\src\\input.txt");
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
