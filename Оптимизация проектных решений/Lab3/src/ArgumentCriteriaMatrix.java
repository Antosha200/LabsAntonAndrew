import java.util.Scanner;

public class ArgumentCriteriaMatrix {
    private int[][] data;
    private int[][] rotateData;
    private double[][] normalData;
    private String[][] doubleData;
    private int argumentCount;
    private boolean[] compromises;
    private double[] lambdas = Lab.LAMBDAS;
    private boolean[] approachRestrictionArea;
    private double[] byMainCriteria;
    private int byMainCriteriaAnsIndex = -1;
    private boolean[] criteriaMaxMin = Lab.CRITERIA_MAX_MIN;

    public ArgumentCriteriaMatrix(Scanner scanner)
    {
        argumentCount = scanner.nextInt();
        compromises = new boolean[argumentCount];
        data = new int[argumentCount][Lab.CRITERIA_COUNT];
        rotateData = new int[argumentCount][Lab.CRITERIA_COUNT];
        normalData = new double[argumentCount][Lab.CRITERIA_COUNT];
        doubleData = new String[argumentCount][argumentCount];
        approachRestrictionArea = new boolean[argumentCount];
        byMainCriteria = new double[argumentCount];
        for (int i = 0; i < argumentCount; i++)
        {
            for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
            {
                data[i][j] = scanner.nextInt();
            }
            compromises[i] = false;
            approachRestrictionArea[i] = false;
        }
        getMainValues();
        arrPareto();
        rotateUP();
        normalization();
        byMainCriteria();
        doubleMethod();
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

    private void byMainCriteria()
    {
        double mainCriteria = lambdas[0];
        int mainCriteriaIndex = 0;
        for (int i = 1; i < Lab.CRITERIA_COUNT; i++) {
            if (mainCriteria<lambdas[i])
            {
                mainCriteria = lambdas[i];
                mainCriteriaIndex = i;
            }
        }
        double ans = 0;
        for (int i = 0; i < argumentCount; i++)
        {
            if (compromises[i])
            {
                approachRestrictionArea[i] = true;
                ans = normalData[i][mainCriteriaIndex];
                for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
                {
                    if (j != mainCriteriaIndex)
                    {
                        if (!((normalData[i][j] >= Lab.RESTRICTION_AREA_MIN) && (normalData[i][j] <= Lab.RESTRICTION_AREA_MAX)))
                        {
                            approachRestrictionArea[i] = false;
                            break;
                        }
                    }
                }
            }
            if (approachRestrictionArea[i])
            {
                byMainCriteria[i] = ans;
                if (byMainCriteriaAnsIndex == -1)
                {
                    byMainCriteriaAnsIndex = i;
                }
                else if (byMainCriteria[byMainCriteriaAnsIndex] < ans)
                {
                    byMainCriteriaAnsIndex = i;
                }
            }
        }
    }

    private void doubleMethod() {
        for (int line1 = 0; line1 < argumentCount; line1++) {
            for (int line2 = 0; line2 < argumentCount; line2++) {
                if (line1 == line2)
                {
                    doubleData[line1][line2] = "NaN";
                    continue;
                }
                double leftV = 0;
                double rightV = 0;
                for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
                {
                    if ((criteriaMaxMin[j] && (data[line1][j] > data[line2][j])) || (!criteriaMaxMin[j] && (data[line1][j] < data[line2][j])))
                    {
                        leftV++;
                    }
                    else if (data[line1][j] == data[line2][j])
                    {
                        leftV += 0.5d;
                        rightV += 0.5d;
                    }
                    else
                    {
                        rightV++;
                    }
                }
                doubleData[line1][line2] = Double.toString(leftV) + "/" + Double.toString(rightV);
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
            System.out.print("  |");
            if (compromises[i])
            {
                System.out.printf("%3s"," K");
            }
            else
            {
                System.out.printf("%3s"," C");
            }
            System.out.print("  |");
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
            System.out.print("  |");
            for (int j = 0; j < Lab.CRITERIA_COUNT; j++)
            {
                if (compromises[i])
                {
                    System.out.printf("%6.2f", normalData[i][j]);
                }
                else
                {
                    System.out.print("      ");
                }
            }
            System.out.print("  |");
            if (approachRestrictionArea[i]) {
                System.out.printf("%6.2f", byMainCriteria[i]);
            } else {
                System.out.print("      ");
            }
            System.out.print("  |");
            for (int j = 0; j < argumentCount; j++)
            {
                System.out.printf("%9s",doubleData[i][j]);
            }
            System.out.println();
        }
    }
}
