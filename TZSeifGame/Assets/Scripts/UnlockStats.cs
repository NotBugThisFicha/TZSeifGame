
public static class UnlockStats  // Shtift position for true pos
{
    public static int shtif1;
    public static int shtif2;
    public static int shtif3;
    public static int shtif4;
    public static int shtif5;
    public static int resultTruePos;

    public static void AllUnlock()
    {
       resultTruePos = shtif1 + shtif2 + shtif3 + shtif4 + shtif5;
    }
    public static void Reset()
    {
        shtif1 = 0;
        shtif2 = 0;
        shtif3 = 0;
        shtif4 = 0;
        shtif5 = 0;
    }
}
