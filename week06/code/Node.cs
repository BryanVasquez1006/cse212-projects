public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        //Handling duplicates
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            //Where in the Insert logic would duplicates naturally sneak in?
            // What condition should stop insertion?

            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        if (value == Data)
        {
            return true;
        } else if (value < Data && Left is not null)
        {
            
            return Left.Contains(value);
        } else if (value > Data && Right is not null)
        {
            return Right.Contains(value);
        }
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        
        int leftHeight = (Left != null) ? Left.GetHeight() : 0;
        int rightHeight = (Right != null) ? Right.GetHeight() : 0;

        var height = Math.Max(leftHeight, rightHeight);
        
        return 1 + height;// Replace this line with the correct return statement(s)
    }
}