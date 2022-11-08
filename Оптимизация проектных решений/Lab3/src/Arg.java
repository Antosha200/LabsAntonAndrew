import java.awt.*;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;

public class Arg {
    private boolean Agree = true;
    private int[] krit;
    private int[] kritRotate = new int[Lab.K];

    Arg(int... kritArr)
    {
        krit = kritArr;
    }

    public int[] getKrit() {
        return krit;
    }

    public void setAgree(boolean agree) {
        Agree = agree;
    }
}
