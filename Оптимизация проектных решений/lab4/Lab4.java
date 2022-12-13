import java.util.Arrays;

public class Lab4 {
    public static void main(String[] args) {

        int[][] matrix = new int[][]{
                {7, -4, 2},
                {5, 1, 8},
                {1, -1, 4}
        };

        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                System.out.print(matrix[i][j] + "   ");
            }
            System.out.println();
        }

        System.out.println("----------");
        if (Solver.findTheSaddlePoint(matrix) == false) {
            System.out.println("Saddle point not found");
            System.out.println("----------");
            int[][] newMatrix = Solver.findDomination(matrix); //3*3, 2*3, 3*2

            int ySize = newMatrix.length;
            int xSize = newMatrix[0].length;

            int[][] transformMatrix = Solver.transformation3On3(newMatrix);
            int[][] transformMatrix1 = Solver.transformation(newMatrix);
            if (ySize == 3 && xSize == 3) {
                //3*3

                System.out.println("Transform matrix:");

                for (int i = 0; i < transformMatrix.length; i++) {
                    for (int j = 0; j < transformMatrix[0].length; j++) {
                        System.out.print(transformMatrix[i][j] + "   ");
                    }
                    System.out.println();
                }
                System.out.println("----------");

                int[] d = new int[3];
                d[0] = (transformMatrix[0][0] * transformMatrix[1][1]) - (transformMatrix[1][0] * transformMatrix[0][1]);
                d[1] = (transformMatrix[0][0] * transformMatrix[1][2]) - (transformMatrix[1][0] * transformMatrix[0][2]);
                d[2] = (transformMatrix[0][1] * transformMatrix[1][2]) - (transformMatrix[1][1] * transformMatrix[0][2]);

                int max = -100500, num1 = 0, num2 = 0;

                for (int i = 0; i < d.length; i++) {
                    if (max < d[i]) {
                        max = d[i];
                        num1 = i;
                    }
                }

                System.out.println("Transform matrix1:");

                for (int i = 0; i < transformMatrix1.length; i++) {
                    for (int j = 0; j < transformMatrix1[0].length; j++) {
                        System.out.print(transformMatrix1[i][j] + "   ");
                    }
                    System.out.println();
                }
                System.out.println("----------");

                d[0] = (transformMatrix1[0][0] * transformMatrix1[1][1]) - (transformMatrix1[1][0] * transformMatrix1[0][1]);
                d[1] = (transformMatrix1[0][0] * transformMatrix1[2][1]) - (transformMatrix1[2][0] * transformMatrix1[0][1]);
                d[2] = (transformMatrix1[1][0] * transformMatrix1[2][1]) - (transformMatrix1[2][0] * transformMatrix1[1][1]);

                for (int i = 0; i < d.length; i++) {
                    if (max < d[i]) {
                        max = d[i];
                        num2 = i;
                    }
                }

                int[][] finalMatrix = new int[2][3];

                int k=0, f=0;

                for (int i = 0; i < matrix.length; i++) {
                    if (i == num1) {
                        continue;
                    }
                    finalMatrix[k]=matrix[i];
                    k++;
                }


                int[][] finalFinalMatrix = new int[2][2];

                for (int i = 0; i < finalMatrix[0].length; i++) {
                    if (i == num2) {
                        continue;
                    }
                    finalFinalMatrix[0][f]=finalMatrix[0][i];
                    finalFinalMatrix[1][f]=finalMatrix[1][i];
                    f++;
                }

                System.out.println("Final matrix");

                for (int i = 0; i < finalFinalMatrix.length; i++) {
                    for (int j = 0; j < finalFinalMatrix[0].length; j++) {
                        System.out.print(finalFinalMatrix[i][j] + "   ");
                    }
                    System.out.println();
                }
                System.out.println("----------");

                Solver.frequencyDetection(finalFinalMatrix);

            }


            if (ySize == 2 && xSize == 3) {
            }

            //2*3

            if (ySize == 3 && xSize == 2) {
                //3*2

            }

        }

    }
}
