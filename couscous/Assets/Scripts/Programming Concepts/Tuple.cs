
public class Tuple<T,U>{
    T one;
    U two;
    
    public Tuple(T x,U y) {
        one = x;
        two = y;
    }

    public Tuple()
    {
        one = default(T);
        two = default(U);
    }

    public T getOne() {
        return one;
    }

    public U getTwo() {
        return two;
    }

    public void setOne(T element)
    {
        one = element;
    }

    public void setTwo(U element)
    {
        two = element;
    }

}
