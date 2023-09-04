using System;
interface Ix
{
    char F0();
    void F1(ref char w);
}
interface Iy
{
    void F0(char w);
    void F1(ref char w);
}
class Class1 : Ix, Iy
{
    private char field;
    public void setfield(char w)
    {
        field = w;
    }
    public Class1(char field)
    {
        this.field = field;
    }
    // Неявная реализация методов интерфейсов
    public char F0()
    {
        if (char.IsLetter(field))
        {
            field = char.ToLower(field);   
        }
        Console.WriteLine("CLASS 1 F0 Ix НЕЯВНАЯ: " + field);
        return field;
    }
    void Ix.F1(ref char w)
    {
        if (char.IsLetter(field))
        {
            field = '5';
        }
        Console.WriteLine("CLASS 1 F1 Ix ЯВНАЯ:   " + field);

    }
    /////////////////////////////////////////////////////////////
    public void F0(char w)
    {
        if (char.IsLetter(w))
        {
            field = char.ToLower(w);
        }
        Console.WriteLine("CLASS 1 F0 Iy НЕЯВНАЯ: " + field);
    }
    void Iy.F1(ref char w)
    {
        if (char.IsLetter(field))
        {
            field = '5';
        }
        Console.WriteLine("CLASS 1 F1 Iy ЯВНАЯ:   " + field);

    }
    //////////////////////////////////////////////////////////////
}
class Class2 : Ix, Iy
{
    private char field;
    public void setfield(char w)
    {
        field = w;
    }
    public Class2(char field)
    {
        this.field = field;
    }
    //////////////////////////////////////////////////////////////
    public char F0()
    {
        if (char.IsLetter(field))
        {
            field = '*';
        }
        Console.WriteLine("CLASS 2 F0 Ix НЕЯВНАЯ: " + field);
        return field;
    }
    void Ix.F1(ref char w)
    {
        field = '-';
        Console.WriteLine("CLASS 2 F1 Ix ЯВНАЯ:   " + field);
    }
    //////////////////////////////////////////////////////////////
    public void F0(char w)
    {
        if (char.IsLetter(w))
        {
        field = '*';
        }
        Console.WriteLine("CLASS 2 F0 Iy НЕЯВНАЯ: " + field);
    }
    void Iy.F1(ref char w)
    {
        field = '-';
        Console.WriteLine("CLASS 2 F1 Iy ЯВНАЯ:   " + field);
    }
}

class Program
{
    static void Main(string[] args)
    {
        char w;
        Console.WriteLine("Введите символ");
        w = Console.ReadKey().KeyChar;
        Console.WriteLine();
        Class1 class1 = new Class1(w);
        Class2 class2 = new Class2(w);
        class1.F0();
        class1.setfield(w);

        ((Ix)class1).F1(ref w);
        class1.setfield(w);

        class1.F0(w);
        class1.setfield(w);

        ((Iy)class1).F1(ref w);
        class2.setfield(w);

        class2.F0();
        class2.setfield(w);

        ((Ix)class2).F1(ref w);
        class2.setfield(w);

        class2.F0(w);
        class2.setfield(w);

        ((Iy)class2).F1(ref w);
        class2.setfield(w);

        Ix ix1 = class1;
        Iy iy1 = class1;

        Ix ix2 = class2;
        Iy iy2 = class2;

        class1.setfield(w)  ;
        ix1.F0();
        class1.setfield(w);
        ix1.F1(ref w);
        class1.setfield(w);
        iy1.F0(w);
        class1.setfield(w);
        iy1.F1(ref w);
        Console.ReadLine();
    }
}