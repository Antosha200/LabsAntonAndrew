import java.io.File;
import java.util.Scanner;

public class Main {
    final static int need = 5;
    final static int reserves = 4;

    public static void main(String[] args) {
        int[][] table = new int[reserves + 1][need + 1];
        int[][] prices = new int[reserves][need];
        File input = new File("D:\\AntonGit\\LabsAntonAndrew\\Оптимизация проектных решений\\Lab2NorthWestCorner\\out\\production\\Lab2NorthWestCorner" + "\\input.txt");
        //File input = new File(System.getProperty("java.class.path") + "\\input.txt");
        inputValue(table, prices, input);
        printTable(table);
        startCornerAlg(1,1,table);
        System.out.println(getF(table,prices));
    }

    public static int getF(int[][] table, int[][] prices)
    {
        int f = 0;
        for (int i = 0; i < reserves; i++)
            for (int j = 0; j < need; j++)
            {
                f += table[i + 1][j + 1] * prices[i][j];
            }
        return f;
    }

    public static void startCornerAlg(int i, int j, int[][] table)
    {
            int value = Math.min(table[i][0], table[0][j]);
            table[i][j] = value;
            table[i][0] -= value;
            table[0][j] -= value;
            printTable(table);
            if (table[i][0] != 0)
            {
                startCornerAlg(i, j + 1, table);
            }
            else if (table[0][j] != 0)
            {
                startCornerAlg(i + 1, j, table);
            }
    }

    public static void inputValue(int[][] table, int[][]prices, File input)
    {
        try {
            Scanner scanner = new Scanner(input);

            for (int i = 0; i < reserves + 1; i++) {
                for (int j = 0; j < need + 1; j++)
                {
                    if (i != 0 && j !=0)
                    {
                        prices[i - 1][j - 1] = scanner.nextInt();
                        table[i][j] = 0;
                    }
                    else {
                        table[i][j] = scanner.nextInt();
                    }
                }
            }
        }
        catch (Exception e)
        {
            System.out.print(e.getMessage());
        }
    }

    public static void printTable(int[][] table){
        for (int[] ints : table) {
            for (int anInt : ints) {
                System.out.printf("%5d ", anInt);
            }
            System.out.println();
        }
        System.out.println();
    }

}
