    public interface IRsa
    {
        void RsaCriptor(int q, int p);
        string Crypt(string m, string e, string n);

        string DeCrypt(string m, string d, string n);
    }