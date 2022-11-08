import java.util.ArrayList;
import java.util.Scanner;

public class Lab {

    public static final int K = 4;
    static int T = 0;
    static ArrayList<Arg> arguments = new ArrayList<>();
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        T = in.nextInt();
        for (int i = 0;i < T;i++)
        {
            int[] krit = new int[K];
            for (int j = 0; j < K; j++)
            {
                krit[j] = in.nextInt();
            }
            arguments.add(new Arg(krit));
        }
        for (int i = 0; i < K ; i++)
        {
            int argIndex = 0;
            int maxMin = arguments.get(0).getKrit()[i];
            for (Arg arg:arguments) {
                int krit = arg.getKrit()[i];
                if (i<3 && krit < maxMin)
                {
                    argIndex = arguments.indexOf(arg);
                    maxMin = krit;
                }
                else if (i>2 && krit > maxMin)
                {
                    argIndex = arguments.indexOf(arg);
                    maxMin = krit;
                }
            }
            arguments.get(argIndex).setAgree(false);
        }
    }
}
