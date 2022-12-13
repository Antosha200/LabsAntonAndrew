import java.util.Arrays;

import static java.lang.Math.abs;

public class

Solver {
    public static boolean findTheSaddlePoint(int[][] matrix) {

        int[] row1 = new int[3];
        int[] row2 = new int[3];
        int[] row3 = new int[3];

        int[] column1 = new int[3];
        int[] column2 = new int[3];
        int[] column3 = new int[3];

        row1[0] = matrix[0][0];
        row1[1] = matrix[0][1];
        row1[2] = matrix[0][2];

        row2[0] = matrix[1][0];
        row2[1] = matrix[1][1];
        row2[2] = matrix[1][2];

        row3[0] = matrix[2][0];
        row3[1] = matrix[2][1];
        row3[2] = matrix[2][2];

        int minRow1 = Arrays.stream(row1)
                .min()
                .getAsInt();

        int minRow2 = Arrays.stream(row2)
                .min()
                .getAsInt();

        int minRow3 = Arrays.stream(row3)
                .min()
                .getAsInt();

        int[] minInRows = new int[]{minRow1, minRow2, minRow3};

        int maxInMinRows = Arrays.stream(minInRows)
                .max()
                .getAsInt();

        System.out.println("Max in Min from rows = " + maxInMinRows);

        column1[0] = matrix[0][0];
        column1[1] = matrix[1][0];
        column1[2] = matrix[2][0];

        column2[0] = matrix[0][1];
        column2[1] = matrix[1][1];
        column2[2] = matrix[2][1];

        column3[0] = matrix[0][2];
        column3[1] = matrix[1][2];
        column3[2] = matrix[2][2];

        int maxCol1 = Arrays.stream(column1)
                .max()
                .getAsInt();

        int maxCol2 = Arrays.stream(column2)
                .max()
                .getAsInt();

        int maxCol3 = Arrays.stream(column3)
                .max()
                .getAsInt();

        int[] maxInColumns = new int[]{maxCol1, maxCol2, maxCol3};

        int minInMaxColumns = Arrays.stream(maxInColumns).min().getAsInt();

        System.out.println("Min in Max from columns = " + minInMaxColumns);

        if (minInMaxColumns == maxInMinRows) {
            System.out.println("----------");
            System.out.println("Saddle point found = " + maxInMinRows);
            System.out.println("The price of the game is equal = " + abs(maxInMinRows));
            return true;
        } else return false;

    }

    public static int[][] findDomination(int[][] matrix) {

        int[] row1 = new int[3];
        int[] row2 = new int[3];
        int[] row3 = new int[3];

        int[] column1 = new int[3];
        int[] column2 = new int[3];
        int[] column3 = new int[3];

        row1[0] = matrix[0][0];
        row1[1] = matrix[0][1];
        row1[2] = matrix[0][2];

        row2[0] = matrix[1][0];
        row2[1] = matrix[1][1];
        row2[2] = matrix[1][2];

        row3[0] = matrix[2][0];
        row3[1] = matrix[2][1];
        row3[2] = matrix[2][2];

        column1[0] = matrix[0][0];
        column1[1] = matrix[1][0];
        column1[2] = matrix[2][0];

        column2[0] = matrix[0][1];
        column2[1] = matrix[1][1];
        column2[2] = matrix[2][1];

        column3[0] = matrix[0][2];
        column3[1] = matrix[1][2];
        column3[2] = matrix[2][2];

        if (column1[0] < column2[0] && column1[1] < column2[1] && column1[2] < column2[2] && column1[0] < column3[0] && column1[1] < column3[1] && column1[2] < column3[2]) {
            System.out.println("Deleting column 1");
            int[][] newMatrix = new int[][]{{column2[0], column3[0]}, {column2[1], column3[1]}, {column2[2], column3[2]}};

            for (int[] ints : newMatrix) {
                for (int j = 0; j < newMatrix[0].length; j++) {
                    System.out.print(ints[j] + " ");
                }
                System.out.println();
            }
            return newMatrix;
        }

        if (column3[0] < column2[0] && column3[1] < column2[1] && column3[2] < column2[2] && column3[0] < column1[0] && column3[1] < column1[1] && column3[2] < column1[2]) {
            System.out.println("Deleting column 3");
            int[][] newMatrix = new int[][]{{column1[0], column3[0]}, {column1[1], column3[1]}, {column1[2], column3[2]}};

            for (int[] ints : newMatrix) {
                for (int j = 0; j < newMatrix[0].length; j++) {
                    System.out.print(ints[j] + " ");
                }
                System.out.println();
            }

            return newMatrix;
        }

        if (column2[0] < column3[0] && column2[1] < column3[1] && column2[2] < column3[2] && column2[0] < column1[0] && column2[1] < column1[1] && column2[2] < column1[2]) {
            System.out.println("Deleting column 2");
            int[][] newMatrix = new int[][]{{column1[0], column3[0]}, {column1[1], column3[1]}, {column1[2], column3[2]}};

            for (int[] ints : newMatrix) {
                for (int j = 0; j < newMatrix[0].length; j++) {
                    System.out.print(ints[j] + " ");
                }
                System.out.println();
            }

            return newMatrix;
        }

        //





        if (row1[0] > row2[0] && row1[1] > row2[1] && row1[2] > row2[2] && row1[0] > row3[0] && row1[1] > row3[1] && row1[2] > row3[2]) {
            System.out.println("Deleting row 1");
            int[][] newMatrix = new int[][]{{row2[0], row2[1], row2[2]}, {row3[0], row3[1], row3[2]}};

            for (int[] ints : newMatrix) {
                for (int j = 0; j < newMatrix[0].length; j++) {
                    System.out.print(ints[j] + " ");
                }
                System.out.println();
            }

            return newMatrix;
        }

        if (row3[0] > row2[0] && row3[1] > row2[1] && row3[2] > row2[2] && row3[0] > row1[0] && row3[1] > row1[1] && row3[2] > row1[2]) {
            System.out.println("Deleting row 3");
            int[][] newMatrix = new int[][]{{row1[0], row1[1], row1[2]}, {row2[0], row2[1], row2[2]}};

            for (int[] ints : newMatrix) {
                for (int j = 0; j < newMatrix[0].length; j++) {
                    System.out.print(ints[j] + " ");
                }
                System.out.println();
            }

            return newMatrix;
        }

        if (row2[0] > row3[0] && row2[1] > row3[1] && row2[2] > row3[2] && row2[0] > row1[0] && row2[1] > row1[1] && row2[2] > row1[2]) {
            System.out.println("Deleting row 2");
            int[][] newMatrix = new int[][]{{row1[0], row1[1], row1[2]}, {row3[0], row3[1], row3[2]}};

            for (int[] ints : newMatrix) {
                for (int j = 0; j < newMatrix[0].length; j++) {
                    System.out.print(ints[j] + " ");
                }
                System.out.println();
            }

            return newMatrix;
        }

        return matrix;
    }

    public static int[][] transformation3On3(int[][] matrix){

        int[] row1 = new int[3];
        int[] row2 = new int[3];
        int[] row3 = new int[3];

        int [] newRow1 = new int[3];
        int [] newRow2 = new int[3];

        int [][] newMatrix = new int[2][3];

        row1[0] = matrix[0][0];
        row1[1] = matrix[0][1];
        row1[2] = matrix[0][2];

        row2[0] = matrix[1][0];
        row2[1] = matrix[1][1];
        row2[2] = matrix[1][2];

        row3[0] = matrix[2][0];
        row3[1] = matrix[2][1];
        row3[2] = matrix[2][2];

        newRow1[0] = row1[0] - row2[0];
        newRow1[1] = row1[1] - row2[1];
        newRow1[2] = row1[2] - row2[2];

        newRow2[0] = row2[0] - row3[0];
        newRow2[1] = row2[1] - row3[1];
        newRow2[2] = row2[2] - row3[2];

        newMatrix[0][0] = newRow1[0];
        newMatrix[0][1] = newRow1[1];
        newMatrix[0][2] = newRow1[2];

        newMatrix[1][0] = newRow2[0];
        newMatrix[1][1] = newRow2[1];
        newMatrix[1][2] = newRow2[2];

        return newMatrix;

    }

    public static int[][] transformation(int[][] matrix){

        int[] row1 = new int[3];
        int[] row2 = new int[3];
        int[] row3 = new int[3];

        int [] newRow1 = new int[2];
        int [] newRow2 = new int[2];
        int [] newRow3 = new int[2];

        int [][] newMatrix = new int[3][2];

        row1[0] = matrix[0][0];
        row1[1] = matrix[0][1];
        row1[2] = matrix[0][2];

        row2[0] = matrix[1][0];
        row2[1] = matrix[1][1];
        row2[2] = matrix[1][2];

        row3[0] = matrix[2][0];
        row3[1] = matrix[2][1];
        row3[2] = matrix[2][2];


        newRow1[0] = row1[0] - row1[1];
        newRow1[1] = row1[1] - row1[2];

        newRow2[0] = row2[0] - row2[1];
        newRow2[1] = row2[1] - row2[2];

        newRow3[0] = row3[0] - row3[1];
        newRow3[1] = row3[1] - row3[2];

        newMatrix[0][0] = newRow1[0];
        newMatrix[0][1] = newRow1[1];

        newMatrix[1][0] = newRow2[0];
        newMatrix[1][1] = newRow2[1];

        newMatrix[2][0] = newRow3[0];
        newMatrix[2][1] = newRow3[1];

        return newMatrix;
    }

    public static void frequencyDetection(int [][] matrix){
        int h1=matrix[0][0]-matrix[0][1];
        int h2=matrix[1][0]-matrix[1][1];
        int v1=matrix[0][0]-matrix[1][0];
        int v2=matrix[0][1]-matrix[1][1];

        double rez = (double) (abs(h1) * abs(matrix[1][0]) + abs(h2) * abs(matrix[0][0]))/(double)(abs(h1)+abs(h2));
        System.out.printf("Game Price = %s",rez);
    }

    public static void determineTheLargestDeterminant(int [][] matrix){

    }


}
