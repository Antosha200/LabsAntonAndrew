import java.util.Scanner;

public class ArgumentCriteriaMatrix {
    private int[][] data;
    private int[][] rotateData;
    private double[][] normalData;
    private int argumentCount;
    private boolean[] compromises;
    private boolean[] criteriaMaxMin = Lab.CRITERIA_MAX_MIN;

    public ArgumentCriteriaMatrix(Scanner scanner)
    {
        argumentCount = scanner.nextInt();
        compromises = new boolean[argumentCount];
        data = new int[argumentCount][Lab.CRITERIA_COUNT];
        rotateData = new int[argumentCount][Lab.CRITERIA_COUNT];
        normalData = new double[argumentCount][Lab.CRITERIA_COUNT];
        for (int i = 0; i < argumentCount; i++)
        {
            for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
            {
                data[i][j] = scanner.nextInt();
            }
            compromises[i] = false;
        }
        getMainValues();
        arrPareto();
        rotateUP();
        normalization();
    }

    private void getMainValues()
    {
        for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
        {
            int value = data[0][j];
            int argWithValue = 0;
            for (int i = 1; i < argumentCount; i++)
            {
                if ((criteriaMaxMin[j] && value < data[i][j])||(!criteriaMaxMin[j] && value > data[i][j]))
                {
                    value = data[i][j];
                    argWithValue = i;
                }
            }
            compromises[argWithValue] = true;
        }
    }

    private void arrPareto()
    {
        for (int i = 0; i < argumentCount; i++)
        {
            if (!compromises[i])
            {
                for (int j = 0; j < argumentCount; j++)
                {
                    if (i != j)
                    {
                        compromises[i] = checkVectors(i, j);
                        if (!compromises[i])
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    private boolean checkVectors(int x, int y)
    {
        for (int i = 0; i < Lab.CRITERIA_COUNT; i++)
        {
            if (((criteriaMaxMin[i] && data[x][i] >= data[y][i]) || (!criteriaMaxMin[i] && data[x][i] <= data[y][i])))
            {
                return true;
            }
        }
        return false;
    }

    private void rotateUP()
    {
        for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
        {
            for (int i = 0; i < argumentCount; i++)
            {
                if (!criteriaMaxMin[j])
                {
                    rotateData[i][j] = -data[i][j];
                }
                else
                {
                    rotateData[i][j] = data[i][j];
                }
            }
        }
    }

    private void normalization()
    {
        for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
        {
            int max = rotateData[0][j];
            int min = rotateData[0][j];
            for (int i = 1; i < argumentCount; i++)
            {
                if (compromises[i])
                {
                    if (max < rotateData[i][j])
                    {
                        max = rotateData[i][j];
                    }
                    if (min > rotateData[i][j])
                    {
                        min = rotateData[i][j];
                    }
                }
            }
            for (int i = 0; i < argumentCount; i++)
            {
                if (compromises[i])
                {
                    normalData[i][j] = (rotateData[i][j] - min) / (double)(max - min);
                }
            }
        }
    }

    public void printMatrix()
    {
        for (int i = 0; i < argumentCount; i++)
        {
            for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
            {
                System.out.printf("%5d",data[i][j]);
            }
            System.out.print(" |");
            if (compromises[i])
            {
                System.out.printf("%2s","K");
            }
            else
            {
                System.out.printf("%2s","C");
            }
            System.out.print(" |");
            for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
            {
                if (compromises[i])
                {
                    System.out.printf("%5d", rotateData[i][j]);
                }
                else
                {
                    System.out.print("     ");
                }
            }
            System.out.print(" |");
            for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
            {
                if (compromises[i])
                {
                    System.out.printf("%6.2f", normalData[i][j]);
                }
                else
                {
                    System.out.print("     ");
                }
            }
            System.out.println();
        }
    }
}
