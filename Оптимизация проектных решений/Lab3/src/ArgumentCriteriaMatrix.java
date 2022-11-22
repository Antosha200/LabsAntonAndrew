import java.util.Scanner;

public class ArgumentCriteriaMatrix {
    private int[][] data;
    private int[][] rotateData;
    private int argumentCunt;
    private boolean[] compromises;
    private boolean[] criteriaMaxMin = Lab.CRITERIA_MAX_MIN;

    public ArgumentCriteriaMatrix(Scanner scanner)
    {
        argumentCunt = scanner.nextInt();
        compromises = new boolean[argumentCunt];
        data = new int[argumentCunt][Lab.CRITERIA_COUNT];
        rotateData = new int[argumentCunt][Lab.CRITERIA_COUNT];
        for (int i = 0; i < argumentCunt; i++)
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
    }

    private void getMainValues()
    {
        for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
        {
            int value = data[0][j];
            int argWithValue = 0;
            for (int i = 1; i < argumentCunt; i++)
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
        for (int i = 0; i < argumentCunt; i++)
        {
            if (!compromises[i])
            {
                for (int j = 0; j < argumentCunt; j++)
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
            for (int i = 0; i < argumentCunt; i++)
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
    public void printMatrix()
    {
        for (int i = 0; i < argumentCunt; i++)
        {
            for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
            {
                System.out.printf("%5d",data[i][j]);
            }
            if (compromises[i])
            {
                System.out.printf("%5s","K");
            }
            else
            {
                System.out.printf("%5s","C");
            }
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
            System.out.println();
        }
    }
}
